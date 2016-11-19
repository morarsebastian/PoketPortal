using Abp.AspNetCore.Mvc.Authorization;
using PoketPortal.Authorization;
using PoketPortal.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace PoketPortal.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : PoketPortalControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}