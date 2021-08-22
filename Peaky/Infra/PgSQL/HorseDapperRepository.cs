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
        private DBSession _session = null;
        public HorseDapperRepository(DBSession session)
        {
            this._session = session;
        }
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Horse>> GetAll()
        {
            String sql = "SELECT * FROM horse";

            List<Horse> result = null;

            result = (await this._session.connection.QueryAsync<Horse>(sql)).ToList();

            //TODO: APPLY UOW

            return result;
        }

        /*public async Task<Horse> GetOneById(int id)
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
        }*/

        public async Task<Horse> GetOneById(int id)
        {
            String sql = "SELECT * FROM horse WHERE id = @id";

            var horse = await this._session.connection.QueryFirstOrDefaultAsync<Horse>(sql, new { id = id });

            if (horse != null)
            {

                return horse;

            }

            return null;
        }

        public async Task<int> InsertOne(Horse element)
        {
            //throw new NotImplementedException();
            return 1;
        }
    }
}
