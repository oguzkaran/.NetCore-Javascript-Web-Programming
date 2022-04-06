using CSD.Util.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.PostalCodeApp.Data.DAL;
using CSD.PostalCodeApp.Geonames;
using static CSD.Data.DatabaseUtil;
using CSD.PostalCodeApp.Data.Repositories.Entities;

using RepoGeoname = CSD.PostalCodeApp.Data.Repositories.Entities.Geoname;
using PostalCodeGeoname = CSD.PostalCodeApp.Geonames.Geoname;


namespace CSD.PostalCodeApp.Data.Services
{
    public class PostalCodeAppService
    {
        private readonly PostalCodeAppDataHelper m_postalCodeAppDataHelper;
        private readonly IMapper m_mapper;
        private readonly PostalCodeClient m_postalCodeClient;

        private async Task<IEnumerable<PostalCodeDTO>> findPostalCodeByQCallbackAsync(string q, int maxRows)
        {            
            IEnumerable<PostalCodeDTO> postalCodeDTO;            

            if (!await m_postalCodeAppDataHelper.ExistsByIdAsync(q))
            {
                var postalGeos = await m_postalCodeClient.FindGeonames(q);
                
                if (postalGeos.Count() == 0)
                    return new List<PostalCodeDTO>();

                postalCodeDTO = postalGeos.Select(g => m_mapper.Map<PostalCodeDTO, PostalCodeGeoname>(g)).Take(maxRows);
                var postalCode = new Repositories.Entities.PostalCodeInfo() { PostalCode = int.Parse(q), SearchTime = DateTime.Now };

                postalCode.Geonames = postalGeos.Select(g => m_mapper.Map<RepoGeoname, PostalCodeGeoname>(g)).ToList();

                await m_postalCodeAppDataHelper.SavePostalCodeAsync(postalCode);
            }
            else
            {
                var postalCode = await m_postalCodeAppDataHelper.FindPostalCodeByQAsync(q, maxRows);
                
                postalCodeDTO = postalCode.Geonames.Select(g => m_mapper.Map<PostalCodeDTO, RepoGeoname>(g)).Take(maxRows);
            }

            return postalCodeDTO;
        }

        public PostalCodeAppService(PostalCodeAppDataHelper postalCodeAppDataHelper, IMapper mapper, PostalCodeClient postalCodeClient)
        {
            m_postalCodeAppDataHelper = postalCodeAppDataHelper;
            m_mapper = mapper;
            m_postalCodeClient = postalCodeClient;
        }

        public Task<IEnumerable<PostalCodeDTO>> FindPostalCodeByQAsync(string q, int maxRows = 10)
        {
            return SubscribeServiceAsync(() => findPostalCodeByQCallbackAsync(q, maxRows), "PostalCodeAppService.FindPostalCodeByQAsync");
        }
    }
}
