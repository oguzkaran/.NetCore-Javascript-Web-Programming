/*---------------------------------------------------------------------------------------------------------------------
    System.Timers.Timer sınıfı
----------------------------------------------------------------------------------------------------------------------*/
using System;

using System.Timers;

namespace CSD
{
    class App
    {
        public static void Main(string[] args)
        {
            var str = "Bugün  ,hava çok .güzel";

            foreach (var s in str.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                Console.WriteLine($"({s})");
        }        
    }    
}
