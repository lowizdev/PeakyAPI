using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peaky.Models.Interfaces;
using Peaky.Infra.PgSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peaky.Models;
using Peaky.Models.DTOs;

namespace Peaky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IHorseRepository repository) {

            /*HorseRepository hr1 = new HorseRepository();

            await hr1.TestQuery();*/

            //TODO: REFACTOR TO SERVICE

            List<Horse> horses = await repository.GetAll();

            return Ok(horses);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromServices] IHorseService horseService)
        {

            var result = await horseService.ReadById(id);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateHorseDTO dto, [FromServices] IHorseService horseService) {

            Horse horse = await horseService.Create(dto);

            if (horse != null) {

                return Ok(horse);

            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            return Ok("NOT IMPLEMENTED");

        }

    }
}
