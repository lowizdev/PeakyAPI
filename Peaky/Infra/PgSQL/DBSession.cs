using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class DBSession: IDisposable
    {

        public IDbConnection connection = null;
        public IDbTransaction transaction = null;

        public DBSession(IPeakyDBConnection connection)
        {
            this.connection = connection.GetConnection();
        }

        public void StartConnection() { }// If any parameter is needed by the connection

        public void Dispose()
        {
            //Closing will be handled by DI Container
            this.connection?.Dispose();
        }
    }
}
