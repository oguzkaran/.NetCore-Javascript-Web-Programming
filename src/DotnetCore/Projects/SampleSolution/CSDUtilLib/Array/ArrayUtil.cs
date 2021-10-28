using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.Util.Array
{
    public static class ArrayUtil
    {
        public static int [] FillRandomArray(this int[] a, Random r, int n, int min, int max)
        {
            for (var i = 0; i < a.Length; ++i)
                a[i] = r.Next(min, max + 1);

            return a;
        }

        public static int[] GetRandomArray(Random r, int n, int min, int max)
        {
            var a = new int[n];

            return a.FillRandomArray(r, n, min, max);
        }

        public static void Display(this int[] a)
        {
            foreach (var val in a)
                Console.Write($"{val} ");

            Console.WriteLine();
        }
    }
}
