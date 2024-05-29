using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;
using Skola.Service.Models;

namespace NBP_project_Store
{
    [ApiController]
    [Route("api/[controller]")]

    public class KupacController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public KupacController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Kupac")]
        public IActionResult ReadKupac()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Kupac.Query().ToList());
        }

        [HttpGet("Pronaði_Kupca")]
        public IActionResult ReadKupac([FromQuery] string id_kupac, [FromQuery] string ime, [FromQuery] string prezime)
        {
            var results = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                                  .Where(i => i.Id_Kupac.Contains(id_kupac) || i.Ime.Contains(ime) || i.Prezime.Contains(prezime))
                                  .ToList();
            if (results == null || !results.Any())
            {
                return NotFound("Kupac nije u bazi");
            }

            return Ok(results);
        }

        [HttpPost("Kupac")]
        public IActionResult WriteKupac([FromQuery] string id_kupac, [FromQuery] string ime, [FromQuery] string prezime)
        {
            _executionContext.Repository.NBP_project_Store.Kupac.Insert(new NBP_project_Store.Kupac
            {
                Id_Kupac = id_kupac,
                Ime = ime,
                Prezime =prezime                
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Kupac")]
        public IActionResult DeleteKupac([FromQuery] string id_kupac, [FromQuery] string prezime, [FromQuery] string ime)
        {
            NBP_project_Store_Kupac result = null;

            result = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                                                    .Where(i => i.Id_Kupac == id_kupac || (i.Ime == ime && i.Prezime == prezime))
                                                    .FirstOrDefault();
            if (result == null)
            {
                return NotFound("Kupac ne postoji u bazi.");
            }
            else
                _executionContext.Repository.NBP_project_Store.Kupac.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
}
