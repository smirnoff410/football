using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Util;

namespace FootBall.Infrastructure.Services.Session
{
    public static class SessionFactory<TContext> where TContext : ICurrentSessionContext
    {
        public static ISessionFactory CreateSessionFactory(string connectionName, IEnumerable<Type> types, ILogger<TContext> logger)
        {
            var configuration = new Configuration();
            logger.Log(LogLevel.Trace, $"Connection name: {connectionName}");
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionName;
            });

            var mappings = new ModelMapper();
            mappings.AddMappings(types);
            configuration.AddMapping(mappings.CompileMappingForAllExplicitlyAddedEntities());
            configuration.CurrentSessionContext<TContext>();

            var request = new SchemaUpdate(configuration);
            request.Execute(true, true);
            if (request.Exceptions.Any())
            {
                foreach (var exception in request.Exceptions)
                {
                    logger.LogError(exception.Message);
                }
            }

            return configuration.BuildSessionFactory();
        }
    }
}