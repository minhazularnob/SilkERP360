using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class LeaveProfile : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {

        public LeaveProfile(System.UInt64 IP_ui64_EmployeeCode)
        {
            this.m_ui64_EmployeeCode = IP_ui64_EmployeeCode;
            this.m_objLst_LeaveBalances = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance>();
            this.m_objLst_EmployeeLeaveApplication = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>();
        }

        protected System.String m_str_EmployeeID;
        protected System.String m_str_EmployeeName;

        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
        }

        
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> m_objLst_EmployeeLeaveApplication;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> EmployeeLeaveApplication
        {
            get { return this.m_objLst_EmployeeLeaveApplication; }
           
        }
        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> m_objLst_LeaveBalances;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> LeaveBalances
        {
            get { return this.m_objLst_LeaveBalances; }
            //set { this.m_objLst_LeaveBalances = value; }
        }
        

    }
}
