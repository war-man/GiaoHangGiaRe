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
        private LoaiKHServices loaiKHServices;
        public KhachHangServices()
        {
            _loaikhachhangrepository = new IRepository<LoaiKhachHang>();
            _khachhangrepository = new IRepository<KhachHang>();
            userServices = new UserServices();
            lichSuServices = new LichSuServices();
            loaiKHServices = new LoaiKHServices();
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
        public List<KhachHangList> GetAll(KhachHangSearchList khachHangSearchList)
        {
            var query = from kh in _khachhangrepository.GetAll()
                        join loaikh in _loaikhachhangrepository.GetAll() on kh.MaLoaiKH equals loaikh.MaLoaiKH
                        select new
                        {
                TrangThai = kh.TrangThai,
                MaKhachHang = kh.MaKhachHang,
                TenLoaiKH = loaikh.TenLoaiKH,
                TenKhachHang = kh.TenKhachHang,
                SoDienThoai = kh.SoDienThoai,
                DiaChi = kh.DiaChi,
                Email = kh.Email,
                TenTaiKhoan = kh.TenTaiKhoan,
                MaLoaiKH = kh.MaLoaiKH
                             
            };
            if(!string.IsNullOrWhiteSpace(khachHangSearchList.TaiKhoan)){
                query = query.Where(p => p.TenTaiKhoan.ToLower().Contains(khachHangSearchList.TaiKhoan.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(khachHangSearchList.HoTen))
            {
                query = query.Where(p => p.TenKhachHang.ToLower().Contains(khachHangSearchList.HoTen.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(khachHangSearchList.DiaChi))
            {
                query = query.Where(p => p.DiaChi.ToLower().Contains(khachHangSearchList.DiaChi.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(khachHangSearchList.SoDienThoai))
            {
                query = query.Where(p => p.SoDienThoai.ToLower().Contains(khachHangSearchList.SoDienThoai.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(khachHangSearchList.LoaiKH))
            {
                query = query.Where(p => p.MaLoaiKH.ToString().Contains(khachHangSearchList.LoaiKH));
            }
            if (!string.IsNullOrWhiteSpace(khachHangSearchList.TrangThai))
            {
                query = query.Where(p => p.TrangThai.ToString()==khachHangSearchList.TrangThai);
            }
            this.count_list = query.Count();
            query = query.OrderBy(p => p.MaKhachHang).Skip(khachHangSearchList.size.Value * khachHangSearchList.page.Value)
                         .Take(khachHangSearchList.size.Value).OrderByDescending(prop => prop.MaKhachHang);

            List<KhachHangList> listKhachHang = new List<KhachHangList>();
            foreach(var i in query)
            {
                KhachHangList kh = new KhachHangList();
                kh.MaKhachHang = i.MaKhachHang;
                kh.TenKhachHang = i.TenKhachHang;
                kh.SoDienThoai = i.SoDienThoai;
                kh.DiaChi = i.DiaChi;
                kh.Email = i.Email;
                kh.LoaiKH = i.TenLoaiKH;
                kh.TenTaiKhoan = i.TenTaiKhoan;
                kh.MaLoaiKH = i.MaLoaiKH.ToString();

                listKhachHang.Add(kh);
            }
            return listKhachHang;
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

        public void Setlock_Unlock(int MaKhachHang)
        {
            var kh = GetById(MaKhachHang);
            if(kh.TrangThai== 0 )
                kh.TrangThai = 1; // Unlock
            if (kh.TrangThai == 1)
                kh.TrangThai = 0; //Lock
        }

        public void Update(KhachHangUpdate input)
        {
            var khach_hang = GetById(input.MaKhachHang);
            if(khach_hang == null){
                return;
            }
            if(!string.IsNullOrWhiteSpace(input.DiaChi)){
                khach_hang.DiaChi = input.DiaChi;
            }
            if (!string.IsNullOrWhiteSpace(input.Email))
            {
                khach_hang.Email = input.Email;
            }
            if (!string.IsNullOrWhiteSpace(input.TenKhachHang))
            {
                khach_hang.TenKhachHang = input.TenKhachHang;
            }
            if (!string.IsNullOrWhiteSpace(input.SoDienThoai))
            {
                khach_hang.SoDienThoai = input.SoDienThoai;
            }
            if(loaiKHServices.Valid(int.Parse(input.MaLoaiKH))){
                khach_hang.MaLoaiKH = int.Parse(input.MaLoaiKH);         
            }
            _khachhangrepository.Update(khach_hang);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.KhachHang,
                NoiDung = Constant.CvtToString(input)
            });
        }

        public List<KhachHang> GetByLoaiKH(int MaLoaiKH)
        {
            return _khachhangrepository.GetAll().Where(prop => prop.MaLoaiKH == MaLoaiKH).ToList();
        }
    }
    enum TrangThaiKhachHang
    {
        Lock=0,
        UnLock=1
    }
}