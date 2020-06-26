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
using System.Net;
using System.IO;
using System.Linq;

namespace BoltTest.DAL.WebCrawlers.SEPages
{
    internal class GoogleWebCrawler : BaseSEPageWebCrawler, ISEPageWebCrawler
    {
        private const string BaseUrl = "https://www.google.com/search";

        public GoogleWebCrawler(IHtmlWebHelper htmlWeb, ILoggerFactory loggerFactory) : base(ESearchEngine.Google, htmlWeb, loggerFactory) { }

        protected override async Task<CrawlingResult> CrawleInnerAsync(CrawlingRequest request) 
        {
            string url = string.Format("{0}?q={1}", BaseUrl, request.QueryWord);

            var httpRequest = createHttpRequest(url);

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            var streamResponse = httpResponse.GetResponseStream();
            var streamRead = new StreamReader(streamResponse);
            var htmlString = await streamRead.ReadToEndAsync();

            var document = new HtmlDocument();
            document.LoadHtml(htmlString);
            
            var htmlNodes = document.DocumentNode.CssSelect(".g h3").ToArray();

            var result = new CrawlingResult();
            for (int i = 0; i < request.Take; i++)
            {
                var htmlNode = htmlNodes[i];
                var item = new SearchResultItem();
                item.SearchEngine = ESearchEngine.Google;
                item.Title = htmlNode.InnerText;
                result.SearchResults.Add(item);
            }

            return result;
        }

        private HttpWebRequest createHttpRequest(string url) 
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";


            return httpRequest;
        }
    }
}
