using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping 
{
    public class ApplicationUserMapping : ClassMap<ApplicationUser>
    {
        public ApplicationUserMapping() {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.Email);
            Map(x => x.NormalizedUserName);
            Map(x => x.PasswordHash);
            Map(x => x.SecurityStamp);
            Table("AspNetUsers");
        }
    }
}
