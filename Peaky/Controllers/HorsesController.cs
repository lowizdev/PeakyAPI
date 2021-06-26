using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peaky.Infra.PgSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get() {

            HorseRepository hr1 = new HorseRepository();

            hr1.TestQuery();

            return Ok("Hello");

        }

    }
}
