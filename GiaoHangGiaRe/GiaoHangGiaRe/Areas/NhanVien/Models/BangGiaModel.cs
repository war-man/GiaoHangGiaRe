using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{

    public  class BangGiaModel
    {
        [Key]
        [Display(Name = "Mã")]
        public int Ma { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Báo giá")]
        public string BaoGia { get; set; }
    }
}
