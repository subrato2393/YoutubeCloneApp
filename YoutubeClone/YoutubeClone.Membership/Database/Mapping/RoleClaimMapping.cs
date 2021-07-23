using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping 
{
    public class RoleClaimMapping : ClassMap<RoleClaim> 
    {
        public RoleClaimMapping()
        {
            Id(x => x.Id);
            Map(x => x.RoleId);
            Map(x => x.ClaimType);
            Map(x => x.ClaimValue);
            Table("AspNetRoleClaims");
        }
    }
}
