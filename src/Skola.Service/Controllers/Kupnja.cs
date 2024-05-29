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
        public IActionResult WriteKupac([FromQuery] string id_kupnja, [FromQuery] string id_kupac, [FromQuery] string id_predmet, [FromQuery] string id_trgovac)
        {
            // Provjera da li kupac postoji
            var kupacExists = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                .Any(k => k.Id_Kupac == id_kupac);

            if (!kupacExists)
            {
                return NotFound("Kupac nije pronaðen.");
            }

            // Provjera da li predmet postoji
            var predmetExists = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                .Any(p => p.Id_Predmet == id_predmet);

            if (!predmetExists)
            {
                return NotFound("Predmet nije pronaðen.");
            }

            // Provjera da li trgovac postoji
            var trgovacExists = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                .Any(p => p.Id_Trgovac == id_trgovac);

            if (!trgovacExists)
            {
                return NotFound("Trgovac nije pronaðen.");
            }

            // Umetanje nove kupnje
            _executionContext.Repository.NBP_project_Store.Kupnja.Insert(new NBP_project_Store_Kupnja
            {
                Id_Kupnja = id_kupnja,
                Id_Kupac = id_kupac,
                Id_Predmet = id_predmet,
                Id_Trgovac = id_trgovac
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Kupnja")]
        public IActionResult DeleteKupnja([FromQuery] string id_kupnja)
        {
            NBP_project_Store_Kupnja result = null;

            result = _executionContext.Repository.NBP_project_Store.Kupnja.Query()
                                                    .Where(i => i.Id_Kupnja == id_kupnja)
                                                    .FirstOrDefault();
            if (result == null)
            {
                return NotFound("Kupnja ne postoji u bazi.");
            }
            else
                _executionContext.Repository.NBP_project_Store.Kupnja.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
        [HttpGet("Pronaði_Kupnju")]
        public IActionResult SearchKupnja([FromQuery] string kupacKeyword, [FromQuery] string predmetKeyword, [FromQuery] string trgovacKeyword)
        {
            var kupnjeQuery = _executionContext.Repository.NBP_project_Store.Kupnja.Query();

            if (!string.IsNullOrEmpty(kupacKeyword))
            {
                var kupacIds = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                    .Where(c => c.Ime.Contains(kupacKeyword) || c.Prezime.Contains(kupacKeyword) || c.Id_Kupac.Contains(kupacKeyword))
                    .Select(c => c.Id_Kupac)
                    .ToList();

                kupnjeQuery = kupnjeQuery.Where(k => kupacIds.Contains(k.Id_Kupac));
            }

            if (!string.IsNullOrEmpty(predmetKeyword))
            {
                var predmetIds = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                    .Where(p => p.Naziv.Contains(predmetKeyword) || p.Id_Predmet.Contains(predmetKeyword))
                    .Select(p => p.Id_Predmet)
                    .ToList();

                kupnjeQuery = kupnjeQuery.Where(k => predmetIds.Contains(k.Id_Predmet));
            }

            if (!string.IsNullOrEmpty(trgovacKeyword))
            {
                var trgovacIds = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                    .Where(t => t.Ime.Contains(trgovacKeyword) || t.Prezime.Contains(trgovacKeyword) || t.Id_Trgovac.Contains(trgovacKeyword))
                    .Select(t => t.Id_Trgovac)
                    .ToList();

                kupnjeQuery = kupnjeQuery.Where(k => trgovacIds.Contains(k.Id_Trgovac));
            }

            var kupnje = kupnjeQuery.ToList();

            if (kupnje == null || !kupnje.Any())
            {
                return NotFound("Kupnja ne postoji u bazi.");
            }

            return Ok(kupnje);
        }
    }
}
