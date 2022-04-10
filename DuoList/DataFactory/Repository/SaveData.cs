using DuoList.Models;
using DuoList.Models.ResultMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoList.DataFactory.Repository
{
    public class SaveData
    {
        /// <summary>
        /// This Function is used to store a new Grocerylist item
        /// </summary>
        /// <param name="groceryItem">Takes in a GroceryItem Model</param>
        /// <returns>Returns a success obj displaying if the save was successful or not</returns>
        public SuccessMessage SaveGroceryItem(GroceryItem groceryItem)
        {

            SuccessMessage ReturnValues = new SuccessMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBOAzureGeneralConntectionString"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[dbo.ssp_ToDuoList_SaveGroceryItem]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {
                SQLComm.Parameters.AddWithValue("@OwnerId", groceryItem.OwnerID);
                SQLComm.Parameters.AddWithValue("@ItemName", groceryItem.ItemName);
                SQLComm.Parameters.AddWithValue("@IconName", groceryItem.IconName);
                SQLComm.Parameters.AddWithValue("@isComplete", groceryItem.isComplete);
                SQLComm.Parameters.AddWithValue("@PartnerID", groceryItem.PartnerID);

                SQLRec = SQLComm.ExecuteReader();
                if (SQLRec.Read())
                {
                    ReturnValues.ReturnMessage = SQLRec.GetString(SQLRec.GetOrdinal("ReturnMessage"));
                    ReturnValues.ReturnStatus = SQLRec.GetString(SQLRec.GetOrdinal("ReturnStatus"));
                    ReturnValues.newId = SQLRec.GetInt32(SQLRec.GetOrdinal("NewIdRow"));
                }
            }
            catch (Exception e)
            {
                ReturnValues.ReturnMessage = "Oops, something went wrong! " + e.Message;
                ReturnValues.ReturnStatus = "Failed";
            }
            finally
            {

                SQLConn.Close();
            }

            return ReturnValues;
        }

        /// <summary>
        /// This will take in a Grocery Item and use it's ID property to update a groceryItem in the DB
        /// matching the ID passed to the SSP
        /// </summary>
        /// <param name="groceryItem">Takes in a GroceryItemModel</param>
        /// <returns>Returns the Updted GroceryItem as a GroceryItemModel</returns>
        public GroceryItem UpdateGroceryItem(GroceryItem groceryItem)
        {
            GroceryItem GroceryItem = new GroceryItem();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBOAzureGeneralConntectionString"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[dbo.ssp_ToDuoList_UpdateGroceryItem]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {
                SQLComm.Parameters.AddWithValue("@ID", groceryItem.ID);
                SQLComm.Parameters.AddWithValue("@isComplete", groceryItem.isComplete);

                SQLRec = SQLComm.ExecuteReader();
                if (SQLRec.Read())
                {
                    GroceryItem.ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID"));
                    GroceryItem.ItemName = SQLRec.GetString(SQLRec.GetOrdinal("ItemName"));
                    GroceryItem.IconName = SQLRec.GetString(SQLRec.GetOrdinal("IconName"));
                    GroceryItem.isComplete = SQLRec.GetBoolean(SQLRec.GetOrdinal("isComplete"));
                    GroceryItem.OwnerID = SQLRec.GetInt32(SQLRec.GetOrdinal("OwnerId"));
                    GroceryItem.PartnerID = SQLRec.GetString(SQLRec.GetOrdinal("PartnerID"));
                }
                SQLRec.Close();
            }
            catch (Exception e)
            {
                GroceryItem.ErrorMessage = "Oops, something went wrong! " + e.Message;
                GroceryItem.ErrorStatus = "Failed";
            }
            finally
            {

                SQLConn.Close();
            }

            

            return GroceryItem;
        }
    }
}