using Abp.Authorization;
using PoketPortal.Authorization.Roles;
using PoketPortal.MultiTenancy;
using PoketPortal.Users;

namespace PoketPortal.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
