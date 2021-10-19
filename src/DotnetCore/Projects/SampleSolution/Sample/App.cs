/*---------------------------------------------------------------------------------------------------------------------
    Aşağıdaki örnekte FindByRandomAsync metodunu yazan programcı sizce GetRandomNumbersAsync metodunda yapılana
    benzer bir iş mi yapmıştır? 
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            Controller controller = new();

            controller.DoWorkAsync();

            Console.WriteLine("main ends!..");
            Console.ReadKey();
        }
    }

    class Controller {
        public async void DoWorkAsync()
        {
            var list = await RandomGeneratorRepository.FindByRandomAsync(new Random(), 10, 0, 99);

            foreach (var val in list)
                Console.Write($"{val} ");
        }
    }

    class RandomGeneratorRepository
    {
        public static async Task<IEnumerable<int>> FindByRandomAsync(Random r, int n, int min, int max)
        {
            return await RandomNumberGenerator.GetRandomNumbersAsync(r, n, min, max);
        }
    }

    class RandomNumberGenerator {        
        public static List<int> GetRandomNumbers(Random r, int n, int min, int max)
        {
            var numbers = new List<int>();

            for (int i = 0; i < n; ++i) {
                var val = r.Next(min, max + 1);

                numbers.Add(val);
                Console.Write($"{val} ");
                Thread.Sleep(1000);
            }

            Console.WriteLine();

            return numbers;
        }

        public static Task<List<int>> GetRandomNumbersAsync(Random r, int n, int min, int max)
        {
            Task.Run(() => { });
            var task = new Task<List<int>>(()=> GetRandomNumbers(r, n, min, max));

            task.Start();

            return task;
        }
    }    
}