using CSD.PostalCodeApp.Data.Repositories;
using CSD.PostalCodeApp.Data.Repositories.Entities;
using System;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

namespace CSD.PostalCodeApp.Data.DAL
{
    public class PostalCodeAppDataHelper
    {
        private readonly IPostalCodeRepository m_postalCodeRepository;

        public PostalCodeAppDataHelper(IPostalCodeRepository postalCodeRepository)
        {
            m_postalCodeRepository = postalCodeRepository;
        }

        public Task<PostalCodeInfo> FindPostalCodeByQAsync(string q, int maxRows)
        {
            return SubscribeRepositoryAsync(() => m_postalCodeRepository.FindByQAsync(q, maxRows), "PostalCodeAppDataHelper.FindPostalCodeByQ");
        }

        public Task<PostalCodeInfo> SavePostalCodeAsync(PostalCodeInfo postalCode)
        { 
            return SubscribeRepositoryAsync(() => m_postalCodeRepository.SaveAsync(postalCode), "PostalCodeAppDataHelper.SavePostalCodeAsync");
        }

        public Task<bool> ExistsByIdAsync(string q)
        {            
            return SubscribeRepositoryAsync(() => m_postalCodeRepository.ExistsByQAsync(q), "PostalCodeAppDataHelper.ExistsByIdAsync");
        }

        //...
    }
}
