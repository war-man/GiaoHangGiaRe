
namespace Models.EntityModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Commune")]
    public partial class Commune
    {
        [Key]
        public int Commune_Id { get; set; }
        public string Commune_Code { set; get; }
        [Required]
        public string Commune_Name { set; get; }
        [Required]
        public int District_Id { set; get; }
    }
}
