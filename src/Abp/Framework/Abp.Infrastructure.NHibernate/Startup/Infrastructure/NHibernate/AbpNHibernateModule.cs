﻿using System.Reflection;
using Abp.Dependency;
using Abp.Domain.Repositories.NHibernate;
using Abp.Domain.Uow;
using Abp.Domain.Uow.NHibernate;
using Abp.Modules;
using FluentNHibernate.Cfg;
using NHibernate;

namespace Abp.Startup.Infrastructure.NHibernate
{
    /// <summary>
    /// This module is used to implement "Data Access Layer" in NHibernate.
    /// </summary>
    public class AbpNHibernateModule : AbpModule
    {
        /// <summary>
        /// Gets NHibernate Fluent configuration object to configure.
        /// Do not call BuildSessionFactory on it.
        /// </summary>
        public FluentConfiguration Configuration { get; private set; }

        /// <summary>
        /// NHibernate session factory object.
        /// </summary>
        private ISessionFactory _sessionFactory;

        public override void PreInitialize(IAbpInitializationContext initializationContext)
        {
            base.PreInitialize(initializationContext);

            UnitOfWorkRegistrer.Initialize(initializationContext);
            Configuration = Fluently.Configure();
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);

            _sessionFactory = Configuration.BuildSessionFactory();
            initializationContext.IocContainer.Install(new NhRepositoryInstaller(_sessionFactory));
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void Shutdown()
        {
            base.Shutdown();
            _sessionFactory.Dispose();
        }
    }
}
