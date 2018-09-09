using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaoHangGiaRe.Models;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class NoServices : INoServices
    {
        private IRepository<No> _noRepository;
        private LichSuServices lichSuServices;
        private UserServices _userServices;
        public NoServices()
        {
            _noRepository = new IRepository<No>();
            lichSuServices = new LichSuServices();
            _userServices = new UserServices();
        }
        public int Count()
        {
            return _noRepository.GetAll().Count();
        }

        public void Create(No input)
        {
            input.ThoiGian = DateTime.Now;
            _noRepository.Insert(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.CreateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.No
            });
        }

        public void Delete(int id)
        {
            _noRepository.Delete(id);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.DeleteAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = id.ToString(),
                ViTriThaoTac = Constant.No
            });
        }

        public List<No> GetAll(NoSearchList noSearchList)
        {
            var query = _noRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(noSearchList.KyHieu))
            {
                query = query.Where(p => p.KyHieu.Contains(noSearchList.KyHieu));
            }
            return query.OrderBy(p => p.Ma)
                    .Take(noSearchList.size.Value).Skip(noSearchList.size.Value * (noSearchList.page.Value - 1)).ToList();
        }
        public List<No> GetNoCurrentUser(int? page, int? size, string KyHieu = "")
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) return _noRepository.GetAll().ToList();
            return _noRepository.GetAll().OrderBy(p => p.Ma)
                .Where(p=>p.MaKhachHang == _userServices.GetCurrentUser().Id && p.KyHieu.Contains(KyHieu))
                    .Take(size.Value).Skip(size.Value * (page.Value - 1)).ToList();
        }

        public No GetById(int Id)
        {
            return _noRepository.SelectById(Id);
        }
   

        public List<No> GetNoOfKH(int? page, int? size,string MaKH)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) return _noRepository.GetAll().ToList();
            return _noRepository.GetAll().Where(p => p.MaKhachHang == MaKH)
                .Take(size.Value).Skip(size.Value * (page.Value - 1)).ToList();
        }

        public void SetHoanThanh(int id)
        {
            var no = _noRepository.SelectById(id);
            no.TrangThai = 0;
            _noRepository.Update(no);
        }

        public void Update(No input)
        {
            _noRepository.Update(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.No
            });
        }

        public List<No> GetNoOfKH(int MaKH)
        {
            throw new NotImplementedException();
        }

        public int CountNoCurenUser()
        {
            return _noRepository.GetAll().Where(p => p.MaKhachHang == _userServices.GetCurrentUser().Id).Count();
        }
    }
}