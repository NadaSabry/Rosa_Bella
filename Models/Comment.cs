using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosa_Bella.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Description { get; set; }

    [ForeignKey("Product")]
    public int? ProductId { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    public DateTime? Date { get; set; }

    public virtual Product? Product { get; set; }
    public virtual User? User { get; set; }
}
