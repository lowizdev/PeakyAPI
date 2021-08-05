using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Peaky.Factories
{
    public class MapDOFactory<T> where T : new() //USE GENERIC NOT FOR CONSTRUCTION BUT FOR RETURN
    {

        

        public T Make(DbDataReader reader, IDictionary<string, string> propertiesObjectDatabase) {

            T element = new T();
            Type elementType = element.GetType();
            //PropertyInfo[] elementProperties = element.GetType().GetProperties().ToDictionary();

            foreach (KeyValuePair<string, string> propertyObjectDatabase in propertiesObjectDatabase) 
            {

                // PropertyInfo currentProperty = elementProperties[propertyObjectDatabase.Key];
                PropertyInfo currentProperty = elementType.GetProperty(propertyObjectDatabase.Key);

                currentProperty.SetValue(element, reader[propertyObjectDatabase.Value]);


            }

            return element;

        }

    }
}
