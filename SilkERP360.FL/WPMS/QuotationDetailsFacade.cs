using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class QuotationDetailsFacade 
    {

//       public ulong Save(CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails)
//       {
//           System.UInt64 lcl_ui64_QuotationDetailsCode = 0;
//           {
//               SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationDetailsManager = new BML.WPMS.QuotationDetailsManager();
//               System.UInt64 lcl_ui64_QuotationCodeTmp = lcl_obj_QuotationDetailsManager.Save(lcl_obj_QuotationDetails);
//               return lcl_ui64_QuotationCodeTmp;
//           };
//           return lcl_ui64_QuotationDetailsCode;
//       }

//       public CCL.BusinessEntities.WPMS.QuotationDetails Get(ulong IP_ui64_Code)
//       {
//           SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
//           lcl_obj_QuotationDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
//           {
//               SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationDetailsManager = new SilkERP360.BML.WPMS.QuotationDetailsManager();
//               SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetailsTmp = lcl_obj_QuotationDetailsManager.Get(IP_ui64_Code);
//               return lcl_obj_QuotationDetailsTmp;
//           }, "FLExceptionPolicy");

//           return lcl_obj_QuotationDetails;
//       }

//       public CCL.BusinessEntities.WPMS.QuotationDetails Get(string IP_str_SqlQuery)
//       {
//           SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_QuotationDetails = null;
//           lcl_obj_QuotationDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>(() =>
//           {
//               SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationDetailsManager = new SilkERP360.BML.WPMS.QuotationDetailsManager();
//               SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_WorkGroupTmp = lcl_obj_QuotationDetailsManager.Get(IP_str_SqlQuery);
//               return lcl_obj_WorkGroupTmp;
//           }, "FLExceptionPolicy");
//           return lcl_obj_QuotationDetails;
//       }

//       //public List<CCL.BusinessEntities.WPMS.QuotationDetails> GetList(string IP_str_SqlQuery)
//       //{
//       //    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> lcl_obj_QuotationDetails = null;
//       //    //lcl_obj_QuotationDetails = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails>>(() =>
//       //    //{
//       //    //    SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationDetailsManager = new SilkERP360.BML.WPMS.QuotationDetailsManager();
//       //    //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> QuotationDetailsTmp =
//       //    //        lcl_obj_QuotationDetailsManager.GetList(IP_str_SqlQuery);
//       //    //    return QuotationDetailsTmp;
//       //    //}, "FLExceptionPolicy");
//       //    //return lcl_obj_QuotationDetails;
//       //}

//       public int Update(CCL.BusinessEntities.WPMS.QuotationDetails IP_obj_T)
//       {
//           throw new NotImplementedException();
//       }

//       public int Update(string IP_str_SqlUpdateQuery)
//       {
//           System.Int32 lcl_i32_RowsUpdated = this.ExceptionManager.Process<System.Int32>(() =>
//           {
//               System.Int32 lcl_i32_RowsUpdatedTmp = 0;
//               SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
//               System.Object lcl_obj_Response = lcl_obj_SqlManager.ExecuteScaler(IP_str_SqlUpdateQuery);
//               lcl_obj_SqlManager.Close();
//               lcl_i32_RowsUpdatedTmp = System.Int32.Parse(lcl_obj_Response.ToString());
//               return lcl_i32_RowsUpdatedTmp;
//           }, "FLExceptionPolicy");
//           return lcl_i32_RowsUpdated;
//       }

////       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
////       {
//////           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> lcl_obj_Quotation = null;

//////           System.String lcl_str_SqlQuery = System.String.Format(@"Select E.QUOTATION_CODE,E.CUSTOMER_REQ,E.BUYER_CODE,D.BUYER_CODE,D.COMPANY_NAME,QD.QUOTATION_DETAILS_CODE,QD.QUOTATION_CODE,QD.PRODUCT_REF,QD.PRODUCT_DESC,
//////QD.PRODUCT_SIZE,QD.QUANTITY,QD.WEIGHT,QD.UNIT_PRICE_CIF_FOS,QD.TOTAL_AMOUNT_CIF_FOS,QD.CURRENCY_CODE,QD.CONVERSION_RATE,QD.PRODUCT_CODE,
//////QD.CARTON,QD.QTY_PKG,QD.CBM,QD.PCS_PER_CARTON,QD.ITEMNO,
//////QD.LENGTH,
//////QD.DENSITY,
//////QD.THICKNESS,
//////QD.GUSSET,
//////QD.PPB,
//////QD.BPC
//////From WPMS_QUOTATION E
//////inner join WPMS_BUYER D 
//////on E.BUYER_CODE=D.BUYER_CODE
//////inner join WPMS_QUOTATION_DETAILS QD
//////on E.QUOTATION_CODE=QD.QUOTATION_CODE where QUOTATION_CODE={0}", IP_str_SqlQuery);
//////               SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationDetailsManager();
//////               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> lcl_obj_QuotationTmp =
//////                   lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
//////               return lcl_obj_QuotationTmp;
       
//////           return lcl_obj_Quotation;
////       }
    }
}
