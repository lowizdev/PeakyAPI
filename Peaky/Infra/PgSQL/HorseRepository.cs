using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class HorseRepository
    {

        public async void TestQuery() {

            var connString = "";

            await using var conn = new NpgsqlConnection(connString);

            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT * FROM horse", conn)) {

                var res = await cmd.ExecuteReaderAsync();
                res.Read();
                res.Read();
                var aaa = res["name"];
                Console.WriteLine(res);
            
            }

        }

    }
}
