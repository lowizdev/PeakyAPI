using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class UnityOfWork: IUnitOfWork
    {

        private readonly DBSession _session;

        public UnityOfWork(DBSession session)
        {
            this._session = session;
        }

        public void BeginTransaction()
        {
            this._session.transaction = this._session.connection.BeginTransaction();
        }

        public void Commit() {

            this._session.transaction.Commit();
            this.Dispose();

        }

        public void Rollback() {

            this._session.transaction.Rollback();
            this.Dispose();

        }

        public void Dispose() {
            this._session.transaction.Dispose();
        }

    }
}
