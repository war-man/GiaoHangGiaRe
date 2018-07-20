using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface ILoaiKHServices
    {
        List<LoaiKhachHang> GetAll(int? page,int?size);
        LoaiKhachHang GetById(object id);
        bool Valid(object MaLoaiKH);
        void Create(LoaiKhachHang input);
        void Update(LoaiKhachHang input);
        void Delete(object id);

        int Count();
    }
}
