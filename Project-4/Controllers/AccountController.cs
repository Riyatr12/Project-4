using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_4.Models;
using Utilities;

namespace Project_4.Controllers
{
    public class AccountController : Controller
    {
        Database database = new Database();

        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            //to read cookie name to check if username has been saved
            var userName = Request.Cookies["BrokerUsername"];
            if (userName != null)
            {
                // Set the username from cookie
                ViewBag.UserName = userName;
            }

            //Display the login
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user, bool rememberMe)
        {
            //to check if the model passed to the action is valid
            if (ModelState.IsValid)
            {
                //
                int userId = database.ValidateLogin(user);
                if(userId > 0)
                {
                    //allow the user to be identified
                    HttpContext.Session.SetInt32("BrokerID", userId);

                   if (rememberMe)
                    {

                        CookieOptions cookie = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(30)
                        };
                        Response.Cookies.Append("UserName", user.UserName, cookie);
                     //   Response.Cookies.Append("Password", user.Password, cookie);
                    }

             
                    ViewData["SuccessMessage"] = "Login successful!";
                    return RedirectToAction("Index", "Home");
                    //  return View();
                }
                else
                {
                    ViewData["ErrorMessage"] = "Invalid username or password.";

                }


            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Clear the session and cookies
            HttpContext.Session.Clear();
            Response.Cookies.Delete("UserName");
            ViewData["SuccessMessage"] = "You have logged out successfully.";

            return View();
        }

        [HttpGet]
        public IActionResult ForgotUserName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotUserName(User user)
        {

            return View();
        }

       
    }
}
