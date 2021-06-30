using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromServices] IRaceService raceService) {

            Race race = await raceService.ReadById(id);

            if(race != null){
                return Ok(race);
            }

            return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok("");

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRaceDTO dto, [FromServices] IRaceService raceService)
        {

            Race race = await raceService.Create(dto);

            if (race != null) {

                return Ok(race);

            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete()
        {

            return Ok("");

        }

        //TODO: ADDHORSE
        [HttpPost("{id}/horses/")]
        public async Task<IActionResult> PostHorse(int id, [FromServices] IRaceService raceService, [FromServices] IHorseService horseService)
        {

            Race race = await raceService.ReadById(id);

            Horse horse = await horseService.ReadById(1); //TODO: FIX THIS, TEST ONLY

            //var result = await raceService.

            return Ok("");

        }

    }
}
