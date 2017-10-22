using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IKienHangServices
    {
        //Cho phuong thuc GET
        List<KienHang> GetAll(int? page,int? size);
        KienHang GetById(object id);
        List<KienHang> SearchByKey(int? page, int? size, string key);
        KienHang GetByMaDonHang(int MaDonHang);
        List<KienHang> GetByKhoChua(int MaKhoChua);

        //Cho phuong thuc POST
        void Create(KienHang input);

        //Cho phuong thuc PUT
        void Update(KienHang input);

        //Cho phuong thuc DELETE
        void Delete(object id);
        bool IsExists(object id);

        int Count();
    }
}
