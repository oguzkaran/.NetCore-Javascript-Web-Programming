using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.TodoApplicationRestApp.Entities
{
    public partial class TodoInfo : IEntity<int>
    {
        public TodoInfo()
        {
            ItemInfos = new HashSet<ItemInfo>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Completed { get; set; }

        public virtual ICollection<ItemInfo> ItemInfos { get; set; }
    }
}
