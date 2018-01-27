using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Module;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/taikhoan")]
    public class TaiKhoanApiController : ApiController
    {
        private UserServices _userServices ;
        public TaiKhoanApiController()
        {
            _userServices = new UserServices();
        }
        // GET: api/TaiKhoanApi
        [HttpGet]
        [Route("get-all")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult Get(int? page =null, int? size = null, string user_name = "", string user_id = "", string name = "")
        {
            return Ok(new {
                data=_userServices.GetAll(page, size, user_name, user_id, name),
                total=_userServices.Count(),
                size,
                page
            });
        }

        // GET: api/TaiKhoanApi/5
        [HttpGet]
        [Route("get-by-id")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetById(string id)
        {
            var user = _userServices.GetById(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("get-by-username")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetByUsername(string id)
        {
            var user = _userServices.GetuserByUsername(id);
            return Ok(user);
        }

        // GET:
        [HttpGet]
        [Route("get-current-user")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetCurrentUser()
        {
            return Ok(_userServices.GetCurrentUser());
        }

        // POST: api/TaiKhoanApi
        //[AllowAnonymous] // Tao 1 user - Khong tao tu dong KhachHang hoac NhanVien
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(RegisterViewModel input)
        {
            input.Password = "123456"; // Mat khau mac dinh
            return Ok(_userServices.Create(input));
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


        // DELETE: api/TaiKhoanApi/5
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(string id)
        {
            var user = _userServices.GetById(id);     
            if (user == null)
                return Ok("User khong ton tai!");
            _userServices.Delete(id);
            return Ok(user);
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

        //Post

        [HttpPost]
        [Route("add-to-role")]
        public IHttpActionResult AddToRole(UserIdRole userIdRole) // Them user vao 1 hoac nhieu role
        {         
            return Ok(_userServices.AddToRole(userIdRole.userId, userIdRole.roleId));
        }

        [HttpPut]
        [Route("remove-user-role")]
        public IHttpActionResult RemoveUserRole(UserIdRole userIdRole) // Xoa user ra khoi 1 hoac nhieu Role
        {
            return Ok(_userServices.RemoveUserRole(userIdRole.userId, userIdRole.roleId)); // 
        }

        [HttpGet]
        [Route("get-claim")]
        public  IHttpActionResult GetClaim(string userID)
        {
            return Ok(_userServices.Claims(userID)); // 
        }
    }
    public class UserIdRole
    {
       public string userId { set; get; }
        public string[] roleId { set; get; }
    }
}
