using System.Threading.Tasks;
using Abp.Application.Services;
using Minh.Configuration.Dto;

namespace Minh.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}