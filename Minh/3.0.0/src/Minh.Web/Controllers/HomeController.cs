using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Minh.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MinhControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}