/*---------------------------------------------------------------------------------------------------------------------
    Aşağıdaki örnekte [min, max] aralığındaki veriler elde edilmiştir
----------------------------------------------------------------------------------------------------------------------*/
using CSD.Util.Array;
using System;
using System.Linq;

namespace CSD
{
    class App
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            ArrayUtil.GetRandomArray(random, 10, 0.45, 99.89).ToArray().Display(sep: "\n", end: "");
            ArrayUtil.GetRandomArray(random, 10, 0, 99).ToArray().Display();
        }
    }
}
