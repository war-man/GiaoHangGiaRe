namespace Models.EntityModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int ImageId { set; get; }
        public string ImageContent { set; get; }
        public string title { set; get; }
        public string RoleId { set; get; }

    }
}
