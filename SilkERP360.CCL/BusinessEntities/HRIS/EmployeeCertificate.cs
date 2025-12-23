using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeCertificate
    {
        public ulong ? EmployeeCertificateCode { get; set; }
        public string Certificate { get; set; }          
        public string FileType { get; set; }             
        public long FileSize { get; set; }               
        public ulong ? EmployeeCode { get; set; }           
        public int Status { get; set; } = 1;             
        public int IsDeleted { get; set; } = 1;          
    }
}
