using CSD.WikiSearchApp.Data.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.WikiSearchApp.Data.Repositories
{
    public interface IWikiSearchRepository
    {
        Task<WikiSearch> SaveAsync(WikiSearch wikiSearch);
        Task<WikiSearch> FindByQAsync(string q);
        Task<bool> ExistsByQAsync(string q);
    }
}
