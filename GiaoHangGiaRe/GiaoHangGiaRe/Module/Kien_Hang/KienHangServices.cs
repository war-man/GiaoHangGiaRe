using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;
using System.Net;

namespace GiaoHangGiaRe.Module
{
    public class KienHangServices : IKienHangServices
    {
        IRepository<KienHang> _repositoryKienHang;
        public KienHangServices()
        {
            _repositoryKienHang = new IRepository<KienHang>();
        }

        public int Count()
        {
            return _repositoryKienHang.GetAll().Count();
        }

        public void Create(KienHang input)
        {
            //MaDonHang tu gen
            _repositoryKienHang.Insert(input);
        }

        public void Delete(object id)
        {
            _repositoryKienHang.Delete(id);
        }

        public List<KienHang> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = Constant.DefaultSize;
            return _repositoryKienHang.GetAll().OrderBy(p=>p.MaDonHang).Take(size.Value).Skip((page.Value-1)*size.Value).ToList();
            
        }

        public KienHang GetById(object id)
        {
            return _repositoryKienHang.SelectById(id);
        }

        public List<KienHang> GetByKhoChua(int MaKhoChua)
        {
            return _repositoryKienHang.GetAll().Where(p => p.MaKhoChua == MaKhoChua).ToList();
        }

        public KienHang GetByMaDonHang(int MaDonHang)
        {
            return _repositoryKienHang.GetAll().Where(p => p.MaDonHang == MaDonHang).FirstOrDefault();
        }

        public bool IsExists(object id)
        {
            if (_repositoryKienHang.SelectById(id) == null)
                return false;
            return true;
        }

        public List<KienHang> SearchByKey(int? page, int? size, string key)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = Constant.DefaultSize;
            return _repositoryKienHang.GetAll().Where(p=>p.NoiDung.Contains(key)).OrderBy(p => p.MaDonHang).Take(size.Value).Skip((page.Value - 1) * size.Value).ToList();
        }

        public void Update(KienHang input)
        {
            _repositoryKienHang.Insert(input);
        }
    }
}