using DuoList.DataFactory.Interfaces;
using DuoList.Models;
using DuoList.Models.ResultMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.DataFactory.UtilClasses
{
    public class ToDoList :  IForms<ToDoItem>
    {
        public SuccessMessage Delete(int OwnerID, string PartnerID)
        {
            throw new NotImplementedException();
        }

        public ToDoItem FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetDataAll(int OwnerId, string PartnerID)
        {
            throw new NotImplementedException();
        }

        public SuccessMessage Save(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public ToDoItem Update(ToDoItem ToDoItem)
        {
            throw new NotImplementedException();
        }
    }
}