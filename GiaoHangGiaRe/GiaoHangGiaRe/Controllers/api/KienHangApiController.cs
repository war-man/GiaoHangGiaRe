using GiaoHangGiaRe.Module;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/kienhang")]
    public class KienHangApiController : ApiController
    {
        private KienHangServices _kienhangServices;
        public KienHangApiController()
        {
            _kienhangServices = new KienHangServices();
        }

        //Get
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetAllKienHang(int? page, int? size)
        {
            return Ok(new
            {
                list = _kienhangServices.GetAll(page, size),
                page = page,
                size = size,
                total = _kienhangServices.Count()
            });
        }
        //Get by id
        [HttpGet]
        [Route("get-by-id")]
        [ResponseType(typeof(KienHang))]
        public IHttpActionResult GetKienHang(int id)
        {
            if (id <= 0)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "id không hợp lệ!"));
            }
            else
                return Ok(_kienhangServices.GetById(id));
        }

        //Put
        [ResponseType(typeof(void))]
        [Route("update")]
        public IHttpActionResult PutDonHang(KienHang input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (input.MaKienHang <= 0)
            {
                return BadRequest();
            }
            _kienhangServices.Update(input);
            return Ok(1);
        }

        // POST: api/kienhang/create
        [ResponseType(typeof(KienHang))]
        [Route("Create")]
        public IHttpActionResult PostDonHang(KienHang input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_kienhangServices.IsExists(input.MaKienHang))
                _kienhangServices.Create(input);
            else
                return BadRequest();

            return Ok(input);
        }


        // DELETE: api/DonHangAPI/5
        [ResponseType(typeof(KienHang))]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var kienhang = _kienhangServices.GetById(id);
            _kienhangServices.Delete(id);
            return Ok(kienhang);
        }


    }
}
