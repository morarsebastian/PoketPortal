using System.Reflection;
using Abp.Modules;
using Abp.Timing;
using Abp.Zero;
using PoketPortal.Localization;
using Abp.Zero.Configuration;
using PoketPortal.MultiTenancy;
using PoketPortal.Authorization.Roles;
using PoketPortal.Users;
using PoketPortal.Timing;

namespace PoketPortal
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class PoketPortalCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            PoketPortalLocalizationConfigurer.Configure(Configuration.Localization);

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = false;

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}