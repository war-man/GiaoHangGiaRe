using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models
{
    public class DonHangSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public string TenTaiKhoan { set; get; }
        public int? MaNhanVien { set; get; }
        public string MaKhachHang { set; get; }
        public string TinhTrang { set; get; }

        public DonHangSearchList()
        {
            if(!this.page.HasValue){
                this.page = Constant.DefaultPage;
            }
            if (!this.size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
        }

        public DonHangSearchList(int? _page, int? _size, string _TenTaiKhoan, int? _MaNhanVien, string _TinhTrang, string _MaKhachHang)
        {
            if (!_page.HasValue)
            {
                this.page = Constant.DefaultPage;
            }
            if (!_size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
            if (!string.IsNullOrWhiteSpace(_TenTaiKhoan))
            {
                this.TenTaiKhoan = _TenTaiKhoan;
            }
            if (_MaNhanVien.HasValue)
            {
                this.MaNhanVien = _MaNhanVien.Value;
            }
            if (!string.IsNullOrWhiteSpace(_TinhTrang))
            {
                this.TinhTrang = _TinhTrang;
            }
            if (!string.IsNullOrWhiteSpace(_MaKhachHang))
            {
                this.MaKhachHang = _MaKhachHang;
            }
        }
    }
}
