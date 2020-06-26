using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.DAL.DBObjects
{
    public class DbSearchResultItem
    {
        public long Pkid { get; set; }
        public string Title { get; set; }
        public byte SearchEngineId { get; set; }
        public string SearchEngine { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}
