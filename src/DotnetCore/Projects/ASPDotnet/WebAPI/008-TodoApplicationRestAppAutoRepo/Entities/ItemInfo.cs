using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.TodoApplicationRestApp.Entities
{
    public partial class ItemInfo
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Completed { get; set; }

        public virtual TodoInfo Todo { get; set; }
    }
}
