using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosa_Bella.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("MainCategory")]
    public int MainCategoryID { get; set; }

    [Required]
    [ForeignKey("ProductType")]
    public int productTypeID { get; set; }

    [Required]
    [ForeignKey("Season")]
    public int SeasonID { get; set; }

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


    public virtual ProductType? ProductTypes { get; set; }
    public virtual MainCategory? MainCategorys { get; set; }
    public virtual Season? Seasons { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Image>? Images { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
}
