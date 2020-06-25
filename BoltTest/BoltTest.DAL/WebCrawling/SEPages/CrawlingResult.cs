using BoltTest.Entities.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.DAL.WebCrawlers.SEPages
{
    public class CrawlingResult
    {
        public List<SearchResultItem> SearchResults { get; set; }

        public CrawlingResult() 
        {
            SearchResults = new List<SearchResultItem>();
        }
    }
}
