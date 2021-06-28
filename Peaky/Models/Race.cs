using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models
{
    public class Race
    {

        public int id { get; set; }
        public DateTime race_date { get; set; }
        public string description { get; set; }
        public int? winner_id { get; set; }

    }
}
