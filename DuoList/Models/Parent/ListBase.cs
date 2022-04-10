using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.Models.Parent
{
    public class ListBase
    {
        public int ID { get; set; }

        public string ErrorMessage { get; set; }
        public string ErrorStatus { get; set; }

        //This is a string because we need a null value in DB if a null is provided the default is PartnerID 0.
        //This causes no new users to be able to access other data.
        public string PartnerID { get; set; }
        public int OwnerID { get; set; }//Tells us who added this item
        public string ItemName { get; set; }
        public string IconName { get; set; }
        public bool isComplete { get; set; } //Tells if the user checked item off their list
    }
}