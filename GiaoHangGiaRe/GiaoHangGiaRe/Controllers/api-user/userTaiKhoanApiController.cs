using GiaoHangGiaRe.Models;
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
        [Route("register")]
        public IHttpActionResult Resister(RegisterViewModel input)
        { 
            //input.Password = "123456"; Nguoi dung phai nhap Mat Khau de dang ky
            return Ok(_userServices.Create(input));
        }

        // PUT: api/TaiKhoanApi/5
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(ApplicationUser input)
        {
            UpdateAccountViewModel _input = new UpdateAccountViewModel
            {
                Id= input.Id,
                DiaChi = input.DiaChi,
                HoTen = input.HoTen,
                SoDienThoai = input.PhoneNumber,

            };
            _userServices.Update(_input);
            return Ok(_input);
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
