using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models.EntityModel;
using GiaoHangGiaRe.Module;
using Newtonsoft.Json.Linq;
using GiaoHangGiaRe.Models;
using System;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("user/api/donhang")]
    [Authorize]
    public class userDonHangAPIController : ApiController
    {
        private DonHangServices _donHangServices;
        private KienHangServices _kienhangServices;
        private UserServices _userServices;
        private NhanVienServices _nhanvienServices;
        userDonHangAPIController() {
            _kienhangServices = new KienHangServices();
            _userServices = new UserServices();
            _nhanvienServices = new NhanVienServices();
            _donHangServices = new DonHangServices();
        }
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
        [HttpGet]
        [Route("get-lishsu-donhang-shipper")]
        public IHttpActionResult GetLishSuDonHangsShipper(int? page = 0, int? size = 50, string user_name = null, string user_id = null, string nhanvien = null)
        {
            return Ok(new
            {
                list = _donHangServices.GetLichSuDonHangCurrentShipper(),
                page,
                size,
                total = _donHangServices.GetLichSuDonHangCurrentShipper().Count
            });
        }

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

        [HttpGet]
        [Route("get-kienhang-donhang")]
        public IHttpActionResult getKienHangOfDonHang(int MaDonHang)
        {
            if (_donHangServices.IsExists(MaDonHang))
            {
                return Ok(_kienhangServices.GetByMaDonHang(MaDonHang));
            }
            else
            {
                return ResponseMessage(Request.CreateErrorResponse
                   (HttpStatusCode.InternalServerError, "id không hợp lệ!"));
            }

        }

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
        }

        [HttpPut]
        [Route("change_status")]
        public IHttpActionResult ThayDoiStatusDonHang (UpdateTrangThaiDonHang _input)
        {
            if (_donHangServices.IsExists(_input.MaDonHang))
            {
                _donHangServices.changeStatusDonHang(_input);
            }
            else
            {
                return ResponseMessage(Request.CreateErrorResponse
                                           (HttpStatusCode.InternalServerError, "Đơn hàng không tòn tại."));
            }
            return Ok(1);
        }

        /// <summary>
        /// ssss
        /// </summary>
        [ResponseType(typeof(void))]
        [Route("ship_receive")]
        [HttpPut]
        public IHttpActionResult ShipReceiveDonHang(int MaDonHang)
        {
            if (MaDonHang <= 0 || !_donHangServices.IsExists(MaDonHang))
            {
                return BadRequest();
            }
            else
            {
                DonHang donHang = _donHangServices.GetById(MaDonHang);
                if (donHang.TinhTrang == 0 ) // Tình trạng đơn hàng đang chờ
                {
                    try
                    {
                        donHang.MaNhanVienGiao = _nhanvienServices.GetNhanVienCurrentUser().MaNhanVien;
                    }
                    catch
                    {
                        return ResponseMessage(Request.CreateErrorResponse
                                           (HttpStatusCode.InternalServerError, "Tài khoản không tồn tại trong danh sách nhân viên."));
                    }
                    donHang.TinhTrang = DonHangConstant.DaTiepNhan;
                    donHang.ThoiDiemTiepNhanDon = DateTime.Now;
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