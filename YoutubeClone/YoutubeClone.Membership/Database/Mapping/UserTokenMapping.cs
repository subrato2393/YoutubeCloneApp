using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class UserTokenMapping : ClassMapping<UserToken> 
    {
        public UserTokenMapping() {
            Schema("dbo");
            Table("AspNetUserTokens");
            ComposedId(id => {
                id.Property(e => e.UserId, prop => {
                    prop.Column("UserId");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
                id.Property(e => e.LoginProvider, prop => {
                    prop.Column("LoginProvider");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
                id.Property(e => e.Name, prop => {
                    prop.Column("Name");
                    prop.Type(NHibernateUtil.String);
                    prop.Length(32);
                });
            });
            Property(e => e.Value, prop => {
                prop.Column("Value");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);
            });
        }
    }
}
