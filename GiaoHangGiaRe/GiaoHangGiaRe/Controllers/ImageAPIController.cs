using GiaoHangGiaRe.Module;
using Microsoft.AspNetCore.Http;
using Models.EntityModel;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageAPIController : ApiController
    {
        private ImageServices _imageServices;
        private UserServices _userServices;
        ImageAPIController()
        {
            _imageServices = new ImageServices();
            _userServices = new UserServices();
        }
        [Route("upload")]
        [HttpPost]
        public IHttpActionResult upload([FromBody] string Base64)
        {
            Image img = new Image();
            img = new Image
            {
                RoleId = "",
                title = "",
                create_by = _userServices.GetCurrentUser().TenTaiKhoan,
                create_at = DateTime.Now,
                ImageContent = Base64
            };
            if (_imageServices.Create(img))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
