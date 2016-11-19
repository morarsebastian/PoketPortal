using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace PoketPortal.Web.Controllers
{
    public abstract class PoketPortalControllerBase: AbpController
    {
        protected PoketPortalControllerBase()
        {
            LocalizationSourceName = PoketPortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}