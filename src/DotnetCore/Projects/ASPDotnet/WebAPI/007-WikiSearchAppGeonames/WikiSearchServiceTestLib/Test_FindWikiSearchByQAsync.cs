using CSD.WikiSearchApp.Data.DAL;
using CSD.WikiSearchApp.Data.Repositories;
using CSD.WikiSearchApp.Data.Repositories.Contexts;
using CSD.WikiSearchApp.Data.Services;
using CSD.WikiSearchApp.Geonames;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WikiSearchGeoNUnitTest
{
    [TestFixture]
    [Author("Muhammed Oğur")]
    class Test_FindWikiSearchQAsync
    {        
        private WikiSearchAppService m_wikiSearchAppDataHelper;
        

        [SetUp]
        public void SetUp()
        {
            var mapper = new CSD.Util.Mappers.Mapster.Mapper();
            var httpClient = new WikiSearchClient(new());
            m_wikiSearchAppDataHelper = new WikiSearchAppService(new WikiSearchAppDataHelper(new WikiSearchRepository(new WikiSearchAppDbContext())), mapper, httpClient);
        }

        [Test]
        [TestCase("zonguldak")]
        [TestCase("ankara")]
        [TestCase("istanbul")]
        [TestCase("izmir")]
        public async Task Test(string q)
        {
            await m_wikiSearchAppDataHelper.FindWikiSearchByQAsync(q);
        }       
    }
}
