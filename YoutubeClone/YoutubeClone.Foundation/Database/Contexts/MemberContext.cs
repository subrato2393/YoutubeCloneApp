using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Database.Contexts
{
    public class MemberContext
    {
        public static ISessionFactory CreateSessionFactory()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(connectionString)
            .ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Channel>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Video>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Likes>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Subscriber>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Views>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Dislikes>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Comments>())


            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ApplicationUser>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserRole>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserLogin>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserToken>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserClaim>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Role>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleClaim>())

            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();

            return sessionFactory;
        }
        public static ISession OpenSession()
        {
            return CreateSessionFactory().OpenSession();
        }
    }
}
