namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
         [Display(Name = "Mã khách hàng")]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Công ty")]
        public string CongTy { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public int? MaLoaiKH { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }

        public bool? deleted { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string TenTaiKhoan { get; set; }
    }
}
