using System.Collections.Generic;

namespace CSD.PostalCodeApp.Geonames
{
    public class PostalCodeInfo
    {
        public IList<Geoname> PostalCodes { get; set; }
    }

    
    public class Geoname
    {
        public string AdminCode2 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public double Lng { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode_ { get; set; }
        public string AdminName1 { get; set; }
        public string ISO31662 { get; set; }
        public string PlaceName { get; set; }
        public double Lat { get; set; }
        public string PostalCodeUrl { get; set; }
    }
}

