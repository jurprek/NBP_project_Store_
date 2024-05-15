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

using NBP_project_Store;

[ApiController]
    [Route("api/[controller]")]

    public class PoslovnicaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Common.ExecutionContext _executionContext;

        public PoslovnicaController(IRhetosComponent<Common.ExecutionContext> executionContext,
            IRhetosComponent<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork.Value;
            _executionContext = executionContext.Value;
        }

        [HttpGet("Poslovnica")]
        public IActionResult ReadPoslovnica()
        {
            return Ok(_executionContext.Repository.NBP_project_Store.Poslovnica.Query().ToList());
        }

        [HttpGet("Poslovnica/{id}")]
        public IActionResult ReadPoslovnica([FromRoute] Guid id)
        {
            NBP_project_Store_Poslovnica result = null;

            result = _executionContext.Repository.NBP_project_Store.Poslovnica.Query()
                              .Where(i => i.ID == id)
                              .FirstOrDefault();


            if (result == null)
            {
                return NotFound("Poslovnica nije u bazi");
            }

            return Ok(result);
        }


        [HttpPost("Poslovnica")]
        public IActionResult WritePoslovnica([FromQuery] string naziv, [FromQuery] Guid trgovacID)
        {
            _executionContext.Repository.NBP_project_Store.Poslovnica.Insert(new NBP_project_Store.Poslovnica
            {
                Naziv = naziv,
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("Poslovnica")]
        public IActionResult DeletePoslovnica([FromQuery] Guid id)
        {
            NBP_project_Store_Poslovnica result = null;

            result = _executionContext.Repository.NBP_project_Store.Poslovnica.Query()
                          .Where(i => i.ID == id)
                          .FirstOrDefault();

            if (result == null)
            {
                return NotFound("U bazi ne postoji  ID = " + id);
            }
            else
                _executionContext.Repository.NBP_project_Store.Poslovnica.Delete(result);

            _unitOfWork.CommitAndClose();
            return Ok(result);
        }
    }
