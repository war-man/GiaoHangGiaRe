namespace Models.EntityModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Metadata.Edm;

    [Table("No")]
    public partial class No
    {
        [Key]
        public int Ma { get; set; }

        [Display(Name = "Ký hiệu")]
        public string KyHieu { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Số tiền")]
        public int SoTien { get; set; }

        [Display(Name = "Mã khách hàng")]
        public string MaKhachHang { get; set; }

        [Display(Name = "Thời gian")]
        public DateTime ThoiGian { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
    }
}
