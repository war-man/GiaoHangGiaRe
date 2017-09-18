using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Minh.Roles.Dto;
using Minh.Users.Dto;

namespace Minh.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}