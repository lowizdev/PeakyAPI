using FluentValidation;
using FluentValidation.Results;
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
        public async Task<IActionResult> Post([FromBody] CreateRaceDTO dto, [FromServices] IRaceService raceService, [FromServices] IValidator<CreateRaceDTO> validator)
        {

            ValidationResult validationResults = validator.Validate(dto);

            if (!validationResults.IsValid) {

                return BadRequest(validationResults.Errors);

            }

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

        [HttpGet("{id}/horses/{horseId}")]
        public async Task<IActionResult> GetHorse(int id, int horseId, [FromServices] IRaceService raceService, [FromServices] IHorseService horseService)
        {

            return Ok("NOT IMPLEMENTED");

        }

        //DONETODO: ADDHORSE
        [HttpPost("{id}/horses/")]
        public async Task<IActionResult> PostHorse(int id, [FromBody] AddHorseToRaceDTO horseToRace , [FromServices] IRaceService raceService, [FromServices] IHorseService horseService, [FromServices] IValidator<AddHorseToRaceDTO> validator)
        {

            /*ValidationResult validationResults = validator.Validate(dto);

            if (!validationResults.IsValid)
            {

                return BadRequest(validationResults.Errors);

            }*/ //TODO: RETHINK THIS FUNCTIONALITY


            Race race = await raceService.ReadById(id);

            Horse horse = await horseService.ReadById(horseToRace.HorseId); //TODO: FIX THIS, TEST ONLY

            var result = await raceService.RegisterHorseToRace(race, horse);

            if (result != null) {
                return Ok(result);
            }

            return BadRequest();

        }

    }
}
