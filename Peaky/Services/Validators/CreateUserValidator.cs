using FluentValidation;
using Peaky.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO> 
    {

        public CreateUserValidator() {

            RuleFor(createUserDTO => createUserDTO.email).NotNull().EmailAddress();
            RuleFor(createUserDTO => createUserDTO.name).NotNull();
            RuleFor(createUserDTO => createUserDTO.password).NotNull();

        }

    }
}
