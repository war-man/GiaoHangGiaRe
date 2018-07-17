using System;
using GiaoHangGiaRe.Module;

namespace GiaoHangGiaRe.Models.TaiKhoan
{
    public class TaiKhoanSearchList
    {
        public int? page { set; get; }
        public int? size { set; get; }
        public String user_name { set; get; }
        public String name { set; get; }
        public String id { set; get; }
        public TaiKhoanSearchList()
        {
            this.page = Constant.DefaultPage;
            this.size = Constant.DefaultSize;
        }
        public TaiKhoanSearchList(int _page, int _size, string _user_name, string _name, string _id)
        {
            this.page = _page;
            this.size = _size;
            this.user_name = _user_name;
            this.name = _name;
            this.id = _id;
        }
    }
}
