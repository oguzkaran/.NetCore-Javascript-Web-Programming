using System;

namespace CSD.TodoApplicationRestApp.Entities
{
    public class TodoInfoItem
    {        
        public string Title { get; set; }
        public string Description { get; set; }        
        public DateTime CreateDateTime { get; set; }
        public string Text { get; set; }
        public DateTime LastUpdate { get; set; }    
    }
}
