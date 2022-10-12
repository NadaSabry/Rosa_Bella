using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;
using Rosa_Bella.ViewModels;

namespace Rosa_Bella.Controllers
{
    public class likeController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public likeController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }
        public IActionResult Start_like(int id)
        {
            if (!Authentication.IsLoggedIn())
                return RedirectToAction("login", "User");

            var user_id = Authentication.LoggedInUser.Id;
            Like Find_like = db.Likes.Where(e => e.productId ==id && e.userId == user_id).FirstOrDefault();
            if (Find_like == null)
            {
                return RedirectToAction("Add_like", new { product_id = id });
            }
            return RedirectToAction("Dislike", new { product_id = id });
        }
        public IActionResult Add_like(int product_id)
        {   
            Like like = new Like();
            like.productId = product_id;
            like.userId = Authentication.LoggedInUser.Id;
            db.Likes.Add(like);
            db.SaveChanges();
            return RedirectToAction("Details","Product", new { id = product_id }); 
        }
        public IActionResult Dislike(int product_id)
        {
            Like like = db.Likes.Where(e => e.productId == product_id && e.userId == Authentication.LoggedInUser.Id).FirstOrDefault();
            db.Likes.Remove(like);
            db.SaveChanges();
            return RedirectToAction("Details", "Product", new { id = product_id });
        }
    }
}
