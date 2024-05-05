using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Common.Queryable;
using NBP_project_Store;

[ApiController]
[Route("api/[controller]")]

public class PredmetController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Common.ExecutionContext _executionContext;

    public PredmetController(IRhetosComponent<Common.ExecutionContext> executionContext,
        IRhetosComponent<IUnitOfWork> unitOfWork)
    {
        _unitOfWork = unitOfWork.Value;
        _executionContext = executionContext.Value;
    }

    [HttpGet("Predmet")]
    public IActionResult Predmet()
    {
        return Ok(_executionContext.Repository.NBP_project_Store.Predmet.Query().ToList());
    }

    [HttpGet("Predmet/Filter")]
    public IActionResult ReadPredmet([FromQuery] Guid PredmetID, [FromQuery] Guid predmet)
    {
        NBP_project_Store_Predmet result = null;


        result = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                                //.Where(i => i.PredmetID == predmet)
                                .FirstOrDefault();

        if (result == null)
        {
            return NotFound("Predmet ne postoji u bazi.");
        }

        return Ok(result);
    }

    [HttpPost("Predmet")]
    public IActionResult WritePredmet([FromQuery] string predmet, [FromQuery] Guid poslovnica)
    {
        _executionContext.Repository.NBP_project_Store.Predmet.Insert(new NBP_project_Store.Predmet
        {
            Naziv = predmet,
            PoslovnicaID = poslovnica
        });

        _unitOfWork.CommitAndClose();

        return NoContent();
    }


    [HttpDelete("Predmet")]
    public IActionResult DeletePredmet([FromQuery] Guid kupcaID, [FromQuery] Guid predmetID)
    {
        NBP_project_Store_Predmet result = null;

        result = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                       .FirstOrDefault();

        if (result == null)
        {
            return NotFound("Predmet ne postoji u bazi.");
        }
        else
            _executionContext.Repository.NBP_project_Store.Predmet.Delete(result);

        _unitOfWork.CommitAndClose();
        return Ok(result);
    }
}


