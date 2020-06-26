using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BoltTest.Core.Interfaces;
using BoltTest.Spa.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ILoggerFactory = BoltTest.Core.Interfaces.ILoggerFactory;

namespace BoltTest.Spa.Controllers
{
    public class SearchController : Controller
    {
        private ILoggingService _logger;
        private ISearchMananger _searchMananger;

        public SearchController(ISearchMananger searchMananger, ILoggerFactory loggerFactory) 
        {
            _searchMananger = searchMananger;
            _logger = loggerFactory.GetLoggerForType<SearchController>();
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchAsync(string queryWord)
        {
            try
            {
                var model = await _searchMananger.SearchAsync(queryWord);
                if (model.IsError) 
                {
                    return new StatusCodeResult(500);
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new StatusCodeResult(500);
            }

        }
    }
}
