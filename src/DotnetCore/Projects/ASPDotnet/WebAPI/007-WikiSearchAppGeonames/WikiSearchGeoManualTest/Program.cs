using CSD.WikiSearchApp.Geonames;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace WikiSearchGeoManualTest
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var httpClient = new HttpClient();
                var search = new WikiSearch(httpClient);
                var data = await search.FindGeonames("ankara", 20);

                data.ToList().ForEach(d => Console.WriteLine($"{d.GeoNameId}"));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
