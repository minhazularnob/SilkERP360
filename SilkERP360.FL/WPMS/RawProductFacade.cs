using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class RawProductFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct>
    {
        public RawProductFacade()
        { 
        
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"select E.RM_CODE,E.RM_NAME,D.MONTH,D.PRICE_M_TON From WPMS_RAW_PRODUCT E 
inner join WPMS_RAW_MATERIAL D on E.RM_CODE=D.rm_code where E.RM_CODE={0}", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.RawProductManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawProductManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;
        }

       public ulong Save(CCL.BusinessEntities.WPMS.RawProduct IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RawProduct Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.RawProduct Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.RawProduct> GetList(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public int Update(CCL.BusinessEntities.WPMS.RawProduct IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           throw new NotImplementedException();
       }
    }
}
