using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo
{
    public class GenericMongoRepository<T> : IMongoRepository<T>
    {
        private readonly IConfiguration _configuration;
        private string _collectionName = null;

        private IMongoCollection<T> _collection;
        public GenericMongoRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            setCollectionName();

            var client = new MongoClient(configuration["Mongo:ConnectionString"]);
            _collection = client.GetDatabase(configuration["Mongo:DatabaseName"]).GetCollection<T>(this._collectionName);

        }

        public void setCollectionName() {

            switch (typeof(T).Name) {
                case "Horse":
                    this._collectionName = "horses";
                    break;
                case "Race":
                    this._collectionName = "races";
                    break;
                default:
                    this._collectionName = null;
                    break;
            }

        }

        public Task<bool> DeleteOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            return this._collection.Find<T>(x => true).ToListAsync();
        }

        public Task<T> GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertOne(T element)
        {
            this._collection.InsertOneAsync(element);
            return 1;
        }
    }
}
