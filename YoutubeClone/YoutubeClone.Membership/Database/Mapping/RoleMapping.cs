using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class RoleMapping : ClassMap<Role> 
    {           
        public RoleMapping() 
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.NormalizedName);
            Map(x => x.ConcurrencyStamp);
            Table("AspNetRoles");
        }
    }
}
