using CSD.WikiSearchApp.Data.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.WikiSearchApp.Data.Repositories
{
    public interface IWikiSearchRepository
    {
        Task<WikiSearch> SaveAsync(WikiSearch wikiSearch);
        Task<IEnumerable<WikiSearch>> FindByQAsync(string q);
    }
}
