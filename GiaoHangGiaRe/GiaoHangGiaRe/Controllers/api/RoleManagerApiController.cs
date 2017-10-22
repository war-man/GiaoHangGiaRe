using GiaoHangGiaRe.Module;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/role")]
    public class RoleManagerApiController : ApiController
    {
        RoleServices _roleServices;
        public RoleManagerApiController()
        {
            _roleServices = new RoleServices();
        }
        // GET: api/RoleManagerApi
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetAll(int? page,int? size)
        {
            var res = _roleServices.GetAll(page, size);
            return Ok(new { 
                     page=page,size=size,
                    total =_roleServices.Count(),
                    data=res
                });
        }

        // GET: api/RoleManagerApi/5
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(string id)
        {
            var res = _roleServices.GetById(id);
            return Ok(res);
        }

        // POST: api/RoleManagerApi
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(IdentityRole input)
        {
            _roleServices.Create(input);
            return Ok(input);
        }

        // PUT: api/RoleManagerApi/5
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(IdentityRole input)
        {
            _roleServices.Update(input);
            return Ok(input);
        }

        // DELETE: api/RoleManagerApi/5
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(_roleServices.Delete(id));
        }
    }
}
