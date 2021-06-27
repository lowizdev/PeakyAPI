using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class HorseRepository
    {

        public async Task<bool> TestQuery() {

            using (var conn = PgDbConnection.getConnection())
            {

                await conn.OpenAsync();

                await using (var cmd = new NpgsqlCommand("SELECT * FROM horse", conn))
                {

                    var res = await cmd.ExecuteReaderAsync();
                    res.Read();
                    res.Read();
                    var aaa = res["name"];
                    Console.WriteLine(res);

                }
            }

            return true;

        }

    }
}
