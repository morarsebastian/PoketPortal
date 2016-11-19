using PoketPortal.EntityFramework;
using EntityFramework.DynamicFilters;

namespace PoketPortal.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PoketPortalDbContext _context;

        public InitialHostDbBuilder(PoketPortalDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
