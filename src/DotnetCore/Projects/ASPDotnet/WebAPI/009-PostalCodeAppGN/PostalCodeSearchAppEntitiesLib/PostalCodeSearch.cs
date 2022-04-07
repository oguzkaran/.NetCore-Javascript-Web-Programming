using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.PostalCodeSearchApp.Data.Repositories.Entities
{
    public partial class PostalCodeSearch
    {
        public PostalCodeSearch()
        {
            PostalCodes = new HashSet<PostalCode>();
        }

        public int Id { get; set; }
        public string Q { get; set; }
        public DateTime SearchTime { get; set; }

        public virtual ICollection<PostalCode> PostalCodes { get; set; }
    }
}
