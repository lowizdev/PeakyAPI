using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peaky.Models;
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
        public async Task<IActionResult> Login ([FromBody] User user){

            //TODO: VALIDATE PASSWORD AND RECOVER USER

            var token = TokenService.GenerateTokenAsString(new User { 
            
                id = 1,
                name = "testuser",
                email = "test@test.com",
                password = "testpwd"


            });

            return Ok(token);

        }
        
        [HttpGet("testlogin")]
        [Authorize]
        public async Task<IActionResult> Test() {

            return Ok("You have access!");
        }
    }
}
