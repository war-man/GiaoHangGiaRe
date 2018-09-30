using System;
namespace GiaoHangGiaRe.Models
{
    public class DonHangList
    {
        public int MaDonHang { get; set; }
        public string NguoiGui { get; set; }
        public string DiaChiGui { get; set; }
        public string SoDienThoaiNguoiGui { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string SoDienThoaiNguoiNhan { get; set; }
        public int? MaNhanVienGiao { get; set; }
        public string GhiChu { get; set; }
        public int TinhTrang { get; set; }
        public DateTime? ThoiDiemDatDonHang { get; set; }
        public DateTime? ThoiDiemTiepNhanDon { get; set; }
        public DateTime? ThoiDiemHoanThanhDH { get; set; }
        public int? ThanhTien { get; set; }

        public string TenTaiKhoan { get; set; }

        public int MaKhachHang { get; set; }
        public int? MaHanhTrinh { get; set; }
        public int? cod { get; set; }
        public DonHangList()
        {
        }
    }
}
