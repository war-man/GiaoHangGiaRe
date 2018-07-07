using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EntityModel
{
    [Table("Province")]
    public partial class Province
    {
        [Key]
        public int Province_Id { get; set; }
        public string Province_Code { set; get; }
        [Required]
        public string Province_Name { set; get; }
    }
}
