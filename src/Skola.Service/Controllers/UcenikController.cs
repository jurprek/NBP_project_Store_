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

        [HttpGet("ReadUcenik/{id}")]
        public IActionResult ReadUcenik([FromRoute] Guid id, [FromQuery] Ucenik ucenik)
        {
            Skola_Ucenik result = null;

            if (string.IsNullOrEmpty(ucenik.Ime))
            {
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            }
            else
            {
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id && i.Ime == ucenik.Ime && i.Prezime == ucenik.Prezime)
                              .FirstOrDefault();
            }

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
