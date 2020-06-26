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
using BoltTest.DAL.WebCrawling.SEPages;
using System.Net.Http;

namespace BoltTest.DAL.WebCrawlers.SEPages
{
    internal class BingWebCrawler : BaseSEPageWebCrawler, ISEPageWebCrawler
    {
        private const string BaseUrl = "https://www.bing.com/search";

        public BingWebCrawler(IHtmlWebHelper htmlWeb, ILoggerFactory loggerFactory) : base(ESearchEngine.Bing, htmlWeb, loggerFactory) { }

        protected override async Task<CrawlingResult> CrawleInnerAsync(CrawlingRequest request) 
        {
            CrawlingResult result = null;
            string url = string.Format("{0}?q={1}", BaseUrl, request.QueryWord);

            string resultHtml = null;
            using (var httpClient = new HttpClient()) 
            {
                var response = await httpClient.GetAsync(url);
                resultHtml = await response.Content.ReadAsStringAsync();

                var document = new HtmlDocument();
                document.LoadHtml(resultHtml);
                
                var htmlNodes = document.DocumentNode.CssSelect("#b_results li h2 a");

                result = new CrawlingResult();
                foreach (var htmlNode in htmlNodes)
                {
                    var item = new SearchResultItem();
                    item.SearchEngine = ESearchEngine.Google;
                    item.Title = htmlNode.InnerText;
                    result.SearchResults.Add(item);
                }
            }
            return result;
        }
    }
}
