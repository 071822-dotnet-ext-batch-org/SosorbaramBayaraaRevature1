using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ModelsLayer
{
    public class Category
    {
        [Key]
        public int ProductId { get; set; }
        [Required]

        public string? ProductName { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime GetDateTime { get; set; } = DateTime.Now;
    }
}