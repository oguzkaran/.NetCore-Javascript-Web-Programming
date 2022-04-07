using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.String;

namespace CSD.PostalCodeSearchApp.Geonames
{
    public class PostalCodeSearchClient
    {
        private readonly HttpClient m_httpClient;

        public PostalCodeSearchClient(HttpClient httpClient)
        {
            m_httpClient = httpClient;        
        }

        public async Task<IEnumerable<PostalCode>> FindGeonames(string q)
        {
            var response = await m_httpClient.GetStringAsync(Format(Global.GeoUrlTemplate, q, 10));

            var geo = JsonConvert.DeserializeObject<PostalCodeSearchInfo>(response);
            
            var result = geo.PostalCodes;

            return result;
        }
    }
}
