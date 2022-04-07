using CSD.PostalCodeSearchApp.Data;
using CSD.PostalCodeSearchApp.Data.Repositories;
using CSD.PostalCodeSearchApp.Data.Repositories.Entities;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

namespace CSD.PostalCodeSearchApp.Data.DAL
{
    public class PostalCodeSearchAppDataHelper
    {
        private readonly IPostalCodeSearchRepository m_postalCodeSearchRepository;

        public PostalCodeSearchAppDataHelper(IPostalCodeSearchRepository postalCodeSearchRepository)
        {
            m_postalCodeSearchRepository = postalCodeSearchRepository;
        }

        public Task<PostalCodeSearch> FindPostalCodeSearchByQAsync(string q, int maxRows)
        {
            return SubscribeRepositoryAsync(() => m_postalCodeSearchRepository.FindByQAsync(q, maxRows), "PostalCodeSearchAppDataHelper.FindPostalCodeSearchByQ");
        }

        public Task<PostalCodeSearch> SavePostalCodeSearchAsync(PostalCodeSearch postalCodeSearch)
        {
            return SubscribeRepositoryAsync(() => m_postalCodeSearchRepository.SaveAsync(postalCodeSearch), "PostalCodeSearchAppDataHelper.SavePostalCodeSearchAsync");
        }

        public Task<bool> ExistsByIdAsync(string q)
        {
            return SubscribeRepositoryAsync(() => m_postalCodeSearchRepository.ExistsByQAsync(q), "PostalCodeSearchAppDataHelper.ExistsByIdAsync");
        }

        //...
    }
}
