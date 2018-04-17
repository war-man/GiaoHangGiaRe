﻿using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models.EntityModel;
using GiaoHangGiaRe.Module;
using Newtonsoft.Json.Linq;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("user/api/donhang")]
    [Authorize]
    public class userDonHangAPIController : ApiController
    {
       // private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();
        private DonHangServices _donHangServices = new DonHangServices();
        private KienHangServices _kienhangServices = new KienHangServices();
        private UserServices _userServices = new UserServices();

        // GET: api/DonHangAPI
        [Authorize]
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult GetDonHangs(int tinhtrang = 0)
        {     
            return Ok(new
            {
                list = _donHangServices.GetDonHangCurrentuser(tinhtrang),
                total = _donHangServices.GetDonHangCurrentuser(tinhtrang).Count
            });
        }

        [HttpGet]
        [Route("get-status")]
        public IHttpActionResult GetDetailsStatus()
        {
            statusDonHang _statusDonHang = new statusDonHang()
            {
                Huy = _donHangServices.GetDonHangCurrentuser(-1).Count,
                DangCho = _donHangServices.GetDonHangCurrentuser().Count,
                DangGiaoHang = _donHangServices.GetDonHangCurrentuser(1).Count,
                NhapKho = _donHangServices.GetDonHangCurrentuser(2).Count,
                GiaoHangCong = _donHangServices.GetDonHangCurrentuser(3).Count
            };
            return Ok(new
            {
                _statusDonHang
            });
        }
        [HttpGet]
        [Route("get-all-waitting")]
        public IHttpActionResult GetDonHangsWaitting(int? page = 0, int? size = 50, string user_name = null, string user_id = null, string nhanvien = null)
        {
            return Ok(new
            {
                list = _donHangServices.GetDonHangWaitting(),
                page,
                size,
                total = _donHangServices.GetDonHangWaitting().Count
            });
        }
        [HttpGet]
        [Route("get-all-shipper")]
        public IHttpActionResult GetDonHangsShipper(int? page = 0, int? size = 50, string user_name = null, string user_id = null, string nhanvien = null)
        {
            return Ok(new
            {
                list = _donHangServices.GetDonHangCurrentShipper(),
                page,
                size,
                total = _donHangServices.GetDonHangCurrentShipper().Count
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

        //GET: api/DonHangAPI/5
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
                DonHang donhang = new DonHang();
                donhang = _donHangServices.GetDonHangCurrentuser().Where(p => p.MaDonHang == id).First();
                return Ok(new
                {
                    donhang = donhang,
                    kienhang = _kienhangServices.GetByMaDonHang(donhang.MaDonHang)
                });
            }
        }

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
        [HttpPut]
        public IHttpActionResult PutDonHang([FromBody] JObject data)
        {
            DonHang donHang = data["donHang"].ToObject<DonHang>();
            KienHang[] kienHang = data["kienHang"].ToObject<KienHang[]>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_donHangServices.IsExists(donHang.MaDonHang) && kienHang != null)
            {
                if (donHang.MaDonHang <= 0)
                {
                    return BadRequest();
                }
                int MaDH = _donHangServices.Update(donHang);
                for (int i = 0; i < kienHang.Length; i++)
                {
                    kienHang[i].MaDonHang = MaDH;
                    _kienhangServices.Update(kienHang[i]);
                }
            }
            else
                return BadRequest();

            return Ok(1);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (donHang.MaDonHang <= 0 || _donHangServices.donHangIsOfUser(donHang.MaDonHang))
            //{
            //    return BadRequest();
            //}
            //_donHangServices.Update(donHang);
            //return Ok(1);
        }
        [ResponseType(typeof(void))]
        [Route("ship_receive")]
        [HttpPut]
        public IHttpActionResult ShipReceiveDonHang(int MaDonHang)
        {
            if (MaDonHang <= 0 || _donHangServices.donHangIsOfUser(MaDonHang))
            {
                return BadRequest();
            }
            else
            {
                DonHang donHang = _donHangServices.GetById(MaDonHang);
                if (donHang.TinhTrang == 0 ) // Tình trạng đơn hàng đang chờ
                {
                    donHang.TinhTrang = 1;
                    _donHangServices.Update(donHang);
                    return Ok(1);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // POST: api/DonHangAPI
        [ResponseType(typeof(DonHang))]
        [Route("create")]
        [HttpPost]
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
                for(int i =0; i< kienHang.Length; i++)
                {
                    kienHang[i].MaDonHang = MaDH;
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
    public class statusDonHang
    {
        public int Huy { get; set; }
        public int DangCho { get; set; }
        public int DangGiaoHang { get; set; }
        public int NhapKho { get; set; }
        public int GiaoHangCong { get; set; }

    }
}