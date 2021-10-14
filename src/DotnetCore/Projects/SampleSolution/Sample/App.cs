/*---------------------------------------------------------------------------------------------------------------------
    Task sınıfı
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            var mt = new Sample { Ch = '.', Milliseconds = 1000};
            var t = new Task(() => mt.PrintChar(10));
            
            t.Start();

            Console.WriteLine("Main ends!...");
            Console.ReadKey();
        }
    }

    class Sample {
        public char Ch { get; set; }        
        public int Milliseconds { get; set; }

        public void PrintChar(int n)
        {
            for (int i = 0; i < n; ++i) {
                Console.Write($"{Ch}");
                Thread.Sleep(Milliseconds);
            }
        }
    }
}