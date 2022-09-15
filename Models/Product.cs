using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Software_Project.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryID { get; set; }

    [Required]
    public string? ProductName { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public float? ProductPrice { get; set; }
    public DateTime? ProductAddedDate { get; set; }

    [Required]
    public string? ProductDescription { get; set; }

    [Required]
    public int? ProductQuantity { get; set; }

    [Required]
    public string? Size { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
}
