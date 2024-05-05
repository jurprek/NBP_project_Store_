using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;
using NBP_project_Store;

[ApiController]
    [Route("api/[controller]")]

    public class TrgovacController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public TrgovacController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Trgovac")]
        public IActionResult ReadTrgovac()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Trgovac.Query().ToList());
        }

        [HttpGet("Trgovac/Poslovnice")]
        public IActionResult ReadTrgovac([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
        NBP_project_Store_Trgovac result = null;
            {
            List<string> poslovnice = new List<string>();

            var trgovac = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                .FirstOrDefault();

            if (trgovac != null)
            {
                using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                {
                    _executionContext.EntityFrameworkContext.Database.Connection.Close();
                    cmd.CommandText = "NBP_project_Store.Poslovnice";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var imeParam = new SqlParameter("@ime", SqlDbType.NVarChar, 50);
                    imeParam.Value = trgovac.Ime;
                    cmd.Parameters.Add(imeParam);

                    var prezimeParam = new SqlParameter("@prezime", SqlDbType.NVarChar, 50);
                    prezimeParam.Value = trgovac.Prezime;
                    cmd.Parameters.Add(prezimeParam);

                    _executionContext.EntityFrameworkContext.Database.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nazivPoslovnice = reader.GetString(0);
                            poslovnice.Add(nazivPoslovnice);
                        }
                    }
                }
                return Ok(new { trgovac, poslovnice });
            }

        }
       
        if (result == null)
            {
                return NotFound("Taj trgovac nije u bazi");
            }

            return Ok(result);
        }

        [HttpPost("Trgovac")]
        public IActionResult WriteTrgovac([FromQuery] string ime, [FromQuery] string prezime, [FromQuery] Guid poslovnica)
        {
        _executionContext.Repository.NBP_project_Store.Trgovac.Insert(new NBP_project_Store.Trgovac
        {
            Ime = ime,
            Prezime = prezime,
            PoslovnicaID = poslovnica
        }) ;

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Trgovac")]
        public IActionResult DeleteTrgovac([FromQuery] Guid id)
        {
            NBP_project_Store_Trgovac result = null;

            result = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                          .Where(i => i.ID == id)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("U bazi ne postoji  ID = " + id);
            }
            else
                _executionContext.Repository.NBP_project_Store.Trgovac.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
