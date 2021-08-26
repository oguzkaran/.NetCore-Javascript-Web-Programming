/*---------------------------------------------------------------------------------------------------------------------
    Yerel metotların yerel değişkenleri yakalamsı
----------------------------------------------------------------------------------------------------------------------*/
using System;

namespace CSD
{    
    class App
    {
        public static void Main()
        {
            Console.Write("Bir sayı giriniz:");
            int count = Convert.ToInt32(Console.ReadLine());

            Sample.Foo(count);                        
        }
    }

    class Sample {
        [Obsolete]
        public static void Foo(int count)
        {
            var random = new Random();

            for (int i = 0; i < count; ++i) {
                var val = random.Next(100);

                bool isEven() => val % 2 == 0;        

                Console.WriteLine("{0}:{1}", val, isEven() ? "Çift" : "Tek");
            }
        }
    }
}


