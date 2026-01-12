using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class WorkGroupOperationHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>
    {
       public WorkGroupOperationHistoryManager()
       {
          this.Initialize();
       }


       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationHistory IP_obj_WorkGroupOperationHistory, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_WorkGroupHistoryCode = 0;
           //System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WG_OP_HISTORY.NEXTVAL AS ID FROM DUAL");
            System.String lcl_str_SqlQuery = System.String.Format("select max(wg_operation_history_code)+1 as ID from work_group_operation_history");
            lcl_ui64_WorkGroupHistoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_WorkGroupOperationHistory.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_WorkGroupHistoryCode;
       }

       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationHistory IP_obj_WorkGroupOperationHistory)
       {
           System.UInt64 lcl_ui64_WorkGroupOperationHistoryCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WG_OP_HSTRY.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_WorkGroupOperationHistoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_WorkGroupOperationHistory.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_WorkGroupOperationHistoryCode;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From WORKS_GROUP_OPERATION_HISTORY WHERE WG_OPRATION_HISTORY_CODE = {0}", IP_ui64_Code);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_MASTER_CODE"].ToString());
               lcl_obj_dr.Close();
               SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
               lcl_obj_EmployeeProfileManager.Initialize();
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode, IP_obj_DBManager);
               return lcl_obj_TmpWorkGroupOperationHistory;
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From WORKS_GROUP_OPERATION_HISTORY WHERE WG_OPRATION_HISTORY_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_MASTER_CODE"].ToString());
                   lcl_obj_dr.Close();
                   SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
                   lcl_obj_EmployeeProfileManager.Initialize();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode, lcl_obj_DBManager);
                   lcl_obj_DBManager.InternalResource.Close();
                   return lcl_obj_TmpWorkGroupOperationHistory;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
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
               SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_MASTER_CODE"].ToString());
               lcl_obj_dr.Close();
               SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
               lcl_obj_EmployeeProfileManager.Initialize();
               lcl_obj_TmpWorkGroupOperationHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode, lcl_obj_DBManager);
               lcl_obj_DBManager.Close();
               return lcl_obj_TmpWorkGroupOperationHistory;
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
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
                   SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_MASTER_CODE"].ToString());
                   lcl_obj_dr.Close();
                   SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
                   lcl_obj_EmployeeProfileManager.Initialize();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode, lcl_obj_DBManager);
                   lcl_obj_DBManager.InternalResource.Close();
                   return lcl_obj_TmpWorkGroupOperationHistory;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> GetListWithoutEmployeeProfile(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_WorkGroupOperationHistoryList = null;
           lcl_objlist_WorkGroupOperationHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               //{
               //    lcl_obj_DBManager.Open();
               //}
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_TmpWorkGroupOperationHistoryList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpWorkGroupOperationHistoryList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.AssessmentStatus = (SilkERP360.CCL.Enums.AssessmentStatus)System.UInt16.Parse(lcl_obj_dr["ASSESSMENT_STATUS"].ToString());
                   lcl_objlist_TmpWorkGroupOperationHistoryList.Add(lcl_obj_TmpWorkGroupOperationHistory);
               }
               lcl_obj_dr.Close();

               SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
               lcl_obj_EmployeeProfileManager.Initialize();
               foreach (CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WGOPHistory in lcl_objlist_TmpWorkGroupOperationHistoryList)
               {
                   //lcl_obj_WGOPHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_WGOPHistory.EmployeeCode, lcl_obj_DBManager);
               }
               //lcl_obj_DBManager.Close();

               return lcl_objlist_TmpWorkGroupOperationHistoryList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_WorkGroupOperationHistoryList;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_WorkGroupOperationHistoryList = null;
           lcl_objlist_WorkGroupOperationHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_TmpWorkGroupOperationHistoryList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpWorkGroupOperationHistoryList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_MASTER_CODE"].ToString());
                   lcl_obj_TmpWorkGroupOperationHistory.AssessmentStatus = (SilkERP360.CCL.Enums.AssessmentStatus)System.UInt16.Parse(lcl_obj_dr["ASSESSMENT_STATUS"].ToString());
                   lcl_objlist_TmpWorkGroupOperationHistoryList.Add(lcl_obj_TmpWorkGroupOperationHistory);
               }
               lcl_obj_dr.Close();

               SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
               lcl_obj_EmployeeProfileManager.Initialize();
               foreach (CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WGOPHistory in lcl_objlist_TmpWorkGroupOperationHistoryList)
               {
                   lcl_obj_WGOPHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_WGOPHistory.EmployeeCode, lcl_obj_DBManager);
               }
               //lcl_obj_DBManager.Close();

               return lcl_objlist_TmpWorkGroupOperationHistoryList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_WorkGroupOperationHistoryList;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_WorkGroupOperationHistoryList = null;
           lcl_objlist_WorkGroupOperationHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objlist_TmpWorkGroupOperationHistoryList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpWorkGroupOperationHistoryList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory = new CCL.BusinessEntities.HRIS.WorkGroupOperationHistory();
                       lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode = System.UInt64.Parse(lcl_obj_dr["WG_OPERATION_HISTORY_CODE"].ToString());
                       lcl_obj_TmpWorkGroupOperationHistory.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpWorkGroupOperationHistory.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_dr["WG_MASTER_CODE"].ToString());
                       lcl_objlist_TmpWorkGroupOperationHistoryList.Add(lcl_obj_TmpWorkGroupOperationHistory);
                   }
                   lcl_obj_dr.Close();
                   SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new DataStructures.EmployeeProfileManager();
                   lcl_obj_EmployeeProfileManager.Initialize();
                   foreach (CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WGOPHistory in lcl_objlist_TmpWorkGroupOperationHistoryList)
                   {
                       lcl_obj_WGOPHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_WGOPHistory.EmployeeCode, lcl_obj_DBManager);
                   }
                   lcl_obj_DBManager.InternalResource.Close();
                   return lcl_objlist_TmpWorkGroupOperationHistoryList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_WorkGroupOperationHistoryList;
       }
    }
}
