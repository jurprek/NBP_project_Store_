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
using System.Data.SqlClient;
using System.Text.Json;
using System.Data;


[ApiController]
    [Route("api/[controller]")]


    //PROFESOR---------------------------------------------------------------------------------------------
    public class ProfesorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public ProfesorController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("ReadProfesor")]
        public IActionResult ReadProfesor()
        {
            return Ok(_executionContext.Repository.Skola.Profesor.Query().ToList());
        }

        [HttpGet("ReadProfesor/Predmeti")]
        public IActionResult ReadProfesor([FromQuery] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            Skola_Profesor result = null;

        /* if (string.IsNullOrEmpty(profesor.Ime))
         {
             result = _executionContext.Repository.Skola.Profesor.Query()
                           .Where(i => i.ID == id)
                           .FirstOrDefault();
         }
         else*/
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        {

            //result = _executionContext.Repository.Skola.Profesor.Query()
            //              .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
            //              .FirstOrDefault();
            /*   string sql = "EXEC Skola.Predmeti ime, prezime";
               var sqlParams = new object[] { ime, prezime };
               var predmeti = _executionContext.EntityFrameworkContext.Database.ExecuteSqlCommand(sql, sqlParams).ToString();
            */

            List<string> predmeti = new List<string>();

            var profesor = _executionContext.Repository.Skola.Profesor.Query()
                .Where(i => i.ID == id || (i.Ime == ime && i.Prezime == prezime))
                .FirstOrDefault();

            if (profesor != null)
            {
                using (var cmd = _executionContext.EntityFrameworkContext.Database.Connection.CreateCommand())
                {
                    _executionContext.EntityFrameworkContext.Database.Connection.Close();
                    cmd.CommandText = "Skola.Predmeti";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var imeParam = new SqlParameter("@ime", SqlDbType.NVarChar, 50);
                    imeParam.Value = profesor.Ime;
                    cmd.Parameters.Add(imeParam);

                    var prezimeParam = new SqlParameter("@prezime", SqlDbType.NVarChar, 50);
                    prezimeParam.Value = profesor.Prezime;
                    cmd.Parameters.Add(prezimeParam);

                    _executionContext.EntityFrameworkContext.Database.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nazivPredmeta = reader.GetString(0);
                            predmeti.Add(nazivPredmeta);
                        }

                    }
                }
                return Ok(new { profesor, predmeti });
            }

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (result == null)
            {
                return NotFound("Profesor nije pronaðen");
            }

            return Ok(result);
        }


        [HttpPost("WriteProfesor")]
        public IActionResult WriteProfesor([FromQuery] string ime, [FromQuery] string prezime)
        {
            _executionContext.Repository.Skola.Profesor.Insert(new Skola.Profesor
            {
                Ime =ime,
                Prezime = prezime,
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("DeleteProfesor")]
        public IActionResult DeleteProfesor([FromQuery] Guid id)
        {
            Skola_Profesor result = null;

            result = _executionContext.Repository.Skola.Profesor.Query()
                          .Where(i => i.ID == id)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Profesor  ID = " + id + "  nije pronaðen.");
            }
            else
                _executionContext.Repository.Skola.Profesor.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
