using Autofac;
using BoltTest.Client.DI;
using BoltTest.Core.DI;
using BoltTest.Spa.Interfaces;
using BoltTest.Spa.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.Spa.DI
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
