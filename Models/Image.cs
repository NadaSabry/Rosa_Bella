using System.ComponentModel.DataAnnotations.Schema;

namespace Rosa_Bella.Models
{
    public class Image
    {
        [ForeignKey("Product")]
        public int? productId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Color { get; set; }

    }
}
