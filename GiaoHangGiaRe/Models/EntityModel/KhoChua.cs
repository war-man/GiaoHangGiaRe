namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoChua")]
    public partial class KhoChua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Mã kho chứa")]
        public int MaKhoChua { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Diện tích")]
        public float DienTich { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

    }
}
