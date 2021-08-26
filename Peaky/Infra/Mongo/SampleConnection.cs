using MongoDB.Driver;
using Peaky.Infra.Mongo.Maps;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo
{
    public class SampleConnection
    {
        private IMongoCollection<Horse> _horses;
        public SampleConnection()
        {

            HorseMongoMap.Map();

            string conn = "";
            var client = new MongoClient(conn);

            _horses = client.GetDatabase("").GetCollection<Horse>("");

            
        }

        public List<Horse> Get() {

            return _horses.Find(horse => true).ToList();

        }

        /*public Horse InsertOne(Horse horse) {

            this._horses.InsertOne(horse);

            return horse;
        
        }*/
    }
}
