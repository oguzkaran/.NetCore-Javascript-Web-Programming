using CSD.Util.Mappers.Mapster;
using CSD.WikiSearchApp.Geonames;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using WGeoname = CSD.WikiSearchApp.Geonames.Geoname;
using EGeoname = CSD.WikiSearchApp.Data.Repositories.Entities.Geoname;
using CSD.WikiSearchApp.Data.DAL;
using CSD.WikiSearchApp.Data.Repositories.Contexts;
using CSD.WikiSearchApp.Data.Repositories;
using CSD.WikiSearchApp.Data.Repositories.Entities;

namespace WikiSearchGeoNUnitTest
{
    [TestFixture]
    [Author("Muhammed Oğur")]
    class Test_SaveWikiSearchAsync
    {
        private WikiSearchClient m_wikiSearch;
        private WikiSearchAppDataHelper m_wikiSearchAppDataHelper;
        private Mapper m_mapper = new();
        

        [SetUp]
        public void SetUp()
        {
            //m_wikiSearch = new WikiSearchClient(new HttpClient());
            m_wikiSearchAppDataHelper = new WikiSearchAppDataHelper(new WikiSearchRepository(new WikiSearchAppDbContext()));
        }

        [Test]
        [TestCase("ankara", 10)]
        [TestCase("istanbul", 20)]
        [TestCase("izmir", 10)]
        public async Task Test(string q, int expected)
        {
            var data = await m_wikiSearch.FindGeonames(q, expected);

            var geonames = data.Select(g => m_mapper.Map<EGeoname, WGeoname>(g)).ToList();
            var wikiSearch = new WikiSearch() { Q = q, Geonames = geonames };

            await m_wikiSearchAppDataHelper.SaveWikiSearchAsync(wikiSearch);            
        }       
    }
}
