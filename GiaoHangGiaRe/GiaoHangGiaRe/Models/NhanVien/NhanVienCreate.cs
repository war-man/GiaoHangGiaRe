using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Models
{
    public class NhanVienCreate
    {
        [Required]
        [MinLength(4)]
        public string TenTaiKhoan { set; get; }
        public string ChucVu { set; get; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        public DateTime? NgaySinh { get; set; }

        public DateTime? NgayBatDau { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        public int TrangThai { get; set; }

        public bool? deleted { get; set; }
    }
}