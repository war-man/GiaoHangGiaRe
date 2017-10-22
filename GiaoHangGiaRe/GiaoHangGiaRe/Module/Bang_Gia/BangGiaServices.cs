using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class BangGiaServices : IBangGiaServices
    {
        private readonly IRepository<BangGia> _banggiarepository;
        LichSuServices lichSuServices;
        public BangGiaServices()
        {
            _banggiarepository = new IRepository<BangGia>();
            lichSuServices = new LichSuServices();
        }
        
        public void Create(BangGia input)
        {
            _banggiarepository.Insert(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.CreateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = input.ToString(),
                ViTriThaoTac = "BangGia"
            });
        }

        public BangGia Delete(object id)
        {
            var banggia=_banggiarepository.SelectById(id);
            _banggiarepository.Delete(id);
            return banggia;
        }

        public List<BangGia> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = Constant.DefaultSize;
            var res = _banggiarepository.GetAll().OrderBy(p => p.Ma)
                .Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public BangGia GetById(object id)
        {
           return _banggiarepository.SelectById(id);
        }

        public void Update(BangGia input)
        {
            _banggiarepository.Update(input);
        }
        public int Count()
        {
            return _banggiarepository.GetAll().Count();
        }

        public bool IsExit(object id)
        {
            if (_banggiarepository.SelectById(id) == null)
                return false;
            return true;
        }
    }
}