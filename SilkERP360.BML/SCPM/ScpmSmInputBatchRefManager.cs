using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScpmSmInputBatchRefManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>
    {
       public ScpmSmInputBatchRefManager()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef IP_obj_ScpmSmInputBatchRef, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_IBFCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_INPUT_BATCH_REF.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_IBFCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmSmInputBatchRef.IBFCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmSmInputBatchRef.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_IBFCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef IP_obj_A)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_ScpmSmInputBatchRef = null;
           lcl_obj_ScpmSmInputBatchRef = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_INPUT_BATCH_REF IBF_CODE= {0} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
               lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
               lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());               

               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmInputBatchRef;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmInputBatchRef;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_ScpmSmInputBatchRef = null;
           lcl_obj_ScpmSmInputBatchRef = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From From SCPM_INPUT_BATCH_REF IBF_CODE= {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
                   lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmInputBatchRef;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmInputBatchRef;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> lcl_objlist_ScpmSmInputBatchRef = null;
           lcl_objlist_ScpmSmInputBatchRef = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>>(() =>
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
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> lcl_objlist_TmpScpmSmInputBatchRef = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>();
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
                       lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
                       lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                       lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());
                       lcl_objlist_TmpScpmSmInputBatchRef.Add(lcl_obj_TmpScpmSmInputBatchRef);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmSmInputBatchRef;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmInputBatchRef;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> lcl_objlist_ScpmSmInputBatchRef = null;
           lcl_objlist_ScpmSmInputBatchRef = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>>(() =>
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
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> lcl_objlist_TmpScpmSmInputBatchRef = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>();
               while (lcl_obj_dr.Read())
               {
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
                   lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());
                   lcl_objlist_TmpScpmSmInputBatchRef.Add(lcl_obj_TmpScpmSmInputBatchRef);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpScpmSmInputBatchRef;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmInputBatchRef;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_ScpmSmInputBatchRef = null;
           lcl_obj_ScpmSmInputBatchRef = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
               lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
               lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
               lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmInputBatchRef;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmInputBatchRef;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_ScpmSmInputBatchRef = null;
           lcl_obj_ScpmSmInputBatchRef = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_TmpScpmSmInputBatchRef = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef();
                   lcl_obj_TmpScpmSmInputBatchRef.IBFCode = System.UInt64.Parse(lcl_obj_dr["IBF_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.BatchCode = System.UInt64.Parse(lcl_obj_dr["BATCH_CODE"].ToString());
                   lcl_obj_TmpScpmSmInputBatchRef.RefBatchCode = System.UInt32.Parse(lcl_obj_dr["REF_BATCH_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmInputBatchRef;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmInputBatchRef;
       }
    }
}
