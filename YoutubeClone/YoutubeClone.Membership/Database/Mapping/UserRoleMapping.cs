using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class UserRoleMapping : ClassMapping<UserRole>
    {
        public UserRoleMapping() {
            Schema("dbo");
            Table("AspNetUserRoles");
            ComposedId(id => {
                id.Property(e => e.UserId, prop => {
                    prop.Column("UserId");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
                id.Property(e => e.RoleId, prop => {
                    prop.Column("RoleId");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
            });
        }
    }
}
