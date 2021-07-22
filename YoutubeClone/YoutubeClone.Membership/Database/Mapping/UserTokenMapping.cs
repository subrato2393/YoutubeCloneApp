using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class UserTokenMapping : ClassMap<UserToken> 
    {
        public UserTokenMapping()
        {
            CompositeId()
           .KeyProperty(x => x.LoginProvider)
           .KeyProperty(x => x.UserId)
           .KeyProperty(x => x.Name);
            Map(x => x.Value);
            Table("AspNetUserTokens");
        }
    }
}
