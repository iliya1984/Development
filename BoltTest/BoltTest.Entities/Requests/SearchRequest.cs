using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Entities.Requests
{
    public class SearchRequest : BaseRequest
    {
        public string QueryWord { get; set; }
    }
}
