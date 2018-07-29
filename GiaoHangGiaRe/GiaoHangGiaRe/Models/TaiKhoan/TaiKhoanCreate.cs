using System;
using System.ComponentModel.DataAnnotations;

namespace GiaoHangGiaRe.Models.TaiKhoan
{
    public class TaiKhoanCreate
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { set; get; }

        public string ImageLink { set; get; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }

        [Required]
        public string TenTaiKhoan { set; get; }

        [StringLength(50)]
        public string CongTy { get; set; }

        [StringLength(20)]
        [Required]
        [Phone]
        public string SoDienThoai { get; set; }
    }
}
