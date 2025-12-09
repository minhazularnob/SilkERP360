using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScpmSmSubBatchManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>
    {
       public ScpmSmSubBatchManager()
       {
           this.Initialize();
       }
       

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmSubBatch IP_obj_SubBatch, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_BatchCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SM_BATCH.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_BatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               /***************************************************************************************************************/
               //Generate Sub_Batch number
               lcl_str_SqlQuery = System.String.Format("SELECT MAX(SUB_BATCH) FROM SCPM_SM_BATCH WHERE MASTER_BATCH_CODE = {0}", IP_obj_SubBatch.MasterBatchCode);
               System.Object lcl_obj_SubBatch = lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
               System.String lcl_str_SubBatch = lcl_obj_SubBatch.ToString();
               System.UInt32 lcl_ui32_SubBatch = 0;
               if (lcl_str_SubBatch.Trim().Length == 0)
               {
                   lcl_ui32_SubBatch = 0;
               }
               else
               {
                   lcl_ui32_SubBatch = System.UInt32.Parse(lcl_str_SubBatch);
               }
               lcl_ui32_SubBatch++;
               IP_obj_SubBatch.SubBatch = lcl_ui32_SubBatch;
               /***************************************************************************************************************/
               IP_obj_SubBatch.BatchCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_SubBatch.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_BatchCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmSubBatch IP_obj_SubBatch)
       {
           System.UInt64 lcl_ui64_BatchCode = 0;
           System.UInt64 lcl_ui64_ID = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SM_BATCH.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_BatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   IP_obj_SubBatch.BatchCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_SubBatch.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);

                   //Save InputBatchReference 
                   if (IP_obj_SubBatch.SMInputBatchRefList != null)
                   {
                       SilkERP360.BML.SCPM.ScpmSmInputBatchRefManager lcl_obj_InputBatchRefManager = new ScpmSmInputBatchRefManager();
                       foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_SmInputBatchRef in IP_obj_SubBatch.SMInputBatchRefList)
                       {
                           lcl_obj_InputBatchRefManager.Save(lcl_obj_SmInputBatchRef, lcl_obj_DBManager.InternalResource);
                       }
                   }

                   //Save QCMaster
                   if (IP_obj_SubBatch.SMQCMasterList != null)
                   {
                       SilkERP360.BML.SCPM.ScpmSmQCMasterManager lcl_obj_ScpmSmQCMasterManager = new ScpmSmQCMasterManager();
                       foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster in IP_obj_SubBatch.SMQCMasterList)
                       {
                           lcl_obj_ScpmSmQCMasterManager.Save(lcl_obj_ScpmSmQCMaster, lcl_obj_DBManager.InternalResource);
                       }
                   }
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
               }
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_BatchCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmSubBatch Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_SubBatch = null;
           lcl_obj_SubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_BATCH BATCH_CODE= {0} and STATUS = {1} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
               lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
               lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus) System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());              
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmSubBatch;
           }, "BMLExceptionPolicy");
           return lcl_obj_SubBatch;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmSubBatch Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_SubBatch = null;
           lcl_obj_SubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_BATCH BATCH_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
                   lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());                  

                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmSubBatch;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_SubBatch;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> lcl_objlist_ScpmSmSubBatch = null;
           lcl_objlist_ScpmSmSubBatch = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> lcl_objlist_TmpScpmSmSubBatch = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); 
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
                       lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
                       lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                       lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());              
                       lcl_objlist_TmpScpmSmSubBatch.Add(lcl_obj_TmpScpmSmSubBatch);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmSmSubBatch;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmSubBatch;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> lcl_objlist_ScpmSmSubBatch = null;
           lcl_objlist_ScpmSmSubBatch = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> lcl_objlist_TmpScpmSmSubBatch = new
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>();
               if (!(lcl_obj_dr.HasRows))
               {
                   return null; ;
               }
               
               while (lcl_obj_dr.Read())
               {
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
                   lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());              
                   lcl_objlist_TmpScpmSmSubBatch.Add(lcl_obj_TmpScpmSmSubBatch);
               }
               lcl_obj_dr.Close();

               //get details of each batch
               SilkERP360.BML.SCPM.ScpmSmInputBatchRefManager lcl_obj_ScpmSmInputBatchRefManager = new ScpmSmInputBatchRefManager();
               SilkERP360.BML.SCPM.ScpmSmQCMasterManager lcl_obj_ScpmSmQCMasterManager = new ScpmSmQCMasterManager();
               System.String lcl_str_SqlQuery = System.String.Empty;
               foreach (CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_SmSubBatchStatus in lcl_objlist_TmpScpmSmSubBatch)
               {
                   lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_INPUT_BATCH_REF WHERE BATCH_CODE = {0}", lcl_obj_SmSubBatchStatus.BatchCode);
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> lcl_objLst_ScpmSmInputBatchRef = lcl_obj_ScpmSmInputBatchRefManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                   lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SM_QC_MASTER WHERE BATCH_CODE = {0}", lcl_obj_SmSubBatchStatus.BatchCode);
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> lcl_objLst_ScpmSmQCMaster = lcl_obj_ScpmSmQCMasterManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
               }

               return lcl_objlist_TmpScpmSmSubBatch;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmSubBatch;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmSubBatch Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_ScpmSmSubBatch = null;
           lcl_obj_ScpmSmSubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
               lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
               lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
               lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());              
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmSubBatch;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmSubBatch;
       }
       public CCL.BusinessEntities.SCPM.ScpmSmSubBatch Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_ScpmSmSubBatch = null;
           lcl_obj_ScpmSmSubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_TmpScpmSmSubBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch();
                   lcl_obj_TmpScpmSmSubBatch.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.OperatorCode = System.UInt64.Parse(lcl_obj_dr["OPERATOR_CODE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.BatchDate = System.DateTime.Parse(lcl_obj_dr["BATCH_DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Wastage = System.UInt32.Parse(lcl_obj_dr["WASTAGE"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalReleased = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.TotalRemaining = System.UInt32.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmSmSubBatch.DeliveryStatus = (CCL.Enums.SCPM.SMSubBatchDeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmSmSubBatch.Status = (CCL.Enums.SCPM.SMSubBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());              
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmSubBatch;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmSubBatch;
       }
    }
}
