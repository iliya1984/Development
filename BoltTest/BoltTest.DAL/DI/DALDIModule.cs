using Autofac;
using BoltTest.Core.DI;
using BoltTest.DAL.Interfaces;
using BoltTest.DAL.WebCrawlers.SEPages;
using BoltTest.Entities.Enums.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.DAL.DI
{
    public class DALDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreDIModule>();

            builder
                .RegisterType<GoogleWebCrawler>()
                .Keyed<ISEPageWebCrawler>(ESearchEngine.Google);


        }
    }
}
