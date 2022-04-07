using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.PostalCodeSearchApp.Data.Repositories.Entities
{
    public partial class PostalCode
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

        public virtual PostalCodeSearch PostalCodeSearch { get; set; }
    }
}
