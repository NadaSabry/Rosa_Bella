using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;

namespace Rosa_Bella.Controllers
{
    public class ImagesSlideShowController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public ImagesSlideShowController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }

        [HttpGet]
        public IActionResult add_imgShow()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add_imgShow(IFormFile ImageUrl)
        {
            ImagesSlideShow imgshow = new ImagesSlideShow();
            if (!file.IsValidImage(ImageUrl) )
            {
                ToastNotify.AddErrorToastMessage("Plaease Enter The Valid Image (png, jpg, jpeg, gif)");
                return View();
            }
            file.SaveFile(ImageUrl, Ih);
            string image = "/Images/" + ImageUrl.FileName;
            ImagesSlideShow Findimgshow = db.ImagesSlideShows.FirstOrDefault(x => x.Images == image);
            if (Findimgshow != null)
            {
                ToastNotify.AddErrorToastMessage("Category is exist");
                return View();
            }
            imgshow.Images = image;
            db.ImagesSlideShows.Add(imgshow);
            db.SaveChanges();
            ToastNotify.AddSuccessToastMessage("تم الاضافه بنجاح");
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete_imgshow(int id)
        {
            ImagesSlideShow imgshow = db.ImagesSlideShows.Find(id);
            db.ImagesSlideShows.Remove(imgshow);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
