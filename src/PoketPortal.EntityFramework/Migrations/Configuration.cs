using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using PoketPortal.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace PoketPortal.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PoketPortal.EntityFramework.PoketPortalDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PoketPortal";
        }

        protected override void Seed(PoketPortal.EntityFramework.PoketPortalDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
