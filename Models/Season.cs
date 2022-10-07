using System.ComponentModel.DataAnnotations;

namespace Rosa_Bella.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
