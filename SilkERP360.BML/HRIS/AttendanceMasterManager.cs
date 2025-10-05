using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class AttendanceMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>
    {
       public AttendanceMasterManager()
       {
           this.Initialize();
       }


       public ulong Save(CCL.BusinessEntities.HRIS.AttendanceMaster IP_obj_AttendanceMaster, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_AttendanceMasterCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL",IP_obj_AttendanceMaster.GetSequence());
           lcl_ui64_AttendanceMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_AttendanceMaster.AttnMasterCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_AttendanceMaster.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

               if (IP_obj_AttendanceMaster.AttendanceList != null)
               {
                   SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                   lcl_obj_AttendanceManager.Initialize();
                   foreach (SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance in IP_obj_AttendanceMaster.AttendanceList)
                   {
                       try
                       {
                           lcl_obj_Attendance.AttnMasterCode = IP_obj_AttendanceMaster.AttnMasterCode;
                           lcl_obj_AttendanceManager.Save(lcl_obj_Attendance, IP_obj_DBManager);
                       }
                       catch (System.Exception EX)
                       {
                           int A = 0;
                           throw EX;
                       }
                   }
               }
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_AttendanceMasterCode;
       }

       public ulong Save(CCL.BusinessEntities.HRIS.AttendanceMaster IP_obj_AttendanceMaster)
       {
           System.UInt64 lcl_ui64_AttendanceMasterCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_AttendanceMaster.GetSequence());
           lcl_ui64_AttendanceMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   IP_obj_AttendanceMaster.AttnMasterCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_AttendanceMaster.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);

                   if (IP_obj_AttendanceMaster.AttendanceList != null)
                   {
                       SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                       lcl_obj_AttendanceManager.Initialize();
                       foreach (SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance in IP_obj_AttendanceMaster.AttendanceList)
                       {
                           lcl_obj_AttendanceManager.Save(lcl_obj_Attendance, lcl_obj_DBManager.InternalResource);
                       }
                   }

                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_AttendanceMasterCode;
       }

       public CCL.BusinessEntities.HRIS.AttendanceMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = null;
           lcl_obj_AttendanceMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From ATTENDANCE_MASTER WHERE ATTENDANCE_MASTER_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   lcl_obj_dr.Close();
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
               lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
               lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
               lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
               lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
               lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_dr.Close();

               //GET ATTENDANCE LIST
               lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0}", lcl_obj_TmpAttendanceMaster.AttnMasterCode);
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
               lcl_obj_AttendanceManager.Initialize();
               lcl_obj_TmpAttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);

               return lcl_obj_TmpAttendanceMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_AttendanceMaster;
       }

       public CCL.BusinessEntities.HRIS.AttendanceMaster Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = null;
           lcl_obj_AttendanceMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From ATTENDANCE_MASTER WHERE ATTENDANCE_MASTER_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       lcl_obj_dr.Close();
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                   lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
                   lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_dr.Close();

                   //GET ATTENDANCE LIST
                   lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0}", lcl_obj_TmpAttendanceMaster.AttnMasterCode);
                   SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                   lcl_obj_AttendanceManager.Initialize();
                   lcl_obj_TmpAttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                   return lcl_obj_TmpAttendanceMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_AttendanceMaster;
       }

       public CCL.BusinessEntities.HRIS.AttendanceMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = null;
           lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   lcl_obj_dr.Close();
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
               lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
               lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
               lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
               lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
               lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
               lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_dr.Close();

               //GET ATTENDANCE LIST
               lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0}", lcl_obj_TmpAttendanceMaster.AttnMasterCode);
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
               lcl_obj_AttendanceManager.Initialize();
               lcl_obj_TmpAttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);

               return lcl_obj_TmpAttendanceMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_AttendanceMaster;
       }

       public CCL.BusinessEntities.HRIS.AttendanceMaster Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = null;
           lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       lcl_obj_dr.Close();
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
                   lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
                   lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_dr.Close();

                   //GET ATTENDANCE LIST
                   System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0} ORDER BY ATTENDANCE_CODE ASC", lcl_obj_TmpAttendanceMaster.AttnMasterCode);
                   SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                   lcl_obj_AttendanceManager.Initialize();
                   lcl_obj_TmpAttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                   foreach (SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance in lcl_obj_TmpAttendanceMaster.AttendanceList)
                   {
                       System.Double lcl_dbl_OvertimeHour = lcl_obj_Attendance.OvertimeTotal / 60;
                       lcl_obj_TmpAttendanceMaster.TotalOvertimeAmount += System.Decimal.Round(((System.Decimal)lcl_dbl_OvertimeHour) * lcl_obj_Attendance.PaidPerHour,2);

                   }
                   if ((lcl_obj_TmpAttendanceMaster.TotalOvertime > 0) & (lcl_obj_TmpAttendanceMaster.TotalOvertime / 60 > 0))
                   {
                       lcl_obj_TmpAttendanceMaster.AverageCostOfOvertimePerHour = System.Decimal.Round(lcl_obj_TmpAttendanceMaster.TotalOvertimeAmount / (lcl_obj_TmpAttendanceMaster.TotalOvertime / 60), 2);
                   }
                   else
                   {
                       lcl_obj_TmpAttendanceMaster.AverageCostOfOvertimePerHour = 0;
                   }
                   /***********************************************************************************************************************/

                   /***********************************************************************************************************************/
                   return lcl_obj_TmpAttendanceMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_AttendanceMaster;
       }

       public List<CCL.BusinessEntities.HRIS.AttendanceMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objlist_AttendanceMasterList = null;
           lcl_objlist_AttendanceMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objlist_TmpAttendanceMasterList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpAttendanceMasterList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                   lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
                   lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                   lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
                   lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_objlist_TmpAttendanceMasterList.Add(lcl_obj_TmpAttendanceMaster);
               }
               lcl_obj_dr.Close();

               foreach (SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster in lcl_objlist_TmpAttendanceMasterList)
               {
                   //GET ATTENDANCE LIST
                   System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0}", lcl_obj_AttendanceMaster.AttnMasterCode);
                   SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                   lcl_obj_AttendanceManager.Initialize();
                   lcl_obj_AttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
               }
               return lcl_objlist_TmpAttendanceMasterList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_AttendanceMasterList;
       }

       public List<CCL.BusinessEntities.HRIS.AttendanceMaster> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objlist_AttendanceMasterList = null;
           lcl_objlist_AttendanceMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objlist_TmpAttendanceMasterList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.AttendanceMaster>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       lcl_obj_dr.Close();
                       return lcl_objlist_TmpAttendanceMasterList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                       lcl_obj_TmpAttendanceMaster.AttnMasterCode = System.UInt64.Parse(lcl_obj_dr["ATTENDANCE_MASTER_CODE"].ToString());
                       lcl_obj_TmpAttendanceMaster.AttendaneDate = System.DateTime.Parse(lcl_obj_dr["ATTENDANCE_DATE"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalProcessed = System.UInt32.Parse(lcl_obj_dr["TOTAL_PROCESSED"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalHoliday = System.UInt32.Parse(lcl_obj_dr["TOTAL_HOLIDAY"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OT"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalManHourServedOT = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OT"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalExpectedManhourOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_EXPECTED_OFF"].ToString());
                       lcl_obj_TmpAttendanceMaster.TotalManHourServedOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_MANHOUR_SERVED_OFF"].ToString());
                       lcl_obj_TmpAttendanceMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_SALARY_PROCESSED"].ToString()));
                       lcl_obj_TmpAttendanceMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                       lcl_obj_TmpAttendanceMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                       lcl_objlist_TmpAttendanceMasterList.Add(lcl_obj_TmpAttendanceMaster);
                   }
                   lcl_obj_dr.Close();

                   foreach (SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster in lcl_objlist_TmpAttendanceMasterList)
                   {
                       //GET ATTENDANCE LIST
                       System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE ATTENDANCE_MASTER_CODE = {0}", lcl_obj_AttendanceMaster.AttnMasterCode);
                       SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new AttendanceManager();
                       lcl_obj_AttendanceManager.Initialize();
                       lcl_obj_AttendanceMaster.AttendanceList = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                   }

                   return lcl_objlist_TmpAttendanceMasterList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_AttendanceMasterList;
       }
    }
}
