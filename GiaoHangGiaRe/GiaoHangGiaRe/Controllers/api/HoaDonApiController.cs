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
    [RoutePrefix("hoadon")]
    public class HoaDonApiController : ApiController
    {
        private HoaDonServices _hoaDonServices;
        public HoaDonApiController()
        {
            _hoaDonServices = new HoaDonServices();
        }
        // GET: api/get-all
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetAll(int? size,int? page)
        {
            return Ok(new {
                data = _hoaDonServices.GetAll(size, page),
                size = size,
                page = page,
                total = _hoaDonServices.Count()
            });
        }

        // GET: api/get-by-id
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            return Ok(_hoaDonServices.GetById(id));
        }

        // POST: api/hoadon/create
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(HoaDon input)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _hoaDonServices.Create(input);
            return Ok(input);
        }

        // PUT: api/HoaDonApi/5
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(HoaDon input)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _hoaDonServices.Update(input);
            return Ok(input);
        }

        // DELETE: api/HoaDonApi/5
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _hoaDonServices.Delete(id);
            return Ok(id);
         }
    }
}
