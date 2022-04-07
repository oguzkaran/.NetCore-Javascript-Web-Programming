using CSD.PostalCodeSearchApp.Data.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.PostalCodeSearchApp.Data.Repositories
{
    public interface IPostalCodeSearchRepository
    {
        Task<PostalCodeSearch> SaveAsync(PostalCodeSearch postalCodeSearch);
        Task<PostalCodeSearch> FindByQAsync(string q, int maxRows);
        Task<bool> ExistsByQAsync(string q);
    }
}
