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

using Skola;

[ApiController]
    [Route("api/[controller]")]

    //PREDMET---------------------------------------------------------------------------------------------
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

        [HttpGet("ReadPredmet")]
        public IActionResult ReadPredmet()
        {
            return Ok(_executionContext.Repository.Skola.Predmet.Query().ToList());
        }

        [HttpGet("ReadPredmet/{id}")]
        public IActionResult ReadPredmet([FromRoute] Guid id)
        {
            Skola_Predmet result = null;

            result = _executionContext.Repository.Skola.Predmet.Query()
                              .Where(i => i.ID == id)
                              .FirstOrDefault();


            if (result == null)
            {
                return NotFound("Predmet nije pronaðen");
            }

            return Ok(result);
        }


        [HttpPost("WritePredmet")]
        public IActionResult WritePredmet([FromQuery] string naziv, [FromQuery] Guid profesorID)
        {
            _executionContext.Repository.Skola.Predmet.Insert(new Skola.Predmet
            {
                Naziv = naziv,
                ProfesorID = profesorID
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("DeletePredmet")]
        public IActionResult DeletePredmet([FromQuery] Guid id)
        {
            Skola_Predmet result = null;

            result = _executionContext.Repository.Skola.Predmet.Query()
                          .Where(i => i.ID == id)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Predmet  ID = " + id + "  nije pronaðen.");
            }
            else
                _executionContext.Repository.Skola.Predmet.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }

