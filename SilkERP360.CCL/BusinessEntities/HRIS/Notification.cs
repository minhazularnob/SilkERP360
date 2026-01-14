using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public Int64 EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public string NotificationMsg { get; set; }
        public string ConfirmationDate { get; set; }
        public string JoiningDate { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}
