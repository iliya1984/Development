using BoltTest.BLL.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.SEPages;
using BoltTest.Entities.Requests;
using BoltTest.Entities.Responses;
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

                var response = new SearchResponse();
                response.QueryWord = request.QueryWord;

                foreach (var crawler in _crawlers) 
                {
                    var crawlingRequest = buildCrawlingRequest(request);
                    var crawlingResult = await crawler.CrawleAsync(crawlingRequest);

                    if (crawlingResult == null) 
                    {
                        _logger.Error(string.Format("Error occurred while crawling {0} search engine.", crawler.SearchEngine));
                    }

                    response.Results.AddRange(crawlingResult.SearchResults);
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
