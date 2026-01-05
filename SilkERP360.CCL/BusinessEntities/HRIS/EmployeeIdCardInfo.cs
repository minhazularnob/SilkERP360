using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeIdCardInfo
    {
        public EmployeeIdCardInfo() { }
        public UInt64 EmployeeCode { get; set; }
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public DateTime JoiningDate { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string BloodGroup { get; set; }
        public string CitizenCardID { get; set; }
        public string MobileNo { get; set; }
        public byte[] EmployeePhoto { get; set; }       // BLOB from DB
        public string EmployeePhotoType { get; set; }   // e.g., "image/png"
        public string EmployeePhotoBase64 { get; set; } // for frontend JSON
    }
}