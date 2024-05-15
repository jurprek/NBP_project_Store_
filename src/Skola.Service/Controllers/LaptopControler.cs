using Microsoft.AspNetCore.Mvc;
using Skola.Service.Models;
using NBP_project_Store;
using System.Collections.Generic;
using NBP_project_Store.Service;

namespace Skola.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly MongoDBContext _laptopService;

        public LaptopsController(MongoDBContext laptopService)
        {
            _laptopService = laptopService;
        }

        // GET: api/Laptops
        [HttpGet]
        public ActionResult<List<Laptop>> GetLaptops()
        {
            var laptops = _laptopService.GetLaptops();
            return Ok(laptops);
        }

        // GET: api/Laptops/5
        [HttpGet("{id:length(24)}", Name = "GetLaptop")]
        public ActionResult<Laptop> GetLaptop(string id)
        {
            var laptop = _laptopService.GetLaptopById(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
        }

        // POST: api/Laptops
        [HttpPost]
        public ActionResult<Laptop> CreateLaptop(Laptop laptop)
        {
            _laptopService.CreateLaptop(laptop);
            return CreatedAtRoute("GetLaptop", new { id = laptop.PredmetId }, laptop);
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
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteLaptop(string id)
        {
            var laptop = _laptopService.GetLaptopById(id);

            if (laptop == null)
            {
                return NotFound();
            }

            _laptopService.DeleteLaptop(id);

            return NoContent();
        }
    }
}
