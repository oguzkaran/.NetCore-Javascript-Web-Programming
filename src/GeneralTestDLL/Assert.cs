using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.Test.Unit
{
    public class AssertException : Exception {
        public AssertException(string message) : base(message)
        { }        
    }

    public static class Assert
    {
        [Conditional("CSDUNITTEST")]
        public static void Equals(int a, int b)
        {
            if (a != b)
                throw new AssertException("Assertion error: expected:true, result:false");            
        }
    }

    //...
}
