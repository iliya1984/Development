using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.Base;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp.Extensions;
using BoltTest.Entities.Searches;
using BoltTest.Entities.Enums.Searches;

namespace BoltTest.DAL.WebCrawlers.SEPages
{
    internal class GoogleWebCrawler : BaseWebCrawler, ISEPageWebCrawler
    {
        private const string BaseUrl = "https://www.google.com/search";

        public GoogleWebCrawler(IHtmlWebHelper htmlWeb, ILoggerFactory loggerFactory) : base(htmlWeb, loggerFactory) { }

        public async Task<CrawlingResult> CrawleAsync(CrawlingRequest request) 
        {
            try
            {
                string url = string.Format("{0}?q={1}", BaseUrl,  request.QueryWord);
                var document = await HtmlWeb.LoadFromWebAsync(url);

                var htmlNodes = document.DocumentNode.CssSelect("#search .g h3, #search .g h2");

                var result = new CrawlingResult();
                foreach (var htmlNode in htmlNodes) 
                {
                    var item = new SearchResultItem();
                    item.SearchEngine = ESearchEngine.Google;
                    item.Title = htmlNode.InnerText;
                    result.SearchResults.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new CrawlingResult();
            }
        }

    }
}
