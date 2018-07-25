using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Module;
using Microsoft.AspNetCore.Http;
using Models.EntityModel;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageAPIController : ApiController
    {
        private ftp_module ftp_Module;
        private ImageServices _imageServices;
        private UserServices _userServices;
        ImageAPIController()
        {
            _imageServices = new ImageServices();
            _userServices = new UserServices();
            ftp_Module = new ftp_module();
        }

        [Route("upload")]
        [HttpPost]
        public IHttpActionResult upload(ImageForm imgForm)
        {
            return Ok(ftp_Module.UploadImage(Convert.FromBase64String(imgForm.base64)));
        }
        [Route("get_image")]
        [HttpGet]
        public IHttpActionResult getImage()
        {
            return Ok(ftp_Module.GetImage());
        }
    }
}
