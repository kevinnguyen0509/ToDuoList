using DuoList.DataFactory.Interfaces;
using DuoList.DataFactory.Repository;
using DuoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.DataFactory.Classes
{
    public class Authentication
    {
        GetData GetData = new GetData();
        public bool CheckIfUserExists(string Email)
        {
            throw new NotImplementedException();
        }

        public User GetUserIfExists(string Email)
        {
            return GetData.GetUser(Email);
           
        }
    }
}