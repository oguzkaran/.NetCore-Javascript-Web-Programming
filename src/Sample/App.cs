/*---------------------------------------------------------------------------------------------------------------------
    Lambda ifadeleri içerisinde kendisinden önce bildirilen yerel ve parametre değişkenleri doğrudan kullanılabilir (capture)
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace CSD
{    
    class App
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> result = new List<int>();
            List<int> evens = new List<int>();

            Console.Write("Bir sayı giriniz:");
            int a = int.Parse(Console.ReadLine());

            Algorithm.Transform(numbers, result, val => val * a);            
            Algorithm.ForEach(result, val => Console.Write("{0} ", val));
            Console.WriteLine();
            Algorithm.Filter(numbers, evens, val => val % 2 == 0);
            Algorithm.ForEach(evens, val => Console.Write("{0} ", val));
            Console.WriteLine();
        }
    }    

    static class Algorithm 
    {
        public static int Filter<T>(List<T> src, List<T> dest, Func<T, bool> pred)
        {
            int count = 0;

            foreach (var t in src)
                if (pred(t))
                {
                    ++count;
                    dest.Add(t);
                }

            return count;
        }
        public static void Transform<T>(List<T> src, List<T> dest, Func<T, T> func)
        {
            foreach (var t in src)
                dest.Add(func(t));
        }

        public static void ForEach<T>(List<T> list, Action<T> action)
        {
            foreach (var t in list)
                action(t);
        }
    }    
}
