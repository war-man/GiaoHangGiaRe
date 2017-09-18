using System.ComponentModel.DataAnnotations;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public class LoaiKhachHangModel
    {
        [Key]
        [Display(Name = "Mã loại khách hàng")]
        public int MaLoaiKH { get; set; }

        [Display(Name = "Loại khách hàng")]
        public string TenLoaiKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
    }
}
