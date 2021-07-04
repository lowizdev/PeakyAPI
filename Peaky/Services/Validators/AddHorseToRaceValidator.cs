using FluentValidation;
using Peaky.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services.Validators
{
    public class AddHorseToRaceValidator : AbstractValidator<AddHorseToRaceDTO>
    {

        public AddHorseToRaceValidator()
        {
            RuleFor(addHorse => addHorse.HorseId).NotNull();
        }

    }
}
