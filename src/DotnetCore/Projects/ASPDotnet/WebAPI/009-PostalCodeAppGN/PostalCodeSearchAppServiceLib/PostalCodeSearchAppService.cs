using CSD.Util.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static CSD.Data.DatabaseUtil;

using RepoGeoname = CSD.PostalCodeSearchApp.Data.Repositories.Entities.PostalCode;
using PostalGeoname = CSD.PostalCodeSearchApp.Geonames.PostalCode;

using CSD.PostalCodeSearchApp.Data.DAL;
using CSD.PostalCodeSearchApp.Data.Repositories.Entities;
using CSD.PostalCodeSearchApp.Geonames;

namespace CSD.PostalCodeSearchApp.Data.Services
{
    public class PostalCodeSearchAppService
    {
        private readonly PostalCodeSearchAppDataHelper m_postalCodeSearchAppDataHelper;
        private readonly IMapper m_mapper;
        private readonly PostalCodeSearchClient m_postalCodeSearchClient;

        private async Task<IEnumerable<PostalCodeSearchDTO>> findPostalCodeSearchByQCallbackAsync(string q, int maxRows)
        {
            IEnumerable<PostalCodeSearchDTO> postalCodeSearchDTO;

            if (!await m_postalCodeSearchAppDataHelper.ExistsByIdAsync(q))
            {
                var postalGeos = await m_postalCodeSearchClient.FindGeonames(q);

                if (postalGeos.Count() == 0)
                    return new List<PostalCodeSearchDTO>();

                postalCodeSearchDTO = postalGeos.Select(g => m_mapper.Map<PostalCodeSearchDTO, PostalGeoname>(g)).Take(maxRows);
                var postalCodeSearch = new PostalCodeSearch() { Q = q, SearchTime = DateTime.Now };

                postalCodeSearch.PostalCodes = postalGeos.Select(g => m_mapper.Map<RepoGeoname, PostalGeoname>(g)).ToList();

                await m_postalCodeSearchAppDataHelper.SavePostalCodeSearchAsync(postalCodeSearch);
            }
            else
            {
                var postalCodeSearch = await m_postalCodeSearchAppDataHelper.FindPostalCodeSearchByQAsync(q, maxRows);

                postalCodeSearchDTO = postalCodeSearch.PostalCodes.Select(g => m_mapper.Map<PostalCodeSearchDTO, RepoGeoname>(g)).Take(maxRows);
            }

            return postalCodeSearchDTO;
        }

        public PostalCodeSearchAppService(PostalCodeSearchAppDataHelper postalCodeSearchAppDataHelper, IMapper mapper, PostalCodeSearchClient postalCodeSearchClient)
        {
            m_postalCodeSearchAppDataHelper = postalCodeSearchAppDataHelper;
            m_mapper = mapper;
            m_postalCodeSearchClient = postalCodeSearchClient;
        }

        public Task<IEnumerable<PostalCodeSearchDTO>> findPostalCodeSearchByQAsync(string q, int maxRows = 10)
        {
            return SubscribeServiceAsync(() => findPostalCodeSearchByQCallbackAsync(q, maxRows), "PostalCodeSearchAppService.FindPostalCodeSearchByQAsync");
        }
    }
}
