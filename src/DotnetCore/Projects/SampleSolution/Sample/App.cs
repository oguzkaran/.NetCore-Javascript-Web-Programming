/*---------------------------------------------------------------------------------------------------------------------
    Yukarıdaki örneklerin sorgu sentaksı yapılışı
----------------------------------------------------------------------------------------------------------------------*/
using CSD.Application.Factories;
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
                if (args.Length != 4)
                {
                    Console.WriteLine("Wrong number of arguments");
                    Environment.Exit(1);
                }
                var month= int.Parse(args[1]);
                var year = int.Parse(args[2]);
                var minCost = long.Parse(args[3]);
                var movieFactory = new MovieFactory(args[0]);

                var query = from m in movieFactory.Movies
                            where m.VisionDate.Month == month && m.VisionDate.Year == year && m.Cost >= minCost
                            orderby m.VisionDate
                            select m;                            
                    
                query.ToList().ForEach(m => Console.WriteLine($"{m.Name}, {m.VisionDate}, {m.Cost}"));

                Console.WriteLine("--------------------------------------------------------------------------");
                query = from m in movieFactory.Movies
                        where m.VisionDate.Month == month && m.VisionDate.Year == year && m.Cost >= minCost
                        orderby m.VisionDate descending
                        select m;

                query.ToList().ForEach(m => Console.WriteLine($"{m.Name}, {m.VisionDate}, {m.Cost}"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
