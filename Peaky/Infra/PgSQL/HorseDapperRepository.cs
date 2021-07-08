using Dapper;
using Peaky.Models;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class HorseDapperRepository : IHorseRepository
    {
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Horse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Horse> GetOneById(int id)
        {
            String sql = "SELECT * FROM horse WHERE id = @id";

            using (IDbConnection conn = PgDbConnection.getConnection())
            {

                conn.Open();

                var horse = await conn.QueryFirstOrDefaultAsync<Horse>(sql, new { id = id });

                if (horse != null){

                    return horse;

                }

            }

            return null;
        }

        public Task<int> InsertOne(Horse element)
        {
            throw new NotImplementedException();
        }
    }
}
