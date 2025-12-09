using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScpmSmQCMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>
    {
       public ScpmSmQCMasterManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmQCMaster IP_obj_ScpmSmQCMaster, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_SMQCMasterCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_MASTER_BATCH.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_SMQCMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmSmQCMaster.SMQCMasterCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmSmQCMaster.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

               
               //if (IP_obj_ScpmSmQCMaster.ScpmSmQCTestsList != null)
               //{
                   switch(IP_obj_ScpmSmQCMaster.SMQCTestType)
                   {
                       case CCL.Enums.SCPM.SMQCTestTypes.PeelOff:
                           SilkERP360.BML.SCPM.ScpmSmPeelOffQCManager lcl_obj_ScpmSmPeelOffQCManager = new SilkERP360.BML.SCPM.ScpmSmPeelOffQCManager();

                           foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQC in IP_obj_ScpmSmQCMaster.PeelOffTests)
                           {
                               //SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQC = (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC)lcl_obj_Object;
                               lcl_obj_ScpmSmPeelOffQC.SMQCMasterCode = lcl_ui64_ID;
                               lcl_obj_ScpmSmPeelOffQCManager.Save(lcl_obj_ScpmSmPeelOffQC, lcl_obj_DBManager);
                           }
                           break;
                   }

                   
               //}

               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_SMQCMasterCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmQCMaster IP_obj_A)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.SCPM.ScpmSmQCMaster Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster = null;
           lcl_obj_ScpmSmQCMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SM_QC_MASTER SM_QC_MASTER_CODE= {0} and STATUS = {1} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
               lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes) System.UInt64.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmQCMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmQCMaster;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmQCMaster Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster = null;
           lcl_obj_ScpmSmQCMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_SM_QC_MASTER SM_QC_MASTER_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
                   lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes)System.UInt16.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmQCMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmQCMaster;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> lcl_objlist_ScpmSmQCMaster = null;
           lcl_objlist_ScpmSmQCMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> lcl_objlist_TmpScpmSmQCMaster = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>();
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
                       lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                       lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                       lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                       lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes)System.UInt16.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
                       lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
                       lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                       lcl_objlist_TmpScpmSmQCMaster.Add(lcl_obj_TmpScpmSmQCMaster);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmSmQCMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmQCMaster;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> lcl_objlist_ScpmSmQCMaster = null;
           lcl_objlist_ScpmSmQCMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return null;
               }
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> lcl_objlist_TmpScpmSmQCMaster = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>();
               while (lcl_obj_dr.Read())
               {
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
                   lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes) System.UInt16.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   lcl_objlist_TmpScpmSmQCMaster.Add(lcl_obj_TmpScpmSmQCMaster);
               }
               lcl_obj_dr.Close();

               ///get QC Tests for each ScpmSmQCMaster
               System.String lcl_str_SqlQuery = System.String.Empty;
               foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster in lcl_objlist_TmpScpmSmQCMaster)
               {
                   switch (lcl_obj_ScpmSmQCMaster.SMQCTestType)
                   {
                       case CCL.Enums.SCPM.SMQCTestTypes.PeelOff:
                           lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SM_PEEL_OFF_QC WHERE SM_QC_MASTER_CODE = {0}",lcl_obj_ScpmSmQCMaster.SMQCMasterCode);
                           SilkERP360.BML.SCPM.ScpmSmPeelOffQCManager lcl_obj_ScpmSmPeelOffQCManager = new ScpmSmPeelOffQCManager();
                           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objLst_ScpmSmPeelOffQC =
                               lcl_obj_ScpmSmPeelOffQCManager.GetList(lcl_str_SqlQuery, IP_obj_DBManager).ToList < SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>();
                           //lcl_obj_ScpmSmQCMaster.ScpmSmQCTestsList = lcl_objLst_ScpmSmPeelOffQC.ToList<System.Object>();
                           break;
                   }
               }
               return lcl_objlist_TmpScpmSmQCMaster;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmQCMaster;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmQCMaster Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster = null;
           lcl_obj_ScpmSmQCMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
               lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes) System.UInt16.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
               lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmQCMaster;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmQCMaster;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmQCMaster Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster = null;
           lcl_obj_ScpmSmQCMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_TmpScpmSmQCMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster();
                   lcl_obj_TmpScpmSmQCMaster.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.SMQCTestType = (CCL.Enums.SCPM.SMQCTestTypes) System.UInt16.Parse(lcl_obj_dr["SM_QC_TEST_TYPE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.QCDate = System.DateTime.Parse(lcl_obj_dr["QC_DATE"].ToString());
                   lcl_obj_TmpScpmSmQCMaster.Status = (CCL.Enums.SCPM.SMQCMasterStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmQCMaster;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmQCMaster;
       }
    }
}
