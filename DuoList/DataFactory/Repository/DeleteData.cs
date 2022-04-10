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
    public class DeleteData
    {
        public SuccessMessage DeleteMyCompletedGroceryList(int OwnerID, string PartnerID)
        {
            SuccessMessage successMessage = new SuccessMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBOAzureGeneralConntectionString"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[dbo.ssp_ToDuoList_DeleteMyCompletedGroceryList]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;
            
            try
            {
                SQLComm.Parameters.AddWithValue("@OwnerId", OwnerID);
                SQLComm.Parameters.AddWithValue("@PartnerID", PartnerID);
                SQLRec = SQLComm.ExecuteReader();

                if (SQLRec.Read())
                {
                    successMessage.ReturnMessage = SQLRec.GetString(SQLRec.GetOrdinal("ReturnMessage"));
                    successMessage.ReturnStatus = SQLRec.GetString(SQLRec.GetOrdinal("ReturnStatus"));
                }
                SQLRec.Close();
            }
            catch(Exception e)
            {
                successMessage.ReturnMessage = "Oops, something went wrong! " + e.Message;
                successMessage.ReturnStatus = "Failed";
            }
            finally
            {
                SQLConn.Close();
            }

            return successMessage;
        }
    }
}