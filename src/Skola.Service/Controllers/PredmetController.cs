
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

    [HttpGet("Pronaði_Predmet")]
    public IActionResult Readredmet([FromQuery] string id_predmet, [FromQuery] string opis)
    {
        var results = _executionContext.Repository.NBP_project_Store.Predmet.Query()
                              .Where(i => i.Id_Predmet.Contains(id_predmet) || i.Naziv.Contains(opis))
                              .ToList();
        if (results == null || !results.Any())
        {
            return NotFound("Predmet nije u bazi");
        }

        return Ok(results);
    }
}
