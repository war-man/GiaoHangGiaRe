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
    [RoutePrefix("api/khochua")]
    public class KhoChuaApiController : ApiController
    {
        private KhoChuaServices _khoChuaServices;
        public KhoChuaApiController()
        {
            _khoChuaServices = new KhoChuaServices();
        }
        // GET: api/get-all
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page, int? size)
        {
            return Ok(new
            {
                data = _khoChuaServices.GetAll(page, size),
                total = _khoChuaServices.Count(),
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
            return Ok(_khoChuaServices.GetById(id));
        }

        // POST: api/
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(KhoChua input)
        {
            _khoChuaServices.Create(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(KhoChua input)
        {
            _khoChuaServices.Update(input);
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
            string message = ""; var no = _khoChuaServices.GetById(id);
            if (no == null) message = "Id khong hop le!";
            var obj = no;
            _khoChuaServices.Delete(id);
            message = "Delete Success !";
            return Ok(new
            {
                obj,
                Message = message
            });
        }
    }
}
