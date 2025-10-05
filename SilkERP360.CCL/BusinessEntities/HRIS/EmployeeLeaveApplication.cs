using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("EMPLOYEE_LEAVE_APPLICATION", "SEQ_LEAVE_APP")]
    public class EmployeeLeaveApplication : SilkERP360.CCL.Validation.ValidationBase
    {
        public EmployeeLeaveApplication()
        {
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_APPLICATION_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_uint64_LeaveApplicationCode;
        public System.UInt64 LeaveApplicationCode
        {
            get { return this.m_uint64_LeaveApplicationCode; }
            set { this.m_uint64_LeaveApplicationCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_uint64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("APPLICATION_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_ApplicationDate;
        public System.DateTime ApplicationDate
        {
            get { return this.m_dt_ApplicationDate; }
            set { this.m_dt_ApplicationDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_TYPE", typeof(SilkERP360.CCL.Enums.LeaveType), false, false)]
        protected SilkERP360.CCL.Enums.LeaveType m_enm_LeaveType;
        public SilkERP360.CCL.Enums.LeaveType LeaveType
        {
            get { return this.m_enm_LeaveType; }
            set { this.m_enm_LeaveType = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_CATEGORY", typeof(SilkERP360.CCL.Enums.LeaveCategory), false, false)]
        protected SilkERP360.CCL.Enums.LeaveCategory m_enm_LeaveCategory;
        public SilkERP360.CCL.Enums.LeaveCategory LeaveCategory
        {
            get { return this.m_enm_LeaveCategory; }
            set { this.m_enm_LeaveCategory = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_START_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_LeaveStartDate;
        public System.DateTime LeaveStartDate
        {
            get { return this.m_dt_LeaveStartDate; }
            set { this.m_dt_LeaveStartDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_END_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_LeaveEndDate;
        public System.DateTime LeaveEndDate
        {
            get { return this.m_dt_LeaveEndDate; }
            set { this.m_dt_LeaveEndDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NUM_OF_DAYS", typeof(System.UInt64), false, false)]
        protected System.UInt16 m_uint16_NumOfDays;
        public System.UInt16 NumOfDays
        {
            get { return this.m_uint16_NumOfDays; }
            set { this.m_uint16_NumOfDays = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REJOIN_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_RejoinDate;
        public System.DateTime RejoinDate
        {
            get { return this.m_dt_RejoinDate; }
            set { this.m_dt_RejoinDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_REASON", typeof(System.String), false, false)]
        protected System.String m_str_Reason;
        public System.String Reason
        {
            get { return this.m_str_Reason; }
            set { this.m_str_Reason = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), false, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_uint64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return this.m_uint64_EntryEmployeeCode; }
            set { this.m_uint64_EntryEmployeeCode = value; }
        }
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return this.m_dt_EntryDate; }
            set { this.m_dt_EntryDate = value; }
        }
        
    }
}