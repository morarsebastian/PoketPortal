using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PoketPortal.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PoketPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}