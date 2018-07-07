using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Module
{
    public class TinNhanServices:ITinNhanServices
    {
        private IRepository<TinNhan> _repositoryTinhNhan;
        public TinNhanServices()
        {
            _repositoryTinhNhan = new IRepository<TinNhan>();
        }
        public int Count()
        {
            return _repositoryTinhNhan.GetAll().Count();
        }

        public void Create(TinNhan input)
        {
            _repositoryTinhNhan.Insert(input);
        }

        public void Delete(object id)
        {
            _repositoryTinhNhan.Delete(id);
        }

        public List<TinNhan> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = 1;
            if (!size.HasValue) return _repositoryTinhNhan.GetAll().OrderBy(p => p.MaTinNhan).ToList();
            var res = _repositoryTinhNhan.GetAll().OrderBy(p => p.MaTinNhan)
                .Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public TinNhan GetById(object id)
        {
            return _repositoryTinhNhan.SelectById(id);
        }

        public void Update(TinNhan input)
        {
            _repositoryTinhNhan.Update(input);
        }
    }
}