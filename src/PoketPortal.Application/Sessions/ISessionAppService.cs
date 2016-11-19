using System.Threading.Tasks;
using Abp.Application.Services;
using PoketPortal.Sessions.Dto;

namespace PoketPortal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
