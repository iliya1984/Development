using BoltTest.Entities.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.DAL.Interfaces
{
    public interface ISearchRepository
    {
        Task<SearchResultItem> CreateAsync(SearchResultItem item);
    }
}
