using BoltTest.Entities.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Entities.Responses
{
    public class SearchResponse : BaseResponse
    {
        public string QueryWord { get; set; }
        public List<SearchResultItem> Results { get; set; }

        public SearchResponse()
        {
            Results = new List<SearchResultItem>();
        }
    }
}
