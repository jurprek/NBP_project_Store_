using Microsoft.AspNetCore.Mvc;
using Skola.Service.Models;
using NBP_project_Store.Service;
using System.Collections.Generic;
using NBP_project_Store;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using Microsoft.AspNetCore.HttpOverrides;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace Skola.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly MongoDBContext _mongoDBContext;
        private readonly IPredmetManager _predmetManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public LaptopController(MongoDBContext mongoDBContext, IPredmetManager predmetManager,
            IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _mongoDBContext = mongoDBContext;
            _predmetManager = predmetManager;

            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet]
        public ActionResult<List<Laptop>> GetLaptops()
        {
            var laptops = _mongoDBContext.GetLaptops();
            return Ok(laptops);
        }

        [HttpGet("Pronaði_Laptop")]
        public ActionResult<Laptop> GetLaptop(string id_laptop)
        {
            var laptop = _mongoDBContext.GetLaptopById(id_laptop);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
        }

        [HttpGet("Detaljna_Pretraga")]
        public ActionResult<List<Laptop>> GetLaptop_keyword(string keyword)
        {
            keyword = keyword.ToLower();

            var laptops = _mongoDBContext.GetLaptops()
                .Where(l => (l.Id_Laptop != null && l.Id_Laptop.ToLower().Contains(keyword)) ||
                            (l.Model != null && l.Model.ToLower().Contains(keyword)) ||
                            (l.Processor != null && (
                                (l.Processor.Type != null && l.Processor.Type.ToLower().Contains(keyword)) ||
                                l.Processor.Cores.ToString().Contains(keyword) ||
                                l.Processor.MaxSpeedGHz.ToString().Contains(keyword)
                            )) ||
                            (l.Ram != null && (
                                l.Ram.SizeGB.ToString().Contains(keyword) ||
                                (l.Ram.Type != null && l.Ram.Type.ToLower().Contains(keyword))
                            )) ||
                            (l.Screen != null && (
                                l.Screen.SizeInches.ToString().Contains(keyword) ||
                                (l.Screen.Resolution != null && l.Screen.Resolution.ToLower().Contains(keyword)) ||
                                (l.Screen.Type != null && l.Screen.Type.ToLower().Contains(keyword))
                            )) ||
                            (l.Storage != null && (
                                l.Storage.SizeGB.ToString().Contains(keyword) ||
                                (l.Storage.Type != null && l.Storage.Type.ToLower().Contains(keyword))
                            )) ||
                            (l.OS != null && l.OS.ToLower().Contains(keyword)) ||
                            (l.Graphics != null && l.Graphics.Type != null && l.Graphics.Type.ToLower().Contains(keyword)) ||
                            (l.Network != null && (
                                l.Network.Wifi.ToString().Contains(keyword) ||
                                l.Network.Ethernet.ToString().Contains(keyword) ||
                                l.Network.Bluetooth.ToString().Contains(keyword)
                            )) ||
                            (l.Ports != null && (
                                l.Ports.USB2_0.ToString().Contains(keyword) ||
                                l.Ports.USB3_1.ToString().Contains(keyword) ||
                                l.Ports.USBTypeC.ToString().Contains(keyword) ||
                                l.Ports.HDMI.ToString().Contains(keyword)
                            )) ||
                            l.WeightKg.ToString().Contains(keyword) ||
                            (l.Color != null && l.Color.ToLower().Contains(keyword)) ||
                            l.WarrantyMonths.ToString().Contains(keyword) ||
                            (l.AdditionalFeatures != null && l.AdditionalFeatures.Any(feature => feature.ToLower().Contains(keyword)))
                 )
                .ToList();

            if (laptops.Count == 0)
            {
                return NotFound();
            }

            return Ok(laptops);
        }


        [HttpPost("Laptop")]
        public ActionResult<Laptop> CreateLaptop(Laptop laptop)
        {
            // Prvo stvaramo Laptop u MongoDB-u
            _mongoDBContext.CreateLaptop(laptop);

            // Zatim stvaramo Predmet u SQL bazi na temelju podataka iz tog Laptopa
            _executionContext.Repository.NBP_project_Store.Predmet.Insert(new NBP_project_Store.Predmet
            {
                Id_Predmet = laptop.Id_Laptop,
                Naziv = laptop.Model
            });

            _unitOfWork.CommitAndClose();

            // Vraæamo odgovor o uspješno stvorenom Laptopu
            return CreatedAtAction(nameof(GetLaptop), new { id_laptop = laptop.Id_Laptop }, laptop);
        }

        [HttpDelete("Laptop")]
        public IActionResult DeleteLaptop(string id_laptop)
        {
            var laptop = _mongoDBContext.GetLaptopById(id_laptop);

            if (laptop == null)
            {
                return NotFound();
            }

            _mongoDBContext.DeleteLaptop(id_laptop);

            // Brišemo odgovarajuæi Predmet u SQL bazi
            var predmet = _executionContext.Repository.NBP_project_Store.Predmet.Query(p => p.Id_Predmet == id_laptop).FirstOrDefault();
            if (predmet != null)
            {
                _executionContext.Repository.NBP_project_Store.Predmet.Delete(predmet);
                _unitOfWork.CommitAndClose();
            }

            return NoContent();
        }
    }
}
