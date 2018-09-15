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

        // GET: api/DonHangAPI/5
        [HttpGet]
        [Route("get-by-username")]
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetDonHangByUserName(string  username)
        {           
            return Ok(_donHangServices.GetByUser(username));
        }
        
        // GET: 
        [HttpGet]
        [Route("get-history-shipper")]
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetLichSuDonHangCurrentShipper()
        {
            return Ok(_donHangServices.GetLichSuDonHangCurrentShipper());
        }
        // GET: 
        [HttpGet]
        [Route("get-current-shipper")]
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult getDonHangCurrentShipper()
        {
            return Ok(_donHangServices.GetDonHangCurrentShipper());
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

        //Shipper tiep nhan đơn hàng 
        //PUT
        [HttpPut]
        [Route("tiep-nhan-don-hang")]
        public IHttpActionResult TiepNhanDonHang(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.DaTiepNhan;
            var donhang = _donHangServices.GetById(MaDonHang);
            if(donhang.TinhTrang != DonHangConstant.XacNhan)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Xác nhận\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
            return Ok(1);
        }
        //Shipper lay hang đơn hàng 
        //PUT
        [HttpPut]
        [Route("lay-hang")]
        public IHttpActionResult LayDonHang(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.DangLayHang;
            var donhang = _donHangServices.GetById(MaDonHang);
            if (donhang.TinhTrang != DonHangConstant.DaTiepNhan)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Đã tiếp nhận\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
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
        //Shipper lay hang đơn hàng 
        //PUT
        [HttpPut]
        [Route("lay-thanh-cong")]
        public IHttpActionResult LayThanhCong(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.LayThanhCong;
            var donhang = _donHangServices.GetById(MaDonHang);
            if (donhang.TinhTrang != DonHangConstant.DangLayHang)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Đang lấy hàng\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
            return Ok(1);
        }
        //Shipper lay hang đơn hàng 
        //PUT
        [HttpPut]
        [Route("khong-the-lay-hang")]
        public IHttpActionResult KhongTheLayHang(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.KhongTheLayHang;
            var donhang = _donHangServices.GetById(MaDonHang);
            if (donhang.TinhTrang != DonHangConstant.DangLayHang)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Đang lấy hàng\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
            return Ok(1);
        }
        //Shipper dang giao đơn hàng 
        //PUT
        [HttpPut]
        [Route("giao-hang")]
        public IHttpActionResult GiaoHang(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.DangGiao;
            var donhang = _donHangServices.GetById(MaDonHang);
            if (donhang.TinhTrang != DonHangConstant.LayThanhCong)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Lấy hàng thành công\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
            return Ok(1);
        }
        //Shipper giao hàng thành công
        //PUT
        [HttpPut]
        [Route("giao-hang-thanh-cong")]
        public IHttpActionResult GiaoHangThanhCong(int MaDonHang)
        {
            UpdateTrangThaiDonHang updateTrangThaiDonHang = new UpdateTrangThaiDonHang();
            updateTrangThaiDonHang.MaDonHang = MaDonHang;
            updateTrangThaiDonHang.TinhTrang = DonHangConstant.GiaoThanhCong;
            var donhang = _donHangServices.GetById(MaDonHang);
            if (donhang.TinhTrang != DonHangConstant.DangGiao)
            {
                return ResponseMessage(Request.CreateErrorResponse
                    (HttpStatusCode.InternalServerError, "Trạng thái đơn hàng phải là \"Đang giao hàng\"!"));
            }
            if (updateTrangThaiDonHang.MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.changeStatusDonHang(updateTrangThaiDonHang);
            return Ok(1);
        }
        //Huy đơn hàng 
        //PUT
        [HttpPut]
        [Route("huy-don-hang")]
        public IHttpActionResult HuyDonHang(int MaDonHang)
        {
            if (MaDonHang <= 0)
            {
                return BadRequest();
            }
            _donHangServices.HuyDonHang(MaDonHang);
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