using CSD.WikiSearchApp.Data.Repositories;

using static CSD.Data.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSD.WikiSearchApp.Data.Repositories.Entities;

namespace CSD.WikiSearchApp.Data.DAL
{
    public class WikiSearchAppDataHelper
    {
        private readonly WikiSearchRepository m_wikiSearchRepository;

        public WikiSearchAppDataHelper(WikiSearchRepository wikiSearchRepository)
        {
            m_wikiSearchRepository = wikiSearchRepository;
        }

        public Task<IEnumerable<WikiSearch>> FindWikiSearchByQAsync(string q)
        {
            return SubscribeRepositoryAsync(() => m_wikiSearchRepository.FindByQAsync(q), "WikiSearchAppDataHelper.FindWikiSearchByQ");
        }

        public Task<WikiSearch> SaveWikiSearchAsync(WikiSearch wikiSearch)
        { 
            return SubscribeRepositoryAsync(() => m_wikiSearchRepository.SaveAsync(wikiSearch), "WikiSearchAppDataHelper.SaveWikiSearchAsync");
        }
    }
}
