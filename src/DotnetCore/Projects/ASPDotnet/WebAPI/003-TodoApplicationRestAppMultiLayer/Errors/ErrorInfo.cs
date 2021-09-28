using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Errors
{
    public class ErrorInfo
    {
        public string Message { get; set; }

        public int Status { get; set; }
        public string Detail { get; set; }
        public object Data { get; set; }
    }
}
