using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Module
{
    public class ReportServices : IReportServices
    {
        private IRepository<Report> _repositoryReport;

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Create(Report input)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAll(int? page, int? size)
        {
            throw new NotImplementedException();
        }

        public Report GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(Report input)
        {
            throw new NotImplementedException();
        }
    }
}