using System;

namespace CSD.TodoApplicationRestApp.DTO
{
    public class TodoInfoDTO
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Completed { get; set; }
    }
}
