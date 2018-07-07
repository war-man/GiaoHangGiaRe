namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HanhTrinh")]
    public partial class HanhTrinh
    {
        [Key]
        public int MaHanhTrinh { get; set; }

        [Display(Name = "Hành trình")]
        public string HanhTrinh1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Điểm bắt đầu")]
        public string DiemBatDau { get; set; }

        [StringLength(50)]
        [Display(Name = "Điểm kết thúc")]
        public string DiemKetThuc { get; set; }

        [Display(Name = "Quãng đường")]
        public int? QuangDuong { get; set; }

        [Display(Name = "Thời gian")]
        public int? ThoiGian { get; set; }

        public bool? deleted { get; set; }
    }
}
