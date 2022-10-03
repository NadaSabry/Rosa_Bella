using Microsoft.AspNetCore.Mvc.Rendering;
using Rosa_Bella.Models;

namespace Rosa_Bella.ViewModels
{
    public class AddCategoryView
    {
        public Product? Products { get; set; }
        public IEnumerable<SelectListItem>? mainCategory { get; set; }
    }
}
