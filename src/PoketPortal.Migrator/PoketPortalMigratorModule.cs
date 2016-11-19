using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using PoketPortal.Configuration;
using PoketPortal.EntityFramework;

namespace PoketPortal.Migrator
{
    [DependsOn(typeof(PoketPortalEntityFrameworkModule))]
    public class PoketPortalMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PoketPortalMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(PoketPortalMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<PoketPortalDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PoketPortalConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}