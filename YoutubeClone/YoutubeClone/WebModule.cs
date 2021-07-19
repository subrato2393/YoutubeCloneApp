using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeClone
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<TestServices>().As<ITestServices>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
