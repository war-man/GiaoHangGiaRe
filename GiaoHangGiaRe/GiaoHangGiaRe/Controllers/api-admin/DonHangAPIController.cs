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
using GiaoHangGiaRe.Models;
using Newtonsoft.Json.Linq;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("api/donhang")]
    [Authorize]
    public class DonHangAPIController : ApiController
    {
        private UserServices _userServices = new UserServices();
        private KienHangServices _kienhangServices = new KienHangServices();
        private DonHangServices _donHangServices = new DonHangServices();
        // GET: api/DonHangAPI
        //[Authorize(Roles ="manager")] 
        [HttpPost]
        [Route("get-all")]
        public IHttpActionResult GetDonHangs(DonHangSearchList donHangSearchList)
        { 
            return Ok(new {
                list = _donHangServices.GetAll(donHangSearchList),
                page = donHangSearchList.page,
                size = donHangSearchList.size,
                total = _donHangServices.count_list
            } );
        }
        [HttpGet]
        [Route("get-donhang-vipham")]
        public IHttpActionResult GetDonHangsViPham(int? page = 0, int? size = 50, string user_name = "", string user_id = "", int? nhanvien = null, int? tinhtrang = null)
        {
            return Ok(new
            {
                list = _donHangServices.GetDonHangViPham(page, size, user_name, user_id, nhanvien, tinhtrang),
                page = page,
                size = size,
                total = _donHangServices.count()
            });
        }
        // GET: api/DonHangAPI/5
        [HttpGet]
        [Route("get-by-username")]
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetDonHangByUserName(string  username)
        {           
            return Ok(_donHangServices.GetByUser(username));
        }

        // GET: api/DonHangAPI/5
        [HttpGet]
        [Route("get-by-id")]
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetDonHang(int id)
        {
            if (id <= 0)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "id không hợp lệ!"));
            }
            else
            {
                var donhang = _donHangServices.GetById(id);
                return Ok(new
                {
                    donhang = donhang,
                    kienhang = _kienhangServices.GetByMaDonHang(donhang.MaDonHang)
                });
            }
        }

        // PUT: api/DonHangAPI/5
        [ResponseType(typeof(void))]
        [Route("update")]
        public IHttpActionResult PutDonHang(DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ( donHang.MaDonHang <=0)
            {
                return BadRequest();
            }
            _donHangServices.Update(donHang);
            return Ok(1);
        }

        // POST: api/DonHangAPI
        [ResponseType(typeof(DonHang))]
        [Route("create")]
        public IHttpActionResult PostDonHang([FromBody] JObject data)
        {
            DonHang donHang = data["donHang"].ToObject<DonHang>();
            KienHang[] kienHang = data["kienHang"].ToObject<KienHang[]>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_donHangServices.IsExists(donHang.MaDonHang) && kienHang != null)
            {
                donHang.TenTaiKhoan = _userServices.GetCurrentUser().TenTaiKhoan;
                int MaDH = _donHangServices.Create(donHang);
                for (int i = 0; i < kienHang.Length; i++)
                {
                    kienHang[i].MaDonHang = MaDH;
                    _kienhangServices.Create(kienHang[i]);
                }
            }
            else
                return BadRequest();

            return Ok(1);
        }

        //Xac nhan đơn hàng 
        //PUT
        [HttpPut]
        [Route("xac-nhan-don-hang")]
        public IHttpActionResult XacNhanDonHang(int MaDonHang)
        {
            if (MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.XacNhanDonHang(MaDonHang);
            return Ok(1);
        }

        // DELETE: api/DonHangAPI/5
        [ResponseType(typeof(DonHang))]
        [Route("delete")]
        public IHttpActionResult DeleteDonHang(int id)
        {
            var donhang = _donHangServices.GetById(id);
            _donHangServices.Delete(id);
            return Ok(donhang);
        }

    }
}