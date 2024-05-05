using Microsoft.AspNetCore.Mvc;
using Rhetos;
using System.Data;
using Skola.Service.Models;

[ApiController]
[Route("api/[controller]")]

public partial class IspisProdanihPredmetaController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Common.ExecutionContext _executionContext;

    public IspisProdanihPredmetaController(IRhetosComponent<Common.ExecutionContext> executionContext,
        IRhetosComponent<IUnitOfWork> unitOfWork)
    {
        _unitOfWork = unitOfWork.Value;
        _executionContext = executionContext.Value;
    }

    [HttpGet("IspisProdanihPredmeta")]
    public IActionResult IspisProdanihPredmeta()
    {
        List<String> formattedGuids = new List<String>();

        using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
        {
            _executionContext.EntityFrameworkContext.Database.Connection.Close();

            cmd.CommandText = "select * from NBP_project_Store.Pregled";
            cmd.CommandType = CommandType.Text;

            _executionContext.EntityFrameworkContext.Database.Connection.Open();

            
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Guid Trgovac = reader.GetGuid(0);
                    Guid Poslovnica = reader.GetGuid(1);
                    Guid Predmet = reader.GetGuid(2);
                    Guid Kupac = reader.GetGuid(3);

                    string formattedGuid = $"Poslovnica: {Poslovnica}, Trgovac: {Trgovac}, Predmet: {Predmet}, Kupac: {Kupac}";
                    formattedGuids.Add(formattedGuid);
                }
            }
        }
        return Ok(formattedGuids);
    }
}