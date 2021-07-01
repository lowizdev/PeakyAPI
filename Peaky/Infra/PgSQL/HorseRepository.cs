using Npgsql;
using Peaky.Models.Interfaces;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peaky.Factories;

namespace Peaky.Infra.PgSQL
{
    public class HorseRepository: IHorseRepository
    {

        public async Task<List<Horse>> GetAll()
        {
            //TODO: PAGINATE
            String sql = "SELECT * FROM horse";

            NpgsqlDataReader result;

            using (var conn = PgDbConnection.getConnection())
            {

                await conn.OpenAsync();

                await using (var command = conn.CreateCommand())
                {

                    command.CommandText = sql;

                    result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {

                        GenericDOFactoryADO<Horse> horseFactory = new GenericDOFactoryADO<Horse>();
                        List<Horse> resultList = new List<Horse>();

                        while (result.Read()) {

                            Horse currentHorse = horseFactory.Make(result);

                            resultList.Add(currentHorse);
                        }

                        return resultList;

                    }

                }

            }

            return null;

        }

        public async Task<Horse> GetOneById(int id)
        {

            String sql = "SELECT * FROM horse WHERE id = @id";

            NpgsqlDataReader result;

            using (var conn = PgDbConnection.getConnection()) {

                await conn.OpenAsync();

                await using ( var command = conn.CreateCommand()){

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("id", id);

                    result = await command.ExecuteReaderAsync();

                    if (result.Read())
                    {

                        //var aaa = result["name"];
                        //Console.WriteLine(result);

                        /*var bbb = new Horse();
                        var ccc = bbb.GetType().GetProperties()[0].Name;*/



                        GenericDOFactoryADO<Horse> horseFactory = new GenericDOFactoryADO<Horse>();
                        var horseResult = horseFactory.Make(result);

                        //Console.WriteLine(lookatmyhorse);

                        return horseResult; //new Horse();

                    }
                    

                }

            }

            return null;
            
        }

        public async Task<int> InsertOne(Horse element)
        {
            //throw new NotImplementedException();

            String sql = "INSERT INTO Horse (name, age) VALUES (@name, @age)";

            int result = 0;

            using (var conn = PgDbConnection.getConnection()) 
            {

                await using (var command = conn.CreateCommand()) {

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("name", element.name);
                    command.Parameters.AddWithValue("age", element.age);

                    await conn.OpenAsync();

                    result = await command.ExecuteNonQueryAsync();
                }

                

            }

            return result;

        }

        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

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
