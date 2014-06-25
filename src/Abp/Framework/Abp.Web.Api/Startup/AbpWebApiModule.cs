﻿using System;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;
using Abp.Startup.Application;
using Abp.Startup.Web;
using Abp.WebApi.Controllers;
using Abp.WebApi.Controllers.Dynamic;
using Abp.WebApi.Controllers.Dynamic.Formatters;
using Abp.WebApi.Controllers.Dynamic.Selectors;
using Abp.WebApi.Controllers.Filters;
using Newtonsoft.Json.Serialization;

namespace Abp.WebApi.Startup
{
    /// <summary>
    /// This module provides Abp features for ASP.NET Web API.
    /// </summary>
    public class AbpWebApiModule : AbpModule
    {
        public override Type[] GetDependedModules()
        {
            return new[]
                   {
                       typeof(AbpWebModule),
                       typeof(AbpApplicationModule),
                   };
        }

        public override void PreInitialize(IAbpInitializationContext initializationContext)
        {
            base.PreInitialize(initializationContext);

            IocManager.Instance.AddConventionalRegisterer(new ApiControllerConventionalRegisterer());
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);

            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            InitializeAspNetServices();
            InitializeFilters();
            InitializeFormatters();
            InitializeRoutes();
        }

        private static void InitializeAspNetServices()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new AbpHttpControllerSelector(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpActionSelector), new AbpApiControllerActionSelector());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new AbpControllerActivator());
        }

        private static void InitializeFilters()
        {
            GlobalConfiguration.Configuration.Filters.Add(new AbpExceptionFilterAttribute());
        }

        private static void InitializeFormatters()
        {
            GlobalConfiguration.Configuration.Formatters.Clear();
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration.Configuration.Formatters.Add(formatter);
            GlobalConfiguration.Configuration.Formatters.Add(new PlainTextFormatter());
        }

        private static void InitializeRoutes()
        {
            DynamicApiRouteConfig.Register();
        }
    }
}
