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
    [RoutePrefix("api/banggia")]
    public class BangGiaApiController : ApiController
    {
        private BangGiaServices _bangGiaServices;
        public BangGiaApiController()
        {
            _bangGiaServices = new BangGiaServices();
        }
        // GET: api/get-all
        [AllowAnonymous]
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(int? page,int?size)
        {
            return Ok(_bangGiaServices.GetAll(page,size));
        }

        // GET: api/get-by-id
        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_bangGiaServices.GetById(id));
        }
        
        // POST: api/BangGiaApi
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(BangGia input)
        {
            _bangGiaServices.Create(input);
            return Ok(new
            {
                obj=input,
                message="success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(BangGia input)
        {
            _bangGiaServices.Update(input);
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
            string message = "";
            if (_bangGiaServices.IsExit(id)) message = "Id khong hop le!";
            var obj = _bangGiaServices.Delete(id);
            message = "Delete Success !";
            return Ok(new
            {
                obj,
                Message = message
            }); 
        }
    }
}
