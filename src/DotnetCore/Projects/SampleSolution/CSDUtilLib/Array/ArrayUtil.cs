using System;
using System.Linq;

using static System.Linq.Enumerable;

namespace CSD.Util.Array
{
    public static class ArrayUtil
    {
        public static int [] FillRandomArray(this int[] a, Random r, int min, int max)
        {
            for (var i = 0; i < a.Length; ++i)
                a[i] = r.Next(min, max + 1);

            return a;
        }

        public static int[] GetRandomArray(Random r, int n, int min, int max)
        {
            return Range(0, n).Select(i => r.Next(min, max + 1)).ToArray();
        }

        public static double[] GetRandomArray(Random r, int n, double min, double max)
        {
            return Range(0, n).Select(i => r.NextDouble() * (max - min) + min).ToArray();
        }


        public static double[] FillRandomArray(this double[] a, Random r, double min, double max)
        {
            for (var i = 0; i < a.Length; ++i)
                a[i] = r.NextDouble() * (max - min) + min;

            return a;
        }        

        public static void Display<T>(this T[] a, string sep = " ", string end = "\n")
        {
            a.ToList().ForEach(t => Console.Write($"{t}{sep}"));
            Console.Write(end);
        }
        
    }
}
