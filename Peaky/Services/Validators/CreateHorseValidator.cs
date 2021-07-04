using FluentValidation;
using Peaky.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services.Validators
{
    public class CreateHorseValidator : AbstractValidator<CreateHorseDTO>
    {

        public CreateHorseValidator()
        {
            
            RuleFor(createHorseDTO => createHorseDTO.age).NotNull();
            RuleFor(createHorseDTO => createHorseDTO.name).NotNull();

        }

    }
}
