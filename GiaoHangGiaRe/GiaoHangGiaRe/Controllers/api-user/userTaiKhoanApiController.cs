using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Models.TaiKhoan;
using GiaoHangGiaRe.Module;
using System.Web.Http;
using System.Web.Http.Description;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("user/api/taikhoan")]
    public class userTaiKhoanApiController : ApiController
    {
        private UserServices _userServices ;
        public userTaiKhoanApiController()
        {
            _userServices = new UserServices();
        }

        // GET:
        [HttpGet]
        [Route("get-current-user")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetCurrentUser()
        {
            return Ok(_userServices.GetCurrentUser());
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IHttpActionResult Resister(TaiKhoanCreate input)
        { 
            return Ok(_userServices.Create(input));
        }

        // PUT: api/TaiKhoanApi/5
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(TaiKhoanUpdate input)
        {
            _userServices.Update(input);
            return Ok(input);
        }

        //GET
        [HttpGet]
        [Route("get-role-user")]
        public IHttpActionResult GetRoleByUserId(string id)
        {
            return Ok(_userServices.GetRoleByUserId(id));
        }
        //GET

        [HttpGet]
        [Route("get-user-of-role")]
        public IHttpActionResult GetUserOfRole(string role)
        {
            return Ok(_userServices.GetUserOfRole(role));
        }
    }
}
