using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaoHangGiaRe.Models.KhachHang;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class KhachHangServices : IKhachHangServices
    {
        private IRepository<KhachHang> _khachhangrepository;
        private IRepository<LoaiKhachHang> _loaikhachhangrepository;
        private UserServices userServices;
        private LichSuServices lichSuServices;
        public KhachHangServices()
        {
            _loaikhachhangrepository = new IRepository<LoaiKhachHang>();
            _khachhangrepository = new IRepository<KhachHang>();
            userServices = new UserServices();
            lichSuServices = new LichSuServices();
        }
        public int Count()
        {
            return _khachhangrepository.GetAll().Count();
        }

        public void Create(KhachHang input)
        {
            input.TrangThai = 1;
            _khachhangrepository.Insert(input);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                HanhDong = Constant.CreateAction,
                ViTriThaoTac = Constant.KhachHang,
                NoiDung = Constant.CvtToString(input)
            });
        }

        public void Delete(int id)
        {
            _khachhangrepository.Delete(id);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                HanhDong = Constant.DeleteAction,
                ViTriThaoTac = Constant.KhachHang,
                NoiDung = id.ToString()
            });
        }
        public int count_list { set; get; }
        public List<KhachHang> GetAll(KhachHangSearchList khachHangSearchList)
        {
            from khachhang in _khachhangrepository.GetAll()
                                                  join loaikh in _loaikhachhangrepository.GetAll()
                                                  on khachhang.MaLoaiKH equals loaikh.MaLoaiKH;
            var query = _khachhangrepository.GetAll()
                        .Join(_loaikhachhangrepository.GetAll(),khachhang => khachhang.MaLoaiKH, loaikh => loaikh.MaLoaiKH,
                                                                        (khachhang,loaikh) => new {  KhachHang = khachhang ,LoaiKhachHang = loaikh}
                                                          );
            if(string.IsNullOrWhiteSpace(khachHangSearchList.TaiKhoan)){
                query = query.Where(p => p.KhachHang.TenTaiKhoan.ToLower().Contains(khachHangSearchList.TaiKhoan.ToLower()));
            }
            if (string.IsNullOrWhiteSpace(khachHangSearchList.HoTen))
            {
                query = query.Where(p => p.KhachHang.TenKhachHang.ToLower().Contains(khachHangSearchList.HoTen.ToLower()));
            }
            if (string.IsNullOrWhiteSpace(khachHangSearchList.DiaChi))
            {
                query = query.Where(p => p.KhachHang.DiaChi.ToLower().Contains(khachHangSearchList.DiaChi.ToLower()));
            }
            if (string.IsNullOrWhiteSpace(khachHangSearchList.SoDienThoai))
            {
                query = query.Where(p => p.KhachHang.SoDienThoai.ToLower().Contains(khachHangSearchList.SoDienThoai.ToLower()));
            }
            if (string.IsNullOrWhiteSpace(khachHangSearchList.LoaiKH))
            {
                query = query.Where(p => p.LoaiKhachHang.TenLoaiKH.ToLower().Contains(khachHangSearchList.LoaiKH.ToLower()));
            }

            query = query.OrderBy(p => p.KhachHang.MaKhachHang).Take(khachHangSearchList.size.Value)
                                       .Skip(khachHangSearchList.size.Value * khachHangSearchList.page.Value);
            this.count_list = query.Count();
  
            return null;
        }

        public KhachHang GetById(int id)
        {
            return _khachhangrepository.SelectById(id);
        }

        public KhachHang GetCurrentKhacHang()
        {
            var res = _khachhangrepository.GetAll().Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName)
                .FirstOrDefault();
            return res;            
        }

        public KhachHang GetKhacHangOfUser(object username)
        {
            var res = _khachhangrepository.GetAll().Where(p => p.TenTaiKhoan == username.ToString())
                 .FirstOrDefault();
            return res;
        }

        public void Setlock_Unlock(object username)
        {
            var kh = GetKhacHangOfUser(username);
            if(kh.TrangThai== 0)
                kh.TrangThai = 1; // Unlock
            if (kh.TrangThai == 1)
                kh.TrangThai = 0; //Lock
        }

        public void Update(KhachHang input)
        {
            _khachhangrepository.Update(input);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.KhachHang,
                NoiDung = Constant.CvtToString(input)
            });
        }
    }
    enum TrangThaiKhachHang
    {
        Lock=0,
        UnLock=1
    }
}