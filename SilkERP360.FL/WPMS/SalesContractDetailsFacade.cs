using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
   public class SalesContractDetailsFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails>
    {
       public SalesContractDetailsFacade()
       { 
       }

       public ulong Save(CCL.BusinessEntities.WPMS.SalesContractDetails IP_obj_SalesContractDetails)
       {
           System.UInt64 lcl_ui64_SalesContractDetailsCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.WPMS.SalesContractDetailsManager lcl_obj_SalesContractDetailsManager = new BML.WPMS.SalesContractDetailsManager();
               System.UInt64 lcl_ui64_SalesContractDetailsCodeTmp = lcl_obj_SalesContractDetailsManager.Save(IP_obj_SalesContractDetails);
               return lcl_ui64_SalesContractDetailsCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_SalesContractDetailsCode;
       }

       public CCL.BusinessEntities.WPMS.SalesContractDetails Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractDetails = null;
           lcl_obj_SalesContractDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails>(() =>
           {
               SilkERP360.BML.WPMS.SalesContractDetailsManager lcl_obj_SalesContractDetailsManager = new SilkERP360.BML.WPMS.SalesContractDetailsManager();
               SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractDetailsTmp = lcl_obj_SalesContractDetailsManager.Get(IP_ui64_Code);
               return lcl_obj_SalesContractDetailsTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_SalesContractDetails;
       }

       public CCL.BusinessEntities.WPMS.SalesContractDetails Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractDetails = null;
           lcl_obj_SalesContractDetails = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails>(() =>
           {
               SilkERP360.BML.WPMS.SalesContractDetailsManager lcl_obj_SalesContractDetailsManager = new SilkERP360.BML.WPMS.SalesContractDetailsManager();
               SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractDetailsTmp = lcl_obj_SalesContractDetailsManager.Get(IP_str_SqlQuery);
               return lcl_obj_SalesContractDetailsTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_SalesContractDetails;
       }

       public List<CCL.BusinessEntities.WPMS.SalesContractDetails> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails> lcl_obj_SalesContractDetails = null;
           lcl_obj_SalesContractDetails = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails>>(() =>
           {
               SilkERP360.BML.WPMS.SalesContractDetailsManager lcl_obj_SalesContractDetailsManager = new SilkERP360.BML.WPMS.SalesContractDetailsManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails> SalesContractDetailsTmp =
                   lcl_obj_SalesContractDetailsManager.GetList(IP_str_SqlQuery);
               return SalesContractDetailsTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_SalesContractDetails;
       }

       public int Update(CCL.BusinessEntities.WPMS.SalesContractDetails IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           System.Int32 lcl_i32_RowsUpdated = this.ExceptionManager.Process<System.Int32>(() =>
           {
               System.Int32 lcl_i32_RowsUpdatedTmp = 0;
               SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
               System.Object lcl_obj_Response = lcl_obj_SqlManager.ExecuteScaler(IP_str_SqlUpdateQuery);
               lcl_obj_SqlManager.Close();
               lcl_i32_RowsUpdatedTmp = System.Int32.Parse(lcl_obj_Response.ToString());
               return lcl_i32_RowsUpdatedTmp;
           }, "FLExceptionPolicy");
           return lcl_i32_RowsUpdated;
       }
    }
}
