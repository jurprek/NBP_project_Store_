using Microsoft.AspNetCore.Mvc;
using Rhetos;
using System.Data;
using Skola.Service.Models;

[ApiController]
[Route("api/[controller]")]

public partial class IspisOcjenaController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Common.ExecutionContext _executionContext;

    public IspisOcjenaController(IRhetosComponent<Common.ExecutionContext> executionContext,
        IRhetosComponent<IUnitOfWork> unitOfWork)
    {
        _unitOfWork = unitOfWork.Value;
        _executionContext = executionContext.Value;
    }

    [HttpGet("IspisOcjena")]
    public IActionResult IspisOcjena()
    {
        List<IspisModel> ocjene = new List<IspisModel>();

        using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
        {
            _executionContext.EntityFrameworkContext.Database.Connection.Close();

            cmd.CommandText = "SELECT * FROM NBP_project_Store.ocjene";
            cmd.CommandType = CommandType.Text;

            _executionContext.EntityFrameworkContext.Database.Connection.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ImeUcenika = reader.GetString(0);
                    string PrezimeUcenika = reader.GetString(1);
                    string ImeProfesora = reader.GetString(2);
                    string PrezimeProfesora = reader.GetString(3);
                    string NazivPredmeta = reader.GetString(4);
                    int ZakljucnaOcjena = reader.GetInt32(5);
                    IspisModel ocjena = new IspisModel(ImeUcenika, PrezimeUcenika, ImeProfesora, PrezimeProfesora, NazivPredmeta, ZakljucnaOcjena);
                    ocjene.Add(ocjena);
                }
            }
            return Ok(ocjene);
        }
    }
}