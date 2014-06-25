using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Authorization.Permissions;
using Abp.Dependency;
using Abp.Web.Mvc.Controllers;

namespace Taskever.Management.Controllers
{
    public class HomeController : AbpController
    {

        private readonly PermissionDefinitionManager _permissionDefinitionManager;

        public HomeController()
        {
            _permissionDefinitionManager = new IocManager.Instance.IocContainer.Resolve<PermissionDefinitionManager>();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            _permissionDefinitionManager.GetAllPermissions();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
