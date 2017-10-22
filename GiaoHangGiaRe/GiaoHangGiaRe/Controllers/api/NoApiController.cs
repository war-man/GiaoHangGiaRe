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
    [RoutePrefix("api/no")]
    public class NoApiController : ApiController
    {
        private NoServices _noServices;
        public NoApiController()
        {
            _noServices = new NoServices();
        }
        // GET: api/get-all
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page, int? size)
        {
            return Ok(new {
                data = _noServices.GetAll(page, size),
                total = _noServices.Count(),
                page=page,
                size=size
                }
            );
        }

        // GET: api/get-by-id
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_noServices.GetById(id));
        }

        // POST: api/
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(No input)
        {
            _noServices.Create(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(No input)
        {
            _noServices.Update(input);
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
            string message = "";var no = _noServices.GetById(id);
            if (no==null) message = "Id khong hop le!";
            var obj = no;
            _noServices.Delete(id);
            message = "Delete Success !";
            return Ok(new
            {
                obj,
                Message = message
            });
        }

    }
}
