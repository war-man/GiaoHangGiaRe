using System;
namespace GiaoHangGiaRe.Models.KhachHang
{
    public class KhachHangList
    {
        public int MaKhachHang { set; get; }
        public string TenKhachHang { set; get; }
        public string SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string Email { set; get; }
        public string LoaiKH { set; get; }
        public string TenTaiKhoan { set; get; }
        public string MaLoaiKH { set; get; }
        public int TrangThai { set; get; }
        public KhachHangList (){
        }
    }
}
