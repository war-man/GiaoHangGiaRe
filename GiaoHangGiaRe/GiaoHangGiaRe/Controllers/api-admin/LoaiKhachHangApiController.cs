using GiaoHangGiaRe.Module;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/loaikh")]
    public class LoaiKhachHangApiController : ApiController
    {
        private LoaiKHServices _loaiKHServices;
        public LoaiKhachHangApiController()
        {
            _loaiKHServices = new LoaiKHServices();
        }
        // GET: api/get-all
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page, int? size)
        {
            return Ok(new
            {
                data = _loaiKHServices.GetAll(page, size),
                total = _loaiKHServices.Count(),
                page = page,
                size = size
            }
            );
        }

        // GET: api/get-by-id
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_loaiKHServices.GetById(id));
        }

        // POST: api/
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(LoaiKhachHang input)
        {
            _loaiKHServices.Create(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(LoaiKhachHang input)
        {
            _loaiKHServices.Update(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            string message = ""; var no = _loaiKHServices.GetById(id);
            if (no == null) message = "Id khong hop le!";
            var obj = no;
            _loaiKHServices.Delete(id);
            message = "Delete Success !";
            return Ok(new
            {
                obj,
                Message = message
            });
        }
    }
}
