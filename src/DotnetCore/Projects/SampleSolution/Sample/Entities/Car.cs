using System;

namespace CSD.Application.Entities
{
    public class Car
    {
        public long Id { get; set; }

        public string Vin { get; set; }

        public string Make { get; set;  }

        public string Model { get; set; }

        public int Year { get; set; }

        public DateTime TrafficDate { get; set; }
    }
}
