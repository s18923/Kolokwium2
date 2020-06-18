using Kolokwium2.DTOs.Requests;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/championship")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        IDbService service;
        public TeamsController(IDbService service)
        {
            this.service = service;
        }

        [HttpPost("{id:int}")]
        public IActionResult AddPlayerToTeam(int id, PlayerRequest request)
        {
            try
            {
                service.AddPLayerToTeam(id, request);
                return Ok();
            }
            catch (PlayerDoesNotExistException exc)
            {
                return NotFound(exc.Message);
            }
            catch (TooOldException exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
