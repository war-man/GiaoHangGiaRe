using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models.NhanVien
{
    public class NhanVienSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public string TenTaiKhoan { set; get; }
        public string ChucVu { set; get; }
        public string Email { get; set; }
        public string TenNhanVien { get; set; }
        public NhanVienSearchList()
        {
            this.page = Constant.DefaultPage;
            this.size = Constant.DefaultSize;
        }
        public NhanVienSearchList(int? _page,int? _size, string _TenTaiKhoan, string _ChucVu, string _Email, string _TenNhanVien)
        {
            if(_page.HasValue){
                this.page = _page;
            }
            if (_size.HasValue)
            {
                this.size = size;
            }
            if(!string.IsNullOrWhiteSpace(_TenTaiKhoan)){
                this.TenTaiKhoan = _TenTaiKhoan;
            }
            if (!string.IsNullOrWhiteSpace(_TenNhanVien))
            {
                this.TenNhanVien = _TenNhanVien;
            }
            if (!string.IsNullOrWhiteSpace(_ChucVu))
            {
                this.ChucVu = _ChucVu;
            }
            if (!string.IsNullOrWhiteSpace(_Email))
            {
                this.Email = _Email;
            }
        }
    }
}
