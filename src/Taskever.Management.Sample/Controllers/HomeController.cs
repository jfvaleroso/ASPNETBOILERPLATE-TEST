using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Authorization.Permissions;
using Abp.Dependency;
using Abp.Security.Roles.Management;
using Abp.Web.Mvc.Controllers;
using Abp.Security.IdentityFramework;

namespace Taskever.Management.Sample.Controllers
{
    public class HomeController : AbpController
    {

        private readonly AbpUserManager _userManager;
        private readonly PermissionDefinitionManager _permissionDefinitionManager;

        public HomeController(AbpUserManager userManager, PermissionDefinitionManager permissionDefinitionManager)
        {
            _userManager = userManager;
            _permissionDefinitionManager = permissionDefinitionManager;
        }
        public ActionResult Index()
        {
            _permissionDefinitionManager.GetAllPermissions();
           return
                View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}