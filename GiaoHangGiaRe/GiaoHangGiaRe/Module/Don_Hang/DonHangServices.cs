using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaoHangGiaRe.Models;
using Models.EntityModel;
using System.Web.Script.Serialization;

namespace GiaoHangGiaRe.Module
{
    public class DonHangServices : IDonHangServices
    {
        private IRepository<DonHang> _donhangRepository;
        private UserServices userServices;
        private NhanVienServices nhanVienServices;
        private LichSuServices lichSuServices;
        private KienHangServices kienHangServices;
        private IRepository<KienHang> _kienhangRepository;
        private IRepository<HoaDon> _hoadonRepository;
        public DonHangServices()
        {
            _donhangRepository = new IRepository<DonHang>();
            userServices = new UserServices();
            nhanVienServices = new NhanVienServices();
            lichSuServices = new LichSuServices();
            kienHangServices = new KienHangServices();
            _hoadonRepository = new IRepository<HoaDon>();
            _kienhangRepository = new IRepository<KienHang>();
        }
        public DonHangServices(IRepository<DonHang> donhangRepository)
        {
            _donhangRepository = donhangRepository;
        }

        public int count()
        {
            return _donhangRepository.GetAll().Count();
        }

        public int Create(DonHang input)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            input.ThoiDiemDatDonHang = time;
            input.TinhTrang = 0;
            input.TenTaiKhoan = userServices.GetCurrentUser().TenTaiKhoan == null? userServices.GetCurrentUser().UserName: userServices.GetCurrentUser().TenTaiKhoan;
            _donhangRepository.Insert(input);
            DonHang input2 = new DonHang();
            input2 =_donhangRepository.GetAll().Where(p => p.ThoiDiemDatDonHang == time && 
            p.TenTaiKhoan == userServices.GetCurrentUser().TenTaiKhoan 
            &&p.ThanhTien == input.ThanhTien && p.NguoiGui == input.NguoiGui && p.NguoiNhan == input.NguoiNhan).FirstOrDefault();
            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                HanhDong = Constant.CreateAction,
                ViTriThaoTac = "User",
                NoiDung = new JavaScriptSerializer().Serialize(input)
            });
            return input2.MaDonHang;
        }

        public void Delete(object id)
        {
            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                HanhDong = Constant.DeleteAction,
                ViTriThaoTac = Constant.DonHang,
                NoiDung = id.ToString()
            });

            _donhangRepository.Delete(id);
        }

        public List<DonHang> GetAll(int? page = 0, int? size= 50, string user_name = "", string user_id = null, int? ma_nhanvien = null, int? tinhtrang = null)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = _donhangRepository.GetAll().Count(); 
            if (user_name == null)
            {
                user_name = "";
            }
            //mac dinh tinh trang =0
            if (tinhtrang == null)
            {
                tinhtrang = 0;
            }
            List<DonHang> res = _donhangRepository.GetAll().Where(p => p.TinhTrang>= 0 && p.TenTaiKhoan.Contains(user_name) && p.TinhTrang==tinhtrang)
            .OrderBy(p => p.MaDonHang)
            .Skip(size.Value * (page.Value))
            .Take(size.Value).ToList();
            return res;
        }
        public List<DonHang> GetDonHangViPham(int? page = 0, int? size = 50, string user_name = "", string user_id = null, int? ma_nhanvien = null, int? tinhtrang = null)
        {
            if (user_name == null)
            {
                user_name = "";
            }
            List<DonHang> res = _donhangRepository.GetAll().Where(p => p.TinhTrang == DonHangConstant.Huy)
            .OrderBy(p => p.MaDonHang)
            .Skip(size.Value * (page.Value))
            .Take(size.Value).ToList();
            return res;
        }
        public DonHang GetById(object id) // lay don hang theo id
        {
            return _donhangRepository.SelectById(id);
        }

        public List<DonHang> GetByKhoChua(int MaKhoChua) // Danh sach don hang trong kho hang
        {
            throw new NotImplementedException();
        }

        public List<DonHang> GetByUser(object username)
        {
            var res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan == username.ToString());
            return res.ToList();
        }
        /// <summary>
        /// Đơn hàng shiper hiện tại đang tiếp nhận (không kể đơn hàng hoàn thành hoặc bị hủy)
        /// </summary>
        /// <returns></returns>
        public List<DonHangKienHang> GetDonHangCurrentShipper()
        {
            if (nhanVienServices.GetNhanVienCurrentUser() != null)
            {
                List<DonHangKienHang> listDonHangKienHang = new List<DonHangKienHang>();
                var res = _donhangRepository.GetAll()
                .Where(p => p.MaNhanVienGiao == (nhanVienServices.GetNhanVienCurrentUser().MaNhanVien) && 
                p.TinhTrang != DonHangConstant.Huy && p.TinhTrang != DonHangConstant.GiaoThanhCong)
                .ToList();
                foreach (var item in res)
                {
                    DonHangKienHang donHangkienHang = new DonHangKienHang();
                    var resKienHang = _kienhangRepository.GetAll().Where(p => p.MaDonHang == item.MaDonHang).ToList();
                    if(resKienHang != null)
                    {
                        donHangkienHang.listKienHang = resKienHang;                     
                    }
                    donHangkienHang.DonHang = item;
                    listDonHangKienHang.Add(donHangkienHang);
                }
                return listDonHangKienHang;
            }
            return new List<DonHangKienHang>();
        }
        /// <summary>
        /// Lấy danh sách đơn hàng của shiper đã hoàn thành hoặc đã hủy
        /// </summary>
        /// <returns></returns>
        public List<DonHangKienHang> GetLichSuDonHangCurrentShipper()
        {
            if (nhanVienServices.GetNhanVienCurrentUser() != null)
            {
                List<DonHangKienHang> listDonHangKienHang = new List<DonHangKienHang>();
                var res = _donhangRepository.GetAll()
                .Where(p => p.MaNhanVienGiao == (nhanVienServices.GetNhanVienCurrentUser().MaNhanVien) &&
                (p.TinhTrang == DonHangConstant.Huy || p.TinhTrang == DonHangConstant.GiaoThanhCong))
                .ToList();
                foreach (var item in res)
                {
                    DonHangKienHang donHangkienHang = new DonHangKienHang();
                    var resKienHang = _kienhangRepository.GetAll().Where(p => p.MaDonHang == item.MaDonHang).ToList();
                    if (resKienHang != null)
                    {
                        donHangkienHang.listKienHang = resKienHang;
                    }                
                    donHangkienHang.DonHang = item;
                    listDonHangKienHang.Add(donHangkienHang);
                }
                return listDonHangKienHang;
            }
            return new List<DonHangKienHang>();
        }
        /// <summary>
        /// Danh sách đơn hàng đang chờ
        /// </summary>
        /// <returns></returns>
        public List<DonHang> GetDonHangWaitting()// Nguoi giao hang muon xem danh sach don hang dang cho`
        {
            var res = _donhangRepository.GetAll()
                .Where(p => p.TinhTrang == 0)
                .ToList();
            return res;
        }

        /// <summary>
        /// Danh sách các đơn hàng của user hiện tại
        /// </summary>
        /// <param name="tinhtrang"></param>
        /// <returns></returns>
        public List<DonHang> GetDonHangCurrentuser(int tinhtrang = 0) //lay cac don hang cua user
        {
            var res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName && p.TinhTrang == tinhtrang);
            return res.ToList();
        }
        /// <summary>
        /// Đơn hàng tồn tại trả về true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExists(object id)
        {
            if (GetById(id) != null)
                return true;
            return false;
        }

        public List<DonHang> SearchByKey(int? page, int? size, string key)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = Constant.DefaultSize;
            var res = _donhangRepository.GetAll().Where(p=>p.TenTaiKhoan.Contains(key)).OrderBy(p => p.TinhTrang).Take(size.Value).Skip((page.Value - 1) * page.Value).ToList();
            return res;
        }

        public int Update(DonHang input)
        {
            DonHang donhang_tam = _donhangRepository.SelectById(input.MaDonHang);
            donhang_tam.DiaChiGui = input.DiaChiGui;
            donhang_tam.DiaChiNhan = input.DiaChiNhan;
            donhang_tam.GhiChu = input.GhiChu;
            donhang_tam.NguoiGui = input.NguoiGui;
            donhang_tam.NguoiNhan = input.NguoiNhan;
            donhang_tam.SoDienThoaiNguoiGui = input.SoDienThoaiNguoiGui;
            donhang_tam.SoDienThoaiNguoiNhan = input.SoDienThoaiNguoiNhan;
            donhang_tam.ThanhTien = input.ThanhTien;
            _donhangRepository.Update(donhang_tam);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = new JavaScriptSerializer().Serialize(input)
            });
            return donhang_tam.MaDonHang;
        }

        /// <summary>
        ///  Thay đổi tình trạng đơn hàng
        /// </summary>
        /// <param name="_input"></param>
        public void changeStatusDonHang(UpdateTrangThaiDonHang _input)
        {
            var donhang = _donhangRepository.SelectById(_input.MaDonHang);
            if(_input.TinhTrang == DonHangConstant.GiaoThanhCong)
            {
                donhang.ThoiDiemHoanThanhDH = DateTime.Now;
                _hoadonRepository.Insert(new HoaDon //Tạo hóa đơn cho đơn hàng hoàn thành
                {
                    MaDonHang = donhang.MaDonHang,
                    GhiChu = donhang.GhiChu,
                    MaNhanVienGH = donhang.MaNhanVienGiao,
                    ThanhTien = donhang.ThanhTien
                    //MaKhachHang = donhang.TenTaiKhoan,
                });
            }
            donhang.TinhTrang = _input.TinhTrang;
            _donhangRepository.Update(donhang);
        }
        public bool donHangIsOfUser(int MaDonHang)
        {
            if (_donhangRepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().TenTaiKhoan && p.MaDonHang == MaDonHang).ToList().Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}