using BoltTest.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.WebApp.Interfaces
{
    public interface ISearchMananger
    {
        Task<SearchResultViewModel> SearchAsync(string queryWord);
    }
}
