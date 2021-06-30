using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.Interfaces
{
    public interface IRaceRepository: IRepository<Race>
    {
        public Task<Race> AddHorse(Race race, Horse horse);

        public Task<int> GetHorseQuantity(Race race);

    }
}
