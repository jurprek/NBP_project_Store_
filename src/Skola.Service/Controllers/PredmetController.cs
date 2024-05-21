
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
    public IActionResult ReadPredmet()
    {
        return Ok(_executionContext.Repository.NBP_project_Store.Predmet.Query().ToList());
    }

    [HttpGet("Predmet/Id")]
    public IActionResult ReadPredmet([FromQuery] string id_predmet, [FromQuery] string naziv)
    {
        var results = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                              .Where(i => i.Id_Predmet == id_predmet || i.Naziv.Contains(naziv))
                              .ToList();
        if (results == null || !results.Any())
        {
            return NotFound("Laptop nije u SQL bazi");
        }

        return Ok(results);
    }
}
