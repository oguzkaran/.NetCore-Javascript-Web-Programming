using System;

namespace CSD.TodoApplicationRestApp.Entities
{
    public class TodoInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Completed { get; set; }
    }
}
