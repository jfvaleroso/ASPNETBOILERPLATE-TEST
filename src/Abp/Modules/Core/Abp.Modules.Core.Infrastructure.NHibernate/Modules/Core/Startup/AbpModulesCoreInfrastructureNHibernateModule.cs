﻿using System.Reflection;
using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Modules.Core.Data.Repositories.Interceptors;
using Abp.Startup;
using Abp.Startup.Infrastructure.NHibernate;
using Castle.Core;
using Castle.MicroKernel;

namespace Abp.Modules.Core.Startup
{
    public class AbpModulesCoreInfrastructureNHibernateModule : AbpModule
    {
        public override void PreInitialize(IAbpInitializationContext initializationContext)
        {
            base.PreInitialize(initializationContext);

            initializationContext.IocContainer.Kernel.ComponentRegistered += ComponentRegistered;

            initializationContext.GetModule<AbpNHibernateModule>().Configuration
                .Mappings(
                    m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                );
        }

        private void ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IRepository).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                foreach (var implementedInterface in handler.ComponentModel.Implementation.GetInterfaces())
                {
                    if (implementedInterface.Name == "IRepository`2" && implementedInterface.IsGenericType && implementedInterface.GenericTypeArguments.Length == 2)
                    {
                        var typeArgs = implementedInterface.GenericTypeArguments;
                        if (typeof(ICreationAudited).IsAssignableFrom(typeArgs[0]) || typeof(IModificationAudited).IsAssignableFrom(typeArgs[0]))
                        {
                            handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AuditInterceptor)));
                        }
                    }
                }
            }
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
