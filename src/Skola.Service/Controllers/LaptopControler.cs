using Microsoft.AspNetCore.Mvc;
using Skola.Service.Models;
using NBP_project_Store;
using System.Collections.Generic;
using NBP_project_Store.Service;

namespace Skola.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly MongoDBContext _laptopService;
        private readonly IPredmetManager _predmetManager;

        public LaptopController(MongoDBContext laptopService, IPredmetManager predmetManager)
        {
            _laptopService = laptopService;
            _predmetManager = predmetManager;
        }

        // GET: api/Laptop
        [HttpGet]
        public ActionResult<List<Laptop>> GetLaptop()
        {
            var laptops = _laptopService.GetLaptops();
            return Ok(laptops);
        }

        // GET: api/Laptop
        [HttpGet("Laptop/id")]
        public ActionResult<Laptop> GetLaptop(string id_laptop)
        {
            var laptop = _laptopService.GetLaptopById(id_laptop);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
        }



        [HttpPost]
        public ActionResult<Laptop> CreateLaptop(Laptop laptop)
        {
            // Prvo stvaramo Laptop u MongoDB-u.
            _laptopService.CreateLaptop(laptop);

            // Zatim stvaramo Predmet u SQL bazi na temelju podataka iz tog Laptopa.
            _predmetManager.KreirajPredmetIzLaptopa(laptop.Model);

            // Vraæamo odgovor o uspješno stvorenom Laptopu.
            return CreatedAtRoute("GetLaptop", new { id = laptop.Model }, laptop);
        }


        // PUT: api/Laptops/5
        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateLaptop(string id, Laptop laptopIn)
        {
            var laptop = _laptopService.GetLaptopById(id);

            if (laptop == null)
            {
                return NotFound();
            }

            _laptopService.UpdateLaptop(id, laptopIn);

            return NoContent();
        }

        // DELETE: api/Laptops/5
        [HttpDelete("Laptop")]
        public IActionResult DeleteLaptop(string id_laptop)
        {
            var laptop = _laptopService.GetLaptopById(id_laptop);

            if (laptop == null)
            {
                return NotFound();
            }

            _laptopService.DeleteLaptop(id_laptop);

            return NoContent();
        }
    }
}
