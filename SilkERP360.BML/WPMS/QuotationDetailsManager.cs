using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class QuotationDetailsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>
    {
       public QuotationDetailsManager()
       {
           this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.QuotationDetails IP_obj_QuotationDetails, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_QuotationDCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT WPMS_SEC_QUOTATION_DEATILS.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_QuotationDCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_QuotationDetails.QuotationDCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_QuotationDetails.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_QuotationDCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.QuotationDetails IP_obj_QuotationDetails)
       {
           System.UInt64 lcl_ui64_QuotationDCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT WPMS_SEC_QUOTATION_DEATILS.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_QuotationDCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_QuotationDetails.QuotationDCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_QuotationDetails.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_QuotationDCode;
       }

       public CCL.BusinessEntities.WPMS.QuotationDetails Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
           lcl_obj_QuotationDetails = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_QUOTATION_D WHERE QUOTATION_D_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new CCL.BusinessEntities.WPMS.QuotationDetails();
               lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
               lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
               lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
               lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
               lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
               lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
               lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
               lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
               lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
               lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
               lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
              
               lcl_obj_dr.Close();
               return lcl_obj_TmpQuotationDetails;
           }, "BMLExceptionPolicy");
           return lcl_obj_QuotationDetails;
       }

       public CCL.BusinessEntities.WPMS.QuotationDetails Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
           lcl_obj_QuotationDetails = this.ExceptionManager.Process<CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_QUOTATION_D WHERE QUOTATION_D_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new CCL.BusinessEntities.WPMS.QuotationDetails();
                   lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpQuotationDetails;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_QuotationDetails;
       }

       public CCL.BusinessEntities.WPMS.QuotationDetails Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
           lcl_obj_QuotationDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
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
               SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails();
               lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
               lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
               lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
               lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
               lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
               lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
               lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
               lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
               lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
               lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
               lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
               lcl_obj_dr.Close();
               return lcl_obj_TmpQuotationDetails;
           }, "BMLExceptionPolicy");
           return lcl_obj_QuotationDetails;
       }

       public CCL.BusinessEntities.WPMS.QuotationDetails Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
           lcl_obj_QuotationDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
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
                   SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails();
                   lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpQuotationDetails;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_QuotationDetails;
       }

       public List<CCL.BusinessEntities.WPMS.QuotationDetails> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails> lcl_objlist_QuotationDetailsList = null;
           lcl_objlist_QuotationDetailsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails> lcl_objlist_TmpQuotationDetailsList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpQuotationDetailsList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new CCL.BusinessEntities.WPMS.QuotationDetails();
                   lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                   lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                   lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                   lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                   lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                   lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
                   lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
                   lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                   lcl_objlist_TmpQuotationDetailsList.Add(lcl_obj_TmpQuotationDetails);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpQuotationDetailsList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_QuotationDetailsList;
       }

       public List<CCL.BusinessEntities.WPMS.QuotationDetails> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails> lcl_objlist_QuotationDetailsList = null;
           lcl_objlist_QuotationDetailsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails> lcl_objlist_TmpQuotationDetailsList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.QuotationDetails>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpQuotationDetailsList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_TmpQuotationDetails = new CCL.BusinessEntities.WPMS.QuotationDetails();
                       lcl_obj_TmpQuotationDetails.QuotationDCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_D_CODE"].ToString());
                       lcl_obj_TmpQuotationDetails.QuotationMCode = System.UInt64.Parse(lcl_obj_dr["QUOTATION_M_CODE"].ToString());
                       lcl_obj_TmpQuotationDetails.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                       lcl_obj_TmpQuotationDetails.ProductRef = lcl_obj_dr["PRODUCT_REF"].ToString();
                       lcl_obj_TmpQuotationDetails.ProductDesc = lcl_obj_dr["PRODUCT_DESC"].ToString();
                       lcl_obj_TmpQuotationDetails.Quantity = System.Decimal.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpQuotationDetails.NetWeight = System.Decimal.Parse(lcl_obj_dr["NET_WEIGHT"].ToString());
                       lcl_obj_TmpQuotationDetails.UnitPriceCifFos = System.Decimal.Parse(lcl_obj_dr["UNIT_PRICE_CIF_FOS"].ToString());
                       lcl_obj_TmpQuotationDetails.TotalAmountCofFos = System.Decimal.Parse(lcl_obj_dr["TOTAL_AMOUNT_CIF_FOS"].ToString());
                       lcl_obj_TmpQuotationDetails.PkgCarton = System.UInt32.Parse(lcl_obj_dr["PKG_CARTON"].ToString());
                       lcl_obj_TmpQuotationDetails.PkgPcsPerCarton = System.UInt32.Parse(lcl_obj_dr["PKG_PCS_PER_CARTON"].ToString());
                       lcl_obj_TmpQuotationDetails.CBM = System.Decimal.Parse(lcl_obj_dr["CBM"].ToString());
                       lcl_obj_TmpQuotationDetails.PPB = System.UInt16.Parse(lcl_obj_dr["PPB"].ToString());
                       lcl_obj_TmpQuotationDetails.BPC = System.UInt16.Parse(lcl_obj_dr["BPC"].ToString());
                       lcl_obj_TmpQuotationDetails.QtyKg = System.Decimal.Parse(lcl_obj_dr["QTY_KG"].ToString());
                       lcl_objlist_TmpQuotationDetailsList.Add(lcl_obj_TmpQuotationDetails);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpQuotationDetailsList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_QuotationDetailsList;
       }
    }
}
