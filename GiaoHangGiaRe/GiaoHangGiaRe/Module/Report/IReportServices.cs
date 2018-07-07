using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IReportServices
    {
        List<Report> GetAll(int? page, int? size);
        Report GetById(object id);

        void Create(Report input);
        void Update(Report input);
        void Delete(object id);

        int Count();
    }
}
