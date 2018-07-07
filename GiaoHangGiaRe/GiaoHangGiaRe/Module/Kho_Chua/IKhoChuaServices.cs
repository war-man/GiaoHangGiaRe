using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IKhoChuaServices
    {
        //Cho phuong thuc GET
        List<KhoChua> GetAll(int? page, int? size);
        KhoChua GetById(int Id);
        KhoChua GetKhoChuaOfKienHang(int MaKienHang);
        KhoChua GetKhoChuaOfDonHang(int MaDonHang);

        //Cho phuong thuc POST
        void Create(KhoChua input);

        //Cho phuong thuc PUT
        void Update(KhoChua input);

        //Cho phuong thuc DELETE
        void Delete(int id);

        int Count();
    }
}
