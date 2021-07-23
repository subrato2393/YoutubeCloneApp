using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class UserLoginMapping : ClassMap<UserLogin>
    {
        public UserLoginMapping()
        {
            CompositeId()
            .KeyProperty(x => x.LoginProvider)
            .KeyProperty(x => x.ProviderKey);
            Map(x => x.ProviderDisplayName);
            Map(x => x.UserId);
            Table("AspNetUserLogins");
        }
    }
}
