using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScJobOrderItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>
    {
       public ScpmScJobOrderItemManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrderItem IP_obj_ScpmScJobOrderItem, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ScpmScJobOrderItemCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_JO_ITEM.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_ScpmScJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmScJobOrderItem.ScJOItemCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmScJobOrderItem.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScpmScJobOrderItemCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrderItem IP_obj_ScpmScJobOrderItem)
       {
           System.UInt64 lcl_ui64_ScpmScJobOrderItemCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_JO_ITEM.NEXTVAL AS ID FROM DUAL", IP_obj_ScpmScJobOrderItem.GetSequence());
           lcl_ui64_ScpmScJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_ScpmScJobOrderItem.ScJOItemCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_ScpmScJobOrderItem.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScpmScJobOrderItemCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem = null;
           lcl_obj_ScpmScJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_JOB_ORDER_ITEM WHERE SC_JO_ITEM_CODE = {0}", IP_ui64_Code);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
               lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());

              lcl_obj_dr.Close();
               return lcl_obj_TmpScpmScJobOrderItem;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrderItem;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem = null;
           lcl_obj_ScpmScJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_JOB_ORDER_ITEM WHERE SC_JO_ITEM_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
                   lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmScJobOrderItem;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrderItem;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem = null;
           lcl_obj_ScpmScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
               lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
               lcl_obj_dr.Close();

               return lcl_obj_TmpScpmScJobOrderItem;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrderItem;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem = null;
           lcl_obj_ScpmScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
                   lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmScJobOrderItem;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrderItem;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_objlist_ScpmScJobOrderItemList = null;
           lcl_objlist_ScpmScJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_objlist_TmpScpmScJobOrderItemList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpScpmScJobOrderItemList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
                   lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_objlist_TmpScpmScJobOrderItemList.Add(lcl_obj_TmpScpmScJobOrderItem);
               }
               lcl_obj_dr.Close();


               return lcl_objlist_TmpScpmScJobOrderItemList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmScJobOrderItemList;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_objlist_ScpmScJobOrderItemList = null;
           lcl_objlist_ScpmScJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_objlist_TmpScpmScJobOrderItemList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpScpmScJobOrderItemList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_TmpScpmScJobOrderItem = new CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
                       lcl_obj_TmpScpmScJobOrderItem.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.ScPOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                       lcl_obj_TmpScpmScJobOrderItem.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                       lcl_objlist_TmpScpmScJobOrderItemList.Add(lcl_obj_TmpScpmScJobOrderItem);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmScJobOrderItemList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmScJobOrderItemList;
       }
    }
}
