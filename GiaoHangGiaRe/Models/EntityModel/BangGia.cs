namespace Models.EntityModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BangGia")]
    public partial class BangGia
    {
        [Key]
        public int Ma { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Báo giá")]
        public string BaoGia { get; set; }
    }
}
