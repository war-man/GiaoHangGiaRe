using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Minh.MultiTenancy.Dto;

namespace Minh.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
