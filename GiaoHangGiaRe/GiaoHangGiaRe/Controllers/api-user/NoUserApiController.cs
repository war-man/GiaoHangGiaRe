using GiaoHangGiaRe.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("user/api/no")]
    [Authorize]
    public class NoUserApiController : ApiController
    {
        private DonHangServices _donHangServices = new DonHangServices();
        private UserServices _userServices = new UserServices();
        private NoServices _noServices = new NoServices();
        // GET: NoApi
        [Authorize]
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetNo(int? page = 0, int? size = 50, string user_name = null, string user_id = null, string nhanvien = null, string KyHieu = "")
        {
            return Ok(new
            {
                list = _noServices.GetNoCurrentUser(page,size, KyHieu),
                page,
                size,
                total = _noServices.CountNoCurenUser()
            });
        }
    }
}