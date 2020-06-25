using Autofac;
using BoltTest.BLL.Interfaces;
using BoltTest.BLL.Services;
using BoltTest.Core.DI;
using BoltTest.Core.Interfaces;
using BoltTest.DAL.DI;
using BoltTest.DAL.Interfaces;
using BoltTest.Entities.Enums.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.BLL.DI
{
    public class BLLDIModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreDIModule>();
            builder.RegisterModule<DALDIModule>();

            builder
                .Register(c =>
                {
                    var toolkit = new SearchServiceToolkit();
                    toolkit.LoggerFactory = c.Resolve<ILoggerFactory>();
                    toolkit.Repository = c.Resolve<ISearchRepository>();

                    var crawlers = new List<ISEPageWebCrawler>();

                    var googleCrawler = c.ResolveKeyed<ISEPageWebCrawler>(ESearchEngine.Google);
                    crawlers.Add(googleCrawler);

                    toolkit.Crawlers = crawlers;

                    return new SearchService(toolkit);
                })
                .As<ISearchService>();
        }
    }
}
