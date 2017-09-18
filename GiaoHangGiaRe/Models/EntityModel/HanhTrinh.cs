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

        [Display(Name = "H¨¤nh tr¨¬nh")]
        public string HanhTrinh1 { get; set; }

        [StringLength(50)]
        public string DiemBatDau { get; set; }

        [StringLength(50)]
        public string DiemKetThuc { get; set; }

        public int? QuangDuong { get; set; }

        public int? ThoiGian { get; set; }

        public bool? deleted { get; set; }
    }
}
