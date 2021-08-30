using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Peaky.Infra.Mongo.Serializers;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo.Maps
{

    /*public class MySampleSerializer : SerializerBase<int> //<T>
    {
        public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            int value = int.Parse(context.Reader.ReadString());
            return value;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            context.Writer.WriteInt32(value);
        }

    }*/
    

    public class HorseMongoMap
    {
        public static void Map() {

            BsonClassMap.RegisterClassMap<Horse>(map => 
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                //map.MapIdMember(x => x.id);
                map.UnmapMember(x => x.id);
                map.MapMember(x => x.age).SetSerializer(new IntToStringFieldSerializer());

            
            });
        
        }
    }
}
