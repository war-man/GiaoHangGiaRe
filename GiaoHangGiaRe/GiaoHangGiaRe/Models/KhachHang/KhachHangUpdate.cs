using System;
namespace GiaoHangGiaRe.Models.KhachHang
{
    public class KhachHangUpdate
    {
        public int MaKhachHang { set; get; }
        public string TenKhachHang { set; get; }
        public string SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string Email { set; get; }
        public string MaLoaiKH { set; get; }

        public KhachHangUpdate()
        {
        }
        //public KhachHangUpdate(string HoTen, string SoDienThoai, string DiaChi, string Email, string MaLoaiKH )
        //{
        //}
    }
}
