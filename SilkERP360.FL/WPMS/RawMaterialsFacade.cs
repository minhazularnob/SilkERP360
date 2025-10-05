using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
   public class RawMaterialsFacade: SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>
    {
       public RawMaterialsFacade()
       {       
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RawMaterials IP_obj_RawMaterials)
       {

                SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_RawMatarialManager = new BML.WPMS.RawMatarialManager();
                System.UInt64 lcl_ui64_RawMaterialsCode = lcl_obj_RawMatarialManager.Save(IP_obj_RawMaterials);
                return lcl_ui64_RawMaterialsCode;
         
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(ulong IP_ui64_RawMatarialCode)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMatarial = null;
           lcl_obj_RawMatarial = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
           {
               SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_CustomerManager = new SilkERP360.BML.WPMS.RawMatarialManager();
               SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMatarialTmp = lcl_obj_CustomerManager.Get(IP_ui64_RawMatarialCode);
               return lcl_obj_RawMatarialTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_RawMatarial;
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMatarial = null;
           lcl_obj_RawMatarial = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
           {
               SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_RawMatarialManager = new SilkERP360.BML.WPMS.RawMatarialManager();
               SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMatarialTmp = lcl_obj_RawMatarialManager.Get(IP_str_SqlQuery);
               return lcl_obj_RawMatarialTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_RawMatarial;
       }

       public List<CCL.BusinessEntities.WPMS.RawMaterials> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_RawMatarial = null;
           lcl_obj_RawMatarial = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>>(() =>
           {
               SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_RawMatarialManager = new SilkERP360.BML.WPMS.RawMatarialManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_RawMatarialTmp =
                   lcl_obj_RawMatarialManager.GetList(IP_str_SqlQuery);
               return lcl_obj_RawMatarialTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_RawMatarial;
       }

       public int Update(CCL.BusinessEntities.WPMS.RawMaterials IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           throw new NotImplementedException();
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> GetPrice(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"Select RM_NAME,PRICE_M_TON From  WPMS_RAW_MATERIAL where RM_NAME={0} order by RM_NAME desc", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawMatarialManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"select E.RM_CODE,E.RM_NAME,to_char(D.MONTH,'dd-Mon-yyyy'),D.PRICE_M_TON From WPMS_RAW_PRODUCT E 
inner join WPMS_RAW_MATERIAL D on E.RM_CODE=D.rm_code where E.RM_CODE={0} order by D.PRODUCT_UPDATE_CODE desc ", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawMatarialManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetListJoin(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> GetAllDesignationWise2(System.DateTime IP_str_Month)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"select E.RM_CODE,E.RM_NAME,to_char(D.MONTH,'dd-Mon-yyyy'),D.PRICE_M_TON,D.STATUS From WPMS_RAW_PRODUCT E 
inner join WPMS_RAW_MATERIAL D on E.RM_CODE=D.rm_code where to_char(D.MONTH,'dd-Mon-yyyy')={0}", IP_str_Month);
           SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawMatarialManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_QuotationTmp =
           lcl_obj_QuotationManager.GetListAllJoin(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;
           return lcl_obj_Quotation;
       }


       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> GetUpdateProductPrice(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"select E.RM_CODE,E.RM_NAME,to_char(MONTH,'dd-Mon-yyyy'),D.PRICE_M_TON,D.STATUS From WPMS_RAW_PRODUCT E 
inner join WPMS_RAW_MATERIAL D on E.RM_CODE=D.rm_code  where D.PRODUCT_UPDATE_CODE=(select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE ={0}) ", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.RawMatarialManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RawMatarialManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetListJoin(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;
           return lcl_obj_Quotation;
       }

    }
}
