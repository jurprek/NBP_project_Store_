using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;

namespace NBP_project_Store
{
    [ApiController]
    [Route("api/[controller]")]

    public class UcenikController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public UcenikController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Ucenik")]
        public IActionResult ReadUcenik()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Ucenik.Query().ToList());
        }

        [HttpGet("Ucenik/Predmet")]
        public IActionResult ReadUcenik([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            NBP_project_Store_Ucenik result = null;
            {
                
                result = _executionContext.Repository.NBP_project_Store.Ucenik.Query()
                              .Where(i => i.ID == id || (i.Ime == ime && i.Prezime ==prezime))
                              .FirstOrDefault();

                Dictionary<string, int> predmeti = new Dictionary<string, int>();
                var ucenik = _executionContext.Repository.NBP_project_Store.Ucenik.Query()
                    .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                    .FirstOrDefault();

                if (ucenik != null)
                {
                    using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                    {
                        _executionContext.EntityFrameworkContext.Database.Connection.Close();

                        cmd.CommandText = "NBP_project_Store.Predmeti";
                        cmd.CommandType = CommandType.StoredProcedure;

                        var imeParam = new SqlParameter("@ime", SqlDbType.NVarChar, 50);
                        imeParam.Value = ucenik.Ime;
                        cmd.Parameters.Add(imeParam);

                        var prezimeParam = new SqlParameter("@prezime", SqlDbType.NVarChar, 50);
                        prezimeParam.Value = ucenik.Prezime;
                        cmd.Parameters.Add(prezimeParam);

                        _executionContext.EntityFrameworkContext.Database.Connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nazivPredmeta = reader.GetString(0);
                                int ocjena = reader.GetInt32(1);
                                predmeti.Add(nazivPredmeta, ocjena);
                            }
                            
                        }
                    }
                    return Ok(new { result, predmeti });
                }

            }
            
            if (result == null)
            {
                return NotFound("Ucenik nije u bazi");
            }

            return Ok(result);
        }

        [HttpPost("Ucenik")]
        public IActionResult WriteUcenik([FromQuery] string ime, [FromQuery] string prezime)
        {
            _executionContext.Repository.NBP_project_Store.Ucenik.Insert(new NBP_project_Store.Ucenik
            {
                Ime = ime,
                Prezime =prezime,
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Ucenik")]
        public IActionResult DeleteUcenik([FromQuery] Guid id)
        {
            NBP_project_Store_Ucenik result = null;

            result = _executionContext.Repository.NBP_project_Store.Ucenik.Query()
                            .Where(i => i.ID == id)
                            .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Ucenik ne postoji u bazi.");
            }
            else
                _executionContext.Repository.NBP_project_Store.Ucenik.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
}
