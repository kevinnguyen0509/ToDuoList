using DuoList.DataFactory.Interfaces;
using DuoList.DataFactory.Repository;
using DuoList.Models;
using DuoList.Models.ResultMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.DataFactory.UtilClasses
{
    public class GroceryList : IForms<GroceryItem>
    {
        SaveData saveData = new SaveData();
        GetData getData = new GetData();
        DeleteData deleteData = new DeleteData();
        /// <summary>
        /// This method will get all the Grocerylist items reguardless if the item is complete or incomplete
        /// </summary>
        /// <param name="OwnerID">Takes in the current logged in user's ID</param>
        /// <param name="PartnerID">Takes in a partner ID. If none is provided the the DB will save 0 in SSP</param>
        /// <returns>Returns a list of GroceryItems owned by logged in user</returns>
        public List<GroceryItem> GetDataAll(int OwnerId, string PartnerID)
        {
            return getData.GetMyGroceryList(OwnerId, PartnerID);
            
        }

        /// <summary>
        /// This function takes in a Grocerlist item and passes it to the SaveGroceryItem method in the SaveData 
        /// class. It will then return a success message or a failed message
        /// </summary>
        /// <param name="groceryItem">Takes in a GroceryItem Model</param>
        /// <returns>Returns a Success Object that will have a StatusMessage a Status and a ID number, -1 if failed</returns>
        public SuccessMessage Save(GroceryItem groceryItem)
        {
            return saveData.SaveGroceryItem(groceryItem);
        }

        public GroceryItem FindByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates A Grocery Item Given the Whole GroceryItemModel
        /// </summary>
        /// <param name="groceryItem">Takes A GroceryItemModel</param>
        /// <returns>Returns an Update GroceryItemModel</returns>
        public GroceryItem Update(GroceryItem groceryItem)
        {
            return saveData.UpdateGroceryItem(groceryItem);
           
        }
        /// <summary>
        /// This Deletes all the completed grocery Item for the logged in user and their partnerID
        /// </summary>
        /// <param name="GroceryItem">Takes in a GroceryItemModel to use the OwnerID and partner ID</param>
        /// <returns>Returns a SuccessMessageModel</returns>
        public SuccessMessage Delete(int OwnerID, string PartnerID)
        {
            return deleteData.DeleteMyCompletedGroceryList(OwnerID, PartnerID);
        }
           
    }
}