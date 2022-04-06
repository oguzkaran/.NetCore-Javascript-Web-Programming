using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.PostalCodeApp.Data.Repositories.Entities
{
    public partial class PostalCodeInfo
    {
      
        public PostalCodeInfo()
        {
            Geonames = new HashSet<Geoname>();
        }

        public int Id { get; set; }
        public int  PostalCode { get; set; }
        public DateTime SearchTime { get; set; }

        public virtual ICollection<Geoname> Geonames { get; set; }
    }
}
