﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public class NhanVienModel
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int MaNhanVien { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string TenTaiKhoan { set; get; }

        [StringLength(50)]
        [Display(Name = "Tên nhân viên")]
        public string TenNhanVien { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Thời gian bắt đầu")]
        public DateTime? NgayBatDau { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }

        public bool? deleted { get; set; }

    }
}
