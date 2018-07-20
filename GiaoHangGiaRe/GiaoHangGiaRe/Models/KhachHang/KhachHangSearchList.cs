using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models.KhachHang
{
    public class KhachHangSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public string HoTen { set; get; }
        public string SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string Email { set; get; }
        public string LoaiKH { set; get; }
        public string TaiKhoan { set; get; }

        public KhachHangSearchList()
        {
            if(!this.page.HasValue){
                this.page = Constant.DefaultPage;
            }
            if (!this.size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
        }
        public KhachHangSearchList(int? _page, int? _size, string HoTen, string SoDienThoai, string DiaChi, string Email, string LoaiKH, string TaiKhoan)
        {
            if (_page.HasValue)
            {
                this.page = _page;
            }
            if (_size.HasValue)
            {
                this.size = _size;
            }
            if(!string.IsNullOrWhiteSpace(HoTen)){
                this.HoTen = HoTen;
            }
            if (!string.IsNullOrWhiteSpace(SoDienThoai))
            {
                this.SoDienThoai = SoDienThoai;
            }
            if (!string.IsNullOrWhiteSpace(DiaChi))
            {
                this.DiaChi = DiaChi;
            }
            if (!string.IsNullOrWhiteSpace(Email))
            {
                this.Email = Email;
            }
            if (!string.IsNullOrWhiteSpace(LoaiKH))
            {
                this.LoaiKH = LoaiKH;
            }
            if (!string.IsNullOrWhiteSpace(TaiKhoan))
            {
                this.TaiKhoan = TaiKhoan;
            }

        }
    }
}
