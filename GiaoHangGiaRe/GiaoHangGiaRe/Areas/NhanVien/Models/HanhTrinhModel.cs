using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public class HanhTrinhModel
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
