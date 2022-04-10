using DuoList.DataFactory.Classes;
using DuoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DuoList.Controllers
{
    public class AuthenticationController : Controller
    {
        Authentication AuthVerify = new Authentication();
        public static string _LoginView = "~/Views/Authentication/Login.cshtml";
        // GET: Authentication
        public ActionResult Login()
        {
            return View(_LoginView);
        }

        /// <summary>
        /// checks if the user exists and if the correct password was inputed. The password will be encrypted
        /// before sending to the database and comparing that string
        /// </summary>
        /// <param name="Email">Takes in the user's email address</param>
        /// <param name="password">Takes in a user's password input</param>
        /// <returns></returns>
        public JsonResult LoginVerification(string Email, string password)
        {
            User UserFromDatabase = new User(); //Creates a user model to store User inforamation
            UserFromDatabase = AuthVerify.GetUserIfExists(Email);
            bool PasswordIsCorrect = Crypto.VerifyHashedPassword(UserFromDatabase.Password, password);

            if (PasswordIsCorrect)
            {
                //Create cookie, Add the ID and PartnerID that belongs with Logged in user
                //Set it to expire in 90 days.
                HttpCookie CurrentUserCookie = new HttpCookie("CurrentUserCookie");
                CurrentUserCookie.Values.Add("ID", UserFromDatabase.ID.ToString());
                CurrentUserCookie.Values.Add("PartnerID", UserFromDatabase.PartnerID);
                CurrentUserCookie.Expires = DateTime.Now.AddDays(90);
                Response.Cookies.Add(CurrentUserCookie);

                return Json("Success", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            
           
        }
    }
}