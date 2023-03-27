using Common;
using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Processing;
using Rhetos.Processing.DefaultCommands;
using Rhetos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Common.Queryable;
using System.Data.Entity.ModelConfiguration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.CommandLine;
using System.Data.SqlClient;
using System.Text.Json;
using System.Data;
using Skola;
using Newtonsoft.Json;
using Skola.Service.Models;

[ApiController]
[Route("api/[controller]")]


//Ispis svih ocjena, predmeta, ucenika, profesora---------------------------------------------------------------------------------------------
public partial class IspisController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Common.ExecutionContext _executionContext;

    public IspisController(IRhetosComponent<Common.ExecutionContext> executionContext,
        IRhetosComponent<IUnitOfWork> unitOfWork)
    {
        _unitOfWork = unitOfWork.Value;
        _executionContext = executionContext.Value;
    }

    [HttpGet("ReadIspis")]
    public IActionResult ReadIspis()
    {
        List<IspisModel> ocjene = new List<IspisModel>();

        using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
        {
            _executionContext.EntityFrameworkContext.Database.Connection.Close();

            cmd.CommandText = "SELECT * FROM Skola.ocjene";
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