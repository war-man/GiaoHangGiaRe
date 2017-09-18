using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{

    public  class HoaDonModel
    {   
        [Display(Name = "Mã hóa đơn")]
        public int MaHoaDon { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int? MaDonHang { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? ThanhTien { get; set; }

        [Display(Name = "Mã khách hàng")]
        public int? MaKhachHang { get; set; }

        [Display(Name = "Mã nhận viên giao hàng")]
        public int? MaNhanVienGH { get; set; }

        [StringLength(50)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}
