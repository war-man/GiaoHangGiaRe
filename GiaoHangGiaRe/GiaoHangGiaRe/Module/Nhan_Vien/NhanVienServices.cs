using GiaoHangGiaRe.Models;
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
        public void Delete(object id)
        {
            _repositoryNhanVien.Delete(id);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.DeleteAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = id.ToString(),
                ViTriThaoTac = Constant.NhanVien
            });
        }

        public List<NhanViens> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = 1;
            if (!size.HasValue) return _repositoryNhanVien.GetAll().OrderBy(p => p.MaNhanVien).ToList();
            var res = _repositoryNhanVien.GetAll().OrderBy(p => p.MaNhanVien)
                .Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public NhanViens GetById(object id)
        {
            return _repositoryNhanVien.SelectById(id);
        }

        public void Update(NhanViens input)
        {
            _repositoryNhanVien.Update(input);
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