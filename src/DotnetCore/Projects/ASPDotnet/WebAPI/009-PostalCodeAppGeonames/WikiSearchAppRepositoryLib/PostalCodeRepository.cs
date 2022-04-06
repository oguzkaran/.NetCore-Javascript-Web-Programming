

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;
using Microsoft.EntityFrameworkCore;
using System;
using CSD.PostalCodeApp.Data.Repositories.Entities;
using CSD.PostalCodeApp.Data.Repositories.Context;

namespace CSD.PostalCodeApp.Data.Repositories
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly PostalCodeAppDbContext m_postalCodeAppDbContext;

        private bool existsByQ(string q)
        {
            return m_postalCodeAppDbContext.PostalCodes.Any(w => w.PostalCode == int.Parse(q));               
        }

        private PostalCodeInfo findByQCallback(string q, int maxRows)
        {            
            return m_postalCodeAppDbContext.PostalCodes
                .Include(w => w.Geonames)
                .Where(ws => ws.PostalCode == int.Parse(q))                
                .FirstOrDefault();
        }

        private PostalCodeInfo savecallback(PostalCodeInfo postalCode)
        {
            m_postalCodeAppDbContext.PostalCodes.Add(postalCode);
            m_postalCodeAppDbContext.SaveChanges();

            return postalCode;
        }

        public PostalCodeRepository(PostalCodeAppDbContext wikiSearchAppDbContext)
        {            
            m_postalCodeAppDbContext = wikiSearchAppDbContext;
        }

        public Task<PostalCodeInfo> FindByQAsync(string q, int maxRows)
        {
            return Create(() => findByQCallback(q, maxRows));            
        }

        public Task<PostalCodeInfo> SaveAsync(PostalCodeInfo postalCode)
        {
            return Create(() => savecallback(postalCode));
        }

        public Task<bool> ExistsByQAsync(string q)
        {
            return Create(() => existsByQ(q));
        }

    }
}
