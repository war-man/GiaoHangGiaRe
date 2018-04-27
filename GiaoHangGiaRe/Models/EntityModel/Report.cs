using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EntityModel
{
    [Table("Report")]
    public partial class Report
    {
        [Key]
        public int Report_Id { get; set; }
        [Required]
        public string Report_Type { get; set; }
        [Required]
        public string Report_Content { get; set; }
        public int MaDonHang { set; get; }
        [Required]
        public string User_id { set; get; }
        public int MaNhanVien { set; get; }
    }
}
