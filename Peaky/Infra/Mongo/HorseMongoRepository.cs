using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo
{
    public class HorseMongoRepository : IMongoRepository<Horse>
    {
        private readonly IConfiguration _configuration;
        private IMongoCollection<Horse> _collection;
        private string _collectionName = "horses";

        public HorseMongoRepository(IConfiguration configuration)
        {
            this._configuration = configuration;

            MongoClient client = new MongoClient(configuration["Mongo:ConnectionString"]);

            this._collection = client.GetDatabase(configuration["Mongo:DatabaseName"])
                .GetCollection<Horse>(this._collectionName);
        }
        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Horse>> GetAll()
        {
            return this._collection.Find<Horse>(horse => true).ToListAsync();
        }

        public Task<Horse> GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOne(Horse element)
        {
            throw new NotImplementedException();
        }
    }
}
