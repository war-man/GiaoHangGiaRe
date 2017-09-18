using Abp.Web.Mvc.Views;

namespace Minh.Web.Views
{
    public abstract class MinhWebViewPageBase : MinhWebViewPageBase<dynamic>
    {

    }

    public abstract class MinhWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MinhWebViewPageBase()
        {
            LocalizationSourceName = MinhConsts.LocalizationSourceName;
        }
    }
}