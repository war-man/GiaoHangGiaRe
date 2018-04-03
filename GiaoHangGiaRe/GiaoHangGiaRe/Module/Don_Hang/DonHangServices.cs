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
        public DonHangServices()
        {
            _donhangRepository = new IRepository<DonHang>();
            userServices = new UserServices();
            nhanVienServices = new NhanVienServices();
            lichSuServices = new LichSuServices();
            kienHangServices = new KienHangServices();
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
            List<DonHang> res ;
            if (user_name == null)
                user_name = "";
            if (ma_nhanvien == null)
            {
                res = _donhangRepository.GetAll().Where(p => p.TinhTrang>= 0)
                .OrderBy(p => p.MaDonHang)
                .Take(size.Value)
                .Skip(size.Value * (size.Value * (page.Value - 1))).ToList();
            }
            else
            {
                res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan.Contains(user_name) && p.MaNhanVienGiao == ma_nhanvien)
                .Skip((page.Value - 1) * size.Value)
               .Take(size.Value).ToList();
            }
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

        public List<DonHang> GetDonHangCurrentShipper()// Nguoi giao hang muon xem danh sach don hang minh giao
        {
            if (nhanVienServices.GetNhanVienCurrentUser() != null)
            {
                var res = _donhangRepository.GetAll()
                .Where(p => p.MaNhanVienGiao == (nhanVienServices.GetNhanVienCurrentUser().MaNhanVien))
                .ToList();
                return res;
            }
            return new List<DonHang>();
        }

        public List<DonHang> GetDonHangWaitting()// Nguoi giao hang muon xem danh sach don hang dang cho`
        {
            var res = _donhangRepository.GetAll()
                .Where(p => p.TinhTrang == 0)
                .ToList();
            return res;
        }

        public List<DonHang> GetDonHangCurrentuser() //lay cac don hang cua user
        {
            var res = _donhangRepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName);
            return res.ToList();
        }

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
            _donhangRepository.Update(input);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = new JavaScriptSerializer().Serialize(input)
            });
            return input.MaDonHang;
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