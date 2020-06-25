using BoltTest.Entities.Enums.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Entities.Searches
{
    public class SearchResultItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public ESearchEngine SearchEngine { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}
