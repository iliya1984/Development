using BoltTest.Core.Interfaces;
using HtmlAgilityPack;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.Core.Helpers
{
    internal class HtmlWebHelper
    {
        private HtmlWeb _htmlWeb;
        private ILoggingService _logger;

        public HtmlWebHelper(ILoggerFactory loggerFactory) 
        {
            _logger = loggerFactory.GetLoggerForType<HtmlWebHelper>();
            _htmlWeb = new HtmlWeb();
        }

        public async Task<HtmlDocument> LoadFromWebAsync(string url) 
        {
            try
            {
                return await _htmlWeb.LoadFromWebAsync(url);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
