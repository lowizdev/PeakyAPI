using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Infra.Mongo.Maps
{

    public class MySampleSerializer : SerializerBase<int> //<T>
    {
        public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            int value = int.Parse(context.Reader.ReadString());
            return value;
        }

        /*public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            context.Writer.WriteInt32(value);
        }*/

    }
    public class MySampleSerializerRevenge : IBsonSerializer//<T>
    {
        /*public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            int value = int.Parse(context.Reader.ReadString());
            return value;
        }*/

        /*public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            context.Writer.WriteInt32(value);
        }*/
        public Type ValueType => typeof(int);//=> throw new NotImplementedException();

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            //STRING TO INT
            int value = int.Parse(context.Reader.ReadString());
            return value;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            //INT TO STRING
            //throw new NotImplementedException();
            string serializedValue = value.ToString();
            context.Writer.WriteString(serializedValue);
        }
    }

    public class HorseMongoMap
    {
        public static void Map() {

            BsonClassMap.RegisterClassMap<Horse>(map => 
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.id);
                map.MapMember(x => x.age).SetSerializer(new MySampleSerializerRevenge());

            
            });
        
        }
    }
}
