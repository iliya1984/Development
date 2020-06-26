using BoltTest.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.Client.Interfaces
{
    public interface ISearchClient
    {
        Task<SearchResponse> SearchAsync(string queryWord);
    }
}
