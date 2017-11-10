using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class NoServices : INoServices
    {
        private IRepository<No> _noRepository;
        private LichSuServices lichSuServices;
        public NoServices()
        {
            _noRepository = new IRepository<No>();
            lichSuServices = new LichSuServices();
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

        public List<No> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) return _noRepository.GetAll().ToList();
            return _noRepository.GetAll().OrderBy(p => p.Ma)
                    .Take(size.Value).Skip(size.Value * (page.Value - 1)).ToList();
        }

        public No GetById(int Id)
        {
            return _noRepository.SelectById(Id);
        }
   

        public List<No> GetNoOfKH(int MaKH)
        {
            return _noRepository.GetAll().Where(p => p.MaKhachHang == MaKH).ToList();
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
    }
}