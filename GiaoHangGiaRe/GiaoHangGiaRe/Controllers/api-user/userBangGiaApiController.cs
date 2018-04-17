using GiaoHangGiaRe.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("user/api/banggia")]
    public class userBangGiaApiController : ApiController
    {
        public BangGiaServices _bangGiaServices;
        userBangGiaApiController()
        {
            _bangGiaServices = new BangGiaServices();
        }

        // GET: api/get-all

        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page = null, int? size = null)
        {
            return Ok(new
            {
                data = _bangGiaServices.GetAll(page, size),
                total = _bangGiaServices.Count(),
                size = size,
                page = page
            });
        }

        // GET: api/get-by-id
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_bangGiaServices.GetById(id));
        }
    }

}
