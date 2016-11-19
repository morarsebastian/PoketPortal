using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace PoketPortal.EntityFramework
{
    [DependsOn(
        typeof(PoketPortalCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class PoketPortalEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PoketPortalDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}