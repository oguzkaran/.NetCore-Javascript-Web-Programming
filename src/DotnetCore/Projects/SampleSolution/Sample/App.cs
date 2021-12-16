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
            var timer = new Timer();

            timer.Interval = 1000;
            timer.Elapsed += (_, _) => Console.Write(".");
            timer.Enabled = true;


            Console.ReadKey(true);                   
        }
    }    
}
