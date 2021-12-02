using CSD.WikiSearchApp.Data.Repositories.Contexts;
using CSD.WikiSearchApp.Data.Repositories.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;

namespace CSD.WikiSearchApp.Data.Repositories
{
    public class WikiSearchRepository : IWikiSearchRepository
    {
        private readonly WikiSearchAppDbContext m_wikiSearchAppDbContext;

        private IEnumerable<WikiSearch> findByQCallback(string q)
        {
            return m_wikiSearchAppDbContext.WikiSearches.Where(ws => ws.Q == q);
        }

        private WikiSearch savecallback(WikiSearch wikiSearch)
        {
            m_wikiSearchAppDbContext.WikiSearches.Add(wikiSearch);
            m_wikiSearchAppDbContext.SaveChanges();

            return wikiSearch;
        }

        public WikiSearchRepository(WikiSearchAppDbContext wikiSearchAppDbContext)
        {
            m_wikiSearchAppDbContext = wikiSearchAppDbContext;
        }

        public Task<IEnumerable<WikiSearch>> FindByQAsync(string q)
        {
            return Create(() => findByQCallback(q));            
        }

        public Task<WikiSearch> SaveAsync(WikiSearch wikiSearch)
        {
            return Create(() => savecallback(wikiSearch));
        }
    }
}
