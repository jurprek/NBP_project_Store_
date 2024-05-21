using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using System.Data.SqlClient;
using System.Data;
using NBP_project_Store;

[ApiController]
    [Route("api/[controller]")]

    public class TrgovacController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public TrgovacController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Trgovac")]
        public IActionResult ReadTrgovac()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Trgovac.Query().ToList());
        }

        [HttpGet("Trgovac/Id")]
        public IActionResult ReadTrgovac([FromQuery] string id_trgovac, [FromQuery] string ime, [FromQuery] string prezime)
        {
            var results = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                                  .Where(i => i.Id_Trgovac == id_trgovac || (i.Ime == ime && i.Prezime == prezime))
                                  .ToList();
            if (results == null || !results.Any())
            {
                return NotFound("Trgovac nije u bazi");
            }

            return Ok(results);
        }

        [HttpPost("Trgovac")]
        public IActionResult WriteTrgovac([FromQuery] string ime, [FromQuery] string prezime, [FromQuery] string id_trgovac)
        {
        _executionContext.Repository.NBP_project_Store.Trgovac.Insert(new NBP_project_Store.Trgovac
        {
            Id_Trgovac = id_trgovac,
            Ime = ime,
            Prezime = prezime
            }) ;

            _unitOfWork.CommitAndClose();

            return NoContent();
        }

        [HttpDelete("Trgovac")]
        public IActionResult DeleteTrgovac([FromQuery] string id_trgovac)
        {
            NBP_project_Store_Trgovac result = null;

            result = _executionContext.Repository.NBP_project_Store.Trgovac.Query()
                          .Where(i => i.Id_Trgovac == id_trgovac)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("U bazi ne postoji  ID = " + id_trgovac);
            }
            else
                _executionContext.Repository.NBP_project_Store.Trgovac.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
