/*---------------------------------------------------------------------------------------------------------------------
    Aşağıdaki kodu CSD.Util.Collections.dll üreten projedeki CSDList sınıfının allocate metodunda #if kullanımı ile birlikte 
    inceleyiniz
----------------------------------------------------------------------------------------------------------------------*/

using System;
using CSD.Util.Collections;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            CSDList<int> list = new CSDList<int>();

            for (int i = 0; i < 12; ++i)
                list.Add(i * 10);

            Console.WriteLine($"Capacity:{list.Capacity}");
            Console.WriteLine($"Count:{list.Count}");

            int count = list.Count;

            for (int i = 0; i < count; ++i)
                Console.Write($"{list[i]} ");

            Console.WriteLine();

            list.TrimToSize();

            Console.WriteLine($"Capacity:{list.Capacity}");
            Console.WriteLine($"Count:{list.Count}");

            list.Clear();

            Console.WriteLine($"Capacity:{list.Capacity}");
            Console.WriteLine($"Count:{list.Count}");

            list.TrimToSize();

            Console.WriteLine($"Capacity:{list.Capacity}");
            Console.WriteLine($"Count:{list.Count}");

            list.Add(67);

            Console.WriteLine($"Capacity:{list.Capacity}");
            Console.WriteLine($"Count:{list.Count}");
        }
    }    
}

