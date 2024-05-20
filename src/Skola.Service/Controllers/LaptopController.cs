using Microsoft.AspNetCore.Mvc;
using Skola.Service.Models;
using NBP_project_Store.Service;
using System.Collections.Generic;
using NBP_project_Store;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;

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

        [HttpGet("{id_laptop}")]
        public ActionResult<Laptop> GetLaptop(string id_laptop)
        {
            var laptop = _mongoDBContext.GetLaptopById(id_laptop);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
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
            return CreatedAtAction(nameof(GetLaptop), new { id = laptop.Id_Laptop }, laptop);//, NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLaptop(string id, Laptop updatedLaptop)
        {
            var laptop = _mongoDBContext.GetLaptopById(id);

            if (laptop == null)
            {
                return NotFound();
            }

            _mongoDBContext.UpdateLaptop(id, updatedLaptop);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLaptop(string id)
        {
            var laptop = _mongoDBContext.GetLaptopById(id);

            if (laptop == null)
            {
                return NotFound();
            }

            _mongoDBContext.DeleteLaptop(id);

            return NoContent();
        }
    }
}
