using Microsoft.AspNetCore.Mvc;
using CSD.PostalCodeSearchApp.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.PostalCodeSearchApp.Controllers
{
    [Route("api/[controller]")]
    public class PostalCodeSearchController : ControllerBase
    {
        private readonly PostalCodeSearchAppService m_postalCodeSearchAppService;

        public PostalCodeSearchController(PostalCodeSearchAppService postalCodeSearchAppService)
        {
            m_postalCodeSearchAppService = postalCodeSearchAppService;
        }


        [HttpGet("postalcode")]
        public async Task<IEnumerable<PostalCodeSearchDTO>> FindPlaceInfo(string q, int maxRows)
        {
            return await m_postalCodeSearchAppService.findPostalCodeSearchByQAsync(q, maxRows);
        }
    }
}
