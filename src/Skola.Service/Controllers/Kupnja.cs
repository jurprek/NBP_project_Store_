using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;
using Skola.Service.Models;

namespace NBP_project_Store
{
    [Route("api/[controller]")]

    public class KupnjaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public KupnjaController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Kupnja")]
        public IActionResult ReadKupnja()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Kupnja.Query().ToList());
        }

        [HttpPost("Kupnja")]
        public IActionResult WriteKupac([FromQuery] string id_kupnja, [FromQuery] Guid id_kupac, [FromQuery] Guid id_predmet)
        {
            // Provjera da li kupac postoji
            var kupacExists = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                .Any(k => k.ID == id_kupac);

            if (!kupacExists)
            {
                return NotFound("Kupac nije pronaðen.");
            }

            // Provjera da li predmet postoji
            var predmetExists = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                .Any(p => p.ID == id_predmet);

            if (!predmetExists)
            {
                return NotFound("Predmet nije pronaðen.");
            }

            // Umetanje nove kupnje
            _executionContext.Repository.NBP_project_Store.Kupnja.Insert(new NBP_project_Store_Kupnja
            {
                Id_Kupnja = id_kupnja,
                KupacID = id_kupac,
                PredmetID = id_predmet
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Kupnja")]
        public IActionResult DeleteKupac([FromQuery] Guid kupnja)
        {
            NBP_project_Store_Kupac result = null;

            result = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                                                    .Where(i => i.ID == kupnja)
                                                    .FirstOrDefault();
            if (result == null)
            {
                return NotFound("Kupnja ne postoji u bazi.");
            }
            else
                _executionContext.Repository.NBP_project_Store.Kupac.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
}
