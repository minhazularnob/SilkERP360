using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
   public class RawSubFacade: SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>
    {
       public RawSubFacade()
       { 
       
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> GetAllSubProductWise(System.UInt64 IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"select RMSUB_CODE,RM_SUB_NAME,RM_CODE,STATUS From WPMS_RMSUB where RM_CODE={0}", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.RawSubBML lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawSubBML();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RawLIST IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RawLIST Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RawLIST Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.RawLIST> GetList(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public int Update(CCL.BusinessEntities.WPMS.RawLIST IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           throw new NotImplementedException();
       }
    }
}
