/*---------------------------------------------------------------------------------------------------------------------
    Yukarıdaki problem async belirleyicisi ve await operatörü ile daha kolay bir biçimde yazılabilir
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            Console.WriteLine("main starts");
            Sample.FooAsync();
            Console.WriteLine("main ends");
            Console.ReadKey();
        }
    }

    class Sample {
        public static async void FooAsync()
        {
            var task = new Task<int>(MyTaskUtil.MyTaskProc);

            task.Start();            

            Console.WriteLine($"Sum:{await task}"); // Burada çağıran için metot sonlanır. await'ten sonraki kısım başka bir thread'de devam eder
        }
    }

    class MyTaskUtil {
        public static int MyTaskProc()
        {
            Random r = new();
            int sum = 0;

            for (int i = 0; i < 5; ++i) {
                int val = r.Next(100);

                Thread.Sleep(500);
                sum += val;
            }

            return sum;
        }
    }
}