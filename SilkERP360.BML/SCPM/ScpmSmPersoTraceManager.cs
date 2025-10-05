using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScpmSmPersoTraceManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>
    {
       public ScpmSmPersoTraceManager()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmPersoTrace IP_obj_ScpmSmPersoTrace, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_PersoTraceCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SM_PERSO_TRACE.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_PersoTraceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmSmPersoTrace.PersoTraceCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmSmPersoTrace.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_PersoTraceCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmPersoTrace IP_obj_A)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPersoTrace Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_ScpmSmPersoTrace = null;
           lcl_obj_ScpmSmPersoTrace = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SM_PERSO_TRACE SM_PERSO_TRACE_CODE= {0} and STATUS = {1} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
               lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
               lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
               lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());               
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmPersoTrace;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPersoTrace;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPersoTrace Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_ScpmSmPersoTrace = null;
           lcl_obj_ScpmSmPersoTrace = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_SM_PERSO_TRACE SM_PERSO_TRACE_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
                   lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmPersoTrace;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPersoTrace;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> lcl_objlist_ScpmSmPersoTrace = null;
           lcl_objlist_ScpmSmPersoTrace = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> lcl_objlist_TmpScpmSmPersoTrace = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>();
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
                       lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
                       lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
                       lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
                       lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_objlist_TmpScpmSmPersoTrace.Add(lcl_obj_TmpScpmSmPersoTrace);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmSmPersoTrace;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmPersoTrace;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> lcl_objlist_ScpmSmPersoTrace = null;
           lcl_objlist_ScpmSmPersoTrace = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return null;
               }
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace> lcl_objlist_TmpScpmSmPersoTrace = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>();
               while (lcl_obj_dr.Read())
               {
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
                   lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_objlist_TmpScpmSmPersoTrace.Add(lcl_obj_TmpScpmSmPersoTrace);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpScpmSmPersoTrace;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmPersoTrace;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPersoTrace Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_ScpmSmPersoTrace = null;
           lcl_obj_ScpmSmPersoTrace = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>(() =>
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
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
               lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
               lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
               lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
               lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmPersoTrace;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPersoTrace;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPersoTrace Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_ScpmSmSubBatch = null;
           lcl_obj_ScpmSmSubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace lcl_obj_TmpScpmSmPersoTrace = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace();
                   lcl_obj_TmpScpmSmPersoTrace.PersoTraceCode = System.UInt64.Parse(lcl_obj_dr["SM_PERSO_TRACE_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartICCID = System.UInt64.Parse(lcl_obj_dr["START_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndICCID = System.UInt64.Parse(lcl_obj_dr["END_ICCID"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.EndSerial = System.UInt32.Parse(lcl_obj_dr["END_SL"].ToString());
                   lcl_obj_TmpScpmSmPersoTrace.StartBarcode = lcl_obj_dr["START_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.EndBarcode = lcl_obj_dr["END_BARCODE"].ToString();
                   lcl_obj_TmpScpmSmPersoTrace.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmPersoTrace;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmSubBatch;
       }
    }
}
