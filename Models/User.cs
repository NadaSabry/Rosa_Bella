using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Software_Project.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public string? UserImageUrl { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    public string? Country { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    public string? phoneNumber { get; set; }

    [Required]
    public string? address { get; set; }

    [Required]
    public int? Age { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
}
