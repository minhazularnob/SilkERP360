using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class RelationBuyerProductManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct>
    {
       public RelationBuyerProductManager()
       {
           this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RelationBuyerProduct lcl_obj_RelationBuyerProduct, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_CustomerCode = 0;

           lcl_ui64_CustomerCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleParameter lcl_obj_RelationCode = new System.Data.OracleClient.OracleParameter("v_RELATION_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_RelationCode.Direction = System.Data.ParameterDirection.Output;
               //lcl_obj_WrokGroupCode.Value = lcl_obj_WrokGroup.WorkGroupCode;
               System.Data.OracleClient.OracleParameter lcl_obj_FinishedProductCode = new System.Data.OracleClient.OracleParameter("v_FINISHED_PRODUCT_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_FinishedProductCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_FinishedProductCode.Value = lcl_obj_RelationBuyerProduct.FinishedProductCode;
               System.Data.OracleClient.OracleParameter lcl_obj_BuyerCode = new System.Data.OracleClient.OracleParameter("v_BUYER_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_BuyerCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_BuyerCode.Value = lcl_obj_RelationBuyerProduct.BuyerCode;
               System.Data.OracleClient.OracleParameter lcl_obj_Phone = new System.Data.OracleClient.OracleParameter("v_PROCESSING_COST", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Phone.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Phone.Value = lcl_obj_RelationBuyerProduct.ProcessingCost;
               System.Data.OracleClient.OracleParameter lcl_obj_ContactPersion = new System.Data.OracleClient.OracleParameter("v_PRINTING_CHARGE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_ContactPersion.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ContactPersion.Value = lcl_obj_RelationBuyerProduct.PrintingCharge;

               System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value = lcl_obj_RelationBuyerProduct.Status;
              
               System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RelationCode, lcl_obj_FinishedProductCode, lcl_obj_BuyerCode, lcl_obj_Phone, lcl_obj_ContactPersion, lcl_obj_Status };
               lcl_obj_DBManager.ExecuteStoredProcedure("WPMS_INS_BUYER_PRODUCT", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_RelationCode.Value.ToString());
           }, "BMLExceptionPolicy");

           return lcl_ui64_CustomerCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RelationBuyerProduct lcl_obj_RelationBuyerProduct)
       {
           System.UInt64 lcl_ui64_BuyerCode = 0;
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleParameter lcl_obj_RelationCode = new System.Data.OracleClient.OracleParameter("v_RELATION_CODE", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_RelationCode.Direction = System.Data.ParameterDirection.Output;
                   //lcl_obj_WrokGroupCode.Value = lcl_obj_WrokGroup.WorkGroupCode;
                   System.Data.OracleClient.OracleParameter lcl_obj_FinishedProductCode = new System.Data.OracleClient.OracleParameter("v_FINISHED_PRODUCT_CODE", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_FinishedProductCode.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_FinishedProductCode.Value = lcl_obj_RelationBuyerProduct.FinishedProductCode;
                   System.Data.OracleClient.OracleParameter lcl_obj_BuyerCode = new System.Data.OracleClient.OracleParameter("v_BUYER_CODE", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_BuyerCode.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_BuyerCode.Value = lcl_obj_RelationBuyerProduct.BuyerCode;


                   System.Data.OracleClient.OracleParameter lcl_obj_Width = new System.Data.OracleClient.OracleParameter("v_WIDTH", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Width.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Width.Value = lcl_obj_RelationBuyerProduct.Width;
                   System.Data.OracleClient.OracleParameter lcl_obj_Gusset = new System.Data.OracleClient.OracleParameter("v_GUSSET", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Gusset.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Gusset.Value = lcl_obj_RelationBuyerProduct.Gusset;
                   System.Data.OracleClient.OracleParameter lcl_obj_Length = new System.Data.OracleClient.OracleParameter("v_LENGTH", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Length.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Length.Value = lcl_obj_RelationBuyerProduct.Length;
                   System.Data.OracleClient.OracleParameter lcl_obj_Density = new System.Data.OracleClient.OracleParameter("v_DENSITY", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Density.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Density.Value = lcl_obj_RelationBuyerProduct.Density;

                   System.Data.OracleClient.OracleParameter lcl_obj_Thickness = new System.Data.OracleClient.OracleParameter("v_THICKNESS", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Thickness.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Thickness.Value = lcl_obj_RelationBuyerProduct.Thickness;

                   System.Data.OracleClient.OracleParameter lcl_obj_PunchOut = new System.Data.OracleClient.OracleParameter("v_PUNCHOUT", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_PunchOut.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_PunchOut.Value = lcl_obj_RelationBuyerProduct.PunchOut;
                   System.Data.OracleClient.OracleParameter lcl_obj_ProcessingCost = new System.Data.OracleClient.OracleParameter("v_PROCESSING_COST", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_ProcessingCost.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_ProcessingCost.Value = lcl_obj_RelationBuyerProduct.ProcessingCost;


                   System.Data.OracleClient.OracleParameter lcl_obj_PrintingCharge = new System.Data.OracleClient.OracleParameter("v_PRINTING_CHARGE", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_PrintingCharge.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_PrintingCharge.Value = lcl_obj_RelationBuyerProduct.PrintingCharge;
                   System.Data.OracleClient.OracleParameter lcl_obj_SpecificationName = new System.Data.OracleClient.OracleParameter("v_SPECIFICATION_NAME", System.Data.OracleClient.OracleType.NVarChar,512);
                   lcl_obj_SpecificationName.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_SpecificationName.Value = lcl_obj_RelationBuyerProduct.SpecificationName;

                   System.Data.OracleClient.OracleParameter lcl_obj_Item = new System.Data.OracleClient.OracleParameter("v_ITEMCODE", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Item.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Item.Value = lcl_obj_RelationBuyerProduct.ItemCode;

                   System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Status.Value = 1;
                   System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RelationCode, lcl_obj_FinishedProductCode, lcl_obj_BuyerCode, lcl_obj_Width, lcl_obj_Gusset, lcl_obj_Length, lcl_obj_Density, lcl_obj_Thickness, lcl_obj_PunchOut, lcl_obj_ProcessingCost,lcl_obj_PrintingCharge, lcl_obj_SpecificationName,lcl_obj_Item, lcl_obj_Status };
                   lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("WPMS_INS_BUYER_PRODUCT", lcl_obj_SP_Parameters);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   lcl_obj_DBManager.InternalResource.Close();
                   return System.UInt64.Parse(lcl_obj_BuyerCode.Value.ToString());
               }
           }
           return lcl_ui64_BuyerCode;
       }

       public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.RelationBuyerProduct> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.RelationBuyerProduct> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> lcl_objLst_Quotation = null;
           
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_Reader.HasRows))
                   {
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (QuotationManager.GetList(SqlQuery)) : No Data Found In The Database!!!");
                   }
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> lcl_objLst_Items2Tmp = new
                       System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct>();
                   while (lcl_obj_Reader.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct();
                       lcl_obj_QuotationTmp.RelationCode = System.UInt64.Parse(lcl_obj_Reader["RELATION_CODE"].ToString());
                       lcl_obj_QuotationTmp.FinishedProductCode = System.UInt64.Parse(lcl_obj_Reader["FINISHED_PRODUCT_CODE"].ToString());
                       lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                       lcl_obj_QuotationTmp.ProcessingCost = System.Decimal.Parse(lcl_obj_Reader["PROCESSING_COST"].ToString());
                       lcl_obj_QuotationTmp.PrintingCharge = System.Decimal.Parse(lcl_obj_Reader["PRINTING_CHARGE"].ToString());
                       lcl_obj_QuotationTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                       lcl_obj_QuotationTmp.Width = System.Decimal.Parse(lcl_obj_Reader["WIDTH"].ToString());
                       lcl_obj_QuotationTmp.Length = System.Decimal.Parse(lcl_obj_Reader["LENGTH"].ToString());
                       lcl_obj_QuotationTmp.Gusset = System.Decimal.Parse(lcl_obj_Reader["GUSSET"].ToString());
                       lcl_obj_QuotationTmp.Density = System.Decimal.Parse(lcl_obj_Reader["DENSITY"].ToString());
                       lcl_obj_QuotationTmp.Thickness = System.Decimal.Parse(lcl_obj_Reader["THICKNESS"].ToString());
                       lcl_obj_QuotationTmp.SpecificationName = lcl_obj_Reader["SPECIFICATION_NAME"].ToString();
                       lcl_obj_QuotationTmp.PunchOut = System.Decimal.Parse(lcl_obj_Reader["PUNCHOUT"].ToString());
                       lcl_obj_QuotationTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());

                       lcl_objLst_Items2Tmp.Add(lcl_obj_QuotationTmp);
                   }
                   lcl_obj_Reader.Close();
                   return lcl_objLst_Items2Tmp;
               }
          
           return lcl_objLst_Quotation;
       }
    }
}
