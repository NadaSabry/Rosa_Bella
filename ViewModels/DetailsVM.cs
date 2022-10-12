using Rosa_Bella.Models;

namespace Rosa_Bella.ViewModels
{
    public class DetailsVM
    {
        public Product? product { get; set; }
        public int userID { get; set; }
        public IEnumerable<Comment>? comment { get; set; }
        public IEnumerable<Like>? like { get; set; }
        public bool LikeIsActive { get; set; }
    }
}
