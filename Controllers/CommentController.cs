using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Rosa_Bella.Models;
using Rosa_Bella.Services;

namespace Rosa_Bella.Controllers
{
    public class CommentController : Controller
    {

        private ApplicationDbContext db;
        private readonly IWebHostEnvironment Ih;
        private readonly IToastNotification ToastNotify;
        public CommentController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }
        public IActionResult add_Comment(int productID, string comt)
        {
            if (!Authentication.IsLoggedIn())
                return RedirectToAction("login", "User");

            Comment comment = new Comment();
            comment.ProductId = productID;
            comment.UserId = Authentication.LoggedInUser.Id;
            comment.Description = comt;
            comment.Date = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToActionPermanent("Details", "Product" , new { id = productID });
        }
        public IActionResult Delete_Comment(int id , int productID)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToActionPermanent("Details", "Product", new { id = productID });
        }

    }
}
