using Npgsql;
using Peaky.Factories;
using Peaky.Models;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.PgSQL
{
    public class RaceRepository : IRaceRepository
    {
        //TODO: REFACTOR TO DAPPER BUT KEEP THIS IMPLEMENTATION
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Race>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Race> GetOneById(int id)
        {
            String sql = "SELECT * FROM race WHERE id = @id";

            NpgsqlDataReader result = null;

            using (var conn = PgDbConnection.getConnection()) {

                await using (var command = conn.CreateCommand()){

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("id", id);

                    result = await command.ExecuteReaderAsync();

                    if (result.Read()) {

                        GenericDOFactoryADO<Race> raceFactory = new GenericDOFactoryADO<Race>();
                        var resultRace = raceFactory.Make(result);

                        return resultRace;

                    }

                }

            }


            return null;
        }

        public async Task<int> InsertOne(Race element)
        {

            String sql = "INSERT INTO race ( race_date, description ) VALUES ( @race_date, @description )";

            int result = 0;

            using (var conn = PgDbConnection.getConnection()) {

                await using (var command = conn.CreateCommand()) {

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("race_date", element.race_date);
                    command.Parameters.AddWithValue("description", element.description);

                    result = await command.ExecuteNonQueryAsync();
                }

            }

            return result;
        }

        public async Task<Race> AddHorse(Race race, Horse horse) { //TODO: REFACTOR

            String sql = "INSERT INTO racehorse (race_id, horse_id) VALUES (@race_id, @horse_id)";

            int result = 0;

            using (var conn = PgDbConnection.getConnection()) {

                await using (var command = conn.CreateCommand()) {

                    await conn.OpenAsync();

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("race_id", race.id);
                    command.Parameters.AddWithValue("horse_id", horse.id);

                    result = command.ExecuteNonQuery();

                }

            }


            return race;

        }

        public async Task<int> GetHorseQuantity(Race race) {


            String sql = @"SELECT COUNT(*) AS horsesinrace FROM race AS r INNER JOIN racehorse AS rh ON r.id = rh.race_id
                WHERE r.id = @id";

            int result = 0;

            using (var conn = PgDbConnection.getConnection()) {


                await using (var command = conn.CreateCommand()) {

                    await conn.OpenAsync();

                    command.CommandText = sql;

                    command.Parameters.AddWithValue("id", race.id);

                    var dataReader = await command.ExecuteReaderAsync();

                    if (dataReader.Read()) {

                        result = int.Parse(dataReader["horsesinrace"].ToString());

                        Console.WriteLine(result);

                    }

                }

            }

            return result;

        }
    }
}
