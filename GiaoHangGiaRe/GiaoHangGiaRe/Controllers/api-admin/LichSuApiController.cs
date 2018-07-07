using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models.EntityModel;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/lichsu")]
    public class LichSuApiController : ApiController
    {
        private LichSuServices _lichSuServices;
        public LichSuApiController()
        {
            _lichSuServices = new LichSuServices();
        }
        // GET: api/LichSuApi
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetLichSus(int? page = null,int? size = null)
        {
            return Ok(new {
                data = _lichSuServices.GetAll(page, size),
                total = _lichSuServices.Count(),
                size,
                page
                });
        }

        // GET: api/LichSuApi/5
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetLichSu(int id)
        {
            var res = _lichSuServices.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

       // khong co update

        // POST: api/LichSuApi
        [HttpPost]
        [Route("create")]
        public IHttpActionResult PostLichSu(LichSu input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _lichSuServices.Create(input);
            return Ok();
        }

       //khong co delete
        
    }
}