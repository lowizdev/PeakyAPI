using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.Interfaces
{
    public interface IAppServiceAsync<T, K>
    {

        Task<T> Create(K element);
        Task<T> ReadById(int id);
        Task<T> ReadAll();
        Task<bool> DeleteById(int id);

    }
}
