using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public  class TinNhanModel
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
