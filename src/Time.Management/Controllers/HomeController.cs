using System.Web.Mvc;
using Abp.Test;
using Taskever.Security.Roles;
using Taskever.Users;

namespace Time.Management.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
        public ActionResult Index()
        {
          
           _testService.Create(new TaskeverRole { DisplayName = "Super Admin", Name = "Super Admin" });
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