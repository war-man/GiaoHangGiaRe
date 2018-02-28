﻿using System;
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
    [RoutePrefix("user/api/donhang")]
    [Authorize]
    public class userDonHangAPIController : ApiController
    {
       // private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();
        private DonHangServices _donHangServices = new DonHangServices();
        private KienHangServices _kienhangServices = new KienHangServices();

        // GET: api/DonHangAPI
        [Authorize]
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetDonHangs(int? page = 0, int? size = 50, string user_name = null, string user_id = null, string nhanvien = null)
        {     
            return Ok(new
            {
                list = _donHangServices.GetDonHangCurrentuser(),
                page,
                size,
                total = _donHangServices.count()
            });
        }

        // GET: api/DonHangAPI/5
        //[HttpGet]
        //[Route("get-by-username")]
        //[ResponseType(typeof(DonHang))]
        //public IHttpActionResult GetDonHangByUserName(string  username)
        //{           
        //    return Ok(_donHangServices.GetByUser(username));
        //}

        // GET: api/DonHangAPI/5
        //[HttpGet]
        //[Route("get-by-id")]
        //[ResponseType(typeof(DonHang))]
        //public IHttpActionResult GetDonHang(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return ResponseMessage(Request.CreateErrorResponse
        //            (HttpStatusCode.InternalServerError, "id không hợp lệ!"));
        //    }
        //    else 
        //        return Ok(_donHangServices.GetById(id));
        //}

        //[HttpGet]
        //[Route("sort-by")]
        //public IHttpActionResult GetDonHangSortBy(string key)
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("search-by-key")]
        //public IHttpActionResult GetDonHangByKey(int? page ,int? size, string key)
        //{
        //    return Ok(_donHangServices.SearchByKey(page,size,key));
        //}

        // PUT: api/DonHangAPI/5
        [ResponseType(typeof(void))]
        [Route("update")]
        public IHttpActionResult PutDonHang(DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (donHang.MaDonHang <= 0 || _donHangServices.donHangIsOfUser(donHang.MaDonHang))
            {
                return BadRequest();
            }
            _donHangServices.Update(donHang);
            return Ok(1);
        }

        // POST: api/DonHangAPI
        [ResponseType(typeof(DonHang))]
        [Route("create")]
        public IHttpActionResult PostDonHang(DonHang donHang, KienHang[] kienHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_donHangServices.IsExists(donHang.MaDonHang) && kienHang != null)
            {
                _donHangServices.Create(donHang);
                for(int i =0; i< kienHang.Length; i++)
                {
                    _kienhangServices.Create(kienHang[i]);
                }
            }
            else
                return BadRequest();

            return Ok(1);
        }

        // DELETE: api/DonHangAPI/5
        //[ResponseType(typeof(DonHang))]
        //[Route("delete")]
        //public IHttpActionResult DeleteDonHang(int id)
        //{
        //    var donhang = _donHangServices.GetById(id);
        //    _donHangServices.Delete(id);
        //    return Ok(donhang);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}