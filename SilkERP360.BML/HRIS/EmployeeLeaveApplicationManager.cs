using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class EmployeeLeaveApplicationManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>
    {
       public EmployeeLeaveApplicationManager()
       {
           this.Initialize();
       }


       public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_LeaveApplication, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_LeaveApplicationCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL",IP_obj_LeaveApplication.GetSequence());
           lcl_ui64_LeaveApplicationCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_LeaveApplication.LeaveApplicationCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_LeaveApplication.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_LeaveApplicationCode;
       }

       /// <summary>
       /// 1. Save Leave App
       /// 2. Adjust LeaveAccount
       /// 3. If Attendance has been processed, update Attendance status to O.L
       /// 4. 
       /// </summary>
       /// <param name="IP_obj_LeaveApplication"></param>
       /// <returns></returns>
       public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_LeaveApplication)
       {
           System.UInt64 lcl_ui64_LeaveApplicationCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL",IP_obj_LeaveApplication.GetSequence());
           lcl_ui64_LeaveApplicationCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_LeaveApplication.LeaveApplicationCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_LeaveApplication.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);

                   //Adjust Leave Account
                   System.String lcl_str_UpdateLeaveAccountQuery = System.String.Empty;
                   switch (IP_obj_LeaveApplication.LeaveType)
                   {
                       case CCL.Enums.LeaveType.CL:
                           lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = CL - {0} WHERE EMPLOYEE_CODE = {1}", IP_obj_LeaveApplication.NumOfDays, IP_obj_LeaveApplication.EmployeeCode);
                           break;
                       case CCL.Enums.LeaveType.SL:
                           lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET SL = SL - {0} WHERE EMPLOYEE_CODE = {1}", IP_obj_LeaveApplication.NumOfDays, IP_obj_LeaveApplication.EmployeeCode);
                           break;
                       case CCL.Enums.LeaveType.ML:
                           lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET ML = ML - {0} WHERE EMPLOYEE_CODE = {1}", IP_obj_LeaveApplication.NumOfDays, IP_obj_LeaveApplication.EmployeeCode);
                           break;
                       case CCL.Enums.LeaveType.EL:
                           lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET EL = EL - {0} WHERE EMPLOYEE_CODE = {1}", IP_obj_LeaveApplication.NumOfDays, IP_obj_LeaveApplication.EmployeeCode);
                           break;
                   }
                   
                   if ((IP_obj_LeaveApplication.LeaveCategory != CCL.Enums.LeaveCategory.Unpaid) && (IP_obj_LeaveApplication.LeaveType != CCL.Enums.LeaveType.None))
                   {
                       //Paid Leave. Adjust Leave Account
                       lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);
                   }
                   else
                   {
                       //Unpaid Leave.No need to adjust Leave Account. 
                       //Make deduction
                       //Get Employee Salary
                       SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_EmployeeSalaryStructureManager = new EmployeeSalaryStructureManger();
                       lcl_obj_EmployeeSalaryStructureManager.Initialize();
                       SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = lcl_obj_EmployeeSalaryStructureManager.Get(IP_obj_LeaveApplication.EmployeeCode, lcl_obj_DBManager.InternalResource);
                       //Get Number Of Days for Leave Application
                       System.Double lcl_dbl_NumberOfDaysLeave = ((IP_obj_LeaveApplication.LeaveEndDate - IP_obj_LeaveApplication.LeaveStartDate).TotalDays + 1);//1 added toMatch
                       //get Salary Month & Year. The month of the Leave start date
                       System.Int32 lcl_i32_SalaryMonth = IP_obj_LeaveApplication.LeaveStartDate.Month;
                       System.Int32 lcl_i32_SalaryYear = IP_obj_LeaveApplication.LeaveStartDate.Year;
                       //get one day Basic salary
                       System.Decimal lcl_dcm_OneDayBasicSalary = lcl_obj_EmployeeSalaryStructure.Basic / 30;
                   }

                   //Update Attendance
                   SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                   lcl_obj_AttendanceManager.Initialize();
                   System.String lcl_str_AttendanceQuery = System.String.Empty;
                   for (System.DateTime lcl_obj_Date = IP_obj_LeaveApplication.LeaveStartDate; lcl_obj_Date <= IP_obj_LeaveApplication.LeaveEndDate; lcl_obj_Date = lcl_obj_Date.AddDays(1))
                   {
                       //if Attendance Processed for the date
                       lcl_str_AttendanceQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", IP_obj_LeaveApplication.EmployeeCode, lcl_obj_Date.ToString("dd/M/yyyy"));
                       SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_AttendanceQuery, lcl_obj_DBManager.InternalResource);
                       if (lcl_obj_Attendance == null)
                       {
                           continue;
                       }
                       //Update Attendance Status
                       lcl_str_AttendanceQuery = System.String.Format("UPDATE ATTENDANCE SET ATTN_STATUS = {0} WHERE ATTENDANCE_CODE = {1}", (System.UInt32)SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE, lcl_obj_Attendance.AttendanceCode);
                       lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_AttendanceQuery);
                       //Update WorkHour in AttendanceMaster
                       //Check If Employee is O.T Eligble
                       lcl_str_SqlQuery = System.String.Format("SELECT IS_OT_ELIGIBLE FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_obj_LeaveApplication.EmployeeCode);
                       Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                       lcl_obj_EmployeeReader.Read();
                       SilkERP360.CCL.Enums.YesNo lcl_enm_IsOTEligible = (CCL.Enums.YesNo)(System.UInt16.Parse(lcl_obj_EmployeeReader["IS_OT_ELIGIBLE"].ToString()));
                       lcl_obj_EmployeeReader.Close();
                       System.String lcl_str_UpdateAttendanceMasterQuery = System.String.Empty;
                       //Calculate stipulated duty hour
                       System.TimeSpan lcl_obj_ScheduledDutyHour = lcl_obj_Attendance.DutyScheduleUpto - lcl_obj_Attendance.DutyScheduleFrom;
                       System.Double lcl_dbl_ScheduleDutyHour = lcl_obj_ScheduledDutyHour.TotalHours;

                       if (lcl_enm_IsOTEligible == CCL.Enums.YesNo.Yes)
                       {
                           lcl_str_UpdateAttendanceMasterQuery = System.String.Format("UPDATE ATTENDANCE_MASTER SET TOTAL_MANHOUR_EXPECTED_OT = TOTAL_MANHOUR_EXPECTED_OT - {0},TOTAL_LEAVE = TOTAL_LEAVE + 1,TOTAL_ABSENT = TOTAL_ABSENT - 1 WHERE ATTENDANCE_MASTER_CODE = {1}", lcl_dbl_ScheduleDutyHour, lcl_obj_Attendance.AttnMasterCode);
                       }
                       else
                       {
                           lcl_str_UpdateAttendanceMasterQuery = System.String.Format("UPDATE ATTENDANCE_MASTER SET TOTAL_MANHOUR_EXPECTED_OFF = TOTAL_MANHOUR_EXPECTED_OFF - {0},TOTAL_LEAVE = TOTAL_LEAVE + 1,TOTAL_ABSENT = TOTAL_ABSENT - 1 WHERE ATTENDANCE_MASTER_CODE = {1}", lcl_dbl_ScheduleDutyHour, lcl_obj_Attendance.AttnMasterCode);
                       }
                       lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_UpdateAttendanceMasterQuery);
                   }
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_LeaveApplicationCode;
       }

       public CCL.BusinessEntities.HRIS.EmployeeLeaveApplication Get(ulong IP_ui64_LeaveApplication, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_LeaveApplication = null;
           lcl_obj_LeaveApplication = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_LEAVE_APPLICATION WHERE LEAVE_APPLICATION_CODE = {0}", IP_ui64_LeaveApplication);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   lcl_obj_dr.Close();
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
               lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
               lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.Reason= lcl_obj_dr["LEAVE_REASON"].ToString();
               lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());

               lcl_obj_dr.Close();
               return lcl_obj_TmpLeaveApplication;
           }, "BMLExceptionPolicy");
           return lcl_obj_LeaveApplication;
       }

       public CCL.BusinessEntities.HRIS.EmployeeLeaveApplication Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_LeaveApplication = null;
           lcl_obj_LeaveApplication = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_LEAVE_APPLICATION WHERE LEAVE_APPLICATION_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
                   lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
                   lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.Reason = lcl_obj_dr["LEAVE_REASON"].ToString();
                   lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpLeaveApplication;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_LeaveApplication;
       }

       public CCL.BusinessEntities.HRIS.EmployeeLeaveApplication Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_LeaveApplication = null;
           lcl_obj_LeaveApplication = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>(() =>
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
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
               lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
               lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
               lcl_obj_TmpLeaveApplication.Reason = lcl_obj_dr["LEAVE_REASON"].ToString();
               lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpLeaveApplication;
           }, "BMLExceptionPolicy");
           return lcl_obj_LeaveApplication;
       }

       public CCL.BusinessEntities.HRIS.EmployeeLeaveApplication Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_LeaveApplication = null;
           lcl_obj_LeaveApplication = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>(() =>
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
                   SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
                   lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
                   lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.Reason = lcl_obj_dr["LEAVE_REASON"].ToString();
                   lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpLeaveApplication;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_LeaveApplication;
       }

       public List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objlist_LeaveApplicationList = null;
           lcl_objlist_LeaveApplicationList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               //{
               //    lcl_obj_DBManager.Open();
               //}
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objlist_TmpLeaveApplicationList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   lcl_obj_dr.Close();
                   return null;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
                   lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
                   lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
                   lcl_obj_TmpLeaveApplication.Reason = lcl_obj_dr["LEAVE_REASON"].ToString();
                   lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_objlist_TmpLeaveApplicationList.Add(lcl_obj_TmpLeaveApplication);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpLeaveApplicationList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_LeaveApplicationList;
       }

       public List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objlist_LeaveApplicationList = null;
           lcl_objlist_LeaveApplicationList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objlist_TmpLeaveApplicationList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveApplication>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpLeaveApplicationList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_TmpLeaveApplication = new CCL.BusinessEntities.HRIS.EmployeeLeaveApplication();
                       lcl_obj_TmpLeaveApplication.LeaveApplicationCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_APPLICATION_CODE"].ToString());
                       lcl_obj_TmpLeaveApplication.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpLeaveApplication.ApplicationDate = System.DateTime.Parse(lcl_obj_dr["APPLICATION_DATE"].ToString());
                       lcl_obj_TmpLeaveApplication.LeaveType = (SilkERP360.CCL.Enums.LeaveType)System.UInt16.Parse(lcl_obj_dr["LEAVE_TYPE"].ToString());
                       lcl_obj_TmpLeaveApplication.LeaveCategory = (SilkERP360.CCL.Enums.LeaveCategory)System.UInt16.Parse(lcl_obj_dr["LEAVE_CATEGORY"].ToString());
                       lcl_obj_TmpLeaveApplication.LeaveStartDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_START_DATE"].ToString());
                       lcl_obj_TmpLeaveApplication.LeaveEndDate = System.DateTime.Parse(lcl_obj_dr["LEAVE_END_DATE"].ToString());
                       lcl_obj_TmpLeaveApplication.NumOfDays = System.UInt16.Parse(lcl_obj_dr["NUM_OF_DAYS"].ToString());
                       lcl_obj_TmpLeaveApplication.RejoinDate = System.DateTime.Parse(lcl_obj_dr["REJOIN_DATE"].ToString());
                       lcl_obj_TmpLeaveApplication.Reason = lcl_obj_dr["LEAVE_REASON"].ToString();
                       lcl_obj_TmpLeaveApplication.Remarks = lcl_obj_dr["REMARKS"].ToString();
                       lcl_obj_TmpLeaveApplication.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpLeaveApplication.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                       lcl_objlist_TmpLeaveApplicationList.Add(lcl_obj_TmpLeaveApplication);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpLeaveApplicationList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_LeaveApplicationList;
       }
    }
}
