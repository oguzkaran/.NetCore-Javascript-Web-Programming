/*---------------------------------------------------------------------------------------------------------------------
    HttpClient sınıfının GetStringAsync metodu
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace CSD
{
    class App
    {
        public static async Task Main(string[] args)
        {
            try
            {                
                var httpClient = new HttpClient();
                var stream = await httpClient.GetStreamAsync("http://161.97.141.113:50500/api/Director/all");

                var sr = new StreamReader(stream);

                Console.WriteLine(await sr.ReadToEndAsync());                
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
