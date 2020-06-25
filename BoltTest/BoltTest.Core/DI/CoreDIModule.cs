using Autofac;
using BoltTest.Core.Enums;
using BoltTest.Core.Helpers;
using BoltTest.Core.Interfaces;
using BoltTest.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.DI
{
    public class CoreDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HtmlWebHelper>()
                .As<IHtmlWebHelper>();

            builder
                .Register(c =>
                {
                    Func<ELoggingTechnology, Type, ILoggingService> factoryMethod = (technology, type) =>
                    {
                        switch (technology)
                        {
                            case ELoggingTechnology.NLog:
                                return new NLogLoggingService(type);
                            default:
                                throw new ArgumentException();
                        }
                    };

                    return new LoggerFactory(factoryMethod);
                })
                .As<ILoggerFactory>();
        }
    }
}
