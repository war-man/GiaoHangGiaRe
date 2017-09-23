using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    interface IDonHangServices
    {
        List<DonHang> GetAll(int? page, int? size);
        List<DonHang> SearchByKey(int? page, string key);
        DonHang GetById(int id);

        int Create(DonHang input);
        int Update(DonHang input);
        int Delete(DonHang input);
    }
}
