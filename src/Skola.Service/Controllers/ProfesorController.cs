using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;


[ApiController]
    [Route("api/[controller]")]

    public class ProfesorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public ProfesorController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Profesor")]
        public IActionResult ReadProfesor()
        {
            return Ok(_executionContext.Repository.Skola.Profesor.Query().ToList());
        }

        [HttpGet("Profesor/Predmeti")]
        public IActionResult ReadProfesor([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            Skola_Profesor result = null;
            {
            List<string> predmeti = new List<string>();

            var profesor = _executionContext.Repository.Skola.Profesor.Query()
                .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                .FirstOrDefault();

            if (profesor != null)
            {
                using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                {
                    _executionContext.EntityFrameworkContext.Database.Connection.Close();
                    cmd.CommandText = "Skola.Predmeti";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var imeParam = new SqlParameter("@ime", SqlDbType.NVarChar, 50);
                    imeParam.Value = profesor.Ime;
                    cmd.Parameters.Add(imeParam);

                    var prezimeParam = new SqlParameter("@prezime", SqlDbType.NVarChar, 50);
                    prezimeParam.Value = profesor.Prezime;
                    cmd.Parameters.Add(prezimeParam);

                    _executionContext.EntityFrameworkContext.Database.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nazivPredmeta = reader.GetString(0);
                            predmeti.Add(nazivPredmeta);
                        }
                    }
                }
                return Ok(new { profesor, predmeti });
            }

        }
       
        if (result == null)
            {
                return NotFound("Taj profesor nije u bazi");
            }

            return Ok(result);
        }

        [HttpPost("Profesor")]
        public IActionResult WriteProfesor([FromQuery] string ime, [FromQuery] string prezime)
        {
            _executionContext.Repository.Skola.Profesor.Insert(new Skola.Profesor
            {
                Ime =ime,
                Prezime = prezime,
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Profesor")]
        public IActionResult DeleteProfesor([FromQuery] Guid id)
        {
            Skola_Profesor result = null;

            result = _executionContext.Repository.Skola.Profesor.Query()
                          .Where(i => i.ID == id)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("U bazi ne postoji  ID = " + id);
            }
            else
                _executionContext.Repository.Skola.Profesor.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
