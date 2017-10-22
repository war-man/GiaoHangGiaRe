namespace Models.EntityModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Metadata.Edm;
    [Table("LichSu")]
    public partial class LichSu 
    {
        [Key]
        public int Ma { get; set; }

        [Display(Name = "Hành động")]
        public string HanhDong { get; set; }

        [Display(Name = "Người tác động")]
        public string TenTaiKhoan { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Vị trí")]
        public string ViTriThaoTac { set; get; }

        [Display(Name = "Thời gian")]
        public DateTime ThoiGianThucHien { set; get; }
    }
}
