using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class BuyerFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>
    {
       public BuyerFacade()
       { 
       
       }

       public ulong Save(CCL.BusinessEntities.WPMS.Buyer IP_Obj_Customer)
       {
           System.UInt64 lcl_ui64_BuyerCode = 0;
           {
               SilkERP360.BML.WPMS.BuyerManager lcl_obj_BuyerManager = new BML.WPMS.BuyerManager();
               System.UInt64 lcl_ui64_BuyerCodeTmp = lcl_obj_BuyerManager.Save(IP_Obj_Customer);
               return lcl_ui64_BuyerCodeTmp;
           }
           return lcl_ui64_BuyerCode;
        
       }

       public CCL.BusinessEntities.WPMS.Buyer Get(ulong IP_ui64_CustomerCode)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Customer = null;
           lcl_obj_Customer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
           {
               SilkERP360.BML.WPMS.BuyerManager lcl_obj_CustomerManager = new SilkERP360.BML.WPMS.BuyerManager();
               SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_CustomerTmp = lcl_obj_CustomerManager.Get(IP_ui64_CustomerCode);
               return lcl_obj_CustomerTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_Customer;
       }

       public CCL.BusinessEntities.WPMS.Buyer Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Customer = null;
           lcl_obj_Customer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
           {
               SilkERP360.BML.WPMS.BuyerManager lcl_obj_CustomerManager = new SilkERP360.BML.WPMS.BuyerManager();
               SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_CustomerTmp = lcl_obj_CustomerManager.Get(IP_str_SqlQuery);
               return lcl_obj_CustomerTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_Customer;
       }

       public List<CCL.BusinessEntities.WPMS.Buyer> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_Customer = null;
           lcl_obj_Customer = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>>(() =>
           {
               SilkERP360.BML.WPMS.BuyerManager lcl_obj_CustomerManager = new SilkERP360.BML.WPMS.BuyerManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_CustomerTmp =
                   lcl_obj_CustomerManager.GetList(IP_str_SqlQuery);
               return lcl_obj_CustomerTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_Customer;
       }

       public int Update(CCL.BusinessEntities.WPMS.Buyer IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           throw new NotImplementedException();
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"select BUYER_CODE,COMPANY_NAME,ADDRESS,PHONE,CONTACT_PERSON,EMAIL,IS_ACTIVE,COUNTRY from WPMS_BUYER where BUYER_CODE={0}", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.BuyerManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.BuyerManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }


       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> GetAllQuotationWise(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@" select E.QUOTATION_CODE,D.BUYER_CODE,D.COMPANY_NAME,D.ADDRESS,D.PHONE,D.CONTACT_PERSON,D.EMAIL,D.COUNTRY,D.IS_ACTIVE
From WPMS_QUOTATION E
inner join WPMS_BUYER D 
on E.BUYER_CODE=D.BUYER_CODE where E.QUOTATION_CODE={0}", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.BuyerManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.BuyerManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }


       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> GetAllCustomer(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@" Select 
BUYER_CODE
,COMPANY_NAME
,ADDRESS
,CONTACT_PERSON
,EMAIL
,COUNTRY
,PHONE from WPMS_BUYER
 ", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.BuyerManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.BuyerManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }


       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> GetAllCustomerCode(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_Quotation = null;

           System.String lcl_str_SqlQuery = System.String.Format(@" Select 
BUYER_CODE
,COMPANY_NAME
,ADDRESS
,CONTACT_PERSON
,EMAIL
,COUNTRY
,PHONE from WPMS_BUYER Where Buyer_CODE={0}
 ", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.BuyerManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.BuyerManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_obj_QuotationTmp =
               lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_QuotationTmp;

           return lcl_obj_Quotation;
       }
    }
}
