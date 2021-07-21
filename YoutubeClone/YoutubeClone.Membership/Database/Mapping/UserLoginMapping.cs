using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using YoutubeClone.Membership.Entities;

namespace  YoutubeClone.IdentityMapping 
{
    public class UserLoginMapping : ClassMapping<UserLogin>
    {
        public UserLoginMapping() {
            Schema("dbo");
            Table("AspNetUserLogins");
            ComposedId(id => {
                id.Property(e => e.LoginProvider, prop => {
                    prop.Column("LoginProvider");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
                id.Property(e => e.ProviderKey, prop => {
                    prop.Column("ProviderKey");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
            });
            Property(e => e.ProviderDisplayName, prop => {
                prop.Column("ProviderDisplayName");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
            });
            Property(e => e.UserId, prop => {
                prop.Column("UserId");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
            });
        }
    }
}
