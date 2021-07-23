using Autofac;
using YoutubeClone.Membership.Seed;

namespace YoutubeClone.Membership
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserDataSeed>().As<IUserDataSeed>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
