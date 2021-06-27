using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class PgDbConnection
    {
        //TODO REFACTOR
        public static NpgsqlConnection getConnection() {

            var connString = "";

            //await using var conn = new NpgsqlConnection(connString);

            return new NpgsqlConnection(connString);

        }


    }
}
