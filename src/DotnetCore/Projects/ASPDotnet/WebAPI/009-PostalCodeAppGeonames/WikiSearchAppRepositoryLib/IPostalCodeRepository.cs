using CSD.PostalCodeApp.Data.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.PostalCodeApp.Data.Repositories
{
    public interface IPostalCodeRepository
    {
        Task<PostalCodeInfo> SaveAsync(PostalCodeInfo postalCode);
        Task<PostalCodeInfo> FindByQAsync(string q, int maxRows);
        Task<bool> ExistsByQAsync(string q);
    }
}
