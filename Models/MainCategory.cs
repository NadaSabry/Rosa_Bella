using System.ComponentModel.DataAnnotations;

namespace Rosa_Bella.Models
{
    public class MainCategory
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }

        [Display(Name = "Main Categoy Image")]
        public string? CategoyImageUrl { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }   
    }
}
