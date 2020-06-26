using BoltTest.Spa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.Spa.Interfaces
{
    public interface ISearchMananger
    {
        Task<SearchResultViewModel> SearchAsync(string queryWord);
    }
}
