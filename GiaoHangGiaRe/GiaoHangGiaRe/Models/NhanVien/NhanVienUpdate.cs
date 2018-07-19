using System;
namespace GiaoHangGiaRe.Models.NhanVien
{
    public class NhanVienUpdate
    {
        public int MaNhanVien { set; get; }

        public string TenNhanVien { get; set; }

        public string ChucVu { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public NhanVienUpdate()
        {
        }
    }
}
