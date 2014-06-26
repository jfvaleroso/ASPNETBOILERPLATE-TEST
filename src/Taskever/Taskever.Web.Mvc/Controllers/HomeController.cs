using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using Abp.Test;
using Abp.Web.Mvc.Authorization;

namespace Taskever.Web.Mvc.Controllers
{
    [AbpAuthorize]
    public class HomeController : TaskeverController
    {
        //public ActionResult Index()
        //{
        //    var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    //var tenantId = prinicpal.Claims.Where(c => c.Type == "TenantId").Select(c => c.Value).SingleOrDefault();

        //    return View("Index");
        //}

        private readonly ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
        public ActionResult Index()
        {
            var a = _testService.Test();

            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}
