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
        List<DonHang> GetAll(int? page, int? size, string user_name, string user_id, int? ma_nhanvien, int? tinhtrang);
        List<DonHang> SearchByKey(int? page, int? size, string key);
        DonHang GetById(object id);
        List<DonHang> GetByUser(object username);
        List<DonHang> GetDonHangCurrentuser(int tinhtrang);
        List<DonHang> GetDonHangCurrentShipper();

        List<DonHang> GetByKhoChua(int MaKhoChua);

        //dung cho phuong thuc POST
        int Create(DonHang input);

        //dung cho phuong  thuc PUT
        int Update(DonHang input);

        //dung cho phuong  thuc DELETE
        void Delete(object id);

        //dung cho phuong thuc khac
        int count();
        bool IsExists(object id);
        bool donHangIsOfUser(int MaDonHang);

    }
}
