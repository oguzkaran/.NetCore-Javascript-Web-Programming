using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp
{
    public class TodoInfo
    {
        public string Title { get; set; }
        public string Text { get; set; }        
        
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
