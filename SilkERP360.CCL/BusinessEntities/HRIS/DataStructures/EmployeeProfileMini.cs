using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeProfileMini : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {

        protected System.UInt64 m_ui64_DepartmentCode;
        public System.UInt64 DepartmentCode
        {
            get { return this.m_ui64_DepartmentCode; }
            set { this.m_ui64_DepartmentCode = value; }
        }

        protected System.String m_str_DepartmentName;
        public System.String DepartmentName
        {
            get { return this.m_str_DepartmentName; }
            set { this.m_str_DepartmentName = value; }
        }


        protected System.UInt64 m_ui64_DesignationCode;
        public System.UInt64 DesignationCode
        {
            get { return this.m_ui64_DesignationCode; }
            set { this.m_ui64_DesignationCode = value; }
        }
        protected System.String m_str_Designation;
        public System.String Designation
        {
            get { return this.m_str_Designation; }
            set { this.m_str_Designation = value; }
        }


        protected System.String m_str_EmployeeID;
        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
        }

        protected System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        

        public EmployeeProfileMini()
        {
           
        }
    }
}
