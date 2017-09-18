using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Models
{
    public class DonHangModel //Model DonHang cua khach hang
    {      
        [Required]
        [Display(Name = "Ngày tạo ")]
        public string NgayTao { set; get; }

        [Required]
        [Display(Name = "Người gửi ")]
        public string NguoiGui { set; get; }

        [Required]
        [Display(Name = "Địa chỉ gửi")]
        public string DiaChiGui { set; get; }

        [Required]
        [Display(Name = "Ngày tạo ")]
        public string SoDienThoaiNguoiGui { set; get; }

        [Required]
        [Display(Name = "Người nhận")]
        public string NguoiNhan { set; get; }

        [Required]
        [Display(Name = "Địa chỉ nhận ")]
        public string DiaChiNhan { set; get; }

        [Required]
        [Display(Name = "Số điện thoại người nhận ")]
        public string SoDienThoaiNguoiNhan { set; get; }

        [Display(Name = "Mô tả")]
        public string MoTa { set; get; }

        [Required]
        [Display(Name = "Thành tiền ")]
        public string ThanhTien { set; get; }

        [Display(Name = "Thời điểm thanh toán đơn hàng ")]
        public string ThoiDiemThanhToanDH { set; get; }

        [Required]
        [Display(Name = "Ngày tạo ")]
        public string ThoiDiemDatDH { set; get; }
    }
    public class DonHangCuaToi
    {
        List<KienHang> dsKienHang { set; get; }
        public string NgayTao { set; get; }
        public string NguoiGui { set; get; }
        public string DiaChiGui { set; get; }
        public string SoDienThoaiNguoiGui { set; get; }
        public string NguoiNhan { set; get; }
        public string DiaChiNhan { set; get; }
        public string SoDienThoaiNguoiNhan { set; get; }
        public string MoTa { set; get; }
        public string ThanhTien { set; get; }
        public string ThoiDiemThanhToanDH { set; get; }
        public string ThoiDiemDatDH { set; get; }
    }
}