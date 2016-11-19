using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace PoketPortal.Web.Views
{
    public abstract class PoketPortalRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PoketPortalRazorPage()
        {
            LocalizationSourceName = PoketPortalConsts.LocalizationSourceName;
        }
    }
}
