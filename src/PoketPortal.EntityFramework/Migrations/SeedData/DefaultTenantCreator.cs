using System.Linq;
using PoketPortal.EntityFramework;
using PoketPortal.MultiTenancy;

namespace PoketPortal.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PoketPortalDbContext _context;

        public DefaultTenantCreator(PoketPortalDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
