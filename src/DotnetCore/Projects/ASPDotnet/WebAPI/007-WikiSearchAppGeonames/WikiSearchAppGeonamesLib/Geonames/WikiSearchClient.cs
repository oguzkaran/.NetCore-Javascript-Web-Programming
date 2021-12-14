using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using static System.String;
using System;

namespace CSD.WikiSearchApp.Geonames
{
    public class WikiSearchClient
    {
        private readonly HttpClient m_httpClient = new HttpClient();

        //public WikiSearchClient(HttpClient httpClient)
        //{
        //    m_httpClient = httpClient;
        //}

        public async Task<IEnumerable<Geoname>> FindGeonames(string q, int maxRows = 10)
        {
            var response = await m_httpClient.GetAsync(Format(Global.WikiUrlTemplate, q, maxRows));

            Console.WriteLine(response == null);
            var result = JsonConvert.DeserializeObject<WikiSearchInfo>(await response.Content.ReadAsStringAsync()).Geonames;            

            Console.WriteLine(result == null);
            return result;
        }
    }
}
