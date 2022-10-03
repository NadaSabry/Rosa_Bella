using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;
using Rosa_Bella.ViewModels;
using System.Linq;

namespace Rosa_Bella.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Add_Product
        [HttpGet]
        public IActionResult Add_Product()
        {
            AddProductVM productVM = new AddProductVM();
            productVM.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString() , Text = n.Name }).ToList();
            productVM.productType = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString() , Text = n.TypeName }).ToList();
            //productVM.Images = new SelectList(db.)
            return View(productVM);
        }

        public bool ValidImages(IFormFile[] ImageUrl)
        {
            foreach (var item in ImageUrl)
            {
                if (!file.IsValidImage(item))
                {
                    return false;
                }
            }
            return true;
        }

        public void InsertImages(IFormFile[] ImageUrl,int productID)
        {
            Image images = new Image();
            foreach (var item in ImageUrl)
            {
                file.SaveFile(item, Ih);
                string image = "/Images/" + item.FileName;
                images.ImageUrl = image;
                images.productId = productID;
                db.Images.Add(images);
                db.SaveChanges();
            }
        }

 
        [HttpPost]        // CategoyImageUrl is the same name in form --> name=" CategoyImageUrl"
        public IActionResult Add_Product(AddProductVM Type, IFormFile[] ImageUrl, int mainValue, int typeValue)
        {

            if(!ModelState.IsValid)
            {
                return View(Type);
            }
            if (!ValidImages(ImageUrl) )
            {
                ToastNotify.AddErrorToastMessage("Plaease Enter The Valid Image (png, jpg, jpeg, gif)");
                return View(Type);
            }
            Type.product.ProductAddedDate = DateTime.Now;
            Type.product.MainCategoryID = mainValue;
            Type.product.productTypeID = typeValue;

            db.Products.Add(Type.product);
            db.SaveChanges();

            InsertImages(ImageUrl, Type.product.Id);

            ToastNotify.AddSuccessToastMessage("تم الاضافه بنجاح");
            return View(Type);
        }
        #endregion

        #region Display_Product
        [HttpGet]
        public IActionResult Display()
        {
            DisplayProductVM  box = new DisplayProductVM();
            box.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            box.type = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.TypeName }).ToList();
            box.product = db.Products.Include(e => e.Images).ToList();
            return View(box);
        }

        [HttpPost]
        public IActionResult Display(DisplayProductVM vm, int seasson)
        {
            var Categorys = vm.mainCategory.Where(x => x.Selected).Select(y => y.Value);
           // Categorys.Select(int.Parse).ToList();

            var Types = vm.type.Where(x => x.Selected).Select(y => y.Value);
            vm.product = db.Products.Include(e => e.Images).ToList();

            

            if (seasson > 0)
            {
                bool b = false; 
                if(seasson==2) b = true;
                vm.product = vm.product.Where(e => e.Season == b).ToList();
               // vm.product = vm.product.Where(e => e.Id == 1 || e.Id == 3).ToList();
            }
            //vm.product = vm.product.Where(t => Categorys.Contains(t.MainCategoryID));

            vm.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            vm.type = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.TypeName }).ToList();
           
            return View(vm);
        }

        #endregion

    }
}

