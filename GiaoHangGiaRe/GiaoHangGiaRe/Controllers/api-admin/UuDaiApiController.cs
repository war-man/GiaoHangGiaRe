using GiaoHangGiaRe.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers.api
{
    [RoutePrefix("api/uudai")]
    [Authorize]
    public class UuDaiApiController : ApiController
    {
        private UuDaiServices uudaiServices;
        public UuDaiApiController()
        {
            uudaiServices = new UuDaiServices();
        }
    }
}
