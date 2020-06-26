using BoltTest.BLL.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.SEPages;
using BoltTest.Entities.Requests;
using BoltTest.Entities.Responses;
using BoltTest.Entities.Searches;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BoltTest.BLL.Services
{
    internal class SearchService : ISearchService
    {
        private IEnumerable<ISEPageWebCrawler> _crawlers;
        private ISearchRepository _repository;
        private ILoggingService _logger;
        private IMemoryCache _cache;

        public SearchService(SearchServiceToolkit toolkit) 
        {
            _crawlers = toolkit.Crawlers;
            _repository = toolkit.Repository;
            _logger = toolkit.LoggerFactory.GetLoggerForType<SearchService>();
            _cache = toolkit.MemoryCache;
        }

        public async Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            try
            {
                List<SearchResultItem> results = null;
                var response = new SearchResponse();

                string key = string.Format("SearchResults_{0}", HttpUtility.UrlEncode(request.QueryWord));
                response.QueryWord = request.QueryWord;

                if (false == _cache.TryGetValue(key, out results))
                {
                    var enteredDate = DateTime.Now;
                    string error = string.Empty;
                    
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

                        results = new List<SearchResultItem>();
                        foreach (var item in crawlingResult.SearchResults)
                        {
                            item.EnteredDate = enteredDate;
                            var resultItem = await _repository.CreateAsync(item);
                            if (resultItem == null)
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

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1));

                    _cache.Set(key, response.Results, cacheEntryOptions);
                }
                else
                {
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
