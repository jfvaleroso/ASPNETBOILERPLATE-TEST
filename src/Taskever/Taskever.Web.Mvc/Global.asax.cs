﻿using System;
using Abp.Startup.Web;
using Microsoft.AspNet.Identity;

namespace Taskever.Web.Mvc
{
    public class MvcApplication : AbpWebApplication
    {
        //TODO: Create a module in Abp.Modules.Core.Web and move this method there!
        protected virtual void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            
        }
    }
}
