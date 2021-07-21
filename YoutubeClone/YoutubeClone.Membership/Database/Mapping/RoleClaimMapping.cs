using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping 
{
    public class RoleClaimMapping : ClassMapping<RoleClaim> 
    {
        public RoleClaimMapping() {
            Schema("dbo");
            Table("AspNetRoleClaims");
            Id(e => e.Id, id => {
                id.Column("Id");
                id.Type(NHibernateUtil.Int32);
                id.Generator(Generators.Identity);
            });
            Property(e => e.ClaimType, prop => {
                prop.Column("ClaimType");
                prop.Type(NHibernateUtil.String);
                prop.Length(1024);
                prop.NotNullable(true);
            });
            Property(e => e.ClaimValue, prop => {
                prop.Column("ClaimValue");
                prop.Type(NHibernateUtil.String);
                prop.Length(1024);
                prop.NotNullable(true);
            });
            Property(e => e.RoleId, prop => {
                prop.Column("RoleId");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
            });
        }
    }
}
