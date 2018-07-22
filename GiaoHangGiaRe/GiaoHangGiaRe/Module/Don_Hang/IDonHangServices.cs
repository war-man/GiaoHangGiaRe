using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModel;
using GiaoHangGiaRe.Models;

namespace GiaoHangGiaRe.Module
{
    interface IDonHangServices
    {
        //dung cho phuong  thuc GET
        List<DonHangList> GetAll(DonHangSearchList donHangSearchList);
        DonHang GetById(object id);
        List<DonHang> GetByUser(object username);
        List<DonHang> GetDonHangCurrentuser(int? tinhtrang);
        List<DonHangKienHang> GetDonHangCurrentShipper();

        List<DonHang> GetByKhoChua(int MaKhoChua);
        List<DonHang> GetDonHangWaitting();

        //dung cho phuong thuc POST
        int Create(DonHang input);

        //dung cho phuong  thuc PUT
        int Update(DonHang input);

        //dung cho phuong  thuc PUT
        int XacNhanDonHang(int MaDonHang);

        //dung cho phuong  thuc DELETE
        void Delete(object id);

        //dung cho phuong thuc khac
        int count();
        bool IsExists(object id);
        bool donHangIsOfUser(int MaDonHang);

    }
}
