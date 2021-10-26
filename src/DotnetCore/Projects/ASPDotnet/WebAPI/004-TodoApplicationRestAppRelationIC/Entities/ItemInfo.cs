using System;

namespace CSD.TodoApplicationRestApp.Entities
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Text { get; set; }        
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Completed { get; set; }
    }
}
