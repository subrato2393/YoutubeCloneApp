using Autofac;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Membership.Database.Contexts;

namespace YoutubeClone.Membership
{
    public class MembershipModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => IdentityContext.OpenSession()).As<ISession>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
