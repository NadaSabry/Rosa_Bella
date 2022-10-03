using Microsoft.AspNetCore.Mvc.Rendering;
using Rosa_Bella.Models;

namespace Rosa_Bella.ViewModels
{
    public class AddProductVM
    {
        public Product? product { get; set; }
        public IEnumerable<SelectListItem>? mainCategory { get; set; }
        public IEnumerable<SelectListItem>? productType { get; set; }

    }
}
