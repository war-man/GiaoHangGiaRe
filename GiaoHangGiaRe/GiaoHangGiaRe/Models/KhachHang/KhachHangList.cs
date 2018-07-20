using System;
namespace GiaoHangGiaRe.Models.KhachHang
{
    public class KhachHangList
    {
        public string TenKhachHang { set; get; }
        public string SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string Email { set; get; }
        public string LoaiKH { set; get; }
        public string TaiKhoan { set; get; }
        public KhachHangList (){
        }
        public KhachHangList(string TenKhachHang, string SoDienThoai, string DiaChi, string Email, string LoaiKH, string TaiKhoan)
        {
            
        }
    }
}
