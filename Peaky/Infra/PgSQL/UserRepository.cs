using Peaky.Models.Interfaces;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
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
