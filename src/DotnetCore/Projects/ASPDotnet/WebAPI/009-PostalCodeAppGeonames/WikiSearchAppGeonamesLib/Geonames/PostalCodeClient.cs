using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.String;

namespace CSD.PostalCodeApp.Geonames
{
    public class PostalCodeClient
    {
        private readonly HttpClient m_httpClient;

        public PostalCodeClient(HttpClient httpClient)
        {
            m_httpClient = httpClient;        
        }

        public async Task<IEnumerable<Geoname>> FindGeonames(string q)
        {
            var response = await m_httpClient.GetStringAsync(Format(Global.GeoUrlTemplate, q, 10));

            var geo = JsonConvert.DeserializeObject<PostalCodeInfo>(response);
            
            var result = geo.PostalCodes;            

            return result;
        }
    }
}
