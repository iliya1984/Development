using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.BLL.Services
{
    public class SearchServiceToolkit
    {
        public IEnumerable<ISEPageWebCrawler> Crawlers { get; set; } 
        public ISearchRepository Repository { get; set; } 
        public ILoggerFactory LoggerFactory { get; set; }
    }
}
