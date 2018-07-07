using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models.EntityModel;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Controllers.api_admin
{
    [RoutePrefix("api/dashBoard")]
    public class DashBoardApiController : ApiController
    {
        private DashBoardServices _dashBoardServices;
        public DashBoardApiController()
        {   
            _dashBoardServices = new DashBoardServices();
        }

    }
}
