using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using PoketPortal.Authorization;
using PoketPortal.Users;
using Microsoft.AspNetCore.Mvc;

namespace PoketPortal.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : PoketPortalControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}