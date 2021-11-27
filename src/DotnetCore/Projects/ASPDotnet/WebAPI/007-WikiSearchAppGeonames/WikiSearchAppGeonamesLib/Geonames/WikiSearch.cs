using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using static System.String;

namespace CSD.WikiSearchApp.Geonames
{
    public class WikiSearch
    {
        private readonly HttpClient m_httpClient;

        public WikiSearch(HttpClient httpClient)
        {
            m_httpClient = httpClient;
        }

        public async Task<IEnumerable<Geoname>> FindGeonames(string q, int maxRows = 10)
        {
            var response = await m_httpClient.GetAsync(Format(Global.WikiUrlTemplate, q, maxRows));

            return JsonConvert.DeserializeObject<WikiSearchInfo>(await response.Content.ReadAsStringAsync()).Geonames;            
        }
    }
}
