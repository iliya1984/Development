using BoltTest.Entities.Requests;
using BoltTest.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.BLL.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResponse> SearchAsync(SearchRequest request);
    }
}
