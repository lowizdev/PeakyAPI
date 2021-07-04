using FluentValidation;
using Peaky.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services.Validators
{
    public class CreateRaceValidator: AbstractValidator<CreateRaceDTO>
    {

        public CreateRaceValidator()
        {
            RuleFor(createRaceDTO => createRaceDTO.description).NotNull();
            RuleFor(createRaceDTO => createRaceDTO.raceDate).NotNull(); //TODO: CHECK DATE
        }

    }
}
