using Microsoft.AspNetCore.Mvc;

namespace PoketPortal.Web.Controllers
{
    public class AboutController : PoketPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}