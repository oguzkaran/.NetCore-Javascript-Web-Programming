using CSD.WikiSearchApp.Data.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.WikiSearchApp.Data.Repositories
{
    public interface IWikiSearchRepository
    {
        Task<WikiSearch> Save(WikiSearch wikiSearch);
        Task<IEnumerable<WikiSearch>> FindByQ(string q);
    }
}
