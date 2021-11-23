/*---------------------------------------------------------------------------------------------------------------------
    HttpClient sınıfının GetAsync metodu
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Linq;

namespace CSD
{
    class App
    {
        public static async Task Main(string[] args)
        {
            try
            {                
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("http://161.97.141.113:50500/api/Director/all");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();

                    var list = JsonConvert.DeserializeObject<List<DirectorInfo>>(content);

                    list.ForEach(di => Console.WriteLine(di));

                    Console.WriteLine("--------------------------------");
                    list.ForEach(di => Console.WriteLine(JsonConvert.SerializeObject(di)));
                }
                else
                    Console.WriteLine("Fail");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class DirectorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString() => $"[{Id}]{Name}-{BirthDate.ToShortDateString()}";
        
    }
}
