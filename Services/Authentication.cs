using Rosa_Bella.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Rosa_Bella.Services
{
    public class Authentication
    {
        public static User? LoggedInUser { get; private set; }
        public static bool IsLoggedIn ()
        { 
            return LoggedInUser != null; 
        }
        public static bool IsAdmin()
        {
            if (LoggedInUser == null)
                return false;
            return LoggedInUser.Email == "admin@gmail.com";
        }
        public static void LoggedOut()
        {
            LoggedInUser = null;
        }
        public static void SetUser(User loggedInUser)
        {
            LoggedInUser = loggedInUser;
        }

        public static IActionResult? CheckAuthAndRouteLogin(object controllerObj)
        {
            if (!IsLoggedIn())
            {
                var controller = (Controller)controllerObj;
                return controller.RedirectToAction("Index", "Auth");
            }
            return null;
        }
    }
}
