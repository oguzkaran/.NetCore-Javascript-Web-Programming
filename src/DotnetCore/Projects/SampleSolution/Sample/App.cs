/*---------------------------------------------------------------------------------------------------------------------
    Soru: Döngü kullanmadan ve Eratosten kalburunu da kullanmadan parametresi ile aldığı bir sayının asal olup
    olmadığını test eden IsPrime metodunu yazınız
----------------------------------------------------------------------------------------------------------------------*/
using CSD.Util.Number;
using System;
using System.Linq;

namespace CSD
{
    class App
    {
        public static void Main(string[] args)
        {
            int n = 10;

            Console.WriteLine(Enumerable.Range(1, n).Sum());
        }
    }
}

