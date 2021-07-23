using FluentNHibernate.Mapping;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class UserRoleMapping : ClassMap<UserRole>
    {
        public UserRoleMapping()
        {
            CompositeId()
           .KeyProperty(x => x.UserId)
           .KeyProperty(x => x.RoleId);
            Table("AspNetUserRoles");
        }
    }
}
