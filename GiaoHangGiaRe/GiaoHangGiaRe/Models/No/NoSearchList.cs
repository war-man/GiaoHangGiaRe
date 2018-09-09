using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models
{
    public class NoSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public string KyHieu { set; get; }

        public NoSearchList()
        {
            if (!this.page.HasValue)
            {
                this.page = Constant.DefaultPage;
            }
            if (!this.size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
        }

        public NoSearchList(int? _page, int? _size, string _KyHieu)
        {
            if (!_page.HasValue)
            {
                this.page = Constant.DefaultPage;
            }
            if (!_size.HasValue)
            {
                this.size = Constant.DefaultSize;
            }
            if (!string.IsNullOrWhiteSpace(_KyHieu))
            {
                this.KyHieu = _KyHieu;
            }
        }
    }
}