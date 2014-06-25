using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Authorization.Permissions;
using Abp.Security.Roles.Management;
using Microsoft.AspNet.Identity;
using Taskever.Security.Roles;
using Taskever.Users;

namespace Time.Management.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ITaskeverUserAppService _taskeverUserAppService;

        public HomeController(ITaskeverUserAppService taskeverUserAppService)
        {
            _taskeverUserAppService = taskeverUserAppService;

        }
        public ActionResult Index()
        {

            var test = _taskeverUserAppService.GetAllUsers();
        

            ViewBag.Message = "Your application description page.";
            return View();
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