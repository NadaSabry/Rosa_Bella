using Rosa_Bella.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rosa_Bella.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            return View();
        }

    }
}
