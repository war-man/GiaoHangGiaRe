using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public class KienHangModel
    {
       
    }
    public class KienHangView
    {
        public string SoDienThoai { set; get; }
        public int MaKienHang { set; get; }
        public string TenKhachHang { set; get; }
        public string TenNhanVien { set; get; }
        //public string KienHang { set; get; }
        public string GhiChu { set; get; }
        public int? TrongLuong { set; get; }
        public int? ChieuDai { set; get; }
        public int? ChieuRong { set; get; }
        public string DiaChiNhan { set; get; }
        public string DiaChiGui{ set; get; }
        public string CongTy {set;get;}
        public string Email { set; get; }
    }
}