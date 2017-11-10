using GiaoHangGiaRe.Module;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/nhanvien")]
    public class NhanVienApiController : ApiController
    {
        private NhanVienServices _nhanVienServices;
        public NhanVienApiController()
        {
            _nhanVienServices = new NhanVienServices();
        }
        // GET: api/get-all
        [AllowAnonymous]
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page, int? size)
        {
            return Ok(new {
                data = _nhanVienServices.GetAll(page, size),
                size = size,
                page = page,
                total = _nhanVienServices.Count()
            });
        }

        // GET: api/get-by-id
        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_nhanVienServices.GetById(id));
        }

        // POST: api/BangGiaApi
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(NhanViens input)
        {
            _nhanVienServices.Create(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(NhanViens input)
        {
            _nhanVienServices.Update(input);
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
            _nhanVienServices.Delete(id);
            return Ok();
        }
    }
}
