using CSD.WikiSearchApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.WikiSearchApp.Data.Services
{
    public class WikiSearchAppService
    {
        private readonly WikiSearchAppDataHelper m_wikiSearchAppDataHelper;

        public WikiSearchAppService(WikiSearchAppDataHelper wikiSearchAppDataHelper)
        {
            m_wikiSearchAppDataHelper = wikiSearchAppDataHelper;
        }


        public Task<IEnumerable<WikiSearchDTO>> FindWikiSearchByQ(string q)
        {
            throw new NotImplementedException();
        }
    }
}
