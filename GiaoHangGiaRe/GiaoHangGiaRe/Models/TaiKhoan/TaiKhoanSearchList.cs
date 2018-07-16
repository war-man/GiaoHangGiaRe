using System;
namespace GiaoHangGiaRe.Models.TaiKhoan
{
    public class TaiKhoanSearchList
    {
        public int? page;
        public int? size;
        public string user_name;
        public string name;
        public string id;
        public TaiKhoanSearchList(int _page, int _size, string _user_name, string _name, string _id)
        {
            this.page = _page;
            this.page = _size;
            this.user_name = _user_name;
            this.name = _name;
            this.id = _id;
        }
    }
}
