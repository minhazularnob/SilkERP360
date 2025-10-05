using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("ATTENDANCE", "SEQ_ATTENDANCE")]
    public class Attendance : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTENDANCE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_AttendanceCode;
        public System.UInt64 AttendanceCode
        {
            get { return m_ui64_AttendanceCode; }
            set { this.m_ui64_AttendanceCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTENDANCE_MASTER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_AttnMasterCode;
        public System.UInt64 AttnMasterCode
        {
            get { return m_ui64_AttnMasterCode; }
            set { this.m_ui64_AttnMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_ID", typeof(System.String), true, false)]
        protected System.String m_str_EmployeeId;
        public System.String EmployeeId
        {
            get { return m_str_EmployeeId; }
            set { this.m_str_EmployeeId = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_NAME", typeof(System.String), true, false)]
        protected System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DEPARTMENT", typeof(System.String), true, false)]
        protected System.String m_str_Department;
        public System.String Department
        {
            get { return m_str_Department; }
            set { this.m_str_Department = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESIGNATION", typeof(System.String), true, false)]
        protected System.String m_str_Designation;
        public System.String Designation
        {
            get { return m_str_Designation; }
            set { this.m_str_Designation = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTENDANCE_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_AttendaneDate;
        public System.DateTime AttendaneDate
        {
            get { return m_dt_AttendaneDate; }
            set { this.m_dt_AttendaneDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_FROM", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DutyFrom;
        public System.DateTime DutyFrom
        {
            get { return m_dt_DutyFrom; }
            set { this.m_dt_DutyFrom = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_SCHEDULE_FROM", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DutyScheduleFrom;
        public System.DateTime DutyScheduleFrom
        {
            get { return m_dt_DutyScheduleFrom; }
            set { this.m_dt_DutyScheduleFrom = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_UPTO", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DutyUpto;
        public System.DateTime DutyUpto
        {
            get { return m_dt_DutyUpto; }
            set { this.m_dt_DutyUpto = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_SCHEDULE_UPTO", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DutyScheduleUpto;
        public System.DateTime DutyScheduleUpto
        {
            get { return m_dt_DutyScheduleUpto; }
            set { this.m_dt_DutyScheduleUpto = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IN_THROUGH", typeof(System.String), true, false)]
        protected System.String m_str_InThrough;
        public System.String InThrough
        {
            get { return m_str_InThrough; }
            set { this.m_str_InThrough = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_THROUGH", typeof(System.String), true, false)]
        protected System.String m_str_OutThrough;
        public System.String OutThrough
        {
            get { return m_str_OutThrough; }
            set { this.m_str_OutThrough = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IN_DOOR_NO", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_InDoorNo;
        public System.UInt32 InDoorNo
        {
            get { return m_ui32_InDoorNo; }
            set { this.m_ui32_InDoorNo = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_DOOR_NO", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_OutDoorNo;
        public System.UInt32 OutDoorNo
        {
            get { return m_ui32_OutDoorNo; }
            set { this.m_ui32_OutDoorNo = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DUTY_MINUTES", typeof(System.Double), true, false)]
        protected System.Double m_dbl_DutyMinutes;
        public System.Double DutyMinutes
        {
            get { return m_dbl_DutyMinutes; }
            set { this.m_dbl_DutyMinutes = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_AUTO", typeof(System.Double), true, false)]
        protected System.Double m_dbl_OvertimeAuto;
        public System.Double OvertimeAuto
        {
            get { return m_dbl_OvertimeAuto; }
            set { this.m_dbl_OvertimeAuto = System.Math.Round(value, 2); }
        }

        /// <summary>
        /// Signed. + For adding Minutes to OveertimeAuto and - to Substract from OvertimeAuto
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_MANUAL_ADJUSTMENT", typeof(System.Double), true, false)]
        protected System.Double m_dbl_OvertimeManualAdjustment;
        public System.Double OvertimeManualAdjustment
        {
            get { return m_dbl_OvertimeManualAdjustment; }
            set { this.m_dbl_OvertimeManualAdjustment = System.Math.Round(value, 2); }
        }

        /// <summary>
        /// Unit: Minute
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_TOTAL", typeof(System.Double), true, false)]
        protected System.Double m_dbl_OvertimeTotal;
        public System.Double OvertimeTotal
        {
            get { return m_dbl_OvertimeTotal; }
            set { this.m_dbl_OvertimeTotal = System.Math.Round(value, 2); }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTN_STATUS", typeof(SilkERP360.CCL.Enums.AttendanceStatus), true, false)]
        protected SilkERP360.CCL.Enums.AttendanceStatus m_ui16_AttnStatus;
        public SilkERP360.CCL.Enums.AttendanceStatus AttnStatus
        {
            get { return m_ui16_AttnStatus; }
            set { this.m_ui16_AttnStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_ENTRY_TYPE", typeof(SilkERP360.CCL.Enums.OvertimeEntryType), true, false)]
        protected SilkERP360.CCL.Enums.OvertimeEntryType m_enm_OvertimeEntryType;
        public SilkERP360.CCL.Enums.OvertimeEntryType OvertimeEntryType
        {
            get { return m_enm_OvertimeEntryType; }
            set { this.m_enm_OvertimeEntryType = value; }
        }

        /// <summary>
        /// /If OvertimeEntryType == Auto | None -> It Will be 0
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_OvertimeEntryEmployeeCode;
        public System.UInt64 OvertimeEntryEmployeeCode
        {
            get { return m_ui64_OvertimeEntryEmployeeCode; }
            set { this.m_ui64_OvertimeEntryEmployeeCode = value; }
        }

        /// <summary>
        /// The amount the employee gets paid per hour while processing Attendance
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PAID_PER_HOUR", typeof(System.Decimal), true, false)]
        protected System.Decimal m_ui64_PaidPerHour;
        public System.Decimal PaidPerHour
        {
            get { return m_ui64_PaidPerHour; }
            set { this.m_ui64_PaidPerHour = value; }
        }

        /// <summary>
        /// If Emp is NIGHT_BILL_ELIGIBLE and did duty during Night and left 
        /// office after 6 AM
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NIGHT_ALLOWANCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_ui64_NightAllowance;
        public System.Decimal NightAllowance
        {
            get { return m_ui64_NightAllowance; }
            set { this.m_ui64_NightAllowance = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        /// <summary>
        /// If NULL/0 -> Employee is Stray
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WG_OPERATION_MASTER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_WorkGroupOperationMasterCode;
        public System.UInt64 WorkGroupOperationMasterCode
        {
            get { return m_ui64_WorkGroupOperationMasterCode; }
            set { this.m_ui64_WorkGroupOperationMasterCode = value; }
        }

        /// <summary>
        /// Code of Employee that changed the status
        /// When Initial Value 0 when auto process insert in the db
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS_OVERRIDE_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_StatusOverrideEmployeeCode;
        public System.UInt64 StatusOverrideEmployeeCode
        {
            get { return m_ui64_StatusOverrideEmployeeCode; }
            set { this.m_ui64_StatusOverrideEmployeeCode = value; }
        }

        /// <summary>
        /// Code of Employee that adjusted the Overtime manually
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MANUAL_OT_ADJUSTMENT_EMP_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ManualOvertimeAdjustmentEmployeeCode;
        public System.UInt64 ManualOvertimeAdjustmentEmployeeCode
        {
            get { return m_ui64_ManualOvertimeAdjustmentEmployeeCode; }
            set { this.m_ui64_ManualOvertimeAdjustmentEmployeeCode = value; }
        }
    }
}
