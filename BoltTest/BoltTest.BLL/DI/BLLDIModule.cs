﻿using Autofac;
using BoltTest.BLL.Interfaces;
using BoltTest.BLL.Services;
using BoltTest.Core.DI;
using BoltTest.Core.Interfaces;
using BoltTest.DAL.DI;
using BoltTest.DAL.Interfaces;
using BoltTest.Entities.Enums.Searches;
using Microsoft.Extensions.Caching.Memory;
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

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            builder.RegisterInstance<IMemoryCache>(memoryCache);

            builder
                .Register(c =>
                {
                    var toolkit = new SearchServiceToolkit();
                    toolkit.LoggerFactory = c.Resolve<ILoggerFactory>();
                    toolkit.Repository = c.Resolve<ISearchRepository>();

                    var crawlers = new List<ISEPageWebCrawler>();

                    var bingCrawler = c.ResolveKeyed<ISEPageWebCrawler>(ESearchEngine.Bing);
                    crawlers.Add(bingCrawler);
                    var googleCrawler = c.ResolveKeyed<ISEPageWebCrawler>(ESearchEngine.Google);
                    crawlers.Add(googleCrawler);

                    toolkit.Crawlers = crawlers;

                    toolkit.MemoryCache = c.Resolve<IMemoryCache>();

                    return new SearchService(toolkit);
                })
                .As<ISearchService>();
        }
    }
}
