using Peaky.Models;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class UserDapperRepository : IUserRepository
    {
        private DBSession _session;

        public UserDapperRepository(DBSession session)
        {
            this._session = session;
        }

        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetOneByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOne(User element)
        {
            throw new NotImplementedException();
        }
    }
}
