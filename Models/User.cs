using System.ComponentModel.DataAnnotations;

namespace Rosa_Bella.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public string? UserImageUrl { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
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
    [Range(10,100,ErrorMessage="please Enter your age between 10 to 100 year")]
    public int? Age { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
}
