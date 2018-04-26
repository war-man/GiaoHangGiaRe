using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.EntityModel
{
    [Table("District")]
    public partial class District
    {
        [Key]
        public int District_Id { get; set; }
        public string District_Code { set; get; }
        [Required]
        public string  District_Name { set; get; }
        [Required]
        public int Province_Id { set; get; }
    }
}
