using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models
{
    public class LichSuSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public LichSuSearchList()
        {
            if(!page.HasValue)
            {
                page = Constant.DefaultPage;
            }
            if (!size.HasValue)
            {
                size = Constant.DefaultSize;
            }
        }
        public LichSuSearchList(int? page, int? size)
        {
            if (page.HasValue)
            {
                this.page = page;
            }
            if (size.HasValue)
            {
                this.size = size;
            }
        }
    }
}
