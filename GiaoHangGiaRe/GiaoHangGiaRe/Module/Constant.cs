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
        const string _DeleteAction = "Delete";
        const string _UpdateAction = "Update";
        const string _CreateAction = "Create";
        const string _BangNhanVien = "NhanVien";
        const string _BangKhachHang = "KhacHang";
        const string _BangHoaDon = "HoaDon";
        const string _BangDonHang = "DonHang";
        const string _BangUser = "User";
        const string _BangRole = "Role";
        const string _BangTinNhan = "TinNhan";
        const string _BangKienHang = "KienHang";
        const string _BangBangGia = "BangGia";
        const string _BangUuDai = "UuDai";
        const string _BangKhoChua = "KhoChua";
        const string _BangNo = "No";
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