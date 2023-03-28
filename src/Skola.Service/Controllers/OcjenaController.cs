using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;

    [ApiController]
    [Route("api/[controller]")]

    public class OcjenaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public OcjenaController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Ocjena")]
        public IActionResult Ocjena()
        {
            return Ok(_executionContext.Repository.Skola.Ocjena.Query().ToList());
        }

        [HttpGet("Ocjena/Filter")]
        public IActionResult ReadOcjena([FromQuery] Guid predmetID, [FromQuery] Guid ucenik)
        {
            Skola_Ocjena result = null;


            result = _executionContext.Repository.Skola.Ocjena.Query()
                          .Where(i => i.UcenikID == ucenik && i.PredmetID == predmetID)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Ocjena ne postoji u bazi.");
            }

            return Ok(result);
        }
        
        [HttpPost("Ocjena")]
        public IActionResult WriteOcjena([FromQuery] Guid ucenikID, [FromQuery] Guid predmetID, [FromQuery] int ocjena)
        {
            _executionContext.Repository.Skola.Ocjena.Insert(new Skola.Ocjena
            {
                UcenikID = ucenikID,
                PredmetID = predmetID,
                ocjena = ocjena
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("Ocjena")]
        public IActionResult DeleteOcjena([FromQuery] Guid ucenikID, [FromQuery] Guid predmetID)
        {
            Skola_Ocjena result = null;

            result = _executionContext.Repository.Skola.Ocjena.Query()
                          .Where(i => i.UcenikID == ucenikID && i.PredmetID == predmetID)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Ocjena ne postoji u bazi.");
            }
            else
                _executionContext.Repository.Skola.Ocjena.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }


