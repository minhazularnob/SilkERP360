using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class AttendanceManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>
    {
       public AttendanceManager()
       {
           this.Initialize();
       }



       public ulong Save(CCL.BusinessEntities.HRIS.Attendance IP_obj_Attendance, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_AttendanceCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Attendance.GetSequence());
           lcl_ui64_AttendanceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_Attendance.AttendanceCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_Attendance.GenerateSqlInsert();
               try
               {
                   lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               }
               catch (System.Exception EX)
               {
                   int H = 0;
                   throw EX;
               }
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_AttendanceCode;
       }

       public ulong Save(CCL.BusinessEntities.HRIS.Attendance IP_obj_Attendance)
       {
           System.UInt64 lcl_ui64_AttendanceCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Attendance.GetSequence());
           lcl_ui64_AttendanceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   IP_obj_Attendance.AttendanceCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_Attendance.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_AttendanceCode;
       }

       public CCL.BusinessEntities.HRIS.Attendance Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From ATTENDANCE WHERE ATTENDANCE_CODE = {0}", IP_ui64_Code);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new CCL.BusinessEntities.HRIS.Attendance();
               lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
               lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
               lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
               lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
               lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
               lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
               lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
               lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
               lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
               lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
               lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
               lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
               lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
               lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
               lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
               lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
               lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
               lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
               lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
               lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
               lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
               lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));

               lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                   ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpAttendance;
           }, "BMLExceptionPolicy");
           return lcl_obj_Attendance;
       }

       public CCL.BusinessEntities.HRIS.Attendance Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From ATTENDANCE WHERE ATTENDANCE_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new CCL.BusinessEntities.HRIS.Attendance();
                   lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
                   lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                   lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                   lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
                   lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
                   lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
                   lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
                   lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
                   lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
                   lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
                   lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
                   lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
                   lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
                   lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
                   lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));
                   lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                   ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpAttendance;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_Attendance;
       }

       public CCL.BusinessEntities.HRIS.Attendance Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   lcl_obj_dr.Close();
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new SilkERP360.CCL.BusinessEntities.HRIS.Attendance();
               lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
               lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
               lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
               lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
               lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
               lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
               lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
               lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
               lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
               lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
               lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
               lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
               lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
               lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
               lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
               lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
               lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
               lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
               lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
               lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
               lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
               lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));
               lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                   ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpAttendance;
           }, "BMLExceptionPolicy");
           return lcl_obj_Attendance;
       }

       public CCL.BusinessEntities.HRIS.Attendance Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new SilkERP360.CCL.BusinessEntities.HRIS.Attendance();
                   lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
                   lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                   lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                   lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
                   lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
                   lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
                   lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
                   lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
                   lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
                   lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
                   lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
                   lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
                   lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
                   lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
                   lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));
                   lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                   ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpAttendance;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_Attendance;
       }

       public List<CCL.BusinessEntities.HRIS.Attendance> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance> lcl_objlist_AttendanceList = null;
           lcl_objlist_AttendanceList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance> lcl_objlist_TmpAttendanceList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpAttendanceList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new CCL.BusinessEntities.HRIS.Attendance();
                   lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
                   lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                   lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                   lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
                   lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
                   lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
                   lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
                   lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
                   lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
                   lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
                   lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
                   lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
                   lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
                   lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
                   lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
                   lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
                   lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));
                   lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                   ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_objlist_TmpAttendanceList.Add(lcl_obj_TmpAttendance);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpAttendanceList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_AttendanceList;
       }

       public List<CCL.BusinessEntities.HRIS.Attendance> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance> lcl_objlist_AttendanceList = null;
           lcl_objlist_AttendanceList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance> lcl_objlist_TmpAttendanceList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpAttendanceList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.HRIS.Attendance lcl_obj_TmpAttendance = new CCL.BusinessEntities.HRIS.Attendance();
                       lcl_obj_TmpAttendance.AttendanceCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_CODE"].ToString());
                       lcl_obj_TmpAttendance.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                       lcl_obj_TmpAttendance.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpAttendance.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                       lcl_obj_TmpAttendance.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                       lcl_obj_TmpAttendance.Department = lcl_obj_dr["DEPARTMENT"].ToString();
                       lcl_obj_TmpAttendance.Designation = lcl_obj_dr["DESIGNATION"].ToString();
                       lcl_obj_TmpAttendance.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                       lcl_obj_TmpAttendance.DutyFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_FROM"].ToString());
                       lcl_obj_TmpAttendance.DutyUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_UPTO"].ToString());
                       lcl_obj_TmpAttendance.DutyScheduleFrom = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_FROM"].ToString());
                       lcl_obj_TmpAttendance.DutyScheduleUpto = System.DateTime.Parse(lcl_obj_dr["DUTY_SCHEDULE_UPTO"].ToString());
                       lcl_obj_TmpAttendance.InThrough = lcl_obj_dr["IN_THROUGH"].ToString();
                       lcl_obj_TmpAttendance.OutThrough = lcl_obj_dr["OUT_THROUGH"].ToString();
                       lcl_obj_TmpAttendance.DutyMinutes = System.Double.Parse(lcl_obj_dr["DUTY_MINUTES"].ToString());
                       lcl_obj_TmpAttendance.OvertimeAuto = System.Double.Parse(lcl_obj_dr["OVERTIME_AUTO"].ToString());
                       lcl_obj_TmpAttendance.OvertimeManualAdjustment = System.Double.Parse(lcl_obj_dr["OVERTIME_MANUAL_ADJUSTMENT"].ToString());
                       lcl_obj_TmpAttendance.OvertimeTotal = System.Double.Parse(lcl_obj_dr["OVERTIME_TOTAL"].ToString());
                       lcl_obj_TmpAttendance.ManualOvertimeAdjustmentEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANUAL_OT_ADJUSTMENT_EMP_CODE"].ToString());
                       lcl_obj_TmpAttendance.OvertimeEntryType = (SilkERP360.CCL.Enums.OvertimeEntryType)(System.Int32.Parse(lcl_obj_dr["OVERTIME_ENTRY_TYPE"].ToString()));
                       lcl_obj_TmpAttendance.OvertimeEntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_ENTRY_EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpAttendance.StatusOverrideEmployeeCode = System.UInt64.Parse(lcl_obj_dr["STATUS_OVERRIDE_EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpAttendance.PaidPerHour = System.Decimal.Parse(lcl_obj_dr["PAID_PER_HOUR"].ToString());
                       lcl_obj_TmpAttendance.NightAllowance = System.Decimal.Parse(lcl_obj_dr["NIGHT_ALLOWANCE"].ToString());
                       lcl_obj_TmpAttendance.AttnStatus = (SilkERP360.CCL.Enums.AttendanceStatus)(System.Int32.Parse(lcl_obj_dr["ATTN_STATUS"].ToString()));
                       lcl_obj_TmpAttendance.Remarks = lcl_obj_dr["REMARKS"].ToString();
                       lcl_obj_TmpAttendance.WorkGroupOperationMasterCode = (lcl_obj_dr["WG_OPERATION_MASTER_CODE"] == null)
                        ? 0 : System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                       lcl_objlist_TmpAttendanceList.Add(lcl_obj_TmpAttendance);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpAttendanceList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_AttendanceList;
       }
    }
}
