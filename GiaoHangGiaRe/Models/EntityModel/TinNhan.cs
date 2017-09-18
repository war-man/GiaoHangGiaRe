namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinNhan")]
    public partial class TinNhan
    {
        [Key]
        public int MaTinNhan { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Thời gian")]
        public DateTime? ThoiGian { get; set; }

        public int? MaKienHang { get; set; }
    }
}
