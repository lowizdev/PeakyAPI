using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{

    public interface IPeakyDBConnection {

        public IDbConnection GetConnection();

    }

    public class PgDbConnection: IPeakyDBConnection
    {
        //TODO REFACTOR
        public IDbConnection GetConnection() {

            var connString = ""; ;

            //await using var conn = new NpgsqlConnection(connString);

            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();

            return connection;

        }

        //TODO: REPLACE
        public static NpgsqlConnection getConnection()
        {

            var connString = "";

            //await using var conn = new NpgsqlConnection(connString);

            return new NpgsqlConnection(connString);

        }


    }
}
