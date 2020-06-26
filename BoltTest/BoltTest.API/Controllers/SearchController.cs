using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoltTest.BLL.Interfaces;
using BoltTest.Core.Interfaces;
using BoltTest.Entities.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BoltTest.API.Controllers
{
    [ApiController]
    public class SearchController : BaseController
    {
        private ILoggingService _logger;
        private ISearchService _searchService;

        public SearchController(ISearchService searchService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLoggerForType<SearchController>();
            _searchService = searchService;
        }

        [HttpGet]
        [Route("api/search")]
        public async Task<IActionResult> SearchAsync(string queryWord) 
        {
            try
            {
                var request = createRequest(queryWord);
                var response = await _searchService.SearchAsync(request);

                if (response.HasErrors)
                {
                    return Error(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return Exception(ex);
            }
        }

        private SearchRequest createRequest(string queryWord) 
        {
            var request = new SearchRequest();
            request.QueryWord = queryWord;
            return request;
        }
    }
}
