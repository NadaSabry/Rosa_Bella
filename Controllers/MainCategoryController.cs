using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;

namespace Rosa_Bella.Controllers
{
    public class MainCategoryController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public MainCategoryController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }
        public IActionResult Display_MainCategory()
        {
            List<MainCategory> categorys = db.MainCategorys.ToList();
            return View(categorys);
        }
        [HttpGet]
        public IActionResult Add_MainCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_MainCategory(MainCategory category,IFormFile Imageurl)
        {
            var name = db.MainCategorys.FirstOrDefault(x => x.Name == category.Name);
            if (!file.IsValidImage(Imageurl) || !ModelState.IsValid || name!=null)
            {
                category.CategoyImageUrl = Imageurl.FileName;
                if (!file.IsValidImage(Imageurl)) ToastNotify.AddErrorToastMessage("Plaease Enter The Valid Image (png, jpg, jpeg, gif)");
                if (name != null) ToastNotify.AddErrorToastMessage("Category is exist");
                return View(category);
            }
            file.SaveFile(Imageurl, Ih);
            string image = "/Images/" + Imageurl.FileName;
            category.CategoyImageUrl = image;

            ToastNotify.AddSuccessToastMessage("تم الاضافه بنجاح");
            db.MainCategorys.Add(category);
            db.SaveChanges();
            return View();
        }
    }
}
