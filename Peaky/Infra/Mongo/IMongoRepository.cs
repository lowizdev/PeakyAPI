using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo
{
    public interface IMongoRepository<T>: IRepository<T>
    {
    }
}
