using BoltTest.BLL.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.SEPages;
using BoltTest.Entities.Requests;
using BoltTest.Entities.Responses;
using BoltTest.Entities.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.BLL.Services
{
    internal class SearchService : ISearchService
    {
        private IEnumerable<ISEPageWebCrawler> _crawlers;
        private ISearchRepository _repository;
        private ILoggingService _logger;

        public SearchService(SearchServiceToolkit toolkit) 
        {
            _crawlers = toolkit.Crawlers;
            _repository = toolkit.Repository;
            _logger = toolkit.LoggerFactory.GetLoggerForType<SearchService>();
        }

        public async Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            try
            {
                var enteredDate = DateTime.Now;
                string error = string.Empty;
                var response = new SearchResponse();
                response.QueryWord = request.QueryWord;

                foreach (var crawler in _crawlers) 
                {
                    var crawlingRequest = buildCrawlingRequest(request);
                    var crawlingResult = await crawler.CrawleAsync(crawlingRequest);

                    if (crawlingResult == null) 
                    {
                        error = string.Format("Error occurred while crawling {0} search engine.", crawler.SearchEngine);
                        _logger.Error(error);
                        return SearchResponse.FromError(error);
                    }

                    var results = new List<SearchResultItem>();
                    foreach(var item in crawlingResult.SearchResults) 
                    {
                        item.EnteredDate = enteredDate;
                        var resultItem = await _repository.CreateAsync(item);
                        if(resultItem == null) 
                        {
                            error = "Error occurred while saving search result item in DB";
                            _logger.Error(error);
                        }
                        else 
                        {
                            results.Add(resultItem);
                        }
                    }

                    response.Results.AddRange(results);
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return SearchResponse.FromException(ex);
            }
        }

        private CrawlingRequest buildCrawlingRequest(SearchRequest request) 
        {
            var crawlingRequest = new CrawlingRequest();
            crawlingRequest.QueryWord = request.QueryWord;

            //TODO: read from configuration
            crawlingRequest.Take = 5;
            return crawlingRequest;
        }
    }
}
