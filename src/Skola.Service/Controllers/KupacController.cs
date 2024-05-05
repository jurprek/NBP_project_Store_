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

        [HttpGet("Kupac/Predmet")]
        public IActionResult ReadKupac([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            NBP_project_Store_Kupac result = null;

            // Pronaði kupca s odreðenim ID-om ili imenom i prezimenom
            result = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                          .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                          .FirstOrDefault();

            if (result != null)
            {
                // Stvori praznu listu za spremanje predmeta
                List<IspisModel> predmeti = new List<IspisModel>();

                // Ako je kupac pronaðen
                using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                {
                    // Zatvori trenutnu vezu s bazom podataka
                    _executionContext.EntityFrameworkContext.Database.Connection.Close();

                    // Konfiguriraj SQL upit za dohvaæanje podataka iz pogleda "Pregled" samo za odreðenog kupca
                    cmd.CommandText = "select * from NBP_project_Store.Pregled where Kupac = @kupac";
                    cmd.CommandType = CommandType.Text;

                    // Dodaj parametar za ID kupca
                    var kupacParam = cmd.CreateParameter();
                    kupacParam.ParameterName = "@kupac";
                    kupacParam.Value = id;
                    cmd.Parameters.Add(kupacParam);

                    _executionContext.EntityFrameworkContext.Database.Connection.Open();

                    // Izvrši SQL upit
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid Trgovac = reader.GetGuid(0);
                            Guid Poslovnica = reader.GetGuid(1);
                            Guid Predmet = reader.GetGuid(2);
                            Guid Kupac = reader.GetGuid(3);

                            // Dodaj svaki predmet u listu
                            IspisModel predmet = new IspisModel(Trgovac, Poslovnica, Predmet, Kupac);
                            predmeti.Add(predmet);
                        }
                    }
                }

                // Vrati rezultate kao odgovor
                return Ok(new { result});
            }

            // Ako kupac nije pronaðen, vrati odgovarajuæi status
            return NotFound("Kupac nije u bazi");
        }

        [HttpPost("Kupac")]
        public IActionResult WriteKupac([FromQuery] string ime, [FromQuery] string prezime, [FromQuery] Guid predmet)
        {
            _executionContext.Repository.NBP_project_Store.Kupac.Insert(new NBP_project_Store.Kupac
            {
                Ime = ime,
                Prezime =prezime,
                PredmetID = predmet
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Kupac")]
        public IActionResult DeleteKupac([FromQuery] Guid id)
        {
            NBP_project_Store_Kupac result = null;

            result = _executionContext.Repository.NBP_project_Store.Kupac.Query()
                            .Where(i => i.ID == id)
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
