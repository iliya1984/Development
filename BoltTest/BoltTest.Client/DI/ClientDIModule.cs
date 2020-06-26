using Autofac;
using BoltTest.Client.Interfaces;
using BoltTest.Core.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Client.DI
{
    public class ClientDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoreDIModule>();
            
            builder
                .RegisterType<SearchClient>()
                .As<ISearchClient>();
        }
    }
}
