using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.PostalCodeSearchApp.Data.Services
{
    public class PostalCodeSearchDTO
    {
        public long Id { get; set; }
        public int? PostalCodeSearchId { get; set; }
        public string AdminCode2 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public float? Lng { get; set; }
        public string CountryCode { get; set; }
        public int? PostalCode1 { get; set; }
        public string AdminName1 { get; set; }
        public string Iso31662 { get; set; }
        public string PlaceName { get; set; }
        public float? Lat { get; set; }
        public string PostalCodeUrl { get; set; }
    }
}
