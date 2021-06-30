using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using Peaky.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] LoginDTO dto, [FromServices] IUserService userService){

            //DONETODO: VALIDATE PASSWORD AND RECOVER USER

            /*var token = TokenService.GenerateTokenAsString(new User { 
            
                id = 1,
                name = "testuser",
                email = "test@test.com",
                password = "testpwd"


            });*/

            var result = await userService.Login(dto);

            if (result == null) { //TODO: HANDLE THIS MORE ELEGANTLY

                return NotFound();

            }

            return Ok(result);

        }
        
        [HttpGet("testlogin")]
        [Authorize]
        public async Task<IActionResult> Test() {

            return Ok("You have access!");
        }
    }
}
