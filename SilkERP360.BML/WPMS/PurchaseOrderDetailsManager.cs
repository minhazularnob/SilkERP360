using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class PurchaseOrderDetailsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails>
    {
       public PurchaseOrderDetailsManager()
       {
           this.Initialize();
       }


       public ulong Save(CCL.BusinessEntities.WPMS.PurchaseOrderDetails IP_obj_PurchaseOrderDetails, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_PurchaseOrderDetailsCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT WPMS_SEC_PURCHASE_ORDER_DETAILS.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_PurchaseOrderDetailsCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_PurchaseOrderDetails.PurchaseOrderDetailsCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_PurchaseOrderDetails.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_PurchaseOrderDetailsCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.PurchaseOrderDetails IP_obj_PurchaseOrderDetails)
       {
           System.UInt64 lcl_ui64_PurchaseOrderDetailsCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT WPMS_SEC_PURCHASE_ORDER_DETAILS.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_PurchaseOrderDetailsCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_PurchaseOrderDetails.PurchaseOrderDetailsCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_PurchaseOrderDetails.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_PurchaseOrderDetailsCode;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrderDetails Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_PurchaseOrderDetails = null;
           lcl_obj_PurchaseOrderDetails = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_PURCHASE_ORDER_DETAILS WHERE PURCHASE_ORDER_DETAILS_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
               lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
               lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
               lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());

               lcl_obj_dr.Close();
               return lcl_obj_TmpPurchaseOrderDetails;
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrderDetails;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrderDetails Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_PurchaseOrderDetails = null;
           lcl_obj_PurchaseOrderDetails = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_PURCHASE_ORDER_DETAILS WHERE PURCHASE_ORDER_DETAILS_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpPurchaseOrderDetails;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrderDetails;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrderDetails Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_PurchaseOrderDetails = null;
           lcl_obj_PurchaseOrderDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails>(() =>
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
               SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
               lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
               lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
               lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
               lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpPurchaseOrderDetails;
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrderDetails;
       }

       public CCL.BusinessEntities.WPMS.PurchaseOrderDetails Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_PurchaseOrderDetails = null;
           lcl_obj_PurchaseOrderDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails>(() =>
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
                   SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpPurchaseOrderDetails;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_PurchaseOrderDetails;
       }

       public List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_objlist_PurchaseOrderDetailsList = null;
           lcl_objlist_PurchaseOrderDetailsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_objlist_TmpPurchaseOrderDetailsList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpPurchaseOrderDetailsList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());
                   lcl_objlist_TmpPurchaseOrderDetailsList.Add(lcl_obj_TmpPurchaseOrderDetails);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpPurchaseOrderDetailsList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_PurchaseOrderDetailsList;
       }

       public List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_objlist_PurchaseOrderDetailsList = null;
           lcl_objlist_PurchaseOrderDetailsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_objlist_TmpPurchaseOrderDetailsList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpPurchaseOrderDetailsList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.WPMS.PurchaseOrderDetails lcl_obj_TmpPurchaseOrderDetails = new CCL.BusinessEntities.WPMS.PurchaseOrderDetails();
                       lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderDetailsCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_DETAILS_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.PurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["PURCHASE_ORDER_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                       lcl_obj_TmpPurchaseOrderDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                       lcl_obj_TmpPurchaseOrderDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.Weight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.TotalAmountCifFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.CurrencyCode = System.UInt64.Parse(lcl_obj_dr["CURRENCY_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.ConversionRate = System.Decimal.Parse(lcl_obj_dr["CONVERSION_RATE"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.Carton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.Cbm = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.PcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.Ppb = System.UInt32.Parse(lcl_obj_dr["PPB"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.Bpc = System.UInt32.Parse(lcl_obj_dr["BPC"].ToString());
                       lcl_obj_TmpPurchaseOrderDetails.QuotationDetailsCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_DETAILS_CODE"].ToString());
                       lcl_objlist_TmpPurchaseOrderDetailsList.Add(lcl_obj_TmpPurchaseOrderDetails);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpPurchaseOrderDetailsList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_PurchaseOrderDetailsList;
       }
    }
}
