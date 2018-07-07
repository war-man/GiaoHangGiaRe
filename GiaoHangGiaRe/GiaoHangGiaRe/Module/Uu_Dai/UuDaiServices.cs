using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class UuDaiServices : IUuDaiServices
    {
        private IRepository<UuDai> _uudaiRepository;
        private UserServices userServices;
        private LichSuServices lichSuServices;
        private KhachHangServices khachHangServices;
        public UuDaiServices()
        {
            khachHangServices = new KhachHangServices();
            _uudaiRepository = new IRepository<UuDai>();
            userServices = new UserServices();
            lichSuServices = new LichSuServices();

        }
        public int Count()
        {
            return _uudaiRepository.GetAll().Count();
        }

        public void Create(UuDai input)
        {
            _uudaiRepository.Insert(input);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan =userServices.GetCurrentUser().UserName,
                HanhDong = Constant.CreateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = Constant.CvtToString(input)
            });
        }

        public void Delete(int id)
        {
            _uudaiRepository.Delete(id);
            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan =userServices.GetCurrentUser().UserName,
                HanhDong = Constant.DeleteAction,
                ViTriThaoTac = Constant.User,
                NoiDung = id.ToString()
            });
        }

        public List<UuDai> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!page.HasValue) return _uudaiRepository.GetAll().OrderBy(p => p.Ma).ToList();

            return _uudaiRepository.GetAll().OrderBy(p => p.Ma)
                    .Take(size.Value).Skip(size.Value * (page.Value - 1)).ToList();
        }

        public UuDai GetById(int Id)
        {
            return _uudaiRepository.SelectById(Id);
        }

        public List<UuDai> GetUuDaiOfCurrentUser()
        {
            return _uudaiRepository.GetAll().Where(
                p => p.DoiTuongApDung == khachHangServices.GetCurrentKhacHang().MaKhachHang
                ).ToList();
        }

        public List<UuDai> GetUuDaiOfKH(int MaKH)
        {
            return _uudaiRepository.GetAll().Where(p => p.DoiTuongApDung == MaKH).ToList();
        }

        public List<UuDai> GetUuDaiOfUser(object username)
        {
            return _uudaiRepository.GetAll()
                .Where(p => p.DoiTuongApDung == khachHangServices.GetKhacHangOfUser(username).MaKhachHang)
                .ToList();
        }

        public void Update(UuDai input)
        {
            _uudaiRepository.Update(input);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan =userServices.GetCurrentUser().UserName,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = Constant.CvtToString(input)
            });
        }
    }
}