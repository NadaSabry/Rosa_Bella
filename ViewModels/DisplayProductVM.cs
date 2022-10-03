using Microsoft.AspNetCore.Mvc.Rendering;
using Rosa_Bella.Models;

namespace Rosa_Bella.ViewModels
{
    public class DisplayProductVM
    {
        public IList<Product> product { get; set; }
        public IList<SelectListItem> mainCategory { get; set; }
        public IList<SelectListItem> type { get; set; }
        public IList<SelectListItem> season { get; set; }

    }
}
