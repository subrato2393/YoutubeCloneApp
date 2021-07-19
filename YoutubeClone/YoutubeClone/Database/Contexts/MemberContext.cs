using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using YoutubeClone.Entities;

namespace YoutubeClone.Database.Contexts 
{
    public class MemberContext  
    {  
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(@"Server=DESKTOP-FUMUVLC\SQLEXPRESS;Database=YoutubeDB;Integrated Security=True;")
            .ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Channel>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
