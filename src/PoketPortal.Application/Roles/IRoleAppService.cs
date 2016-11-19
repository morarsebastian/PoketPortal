using System.Threading.Tasks;
using Abp.Application.Services;
using PoketPortal.Roles.Dto;

namespace PoketPortal.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
