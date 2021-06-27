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

                //var temp = prop.Name;
                //Console.WriteLine(temp);
                prop.SetValue(element, reader[prop.Name], null);
            
            }

            return element;
        
        }

    }
}
