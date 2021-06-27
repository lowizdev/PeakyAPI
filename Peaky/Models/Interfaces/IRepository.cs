using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.Interfaces
{
    public interface IRepository <T>
    {

        public Task<T> GetOneById(int id);
        public Task<List<T>> GetAll();
        public Task<int> InsertOne(T element);
        public Task<bool> DeleteOneById(int id);

    }
}
