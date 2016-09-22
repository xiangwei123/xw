using System.Web.Mvc;

namespace TestProject.Web.Controllers
{
    public class AboutController : TestProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}