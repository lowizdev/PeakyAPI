using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Peaky.Factories
{
    public class GenericDOFactoryADO<T> where T: new()
    {

        public T Make(DbDataReader reader)
        { 

            //NEVER DO THIS KIND OF THING TO PRODUCTION

            T element = new T();
            
            foreach (PropertyInfo prop in element.GetType().GetProperties()) {

                /*var temp = prop.GetType();
                var temp2 = reader[prop.Name].GetType();
                Console.WriteLine(temp2);*/

                if (reader[prop.Name].GetType().Name.ToString() != "DBNull") //NULL DOESNT MATCH WELL, SO LEAVE IT ALONE FOR NOW
                {

                    prop.SetValue(element, reader[prop.Name], null);
                }
            
            }

            return element;
        
        }

    }
}
