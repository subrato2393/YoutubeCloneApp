using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Membership.Database.Contexts
{
    public class IdentityContext
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
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ApplicationUser>())
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
