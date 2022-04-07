using CSD.PostalCodeSearchApp.Data.Repositories.Context;
using CSD.PostalCodeSearchApp.Data.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;



namespace CSD.PostalCodeSearchApp.Data.Repositories
{
    public class PostalCodeSearchRepository : IPostalCodeSearchRepository
    {
        private readonly PostalCodeSearchAppDbContext m_postalCodeSearchAppDbContext;

        private bool existsByQ(string q)
        {
            return m_postalCodeSearchAppDbContext.PostalCodeSearches.Any(w => w.Q == q);
        }

        private PostalCodeSearch findByQCallback(string q, int maxRows)
        {
            return m_postalCodeSearchAppDbContext.PostalCodeSearches
                .Include(p => p.PostalCodes)
                .Where(ps => ps.Q == q)
                .FirstOrDefault();
        }

        private PostalCodeSearch savecallback(PostalCodeSearch postalCodeSearch)
        {
            m_postalCodeSearchAppDbContext.PostalCodeSearches.Add(postalCodeSearch);
            m_postalCodeSearchAppDbContext.SaveChanges();

            return postalCodeSearch;
        }

        public PostalCodeSearchRepository(PostalCodeSearchAppDbContext postalCodeSearchAppDbContext)
        {
            m_postalCodeSearchAppDbContext = postalCodeSearchAppDbContext;
        }

        public Task<PostalCodeSearch> FindByQAsync(string q, int maxRows)
        {
            return Create(() => findByQCallback(q, maxRows));
        }

        public Task<PostalCodeSearch> SaveAsync(PostalCodeSearch postalCodeSearch)
        {
            return Create(() => savecallback(postalCodeSearch));
        }

        public Task<bool> ExistsByQAsync(string q)
        {
            return Create(() => existsByQ(q));
        }

        

        Task<PostalCodeSearch> IPostalCodeSearchRepository.FindByQAsync(string q, int maxRows)
        {
            throw new NotImplementedException();
        }
    }
}
