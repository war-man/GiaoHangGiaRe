using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GiaoHangGiaRe.Module
{
    public class Constant
    {
        const int _DefaultPage = 1;
        const int _DefaultSize = 5;
        const string _DeleteAction = "Xóa";
        const string _UpdateAction = "Chỉnh sửa";
        const string _CreateAction = "Tạo mới";
        const string _BangNhanVien = "Nhân viên";
        const string _BangKhachHang = "Khách hàng";
        const string _BangHoaDon = "Hóa đơn";
        const string _BangDonHang = "Đơn hàng";
        const string _BangUser = "User";
        const string _BangRole = "Role";
        const string _BangTinNhan = "Tin nhắn";
        const string _BangKienHang = "Kiện hàng";
        const string _BangBangGia = "Bảng giá";
        const string _BangUuDai = "Ưu đãi";
        const string _BangKhoChua = "Kho chứa";
        const string _BangNo = "Nợ";
        public static int DefaultPage{ get { return _DefaultPage; }}
        public static int DefaultSize { get { return _DefaultSize; } }
        public static string DeleteAction { get { return _DeleteAction; } }
        public static string UpdateAction { get { return _UpdateAction; } }
        public static string CreateAction { get { return _CreateAction; } }
        public static string NhanVien { get { return _BangNhanVien; } }
        public static string KhachHang { get { return _BangKhachHang; } }
        public static string HoaDon { get { return _BangHoaDon; } }
        public static string DonHang { get { return _BangDonHang; } }
        public static string User { get { return _BangUser; } }
        public static string Role { get { return _BangRole; } }
        public static string TinNhan { get { return _BangTinNhan; } }
        public static string KienHang { get { return _BangKienHang; } }
        public static string BangGia { get { return _BangBangGia; } }
        public static string UuDai { get { return _BangUuDai; } }
        public static string KhoChua { get { return _BangKhoChua; } }
        public static string No { get { return _BangNo; } }
        public static string CvtToString(object input)
        {
            return new JavaScriptSerializer().Serialize(input);
        }
    }
}