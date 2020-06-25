using BoltTest.Core.Interfaces;
using BoltTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.DAL.WebCrawlers.Base
{
    internal abstract class BaseWebCrawler 
    {
        protected IHtmlWebHelper HtmlWeb { get; private set; }
        protected ILoggingService Logger { get; private set; }

        protected BaseWebCrawler(IHtmlWebHelper htmlWeb, ILoggerFactory loggerFactory) 
        {
            HtmlWeb = htmlWeb;
            Logger = loggerFactory.GetLoggerForType(GetType());
        }
    }
}
