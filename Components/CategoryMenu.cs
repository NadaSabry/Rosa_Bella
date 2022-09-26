using Microsoft.AspNetCore.Mvc;

namespace Rosa_Bella.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public CategoryMenu(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var categorys = db.MainCategorys.ToList();
            return View(categorys);
        }
    }
}
