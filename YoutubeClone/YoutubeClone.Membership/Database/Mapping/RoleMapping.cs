using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.IdentityMapping
{
    public class RoleMapping : ClassMapping<Role> 
    {           
        public RoleMapping() { 
            Schema("dbo");
            Table("AspNetRoles");
            Id(e => e.Id, id => {
                id.Column("Id");
                id.Type(NHibernateUtil.String);
                id.Length(32);
                id.Generator(Generators.UUIDHex("N"));
            });
            Property(e => e.Name, prop => {
                prop.Column("Name");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            Property(e => e.NormalizedName, prop => {
                prop.Column("NormalizedName");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            Property(e => e.ConcurrencyStamp, prop => {
                prop.Column("ConcurrencyStamp");
                prop.Type(NHibernateUtil.String);
                prop.Length(36);
                prop.NotNullable(false);
            });
        }
    }
}
