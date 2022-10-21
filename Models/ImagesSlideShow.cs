using System.ComponentModel.DataAnnotations;

namespace Rosa_Bella.Models
{
    public class ImagesSlideShow
    {
        [Key]
        public int Id { get; set; }
        public string Images { set; get; }
    }
}
