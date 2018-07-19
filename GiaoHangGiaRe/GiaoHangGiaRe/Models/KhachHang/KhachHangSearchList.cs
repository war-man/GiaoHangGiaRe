using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models.KhachHang
{
    public class KhachHangSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
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
        public KhachHangSearchList(int? _page, int? _size)
        {
            if (_page.HasValue)
            {
                this.page = _page;
            }
            if (_size.HasValue)
            {
                this.size = _size;
            }
        }
    }
}
