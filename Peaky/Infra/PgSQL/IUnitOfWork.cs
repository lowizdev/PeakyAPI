using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public interface IUnitOfWork: IDisposable
    {
        public void BeginTransaction();
        public void Commit();
        public void Rollback();

    }
}
