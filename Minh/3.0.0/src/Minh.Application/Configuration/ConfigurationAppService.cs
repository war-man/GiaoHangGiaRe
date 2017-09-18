using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Minh.Configuration.Dto;

namespace Minh.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MinhAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
