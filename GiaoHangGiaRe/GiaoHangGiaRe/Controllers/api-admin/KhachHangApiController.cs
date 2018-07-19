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
using GiaoHangGiaRe.Models.KhachHang;

namespace GiaoHangGiaRe.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/khachhang")]
    public class KhachHangApiController : ApiController
    {
        private KhachHangServices _khachHangServices;
        public KhachHangApiController()
        {
            _khachHangServices = new KhachHangServices();
        }

        //Get
        [HttpPost]
        [Route("get-all")]
        public IHttpActionResult GetAllkhachHang(KhachHangSearchList khachHangSearchList)
        {
            return Ok(new
            {
                data = _khachHangServices.GetAll(khachHangSearchList),
                page = khachHangSearchList.page,
                size = khachHangSearchList.size,
                total = _khachHangServices.count_list
            });
        }
        //Get by id
        [HttpGet]
        [Route("get-by-id")]
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(int id)
        {
            if (id <= 0)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "id không hợp lệ!"));
            }
            else
                return Ok(_khachHangServices.GetById(id));
        }

        //Put
        [ResponseType(typeof(void))]
        [Route("update")]
        public IHttpActionResult PutKhachHang(KhachHang input)
        {
            if (input.MaKhachHang <= 0)
            {
                return BadRequest();
            }
            _khachHangServices.Update(input);
            return Ok(1);
        }

        // POST: api/khachhang/create
        [ResponseType(typeof(KienHang))]
        [Route("create")]
        public IHttpActionResult PostKhachHang(KhachHang input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
            _khachHangServices.Create(input);

            return Ok(input);
        }


        // DELETE: api/khachhang/5
        [ResponseType(typeof(KhachHang))]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var khachhang = _khachHangServices.GetById(id);
            _khachHangServices.Delete(id);
            return Ok(khachhang);
        }

    }
}