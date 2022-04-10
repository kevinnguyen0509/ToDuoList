
using DuoList.DataFactory.Interfaces;
using DuoList.DataFactory.UtilClasses;
using DuoList.Models;
using DuoList.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DuoList.Controllers
{
    public class HomeController : Controller
    {
        
        //Gets all the Grocery Item Icons
        static FileOptions fileOptions = new FileOptions();

        //Forms Being called
        static IForms<GroceryItem> GroceryForm = new GroceryList();

        /*******************Index*********************/
        public ActionResult Index()
        {
            HttpCookie CurrentUserCookie = Request.Cookies["CurrentUserCookie"];

            if(CurrentUserCookie == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            
            IndexViewModel indexViewModel = new IndexViewModel
            {
                flatIcons = fileOptions.GetAllGroceryImagesNames(),
                OwnerID = CurrentUserCookie.Values["ID"].ToString(),
                PartnerID = CurrentUserCookie.Values["PartnerID"].ToString()
            };

            return View(indexViewModel);
        }

        /*****************Index Partial Views**********************/
        public ActionResult _IndexCardContainer()
        {
            return View();
        }

        public ActionResult _IndexSearchContainer()
        {
            return View();
        }


    }
}