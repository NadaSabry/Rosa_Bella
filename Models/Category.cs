using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosa_Bella.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? CategoryName { get; set; }

    [Display(Name = "Main Categoy Image")]
    public string? CategoyImageUrl { get; set; }

    [ForeignKey("MainCategory")]
    public int MainCategoyID { get; set; }

    // 1=[summer]  0=[winter]
    public bool Season  { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
    public virtual MainCategory? MainCategorys { get; set; }
}
