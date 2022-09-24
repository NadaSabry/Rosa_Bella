using Microsoft.AspNetCore.Mvc;

namespace Rosa_Bella.Controllers
{
    public class bla : Controller
    {
        private ApplicationDbContext db;
        public IActionResult Index()
        {
            return View();
        }
    }
}
