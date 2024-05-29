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

    public class InventarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public InventarController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Inventar")]
        public IActionResult ReadInventar()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Inventar.Query().ToList());
        }

        [HttpPost("Inventar")]
        public IActionResult WriteInventar([FromQuery] string id_inventar, [FromQuery] string id_poslovnica, [FromQuery] string id_predmet, [FromQuery] string cijena)
        {
            // Provjera da li poslovnica postoji
            var poslovnicaExists = _executionContext.Repository.NBP_project_Store.Poslovnica.Query()
                .Any(k => k.Id_Poslovnica == id_poslovnica);

            if (!poslovnicaExists)
            {
                return NotFound("Poslovnica nije pronaðena.");
            }

            // Provjera da li predmet postoji
            var predmetExists = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                .Any(p => p.Id_Predmet == id_predmet);

            if (!predmetExists)
            {
                return NotFound("Predmet nije pronaðen.");
            }

            // Umetanje u Inventar
            _executionContext.Repository.NBP_project_Store.Inventar.Insert(new NBP_project_Store_Inventar
            {
                Id_Inventar = id_inventar,
                Id_Predmet = id_predmet,
                Cijena_Eur = cijena,
                Id_Poslovnica = id_poslovnica
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Inventar")]
        public IActionResult DeleteInventar([FromQuery] string id_inventar)
        {
            NBP_project_Store_Inventar result = null;

            result = _executionContext.Repository.NBP_project_Store.Inventar.Query()
                                                    .Where(i => i.Id_Inventar == id_inventar)
                                                    .FirstOrDefault();
            if (result == null)
            {
                return NotFound("Ne postoji u bazi inventara.");
            }
            else
                _executionContext.Repository.NBP_project_Store.Inventar.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
        [HttpGet("Pronaði_u_Inventaru")]
        public IActionResult SearchKupnja([FromQuery] string predmetKeyword, [FromQuery] string poslovnicaKeyword)
        {
            var InventarQuery = _executionContext.Repository.NBP_project_Store.Inventar.Query();

            if (!string.IsNullOrEmpty(poslovnicaKeyword))
            {
                var poslovnicaIds = _executionContext.Repository.NBP_project_Store.Poslovnica.Query()
                    .Where(c => c.Naziv.Contains(poslovnicaKeyword) || c.Id_Poslovnica.Contains(poslovnicaKeyword))
                    .Select(c => c.Id_Poslovnica)
                    .ToList();

                InventarQuery = InventarQuery.Where(k => poslovnicaIds.Contains(k.Id_Poslovnica));
            }

            if (!string.IsNullOrEmpty(predmetKeyword))
            {
                var predmetIds = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                    .Where(p => p.Naziv.Contains(predmetKeyword) || p.Id_Predmet.Contains(predmetKeyword))
                    .Select(p => p.Id_Predmet)
                    .ToList();

                InventarQuery = InventarQuery.Where(k => predmetIds.Contains(k.Id_Predmet));
            }

            var inventar = InventarQuery.ToList();

            if (inventar == null || !inventar.Any())
            {
                return NotFound("Ne postoji u bazi inventara.");
            }

            return Ok(inventar);
        }
    }
}
