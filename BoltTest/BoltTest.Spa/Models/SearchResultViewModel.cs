using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.Spa.Models
{
    public class SearchResultViewModel
    {
        public bool IsError { get; set; }
        public string QueryWord { get; set; }
        public List<SearchResultItemViewModel> Items { get; set; }

        public SearchResultViewModel() 
        {
            Items = new List<SearchResultItemViewModel>();
        }
    }
}
