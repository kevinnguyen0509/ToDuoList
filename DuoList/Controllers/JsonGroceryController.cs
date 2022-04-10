using DuoList.DataFactory.Interfaces;
using DuoList.DataFactory.UtilClasses;
using DuoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuoList.Controllers
{
    public class JsonGroceryController : Controller
    {
        //Create forms that are being used
        static IForms<GroceryItem> GroceryForm = new GroceryList();

        /// <summary>
        /// This will save a GroceryItem to the database
        /// </summary>
        /// <param name="groceryItem">Takes in a GroceryItem Model</param>
        /// <returns>Returns a Success Object with a status message</returns>
        [HttpPost]
        public JsonResult SaveGroceryItem(GroceryItem GroceryItemModel)
        {
            
            return Json(GroceryForm.Save(GroceryItemModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method will get all the Grocerylist items reguardless if the item is complete or incomplete
        /// </summary>
        /// <param name="OwnerID">Takes in the current logged in user's ID</param>
        /// <param name="PartnerID">Takes in a partner ID. If none is provided the the DB will save 0 in SSP</param>
        /// <returns>Returns a JSON list of GroceryItems owned by logged in user</returns>
        [HttpPost]
        public JsonResult GetMyGroceryList(int OwnerID, string PartnerID)
        {
            return Json(GroceryForm.GetDataAll(OwnerID, PartnerID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This will Update the Grocery List to Purple for Incomplete or Yellow for Complete
        /// </summary>
        /// <param name="GroceryItemModel">Excepts A GroceryItem Model</param>
        /// <returns>Returns the Updated GroceryItem As A GroceryItemModel</returns>
        [HttpPost]
        public JsonResult UpdateMyGroceryItem(GroceryItem GroceryItemModel)
        {
            return Json(GroceryForm.Update(GroceryItemModel), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCompletedGroceryItem(int OwnerID, string PartnerID)
        {
            return Json(GroceryForm.Delete(OwnerID, PartnerID), JsonRequestBehavior.AllowGet);
        }
    }
}