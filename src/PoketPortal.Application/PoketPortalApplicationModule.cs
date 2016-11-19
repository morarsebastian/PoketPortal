using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using PoketPortal.Authorization;

namespace PoketPortal
{
    [DependsOn(
        typeof(PoketPortalCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PoketPortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PoketPortalAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}