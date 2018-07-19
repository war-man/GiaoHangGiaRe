using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GiaoHangGiaRe.Module
{
    public class Constant
    {
        const int _DefaultPage = 0;
        const int _DefaultSize = 10;
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
    public class DonHangConstant
    {
        /// <summary>
        /// Đơn hàng bị khách hàng hủy hoặc do nhân viên hủy
        /// </summary>
        public static int Huy = -1;
        /// <summary>
        /// Đơn hàng mới tạo sẽ thuộc đon hàng chờ
        /// </summary>
        public static int DangCho = 0;
        /// <summary>
        /// Đơn hàng đã được nhân viên giao hàng  tiếp nhận
        /// </summary>
        public static int DaTiepNhan = 1;
        /// <summary>
        /// Đơn hàng đang được nhân viên tới địa chỉ lấy hàng
        /// </summary>
        public static int DangLayHang = 2;
        /// <summary>
        /// Đơn hàng đã lấy hàng thành công.
        /// </summary>
        public static int LayThanhCong = 3;
        /// <summary>
        /// Không thể lấy được hàng do yếu tố khách quan.
        /// </summary>
        public static int KhongTheLayHang = -2;
        /// <summary>
        /// Đơn hàng đã lấy được hàng và đang giao cho người nhận
        /// </summary>
        public static int DangGiao = 4;
        /// <summary>
        /// Đơn hàng gửi vào kho
        /// </summary>
        public static int GuiVaoKho = 5;
        //Giao hangfg thành công
        public static int GiaoThanhCong = 6;
    }
    public class NhanVienConstant
    {
        /// <summary>
        /// Nhân viên đang hoạt động có status = 1
        /// </summary>
        public static int Active = 1;
        /// <summary>
        /// Nhân viên đang hoạt động có status = 0
        /// </summary>
        public static int StopActive = 0;
    }
    public class ReportTypeConstant
    {
        /// <summary>
        /// Báo cáo vi phạm liên quan đến đơn hàng
        /// </summary>
        public static string DonHang = "1";

    }
}