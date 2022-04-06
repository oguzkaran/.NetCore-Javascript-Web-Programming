using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.PostalCodeApp.Data.Repositories.Entities
{
    public partial class Geoname
    {
        public long Id { get; set; }
        public int? SearchId { get; set; }
        public string AdminCode2 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public float? Lng { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string AdminName1 { get; set; }
        public string Iso31662 { get; set; }
        public string PlaceName { get; set; }
        public float? Lat { get; set; }
        public string PostalCodeUrl { get; set; }

        public virtual PostalCodeInfo Search { get; set; }
    }
}
