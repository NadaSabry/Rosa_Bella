using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;
using Rosa_Bella.ViewModels;
using System.Collections;
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
            Product_CategoryVM productVM = new Product_CategoryVM();
            productVM.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString() , Text = n.Name }).ToList();
            productVM.productType = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString() , Text = n.TypeName }).ToList();
            productVM.season = db.Seasons.Select(n => new SelectListItem { Value = n.Id.ToString() , Text = n.Name }).ToList();
            
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
        public IActionResult Add_Product(Product_CategoryVM Type, IFormFile[] ImageUrl, int mainValue, int typeValue, int seasonValue)
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
            Type.product.SeasonID = seasonValue;

            db.Products.Add(Type.product);
            db.SaveChanges();

            InsertImages(ImageUrl, Type.product.Id);

            ToastNotify.AddSuccessToastMessage("تم الاضافه بنجاح");
            return RedirectToAction("Display");
        }
        #endregion
        public IActionResult Edit_Product(int id)
        {
            return View();
        }

        #region Display_Product
        [HttpGet]
        public IActionResult Display()
        {
            DisplayProductVM  box = new DisplayProductVM();
            box.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            box.type = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.TypeName }).ToList();
            box.season = db.Seasons.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            box.product = db.Products.Include(e => e.Images).ToList();
            return View(box);
        }

        [HttpPost]
        public IActionResult Display(DisplayProductVM vm)
        {
            var Categorys = vm.mainCategory.Where(x => x.Selected).Select(y => y.Value);
            var Types = vm.type.Where(x => x.Selected).Select(y => y.Value);
            var Seasons = vm.season.Where(x => x.Selected).Select(y => y.Value);
            vm.product = db.Products.Include(e => e.Images).ToList();

            IList _Category_ = new List<int>();
            IList _type_ = new List<int>();
            IList _season_ = new List<int>();

            foreach (var category in Categorys)
            {
                _Category_.Add(int.Parse(category));
            }
            foreach (var type in Types)
            {
                _type_.Add(int.Parse(type));
            }
            foreach (var seas in Seasons)
            {
                _season_.Add(int.Parse(seas));
            }
            
               if(_Category_.Count>0)vm.product = vm.product.Where(t => _Category_.Contains(t.MainCategoryID)).ToList();
               if (_type_.Count > 0) vm.product = vm.product.Where(t => _type_.Contains(t.productTypeID)).ToList();
               if (_season_.Count > 0) vm.product = vm.product.Where(t => _season_.Contains(t.SeasonID)).ToList();
            
            vm.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            vm.type = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.TypeName }).ToList();
            vm.season = db.Seasons.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            return View(vm);
        }

        public IActionResult DisplayByMainCategory(int id)
        {
            DisplayProductVM box = new DisplayProductVM();
            box.mainCategory = db.MainCategorys.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            box.type = db.ProductTypes.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.TypeName }).ToList();
            box.season = db.Seasons.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            box.product = db.Products.Include(e => e.Images).Where(e => e.MainCategoryID == id).ToList();
            return View("Display", box);
        }

        #endregion

        public bool Islike(int product_ID)
        {
            if (!Authentication.IsLoggedIn())
                return false;
            var user_id = Authentication.LoggedInUser.Id;
            Like Find_like = db.Likes.Where(e => e.productId == product_ID && e.userId == user_id).FirstOrDefault();
            if (Find_like == null)
            {
                return false;
            }
            return true;
        }
        public IActionResult Details(int id)
        {
            DetailsVM VM = new DetailsVM();
            VM.product = db.Products.Include(e => e.Images).FirstOrDefault(e => e.Id==id);
            VM.comment = db.Comments.Include(e => e.User).Where(e => e.ProductId == id).ToList();
            VM.like = db.Likes.Where(e => e.productId == id).ToList();
            VM.LikeIsActive = Islike(id);
            if (Authentication.IsLoggedIn())VM.userID = Authentication.LoggedInUser.Id;
            return View(VM);
        }

        public IActionResult Delete(int id)
        {
            IList<Comment> comment = db.Comments.Where(e => e.ProductId == id).ToList();
            foreach(var item in comment)
            {
                db.Comments.Remove(item);
                db.SaveChanges();
            }
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}

