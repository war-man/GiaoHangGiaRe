namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KienHang")]
    public partial class KienHang
    {
        [Key]
        public int MaKienHang { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int? MaDonHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Trọng lượng")]
        public int? TrongLuong { get; set; }

        [Display(Name = "Chiều dài")]
        public int? ChieuDai { get; set; }

        [Display(Name = "Chiều rộng")]
        public int? ChieuRong { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [StringLength(50)]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
    }
}
