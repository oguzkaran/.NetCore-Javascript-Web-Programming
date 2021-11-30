using CSD.WikiSearchApp.Geonames;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WikiSearchGeoNUnitTest
{
    [TestFixture]
    [Author("Muhammed Oğur")]
    class WikiSearchGeoTest
    {
        private WikiSearch m_wikiSearch;

        [SetUp]
        public void SetUp()
        {
            m_wikiSearch = new WikiSearch(new HttpClient());
        }

        [Test]
        [TestCase("ankara", 10)]
        [TestCase("istanbul", 20)]
        [TestCase("cccccccc", null)]
        public async Task TestMaxRowsTest(string q, int expected)
        {
            var data = await m_wikiSearch.FindGeonames(q, expected);
            
            Assert.AreEqual(expected, data.ToList().Count);            
        }
    }
}
