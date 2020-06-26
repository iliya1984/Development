using BoltTest.Client.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.Entities.Responses;
using BoltTest.WebApp.Interfaces;
using BoltTest.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.WebApp.Managers
{
    internal class SearchManager : ISearchMananger
    {
        private ISearchClient _searchClient;
        private ILoggingService _logger;

        public SearchManager(ISearchClient searchClient, ILoggerFactory loggerFactory) 
        {
            _searchClient = searchClient;
            _logger = loggerFactory.GetLoggerForType<SearchManager>();
        }

        public async Task<SearchResultViewModel> SearchAsync(string queryWord)
        {
            try
            {
                var response = await _searchClient.SearchAsync(queryWord);

                if (response.HasErrors) 
                {
                    _logger.Error(string.Format("Error occurred: search action for query word '{0}' failed", queryWord));
                    return errorViewModel();
                }

                return createViewModel(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return errorViewModel();
            }
        }

        private SearchResultViewModel errorViewModel() 
        {
            return new SearchResultViewModel { IsError = true };
        }

        private SearchResultViewModel createViewModel(SearchResponse response) 
        {
            var model = new SearchResultViewModel();
            model.QueryWord = response.QueryWord;

            foreach(var item in response.Results) 
            {
                var itemViewModel = new SearchResultItemViewModel();
                itemViewModel.Id = item.Id;
                itemViewModel.Text = item.Title;

                model.Items.Add(itemViewModel);
            }

            return model;
        }
    }
}
