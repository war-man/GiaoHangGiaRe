using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Module
{
    public class LoaiKHServices : ILoaiKHServices
    {
        private IRepository<LoaiKhachHang> _repositoryLoaiKH;
        public LoaiKHServices()
        {
            _repositoryLoaiKH = new IRepository<LoaiKhachHang>();
        }
        public int Count()
        {
            return _repositoryLoaiKH.GetAll().Count();
        }

        public void Create(LoaiKhachHang input)
        {
            _repositoryLoaiKH.Insert(input);
        }

        public void Delete(object id)
        {
            _repositoryLoaiKH.Delete(id);
        }

        public List<LoaiKhachHang> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = 1;
            if (!size.HasValue) return _repositoryLoaiKH.GetAll().OrderBy(p => p.MaLoaiKH).ToList();
            var res = _repositoryLoaiKH.GetAll().OrderBy(p => p.MaLoaiKH)
                .Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public LoaiKhachHang GetById(object id)
        {
            return _repositoryLoaiKH.SelectById(id);
        }

        public void Update(LoaiKhachHang input)
        {
            _repositoryLoaiKH.Update(input);
        }
    }
}