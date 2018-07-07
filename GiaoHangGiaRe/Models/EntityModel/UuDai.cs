namespace Models.EntityModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  
    [Table("UuDai")]
    public partial class UuDai
    {
        [Key]
        public int Ma { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Đối tượng áp dụng")] // Loại khách hàng nào được áp dụng ưu đãi
        public int DoiTuongApDung { get; set; } // Mã loại khách hàng
    }
}
