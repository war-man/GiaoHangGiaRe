namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiKhachHang")]
    public partial class LoaiKhachHang
    {
        [Key]
        [Display(Name = "Mã loại khách hàng")]
        public int MaLoaiKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại khách hàng")]
        public string TenLoaiKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
    }
}
