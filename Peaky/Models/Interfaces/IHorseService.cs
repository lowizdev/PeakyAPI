using Peaky.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.Interfaces
{
    public interface IHorseService: IAppServiceAsync<Horse, CreateHorseDTO>
    {

    }
}
