using CSD.Util.Mappers;
using CSD.WikiSearchApp.Data.DAL;
using CSD.WikiSearchApp.Data.Repositories.Entities;
using CSD.WikiSearchApp.Geonames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CSD.Data.DatabaseUtil;

using RepoGeoname = CSD.WikiSearchApp.Data.Repositories.Entities.Geoname;
using WikiGeoname = CSD.WikiSearchApp.Geonames.Geoname;

namespace CSD.WikiSearchApp.Data.Services
{
    public class WikiSearchAppService
    {
        private readonly WikiSearchAppDataHelper m_wikiSearchAppDataHelper;
        private readonly IMapper m_mapper;
        private readonly WikiSearchClient m_wikiSearchClient;

        private async Task<WikiSearchDTO> findWikiSearchByQCallbackAsync(string q)
        {            
            WikiSearchDTO wikiSearchDTO;

            if (!await m_wikiSearchAppDataHelper.ExistsByIdAsync(q))
            {
                var wikiGeos = await m_wikiSearchClient.FindGeonames(q);

                if (!wikiGeos.Any())
                    return new WikiSearchDTO();

                wikiSearchDTO = wikiGeos.Select(g => m_mapper.Map<WikiSearchDTO, WikiGeoname>(g)).FirstOrDefault();
                var wikiSearch = new WikiSearch() { Q = q, SearchTime = DateTime.Now };

                wikiSearch.Geonames = wikiGeos.Select(g => m_mapper.Map<RepoGeoname, WikiGeoname>(g)).ToList();

                await m_wikiSearchAppDataHelper.SaveWikiSearchAsync(wikiSearch);
            }
            else
            {
                var wikiSearch = await m_wikiSearchAppDataHelper.FindWikiSearchByQAsync(q);
                wikiSearchDTO = wikiSearch.Geonames.Select(g => m_mapper.Map<WikiSearchDTO, RepoGeoname>(g)).FirstOrDefault();
            }

            return wikiSearchDTO;
        }

        public WikiSearchAppService(WikiSearchAppDataHelper wikiSearchAppDataHelper, IMapper mapper, WikiSearchClient wikiSearchClient)
        {
            m_wikiSearchAppDataHelper = wikiSearchAppDataHelper;
            m_mapper = mapper;
            m_wikiSearchClient = wikiSearchClient;
        }

        public Task<WikiSearchDTO> FindWikiSearchByQAsync(string q)
        {
            return SubscribeServiceAsync(() => findWikiSearchByQCallbackAsync(q), "WikiSearchAppService.FindWikiSearchByQAsync");
        }
    }
}
