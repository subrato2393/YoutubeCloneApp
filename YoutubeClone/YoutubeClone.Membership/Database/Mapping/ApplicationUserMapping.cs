using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping 
{
    public class ApplicationUserMapping : ClassMap<ApplicationUser>
    {
        public ApplicationUserMapping() 
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.NormalizedUserName);
            Map(x => x.Email);
            Map(x => x.NormalizedEmail);
            Map(x => x.EmailConfirmed);
            Map(x => x.PasswordHash);
            Map(x => x.SecurityStamp);
            Map(x => x.ConcurrencyStamp);
            Map(x => x.PhoneNumber);
            Map(x => x.TwoFactorEnabled);
            Map(x => x.LockoutEnd);
            Map(x => x.LockoutEnabled);
            Map(x => x.AccessFailedCount);
            Table("AspNetUsers");
        }
    }
}
