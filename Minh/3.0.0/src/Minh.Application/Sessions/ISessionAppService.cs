using System.Threading.Tasks;
using Abp.Application.Services;
using Minh.Sessions.Dto;

namespace Minh.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
