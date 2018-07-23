using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Models.NhanVien;
using Models.EntityModel;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GiaoHangGiaRe.Module
{
    public class NhanVienServices:INhanVienServices
    {
        private IRepository<NhanViens> _repositoryNhanVien;
        private UserServices userServices;
        private LichSuServices lichSuServices;
        public NhanVienServices()
        {
            _repositoryNhanVien = new IRepository<NhanViens>();
            userServices = new UserServices();
            lichSuServices = new LichSuServices();
        }
        public int Count()
        {
            return _repositoryNhanVien.GetAll().Count();
        }

        public void Create(NhanVienCreate input)
        {
            if(userServices.GetAll().Any(p=>p.TenTaiKhoan == input.TenTaiKhoan)){

                input.TrangThai = 1; //default
            
                _repositoryNhanVien.Insert(new NhanViens {
                    TenTaiKhoan = input.TenTaiKhoan,
                    TenNhanVien = input.TenNhanVien,
                    ChucVu = input.ChucVu,
                    DiaChi = input.DiaChi,
                    Email = input.Email,
                    NgaySinh = input.NgaySinh,
                    NgayBatDau = input.NgayBatDau,
                    SoDienThoai = input.SoDienThoai,
                    TrangThai = input.TrangThai
                });
                lichSuServices.Create(new LichSu
                {
                    HanhDong = Constant.CreateAction,
                    TenTaiKhoan = userServices.GetCurrentUser().UserName,
                    NoiDung = Constant.CvtToString(input),
                    ViTriThaoTac = Constant.NhanVien
                });
            }
            else
            {
                //throw Response
            }
        }

        /// <summary>
        /// Tạo nhân viên từ thông tin user có sẵn
        /// </summary>
        /// <param name="user"></param>
        public void CreateNhanVien_from_User(ApplicationUser user)
        {
            NhanViens nhanvien = new NhanViens
            {
                Email = user.Email,
                DiaChi = user.DiaChi,
                SoDienThoai = user.PhoneNumber,
                TenTaiKhoan = user.TenTaiKhoan,
                TenNhanVien = user.HoTen,
                NgayBatDau = DateTime.Now
            };
            _repositoryNhanVien.Insert(nhanvien);
        }
        public void Change_TinhTrang(object id)
        {
            var nhan_vien = _repositoryNhanVien.SelectById(id);
            if(nhan_vien.TrangThai == NhanVienConstant.Active)
            {
                nhan_vien.TrangThai = NhanVienConstant.StopActive;
            }
            else
            {
                nhan_vien.TrangThai = NhanVienConstant.Active;
            }
            _repositoryNhanVien.Update(nhan_vien);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = id.ToString(),
                ViTriThaoTac = Constant.NhanVien
            });
        }
        public int count_list { set; get; }
        public List<NhanViens> GetAll(NhanVienSearchList nhanVienSearchList)
        {
            if(!nhanVienSearchList.page.HasValue || nhanVienSearchList.page == null){
                nhanVienSearchList.page = Constant.DefaultPage;
            }
            if (!nhanVienSearchList.size.HasValue|| nhanVienSearchList.size == null)
            {
                nhanVienSearchList.size = Constant.DefaultPage;
            }
            var query = _repositoryNhanVien.GetAll();
            if(!string.IsNullOrWhiteSpace(nhanVienSearchList.TenTaiKhoan)){
                query = query.Where(p => p.TenTaiKhoan.ToLower().Contains(nhanVienSearchList.TenTaiKhoan.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(nhanVienSearchList.TenNhanVien))
            {
                query = query.Where(p => p.TenNhanVien.ToLower().Contains(nhanVienSearchList.TenNhanVien.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(nhanVienSearchList.ChucVu))
            {
                query = query.Where(p => p.ChucVu.ToLower().Contains(nhanVienSearchList.ChucVu.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(nhanVienSearchList.Email))
            {
                query = query.Where(p => p.Email.ToLower().Contains(nhanVienSearchList.Email.ToLower()));
            }
            if (nhanVienSearchList.TrangThai.HasValue)
            {
                query = query.Where(p => p.TrangThai == nhanVienSearchList.TrangThai.Value);
            }
            query = query.Take(nhanVienSearchList.size.Value)
                         .Skip(nhanVienSearchList.size.Value * (nhanVienSearchList.page.Value)).OrderBy(p => p.MaNhanVien);
            this.count_list = query.Count();
            return query.ToList();
        }

        public NhanViens GetById(object id)
        {
            return _repositoryNhanVien.SelectById(id);
        }

        public void Update(NhanVienUpdate input)
        {
            var nhanvien = this.GetById(input.MaNhanVien);
            if(!string.IsNullOrWhiteSpace(input.TenNhanVien)){
                nhanvien.TenNhanVien = input.TenNhanVien;
            }
            if (!string.IsNullOrWhiteSpace(input.Email))
            {
                nhanvien.Email = input.Email;
            }
            if (!string.IsNullOrWhiteSpace(input.DiaChi))
            {
                nhanvien.DiaChi = input.DiaChi;
            }
            if (!string.IsNullOrWhiteSpace(input.ChucVu))
            {
                nhanvien.ChucVu = input.ChucVu;
            }
            _repositoryNhanVien.Update(nhanvien);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.NhanVien
            });
        }
        public NhanViens GetNhanVienByUser(object username)
        {
            var res=_repositoryNhanVien.GetAll().Where(p => p.TenTaiKhoan == username.ToString()).FirstOrDefault();
            return res;
        }
        /// <summary>
        /// Xem UserId có tồn tại trong bảng nhân viên hay không?
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsNhanVien(string Id)
        {
            bool re = _repositoryNhanVien.GetAll().Where(p => p.TenTaiKhoan == userServices.GetById(Id).UserName.ToString()).Count() > 0;
            return re;
        }
        public NhanViens GetNhanVienCurrentUser()
        {
            var res = _repositoryNhanVien.GetAll().
                Where(p => p.TenTaiKhoan == userServices.GetCurrentUser().UserName.ToString())
                .FirstOrDefault();
            return res;
        }

    }

    enum PhanLoaiNhanVien
    {
        Admin = 0,
        NhanVien =1,
        GiaoHang=2
    }
}