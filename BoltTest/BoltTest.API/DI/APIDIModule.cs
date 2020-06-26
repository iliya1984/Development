using Autofac;
using BoltTest.BLL.DI;
using BoltTest.Core.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.API.DI
{
    public class APIDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreDIModule>();
            builder.RegisterModule<BLLDIModule>();
        }
    }
}
