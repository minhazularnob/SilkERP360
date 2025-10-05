using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class PurchaseOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>
    {
       public PurchaseOrderManager()
       {
           this.Initialize();
       }


       public ulong Save(CCL.BusinessEntities.WPMS.PurchaseOrder IP_obj_PurchaseOrder, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_PurchaseOrderCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WPMS_PURCHASE_ORDER.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_PurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_PurchaseOrder.PurchaseOrderCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_PurchaseOrder.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_PurchaseOrderCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.PurchaseOrder IP_obj_PurchaseOrder)
       {
           System.UInt64 lcl_ui64_PurchaseOrderCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WPMS_PURCHASE_ORDER.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_PurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_PurchaseOrder.PurchaseOrderCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_PurchaseOrder.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_PurchaseOrderCode;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
           lcl_obj_PurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_PURCHASE_ORDER WHERE PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new CCL.BusinessEntities.WPMS.PurchaseOrder();
               lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
               lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
               lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
               lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
               lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
               lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
               lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
               lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
               lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());              

               lcl_obj_dr.Close();
               return lcl_obj_TmpPurchaseOrder;
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrder;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrder Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
           lcl_obj_PurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_PURCHASE_ORDER WHERE PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new CCL.BusinessEntities.WPMS.PurchaseOrder();
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
                   lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                   lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
                   lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpPurchaseOrder;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrder;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
           lcl_obj_PurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
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
               SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder();
               lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
               lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
               lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
               lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
               lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
               lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
               lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
               lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
               lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpPurchaseOrder;
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrder;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrder Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
           lcl_obj_PurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
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
                   SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder();
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
                   lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                   lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
                   lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpPurchaseOrder;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrder;
       }

       public List<CCL.BusinessEntities.WPMS.PurchaseOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_objlist_PurchaseOrderList = null;
           lcl_objlist_PurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_objlist_TmpPurchaseOrderList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpPurchaseOrderList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new CCL.BusinessEntities.WPMS.PurchaseOrder();
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
                   lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                   lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
                   lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
                   lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());
                   lcl_objlist_TmpPurchaseOrderList.Add(lcl_obj_TmpPurchaseOrder);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpPurchaseOrderList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_PurchaseOrderList;
       }

       public List<CCL.BusinessEntities.WPMS.PurchaseOrder> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_objlist_PurchaseOrderList = null;
           lcl_objlist_PurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_objlist_TmpPurchaseOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrder>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpPurchaseOrderList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_TmpPurchaseOrder = new CCL.BusinessEntities.WPMS.PurchaseOrder();
                       lcl_obj_TmpPurchaseOrder.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrder.BuyerCode = System.UInt64.Parse(lcl_obj_dr["BUYER_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrder.PurchaseOrderDate = System.DateTime.Parse(lcl_obj_dr["PURCHASE_ORDER_DATE"].ToString());
                       lcl_obj_TmpPurchaseOrder.IsActive = System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                       lcl_obj_TmpPurchaseOrder.CustomerReq = lcl_obj_dr["CUSTOMER_REQ"].ToString();
                       lcl_obj_TmpPurchaseOrder.ComName = lcl_obj_dr["COM_NAME"].ToString();
                       lcl_obj_TmpPurchaseOrder.ComAddress = lcl_obj_dr["COM_ADDRESS"].ToString();
                       lcl_obj_TmpPurchaseOrder.ComPhone = lcl_obj_dr["COM_PHONE"].ToString();
                       lcl_obj_TmpPurchaseOrder.ComEmail = lcl_obj_dr["COM_EMAIL"].ToString();
                       lcl_obj_TmpPurchaseOrder.ComAmount = System.Decimal.Parse(lcl_obj_dr["COM_AMOUNT"].ToString());
                       lcl_obj_TmpPurchaseOrder.QuotationCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_CODE"].ToString());
                       lcl_objlist_TmpPurchaseOrderList.Add(lcl_obj_TmpPurchaseOrder);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpPurchaseOrderList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_PurchaseOrderList;
       }
    }
}
