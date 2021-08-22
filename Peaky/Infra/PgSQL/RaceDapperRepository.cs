using Peaky.Models;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class RaceDapperRepository : IRaceRepository
    {
        DBSession _session = null;
        public RaceDapperRepository(DBSession session)
        {
            this._session = session;
        }

        public Task<Race> AddHorse(Race race, Horse horse)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Race>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetHorseQuantity(Race race)
        {
            throw new NotImplementedException();
        }

        public Task<Race> GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOne(Race element)
        {
            throw new NotImplementedException();
        }
    }
}
