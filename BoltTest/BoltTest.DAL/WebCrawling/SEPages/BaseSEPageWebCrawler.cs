using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.Base;
using BoltTest.DAL.WebCrawlers.SEPages;
using BoltTest.Entities.Enums.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.DAL.WebCrawling.SEPages
{
    internal abstract class BaseSEPageWebCrawler : BaseWebCrawler, ISEPageWebCrawler
    {
        public ESearchEngine SearchEngine { get; private set; }

        public BaseSEPageWebCrawler(ESearchEngine searchEngine, IHtmlWebHelper htmlWeb, ILoggerFactory loggerFactory) : base(htmlWeb, loggerFactory)
        {
            SearchEngine = searchEngine;
        }

        public async Task<CrawlingResult> CrawleAsync(CrawlingRequest request) 
        {
            try
            {
                if (false == ValidateRequest(request)) 
                {
                    return null;
                }

                return await CrawleInnerAsync(request);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        protected abstract Task<CrawlingResult> CrawleInnerAsync(CrawlingRequest request);

        protected virtual bool ValidateRequest(CrawlingRequest request) 
        {
            string errorPrefix = "Invalid search engine page web crawling request.";

            if (request == null)
            {
                Logger.Error(string.Format("{0} Request is NULL", errorPrefix));
                return false;
            }
            if (string.IsNullOrEmpty(request.QueryWord)) 
            {
                Logger.Error(string.Format("{0} Query word is NULL or EMPTY", errorPrefix));
                return false;
            }
            if (request.Take < 1)
            {
                Logger.Error(string.Format("{0} Ivalid take argument value {1}.", errorPrefix, request.Take));
                return false;
            }

            return true;
        }
    }
}
