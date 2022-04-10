using DuoList.Models.ResultMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoList.DataFactory.Interfaces
{
    public interface IForms<T>
    {
        //This saves a form entry to the database
        SuccessMessage Save(T ListModel);
        List<T> GetDataAll(int OwnerId, string PartnerID);
        T FindByID(int id);
        T Update(T ListModel);
        SuccessMessage Delete(int OwnerID, string PartnerID);
    }
}

