/*---------------------------------------------------------------------------------------------------------------------
    Aşağıdaki örnekte Complex sınıfının + operatör metoldu olduğunda  Aggregate metodu ile kullanılabilmiştir
----------------------------------------------------------------------------------------------------------------------*/
using Sample.Factories;
using System;
using System.Linq;

namespace CSD
{
    class App
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Wrong number of arguments");
                    Environment.Exit(1);
                }

                var count = int.Parse(args[0]);
                var min = double.Parse(args[1]);
                var max = double.Parse(args[2]);

                var factory = new ComplexFactory(new Random());

                var numbers = factory.GetRandomNumberAsArray(count, min, max);
                var list = numbers.ToList();

                list .ForEach(z => Console.WriteLine(z));
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Sum:{list.Aggregate((r, z) => r + z)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid age threshold value");
            }
            catch (InvalidOperationException) {
                Console.WriteLine("No number generated");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex.GetType().Name}, Message:{ex.Message}");
            }
        }
    }
}
