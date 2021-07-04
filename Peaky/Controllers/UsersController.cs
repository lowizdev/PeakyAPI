using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO dto, [FromServices] IUserService userService, [FromServices] IValidator<CreateUserDTO> validator) {


            ValidationResult validationResults = validator.Validate(dto);

            if (!validationResults.IsValid) {

                return BadRequest(validationResults.Errors);

            }

            var user = await userService.Create(dto);

            return Ok(user);

        }



    }
}
