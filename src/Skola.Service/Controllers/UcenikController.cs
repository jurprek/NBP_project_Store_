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

namespace Skola
{
    [ApiController]
    [Route("api/[controller]")]


    //UCENIK---------------------------------------------------------------------------------------------
    public class UcenikController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public UcenikController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        // Izvrsava upit na bazu
        //ToList() / ToListAsync()
        //Count
        //ToDictionary
        //Any()
        //FirstOrDefault

        //Na tipu IQueryable se stavljaju where uvjeti i order uvjet

        [HttpGet("ReadUcenik")]
        public IActionResult ReadUcenik()
        {
            //Ok, NoContent, BadRequest, NotFound
            return Ok(_executionContext.Repository.Skola.Ucenik.Query().ToList());
        }

        [HttpGet("ReadUcenik/Predmet")]
        public IActionResult ReadUcenik([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            Skola_Ucenik result = null;

            /*if (string.IsNullOrEmpty(prezime) && string.IsNullOrEmpty(prezime))
            {
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                              .FirstOrDefault();
            }
            else*/
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
            {
                
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id || (i.Ime == ime && i.Prezime ==prezime))
                              .FirstOrDefault();
             /*   string sql = "EXEC Skola.Predmeti ime, prezime";
                var sqlParams = new object[] { ime, prezime };
                var predmeti = _executionContext.EntityFrameworkContext.Database.ExecuteSqlCommand(sql, sqlParams).ToString();
             */   

                Dictionary<string, int> predmeti = new Dictionary<string, int>();
                var ucenik = _executionContext.Repository.Skola.Ucenik.Query()
                    .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                    .FirstOrDefault();

                if (ucenik != null)
                {
                    using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                    {
                        _executionContext.EntityFrameworkContext.Database.Connection.Close();

                        cmd.CommandText = "Skola.Predmeti";
                        cmd.CommandType = CommandType.StoredProcedure;

                        var imeParam = new SqlParameter("@ime", SqlDbType.NVarChar, 50);
                        imeParam.Value = ucenik.Ime;
                        cmd.Parameters.Add(imeParam);

                        var prezimeParam = new SqlParameter("@prezime", SqlDbType.NVarChar, 50);
                        prezimeParam.Value = ucenik.Prezime;
                        cmd.Parameters.Add(prezimeParam);

                        _executionContext.EntityFrameworkContext.Database.Connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nazivPredmeta = reader.GetString(0);
                                int ocjena = reader.GetInt32(1);
                                predmeti.Add(nazivPredmeta, ocjena);
                            }
                            
                        }
                    }
                    return Ok(new { result, predmeti });
                }

            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (result == null)
            {
                return NotFound("Uèenik nije pronaðen");
            }

            return Ok(result);
        }


        [HttpPost("WriteUcenik")]
        public IActionResult WriteUcenik([FromQuery] string ime, [FromQuery] string prezime)
        {
            _executionContext.Repository.Skola.Ucenik.Insert(new Skola.Ucenik
            {
                //ID = Guid.NewGuid()
                Ime = ime,
                Prezime =prezime,
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("DeleteUcenik")]
        public IActionResult DeleteUcenik([FromQuery] Guid id)
        {
            Skola_Ucenik result = null;

            result = _executionContext.Repository.Skola.Ucenik.Query()
                            .Where(i => i.ID == id)
                            .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Uèenik  ID = " + id + "  nije pronaðen.");
            }
            else
                _executionContext.Repository.Skola.Ucenik.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
}
