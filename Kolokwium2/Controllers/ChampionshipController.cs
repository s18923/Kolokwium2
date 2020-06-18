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
    public class ChampionshipController : ControllerBase
    {
        ISqlServerDbService service;
        public ChampionshipController(ISqlServerDbService service)
        {
            this.service = service;
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetChampionshipInfo(int Id)
        {
            var result = service.GetChampionshipInfo(Id);

            if (result == null)
            {
                return BadRequest("Mistrzostwa o podanym id nie istniały!");
            }
            return Ok(result);
        }
    }
}
