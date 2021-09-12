/*---------------------------------------------------------------------------------------------------------------------
    CSDArrayList sınıfı ve dolaşılması
----------------------------------------------------------------------------------------------------------------------*/
using System;
using CSD.Util.Collections;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            CSDList<int> list = new ();

            for (int i = 0; i < 10; ++i)
                list.Add(i * 10);

            foreach (var val in list)
                Console.Write($"{val} ");

            Console.WriteLine();
        }
    }    
}

