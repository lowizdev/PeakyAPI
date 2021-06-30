using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.Interfaces
{
    public interface IHashing
    {

        public string Hash(string hashable);

        public bool Verify(string hashed, string value);



    }
}
