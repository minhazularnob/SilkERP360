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
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WORK_GROUP","SEQ_WORK_GROUP")]
    public class WorkGroup : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WORK_GROUP_CODE",typeof(System.UInt64),false,false)]
        protected System.UInt64 m_ui64_WorkGroupCode;
        public System.UInt64 WorkGroupCode
        {
            get { return m_ui64_WorkGroupCode; }
            set { m_ui64_WorkGroupCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WORK_GROUP_NAME", typeof(System.String), false, false)]
        protected System.String m_str_WorkGroupName;
        public System.String WorkGroupName
        {
            get { return m_str_WorkGroupName; }
            set { m_str_WorkGroupName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.Status), false, false)]
        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        public SilkERP360.CCL.Enums.Status Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster m_obj_WorkGroupOperationMaster;
        public SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster WorkGroupOperationMaster
        {
            get { return m_obj_WorkGroupOperationMaster; }
            set { m_obj_WorkGroupOperationMaster = value; }
        }
    }

    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WORK_GROUP_OPERATION_MASTER", "SEQ_WG_OP_MASTER")]
    public class WorkGroupOperationMaster : SilkERP360.CCL.Validation.ValidationBase
    {

        public WorkGroupOperationMaster()
        {
            this.m_objLst_WorkGroupOperationHistoryCollection = new List<WorkGroupOperationHistory>();
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WG_OPERATION_MASTER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_WorkGroupOperationMasterCode;
        public System.UInt64 WorkGroupOperationMasterCode
        {
            get { return m_ui64_WorkGroupOperationMasterCode; }
            set { m_ui64_WorkGroupOperationMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WORK_GROUP_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_WorkGroupCode;
        public System.UInt64 WorkGroupCode
        {
            get { return m_ui64_WorkGroupCode; }
            set { m_ui64_WorkGroupCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WORK_DATE", typeof(System.DateTime), false, false,SilkERP360.CCL.DatabaseMapping.DateTimeFormat.DateOnly)]
        protected System.DateTime m_dt_WorkDate;
        public System.DateTime WorkDate
        {
            get { return m_dt_WorkDate; }
            set { m_dt_WorkDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WORKER_STRENGTH", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui64_WorkerStrength;
        public System.UInt32 WorkerStrength
        {
            get { return m_ui64_WorkerStrength; }
            set { m_ui64_WorkerStrength = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_PRESENT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalPresent;
        public System.UInt32 TotalPresent
        {
            get { return m_ui32_TotalPresent; }
            set { m_ui32_TotalPresent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_LEAVE", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalLeave;
        public System.UInt32 TotalLeave
        {
            get { return m_ui32_TotalLeave; }
            set { m_ui32_TotalLeave = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_OFF", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalOff;
        public System.UInt32 TotalOff
        {
            get { return m_ui32_TotalOff; }
            set { m_ui32_TotalOff = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_ABSENT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalAbsent;
        public System.UInt32 TotalAbsent
        {
            get { return m_ui32_TotalAbsent; }
            set { m_ui32_TotalAbsent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_LATE", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalLate;
        public System.UInt32 TotalLate
        {
            get { return m_ui32_TotalLate; }
            set { m_ui32_TotalLate = value; }
        }

        /// <summary>
        /// Unit: Minites
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_LIMIT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_OvertimeLimit;
        /// <summary>
        /// Unit : Minute
        /// </summary>
        public System.UInt32 OvertimeLimit
        {
            get { return m_ui32_OvertimeLimit; }
            set { m_ui32_OvertimeLimit = value; }
        }


        protected System.UInt64 m_ui32_TotalManHour;
        public System.UInt64 TotalManHour
        {
            get { return m_ui32_TotalManHour; }
            set { m_ui32_TotalManHour = value; }
        }

        protected System.UInt64 m_ui64_TotalOvertime;
        public System.UInt64 TotalOvertime
        {
            get { return m_ui64_TotalOvertime; }
            set { m_ui64_TotalOvertime = value; }
        }

        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OPERATIONAL_STATUS", typeof(SilkERP360.CCL.Enums.WorkGroupOperationalStatus), false, false)]
        protected SilkERP360.CCL.Enums.WorkGroupOperationalStatus m_enm_OperationalStatus;
        public SilkERP360.CCL.Enums.WorkGroupOperationalStatus OperationalStatus
        {
            get { return m_enm_OperationalStatus; }
            set { m_enm_OperationalStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PROCESSED_FOR_SALARY", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsSalaryProcessed;
        public SilkERP360.CCL.Enums.YesNo IsSalaryProcessed
        {
            get { return m_enm_IsSalaryProcessed; }
            set { m_enm_IsSalaryProcessed = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PROCESSED", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsAttendanceProcessed;
        public SilkERP360.CCL.Enums.YesNo IsAttendanceProcessed
        {
            get { return m_enm_IsAttendanceProcessed; }
            set { m_enm_IsAttendanceProcessed = value; }
        }

        /// <summary>
        /// What Time of the day the duty hour for this group starts from
        /// in hh:mm tt format
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_START_FROM", typeof(System.String), false, false)]
        protected System.String m_str_DutyStartFrom;
        public System.String DutyStartFrom
        {
            get { return m_str_DutyStartFrom; }
            set { m_str_DutyStartFrom = value; }
        }

        /// <summary>
        ///How many Hours that This WorkGroup will be on duty
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_HOUR", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_DutyHour;
        public System.UInt32 DutyHour
        {
            get { return m_ui32_DutyHour; }
            set { m_ui32_DutyHour = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DAY_ATTRIBUTE", typeof(SilkERP360.CCL.Enums.DayAttribute), false, false)]
        protected SilkERP360.CCL.Enums.DayAttribute m_enm_DayAttribute;
        public SilkERP360.CCL.Enums.DayAttribute DayAttribute
        {
            get { return m_enm_DayAttribute; }
            set { m_enm_DayAttribute = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { m_ui64_EntryEmployeeCode = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> m_objLst_WorkGroupOperationHistoryCollection;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> WorkGroupOperationHistoryCollection
        {
            get { return m_objLst_WorkGroupOperationHistoryCollection; }
            set { m_objLst_WorkGroupOperationHistoryCollection = value; }
        }
    }

    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WORK_GROUP_OPERATION_HISTORY", "SEQ_WG_OP_HISTORY")]
    public class WorkGroupOperationHistory : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WG_OPERATION_HISTORY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_WorkGroupOperationHistoryCode;
        public System.UInt64 EmployeeWorkGroupHistoryCode
        {
            get { return m_ui64_WorkGroupOperationHistoryCode; }
            set { m_ui64_WorkGroupOperationHistoryCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WG_OPERATION_MASTER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_WorkGroupOperationMasterCode;
        public System.UInt64 WorkGroupOperationMasterCode
        {
            get { return m_ui64_WorkGroupOperationMasterCode; }
            set { m_ui64_WorkGroupOperationMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ASSESSMENT_STATUS", typeof(SilkERP360.CCL.Enums.AssessmentStatus), false, false)]
        protected SilkERP360.CCL.Enums.AssessmentStatus m_enm_AssessmentStatus;
        public SilkERP360.CCL.Enums.AssessmentStatus AssessmentStatus
        {
            get { return m_enm_AssessmentStatus; }
            set { m_enm_AssessmentStatus = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        //protected System.UInt64 m_ui64_EntryEmployeeCode;
        //public System.UInt64 EntryEmployeeCode
        //{
        //    get { return m_ui64_EntryEmployeeCode; }
        //    set { m_ui64_EntryEmployeeCode = value; }
        //}

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), false, false, DatabaseMapping.DateTimeFormat.DateAndTime)]
        //protected System.DateTime m_dt_EntryDate;
        //public System.DateTime EntryDate
        //{
        //    get { return m_dt_EntryDate; }
        //    set { m_dt_EntryDate = value; }
        //}

       // [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_DELETED", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsDeleted;
        public SilkERP360.CCL.Enums.YesNo IsDeleted
        {
            get { return m_enm_IsDeleted; }
            set { m_enm_IsDeleted = value; }
        }


        protected SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile m_obj_EmployeeProfile;
        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile EmployeeProfile
        {
            get { return m_obj_EmployeeProfile; }
            set { m_obj_EmployeeProfile = value; }
        }
    }
}