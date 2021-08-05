using Peaky.Models.Interfaces;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Peaky.Factories;

namespace Peaky.Infra.PgSQL
{
    public class UserRepository : IUserRepository
    {
        //TODO: REFACTOR TO DAPPER BUT KEEP THIS IMPLEMENTATION
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetOneById(int id)
        {
            //throw new NotImplementedException();

            var sql = "SELECT * FROM operator WHERE id = @id";

            NpgsqlDataReader result;

            using (var conn = PgDbConnection.getConnection()) {

                await using (var command = conn.CreateCommand()){

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("id", id);

                    result = await command.ExecuteReaderAsync();

                    if (result.Read()) {

                        GenericDOFactoryADO<User> userFactory = new GenericDOFactoryADO<User>();

                        var resultUser = userFactory.Make(result);

                        return resultUser;

                    }

                }
            }

            return null;

        }

        public async Task<User> GetOneByEmail(string email)
        {
            //throw new NotImplementedException();

            var sql = "SELECT * FROM operator WHERE email = @email LIMIT 1";

            NpgsqlDataReader result;

            using (var conn = PgDbConnection.getConnection())
            {

                await using (var command = conn.CreateCommand())
                {

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("email", email);

                    result = await command.ExecuteReaderAsync();

                    if (result.Read())
                    {

                        GenericDOFactoryADO<User> userFactory = new GenericDOFactoryADO<User>();

                        var resultUser = userFactory.Make(result);

                        return resultUser;

                    }

                }
            }

            return null;

        }

        public async Task<int> InsertOne(User element)
        {

            //ATTENTION: DATABASE NAME DIFFERS

            String sql = "INSERT INTO operator (name, email, password) VALUES (@name, @email, @password)";

            int result = 0;

            using (var conn = PgDbConnection.getConnection()) {

                await using (var command = conn.CreateCommand()) {

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("name", element.name);
                    command.Parameters.AddWithValue("email", element.email);
                    command.Parameters.AddWithValue("password", element.password);


                    result = await command.ExecuteNonQueryAsync();

                    //return result;

                
                }

            }

            return result;
        }
    }
}
