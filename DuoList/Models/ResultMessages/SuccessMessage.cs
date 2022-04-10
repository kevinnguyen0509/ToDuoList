using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.Models.ResultMessages
{
    public class SuccessMessage
    {
        public string ReturnMessage { get; set; }
        public string ReturnStatus { get; set; }
        public int newId { get; set; }
    }
}