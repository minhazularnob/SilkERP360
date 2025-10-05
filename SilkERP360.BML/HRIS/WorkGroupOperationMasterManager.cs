using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class WorkGroupOperationMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>
    {
       public WorkGroupOperationMasterManager()
       {
            this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_WorkGroupOperationMaster, object IP_obj_DBManager)
       {
           
           System.UInt64 lcl_ui64_WorkGroupOperationMasterCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WG_OP_HISTORY.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_WorkGroupOperationMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_WorkGroupOperationMaster.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_WorkGroupOperationMasterCode;
       }

       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_WorkGroupOperationMaster)
       {
           System.UInt64 lcl_ui64_WorkGroupOperationMasterCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WG_OP_MASTER.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_WorkGroupOperationMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_WorkGroupOperationMaster.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   IP_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode = lcl_ui64_ID;
                   if (IP_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection.Count > 0)
                   {
                       SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
                       foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection)
                       {
                           lcl_obj_WorkGroupOperationHistory.WorkGroupOperationMasterCode = IP_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode;
                           System.UInt64 lcl_ui64_OpHstryCode = lcl_obj_WorkGroupOperationHistoryManager.Save(lcl_obj_WorkGroupOperationHistory, lcl_obj_DBManager.InternalResource);
                           lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = lcl_ui64_OpHstryCode;
                       }
                   }

                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_WorkGroupOperationMasterCode;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
           lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From WORK_GROUP_OPERATION_MASTER WHERE WG_MASTER_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
               lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
               lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
               lcl_obj_dr.Close();

               //SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
               //lcl_obj_WorkGroupOperationHistoryManager.Initialize();

               //lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
               //lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
               return lcl_obj_TmpWorkGroupOperationMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationMaster;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
           lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From WORK_GROUP_OPERATION_MASTER WHERE WG_MASTER_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
                   lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_obj_dr.Close();
                   //SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
                   //lcl_obj_WorkGroupOperationHistoryManager.Initialize();

                   //lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                   //lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                   return lcl_obj_TmpWorkGroupOperationMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationMaster;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
           lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
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
               CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
               lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
               lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
               lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
               lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
               lcl_obj_dr.Close();

               //SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
               //lcl_obj_WorkGroupOperationHistoryManager.Initialize();

               //IP_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
               //lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(IP_str_SqlQuery, lcl_obj_DBManager);

               return lcl_obj_TmpWorkGroupOperationMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationMaster;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
           lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
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
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
                   lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_obj_dr.Close();

                   //SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
                   //lcl_obj_WorkGroupOperationHistoryManager.Initialize();

                   //IP_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                   //lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(IP_str_SqlQuery, lcl_obj_DBManager);

                   lcl_obj_DBManager.InternalResource.Close();
                   return lcl_obj_TmpWorkGroupOperationMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationMaster;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objlist_WorkGroupOperationMasterList = null;
           lcl_objlist_WorkGroupOperationMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               //{
               //    lcl_obj_DBManager.Open();
               //}
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objlist_TmpWorkGroupOperationMasterList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = null;
               lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               
               if (!(lcl_obj_dr.HasRows))
               {
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpWorkGroupOperationMasterList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
                   lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
                   lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
                   lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                   lcl_objlist_TmpWorkGroupOperationMasterList.Add(lcl_obj_TmpWorkGroupOperationMaster);
               }
               lcl_obj_dr.Close();

               SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
               lcl_obj_WorkGroupOperationHistoryManager.Initialize();

               foreach (CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster in lcl_objlist_TmpWorkGroupOperationMasterList)
               {
                   IP_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                   lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetListWithoutEmployeeProfile(IP_str_SqlQuery, lcl_obj_DBManager);
               }
               return lcl_objlist_TmpWorkGroupOperationMasterList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_WorkGroupOperationMasterList;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objlist_WorkGroupOperationMasterList = null;
           lcl_objlist_WorkGroupOperationMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objlist_TmpWorkGroupOperationMasterList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpWorkGroupOperationMasterList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_TmpWorkGroupOperationMaster = new CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                       lcl_obj_TmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_dr["WORK_DATE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_dr["WORKER_STRENGTH"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_dr["OPERATIONAL_STATUS"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED"].ToString()));
                       lcl_obj_TmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_dr["TOTAL_PRESENT"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_dr["TOTAL_ABSENT"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_dr["TOTAL_LATE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_dr["TOTAL_LEAVE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_dr["TOTAL_OFF"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_dr["DUTY_START_FROM"].ToString();
                       lcl_obj_TmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_dr["DUTY_HOUR"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_dr["OVERTIME_LIMIT"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_dr["IS_PROCESSED_FOR_SALARY"].ToString()));
                       lcl_obj_TmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_dr["DAY_ATTRIBUTE"].ToString()));
                       lcl_obj_TmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_dr["TOTAL_MAN_HOUR"].ToString());
                       lcl_obj_TmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_dr["TOTAL_OVERTIME"].ToString());
                       lcl_objlist_TmpWorkGroupOperationMasterList.Add(lcl_obj_TmpWorkGroupOperationMaster);
                   }
                   lcl_obj_dr.Close();

                   //SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new WorkGroupOperationHistoryManager();
                   //lcl_obj_WorkGroupOperationHistoryManager.Initialize();
                   
                   //foreach (CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster in lcl_objlist_TmpWorkGroupOperationMasterList)
                   //{
                   //    IP_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}",lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                   //    lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(IP_str_SqlQuery, lcl_obj_DBManager);
                   //}

                   lcl_obj_DBManager.InternalResource.Close();
                   return lcl_objlist_TmpWorkGroupOperationMasterList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_WorkGroupOperationMasterList;
       }
    }
}
