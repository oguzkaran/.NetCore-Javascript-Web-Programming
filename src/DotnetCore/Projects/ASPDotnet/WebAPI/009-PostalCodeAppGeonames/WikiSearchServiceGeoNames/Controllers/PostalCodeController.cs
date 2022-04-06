

using CSD.PostalCodeApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static CSD.Util.Error.ExceptionUtil;

namespace CSD.PostalCodeApp.Controllers
{
    [Route("api/[controller]")]
    public class PostalCodeController : ControllerBase
    {
        private readonly PostalCodeAppService m_postalCodeAppService;

        public PostalCodeController(PostalCodeAppService postalCodeAppService)
        {
            m_postalCodeAppService = postalCodeAppService;
        }

        
        [HttpGet("code")]
        public async Task<IEnumerable<PostalCodeDTO>> FindPlaceInfo(string code, int maxRows)
        {
            return await m_postalCodeAppService.FindPostalCodeByQAsync(code, maxRows);
        }
    }
}
