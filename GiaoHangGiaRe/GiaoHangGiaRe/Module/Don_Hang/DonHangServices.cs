using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaoHangGiaRe.Models;
using Models.EntityModel;
using System.Web.Script.Serialization;
using System.Net;

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
        private IRepository<KhachHang> _khachhangRepository;
        private IRepository<NhanViens> _nhanvienRepository;
        private IRepository<Report> _reportRepository;
        public DonHangServices()
        {
            _donhangRepository = new IRepository<DonHang>();
            userServices = new UserServices();
            nhanVienServices = new NhanVienServices();
            lichSuServices = new LichSuServices();
            kienHangServices = new KienHangServices();
            _hoadonRepository = new IRepository<HoaDon>();
            _kienhangRepository = new IRepository<KienHang>();
            _khachhangRepository = new IRepository<KhachHang>();
            _reportRepository = new IRepository<Report>();
            _nhanvienRepository = new IRepository<NhanViens>();
        }
        public DonHangServices(IRepository<DonHang> donhangRepository)
        {
            _donhangRepository = donhangRepository;
        }

        public int count()
        {
            return this.count_list;
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

        public List<DonHangList> GetAll(DonHangSearchList donHangSearchList)
        {
            var query = from don_hang in _donhangRepository.GetAll()
                        select new
                        {
                            MaKhachHang = don_hang.MaKhachHang,
                            TenTaiKhoan = don_hang.TenTaiKhoan,
                            NguoiGui = don_hang.NguoiGui,
                            MaDonHang = don_hang.MaDonHang,
                            DiaChiGui = don_hang.DiaChiGui,
                            SoDienThoaiNguoiGui = don_hang.SoDienThoaiNguoiGui,
                            NguoiNhan = don_hang.NguoiNhan,
                            DiaChiNhan = don_hang.DiaChiNhan,
                            SoDienThoaiNguoiNhan = don_hang.SoDienThoaiNguoiNhan,
                            MaNhanVienGiao = don_hang.MaNhanVienGiao,
                            GhiChu = don_hang.GhiChu,
                            TinhTrang = don_hang.TinhTrang,
                            ThoiDiemDatDonHang = don_hang.ThoiDiemDatDonHang,
                            ThoiDiemTiepNhanDon = don_hang.ThoiDiemTiepNhanDon,
                            ThoiDiemHoanThanhDH = don_hang.ThoiDiemHoanThanhDH,
                            ThanhTien = don_hang.ThanhTien,
                            MaHanhTrinh = don_hang.MaHanhTrinh
                        };
            if(!string.IsNullOrWhiteSpace(donHangSearchList.TenTaiKhoan)){
                query = query.Where(prop => prop.TenTaiKhoan.ToLower().Contains(donHangSearchList.TenTaiKhoan.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(donHangSearchList.MaKhachHang))
            {
                query = query.Where(prop => prop.MaKhachHang.ToString() == donHangSearchList.MaKhachHang);
            }
            if (donHangSearchList.MaNhanVien.HasValue)
            {
                query = query.Where(prop => prop.MaNhanVienGiao == donHangSearchList.MaNhanVien.Value);
            }
            if (!string.IsNullOrWhiteSpace(donHangSearchList.TinhTrang))
            {
                query = query.Where(prop => prop.TinhTrang.ToString() == donHangSearchList.TinhTrang);
            }
            this.count_list = query.Count();
            query = query.Skip(donHangSearchList.page.Value * donHangSearchList.size.Value).Take(donHangSearchList.size.Value);

            List<DonHangList> donHangLists = new List<DonHangList>();
            DonHangList listdonhang;
            foreach(var dh in query){
                listdonhang = new DonHangList();
                listdonhang.NguoiGui = dh.NguoiGui;
                listdonhang.MaKhachHang = dh.MaKhachHang;
                listdonhang.TenTaiKhoan = dh.TenTaiKhoan;
                listdonhang.MaDonHang = dh.MaDonHang;
                listdonhang.DiaChiGui = dh.DiaChiGui;
                listdonhang.SoDienThoaiNguoiGui = dh.SoDienThoaiNguoiGui;
                listdonhang.NguoiNhan = dh.NguoiNhan;
                listdonhang.DiaChiNhan = dh.DiaChiNhan;
                listdonhang.SoDienThoaiNguoiNhan = dh.SoDienThoaiNguoiNhan;
                listdonhang.MaNhanVienGiao = dh.MaNhanVienGiao;
                listdonhang.GhiChu = dh.GhiChu;
                listdonhang.TinhTrang = dh.TinhTrang;
                listdonhang.ThoiDiemDatDonHang = dh.ThoiDiemDatDonHang;
                listdonhang.ThoiDiemTiepNhanDon = dh.ThoiDiemTiepNhanDon;
                listdonhang.ThoiDiemHoanThanhDH = dh.ThoiDiemHoanThanhDH;
                listdonhang.ThanhTien = dh.ThanhTien;
                listdonhang.MaHanhTrinh = dh.MaHanhTrinh;
                donHangLists.Add(listdonhang);
            }
            return donHangLists;
        }
        public int count_list { set; get; }

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
                p.TinhTrang != DonHangConstant.Huy && p.TinhTrang != DonHangConstant.GiaoThanhCong && p.TinhTrang != DonHangConstant.KhongTheLayHang)
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
        /// Lấy danh sách đơn hàng của shiper đã hoàn thành hoặc đã hủy`
        /// </summary>
        /// <returns></returns>
        public List<DonHangKienHang> GetLichSuDonHangCurrentShipper()
        {
            if (nhanVienServices.GetNhanVienCurrentUser() != null)
            {
                List<DonHangKienHang> listDonHangKienHang = new List<DonHangKienHang>();
                var res = _donhangRepository.GetAll()
                .Where(p => p.MaNhanVienGiao == (nhanVienServices.GetNhanVienCurrentUser().MaNhanVien) &&
                (p.TinhTrang == DonHangConstant.Huy || p.TinhTrang == DonHangConstant.GiaoThanhCong || p.TinhTrang == DonHangConstant.KhongTheLayHang))
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
        public List<DonHang> GetDonHangCurrentuser(int? tinhtrang = null) //lay cac don hang cua user
        {
            var res = new List<DonHang>();
            if (tinhtrang != null)
            {
                res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName && p.TinhTrang == tinhtrang).ToList();
            }
            else
            {
                res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName).ToList();
            }
            
            return res;
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
        /// Xác nhận đơn hàng 
        /// </summary>
        public int XacNhanDonHang(int MaDonHang)
        {
            var dh = _donhangRepository.SelectById(MaDonHang);
            if (dh.TinhTrang == 0 )
            {
                dh.TinhTrang = DonHangConstant.XacNhan;
            }
            _donhangRepository.Update(dh);
            return dh.MaDonHang;
        }
        /// <summary>
        /// Huỷ đơn hàng 
        /// </summary>
        public int HuyDonHang(int MaDonHang)
        {
            var dh = _donhangRepository.SelectById(MaDonHang);
            dh.TinhTrang = DonHangConstant.Huy;
            _donhangRepository.Update(dh);
            return dh.MaDonHang;
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
                if(_khachhangRepository.GetAll().Any(p => p.TenTaiKhoan == donhang.TenTaiKhoan)){

                    var kh = _khachhangRepository.GetAll().Where(p => p.TenTaiKhoan == donhang.TenTaiKhoan).SingleOrDefault().MaKhachHang;
                    donhang.ThoiDiemHoanThanhDH = DateTime.Now;
                    if (donhang.ThanhTien == null)
                    {
                        donhang.ThanhTien = 0;
                    }
                    donhang.TinhTrang = DonHangConstant.GiaoThanhCong;
                    var dh = new HoaDon //Tạo hóa đơn cho đơn hàng hoàn thành
                    {
                        MaDonHang = donhang.MaDonHang,
                        GhiChu = donhang.GhiChu,
                        MaNhanVienGH = donhang.MaNhanVienGiao,
                        ThanhTien = donhang.ThanhTien,
                        MaKhachHang = kh
                    };
                    _hoadonRepository.Insert(dh);                   
                }
            }
            else
            {
                if(_input.TinhTrang == DonHangConstant.DaTiepNhan) //Chuyển trạng thái đơn hàng đang chờ thành giao hàng
                {
                    donhang.MaNhanVienGiao = nhanVienServices.GetNhanVienCurrentUser().MaNhanVien;
                    donhang.ThoiDiemTiepNhanDon = DateTime.Now;
                }
                donhang.TinhTrang = _input.TinhTrang;// Cập nhật tình trạng
            }
            _donhangRepository.Update(donhang);
        }
        public void ReportDonHang(Report input)
        {
            if( _donhangRepository.GetAll().Any(p => p.MaDonHang == input.MaDonHang)){
                changeStatusDonHang(new UpdateTrangThaiDonHang
                {
                    MaDonHang = input.MaDonHang,
                    TinhTrang = DonHangConstant.Huy
                });
                input.MaNhanVien = nhanVienServices.GetNhanVienCurrentUser().MaNhanVien;
                input.Report_Type = ReportTypeConstant.DonHang;
                _reportRepository.Insert(input);
            }
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