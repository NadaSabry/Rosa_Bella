using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosa_Bella.Models;

// ملابس علويه| فسلتين

public class ProductType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? TypeName { get; set; }

    [Display(Name = "Main Categoy Image")]
    public string? ImageUrl { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
