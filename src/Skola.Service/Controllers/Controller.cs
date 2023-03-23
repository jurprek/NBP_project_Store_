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
        public IActionResult ReadUcenik([FromRoute] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            Skola_Ucenik result = null;

            if(string.IsNullOrEmpty(ime))
            {
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            }
            else
            {
                result = _executionContext.Repository.Skola.Ucenik.Query()
                              .Where(i => i.ID == id && i.Ime == ime && i.Prezime == prezime)
                              .FirstOrDefault();
            }

            if(result == null)
            {
                return NotFound("Uèenik nije pronaðen");
            }

            return Ok(result);
        }


        [HttpPost("WriteUcenik")]
        public IActionResult WriteUcenici([FromBody] NoviUcenik ucenik)
        {
            _executionContext.Repository.Skola.Ucenik.Insert(new Skola.Ucenik
            {
                //ID = Guid.NewGuid()
                Ime = ucenik.Ime,
                Prezime = ucenik.Prezime,
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

    public class NoviUcenik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }




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

        [HttpGet("ReadProfesor/{id}")]
        public IActionResult ReadProfesor([FromRoute] Guid id, [FromQuery] string ime, [FromQuery] string prezime)
        {
            Skola_Profesor result = null;

            if (string.IsNullOrEmpty(ime))
            {
                result = _executionContext.Repository.Skola.Profesor.Query()
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            }
            else
            {
                result = _executionContext.Repository.Skola.Profesor.Query()
                              .Where(i => i.ID == id && i.Ime == ime && i.Prezime == prezime)
                              .FirstOrDefault();
            }

            if (result == null)
            {
                return NotFound("Profesor nije pronaðen");
            }

            return Ok(result);
        }


        [HttpPost("WriteProfesor")]
        public IActionResult WriteProfesori([FromBody] NoviProfesor Profesor)
        {
            _executionContext.Repository.Skola.Profesor.Insert(new Skola.Profesor
            {
                //ID = Guid.NewGuid()
                Ime = Profesor.Ime,
                Prezime = Profesor.Prezime,
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

    public class NoviProfesor
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }





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
        public IActionResult WritePredmeti([FromBody] NoviPredmet Predmet, [FromBody] NoviProfesor ProfesorID)
        {
            _executionContext.Repository.Skola.Predmet.Insert(new Skola.Predmet
            {
                Naziv = Predmet.Naziv,
                ProfesorID = Predmet.ProfesorID
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

    public class NoviPredmet
    {
        public string Naziv { get; set; }
        public Guid ProfesorID { get; set; }

    }





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
        public IActionResult WriteOcjenai([FromBody] NovaOcjena Ocjena)
        {
            _executionContext.Repository.Skola.Ocjena.Insert(new Skola.Ocjena
            {
                UcenikID = Ocjena.UcenikID,
                PredmetID = Ocjena.PredmetID,
                ocjena = Ocjena.ocjena
            });

            _unitOfWork.CommitAndClose();

            return NoContent();
        }


        [HttpDelete("DeleteOcjena")]
        public IActionResult DeleteOcjena([FromQuery] Guid UcenikID, [FromQuery] Guid PredmetID)
        {
            Skola_Ocjena result = null;

            result = _executionContext.Repository.Skola.Ocjena.Query()
                          .Where(i => i.ID == UcenikID)
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
    }

    public class NovaOcjena
    {
        public int ocjena { get; set; }
        public Guid UcenikID { get; set; }
        public Guid PredmetID { get; set; }
    }

}