using Models.EntityModel;
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

        public void Create(NhanViens input)
        {
            _repositoryNhanVien.Insert(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.CreateAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.NhanVien
            });
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