using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Models
{
    public class KienHangModel
    {
        [Required]
        [Display(Name = "Mã đơn hàng")]
        public string MaDonHang { set; get; }

        [Required]
        [Display(Name = "Nội dung ")]
        public string NoiDung { set; get; }

        [Required]
        [Display(Name = "Trọng lượng ")]
        public string TrongLuong { set; get; }

        public string ChieuDai { set; get; }

        public string ChieuRong { set; get; }

        public string GhiChu { set; get; }
    }
}