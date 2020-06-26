using Autofac;
using BoltTest.Client.DI;
using BoltTest.Core.DI;
using BoltTest.WebApp.Interfaces;
using BoltTest.WebApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.WebApp.DI
{
    public class WebAppDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreDIModule>();
            builder.RegisterModule<ClientDIModule>();

            builder
                .RegisterType<SearchManager>()
                .As<ISearchMananger>();
        }
    }
}
