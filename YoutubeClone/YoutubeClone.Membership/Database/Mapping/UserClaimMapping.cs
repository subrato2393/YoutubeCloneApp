using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping 
{
    public class UserClaimMapping : ClassMap<UserClaim> 
    {
        public UserClaimMapping() 
        {
            Id(x => x.Id);
            Map(x => x.ClaimType);
            Map(x => x.ClaimValue);
            Map(x => x.UserId);
            Table("AspNetUserClaims");
        }
    }
}
