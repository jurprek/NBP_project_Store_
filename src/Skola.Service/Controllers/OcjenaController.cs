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

    //OCJENA---------------------------------------------------------------------------------------------
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

        [HttpGet("ReadOcjena")]
        public IActionResult ReadOcjena()
        {
            return Ok(_executionContext.Repository.Skola.Ocjena.Query().ToList());
        }
        //------------------------------------------------------------------------------------------------------------------------------------- pretraga po id predmeta + po id ucenika------
        [HttpGet("ReadOcjena/Filter")]
        public IActionResult ReadOcjena([FromQuery] Guid predmet, [FromQuery] Guid ucenik)
        {
            Skola_Ocjena result = null;


            result = _executionContext.Repository.Skola.Ocjena.Query()
                          .Where(i => i.UcenikID == ucenik && i.PredmetID == predmet)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Ocjena nije pronaðena");
            }

            return Ok(result);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost("WriteOcjena")]
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


        [HttpDelete("DeleteOcjena")]
        public IActionResult DeleteOcjena([FromQuery] Guid UcenikID, [FromQuery] Guid PredmetID)
        {
            Skola_Ocjena result = null;

            result = _executionContext.Repository.Skola.Ocjena.Query()
                          .Where(i => i.UcenikID == UcenikID && i.PredmetID == PredmetID)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("Ocjena nije pronaðena.");
            }
            else
                _executionContext.Repository.Skola.Ocjena.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }



    //Action iz .cs


    }


