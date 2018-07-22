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
        public int? MaKhachHang { set; get; }
        public int? TinhTrang { set; get; }

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

        public DonHangSearchList(int? page, int? size, string TenTaiKhoan, int? MaNhanVien, int? TinhTrang, int? MaKhachHang)
        {
            if (!page.HasValue)
            {
                this.page = Constant.DefaultPage;
            }
            if (!size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
        }
    }
}
