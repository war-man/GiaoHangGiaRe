using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IHoaDonServices
    {
        //su dung cho phuong thuc GET
        HoaDon GetById(int id);
        List<HoaDon> GetAll(int?page,int? size);
        List<HoaDon> GetHoaDonOfCurrnetuser();
        List<HoaDon> GetHoaDonOfUser(object username);
        List<HoaDon> GetDonHangByMaKhachHang(int MaKH);


        //su dung cho phuong thuc CREATE
        void Create(HoaDon input);

        //su dung cho phuong thuc UPDATE
        void Update(HoaDon input);

        //su dung cho phuong thuc DELETE
        void Delete(int id);

        //su dung cho phuong thuc khac
        int Count();
    }
}
