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
    public class GetData
    {

        /// <summary>
        /// This method will get all the Grocerylist items reguardless if the item is complete or incomplete
        /// </summary>
        /// <param name="OwnerID">Takes in the current logged in user's ID</param>
        /// <param name="PartnerID">Takes in a partner ID. If none is provided the the DB will save 0 in SSP</param>
        /// <returns>Returns a list of GroceryItems owned by logged in user</returns>
        public List<GroceryItem> GetMyGroceryList(int OwnerID, string PartnerID)
        {

            List<GroceryItem> groceryItems = new List<GroceryItem>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBOAzureGeneralConntectionString"].ConnectionString;
            SQLConn.Open();

            string SQL = "[dbo].[dbo.ssp_ToDuoList_GetMyGroceryList]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {
                SQLComm.Parameters.AddWithValue("@OwnerID", OwnerID);
                SQLComm.Parameters.AddWithValue("@PartnerID", PartnerID);

                SQLRec = SQLComm.ExecuteReader();
                if (SQLRec.HasRows)
                {
                    while (SQLRec.Read())
                    {
                        groceryItems.Add(new GroceryItem
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            ItemName = SQLRec.GetString(SQLRec.GetOrdinal("ItemName")),
                            IconName = SQLRec.GetString(SQLRec.GetOrdinal("IconName")),
                            isComplete = SQLRec.GetBoolean(SQLRec.GetOrdinal("isComplete")),
                        });
                    }
                }

                SQLRec.Close();
            }catch(Exception e)
            {
                SuccessMessage FailedMessage = new SuccessMessage();
                FailedMessage.ReturnMessage = "Oops, something went wrong! " + e.Message;
            }
            finally
            {
                SQLConn.Close();
            }
            return groceryItems;
        }

        public User GetUser(string email)
        {

            User userData = new User();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBOAzureGeneralConntectionString"].ConnectionString;
            SQLConn.Open();


            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetUser]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@Email", email);

            SQLRec = SQLComm.ExecuteReader();

            if (SQLRec.HasRows)
            {
                while (SQLRec.Read())
                {
                    userData = new User
                    {
                        ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                        Email = SQLRec.GetString(SQLRec.GetOrdinal("Email")),
                        Password = SQLRec.GetString(SQLRec.GetOrdinal("password")),
                        PartnerID = SQLRec.IsDBNull(SQLRec.GetOrdinal("PartnerID")) == true ? null : SQLRec.GetString(SQLRec.GetOrdinal("PartnerID"))
                    };
                }
            }
            else
            {

            }
            SQLRec.Close();
            SQLConn.Close();

            return userData;
        }
    }
}