using System.Web.Mvc;

namespace TestProject.Web.Controllers
{
    public class HomeController : TestProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}