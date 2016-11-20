using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using PoketPortal.Authorization.Roles;
using PoketPortal.Configuration;
using PoketPortal.MultiTenancy;
using PoketPortal.Users;
using PoketPortal.Web;
using PoketPortal.Places;

namespace PoketPortal.EntityFramework
{
    [DbConfigurationType(typeof(PoketPortalDbConfiguration))]
    public class PoketPortalDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */
        public DbSet<Place> Places { get; set; }

        /* Default constructor is needed for EF command line tool. */
        public PoketPortalDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                PoketPortalConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of PoketPortalDbContext since ABP automatically handles it.
         */
        public PoketPortalDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public PoketPortalDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }

    public class PoketPortalDbConfiguration : DbConfiguration
    {
        public PoketPortalDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
