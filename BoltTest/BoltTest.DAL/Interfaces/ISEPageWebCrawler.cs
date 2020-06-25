using BoltTest.DAL.WebCrawlers.SEPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.DAL.Interfaces
{
    /// <summary>
    /// ISEPageWebCrawler stands for Search Engine Page Web Crawler
    /// </summary>
    public interface ISEPageWebCrawler
    {
        Task<CrawlingResult> CrawleAsync(CrawlingRequest request);
    }
}
