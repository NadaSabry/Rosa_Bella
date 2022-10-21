using Rosa_Bella.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Rosa_Bella.Services;

namespace Rosa_Bella.Controllers
{
    public class UserController : Controller
    {
        // database 
        private ApplicationDbContext db;
        // for wwwroot path
        private readonly IWebHostEnvironment Ih;
        // for use toaster
        private readonly IToastNotification ToastNotify;
        public UserController(ApplicationDbContext db, IWebHostEnvironment Ih, IToastNotification ToastNotify)
        {
            this.db = db;
            this.Ih = Ih;
            this.ToastNotify = ToastNotify;
        }


        #region login
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(User user)
        {
            var dbUser = db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(dbUser == null)
            {
                ToastNotify.AddErrorToastMessage("Invalid email or passwor");
                return View(user);
            }
            Authentication.SetUser(dbUser);
            ToastNotify.AddSuccessToastMessage("Login Successful");
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region logout

        public IActionResult logout()
        {
            Authentication.LoggedOut();
            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User user, IFormFile userImage)
        {
            var validEmail = db.Users.FirstOrDefault(x => x.Email == user.Email);
        
            if (!file.IsValidImage(userImage) || validEmail !=null || !ModelState.IsValid)
            {
                user.UserImageUrl = userImage.FileName;
                if (!file.IsValidImage(userImage)) ToastNotify.AddErrorToastMessage("Plaease Enter The Valid Image (png, jpg, jpeg, gif)");
                if (validEmail != null) ToastNotify.AddErrorToastMessage("Your Email is exist");
                return View("Register", user);
            }
            file.SaveFile(userImage,Ih);
            string image = "/Images/" + userImage.FileName;
            user.UserImageUrl = image;

            db.Users.Add(user);
            db.SaveChanges();

            ToastNotify.AddSuccessToastMessage("Register Succssfuly");
            return View("login");
        }
        #endregion
    }
}
