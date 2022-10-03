using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;
using Rosa_Bella.ViewModels;

namespace Rosa_Bella.Controllers
{
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public ProductTypeController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }

        // all types of product
        public IActionResult Index()
        {
            List<ProductType> ProductTypes = db.ProductTypes.ToList();
            return View(ProductTypes);
        }

        public IActionResult Shop(int id)
        {
            List<ProductType> categories = db.ProductTypes.Where(x => x.Id == id ).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add_Category()
        {
            return View();
        }

        [HttpPost]        // CategoyImageUrl is the same name in form --> name=" CategoyImageUrl"
        public IActionResult Add_Category(ProductType Type, IFormFile CategoyImageUrl)
        {
            var name = db.ProductTypes.FirstOrDefault(x => x.TypeName == Type.TypeName);
            if (!file.IsValidImage(CategoyImageUrl) || !ModelState.IsValid || name != null)
            {
                if (!file.IsValidImage(CategoyImageUrl)) ToastNotify.AddErrorToastMessage("Plaease Enter The Valid Image (png, jpg, jpeg, gif)");
                if (name != null) ToastNotify.AddErrorToastMessage("Category is exist");
                return View(Type);
            }
            file.SaveFile(CategoyImageUrl, Ih);
            string image = "/Images/" + CategoyImageUrl.FileName;
            Type.ImageUrl = image;

            ToastNotify.AddSuccessToastMessage("تم الاضافه بنجاح");
            db.ProductTypes.Add(Type);
            db.SaveChanges();
            return View();
        }
    }


}
