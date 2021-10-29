using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Enttities
{
    public class Car
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public string Make { get; set;  }

        public string Model { get; set; }

        public int Year { get; set; }

        public DateTime TrafficDate { get; set; }
    }
}
