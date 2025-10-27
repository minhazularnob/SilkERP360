using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ModelClass
{
    public class Employee
    {
        public Employee() { }
        public string EmployeeId { get; set; }
        public UInt64 EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
    }
}
