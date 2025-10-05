using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class QuotationFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>
    {
        public QuotationFacade()
        {

        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.Quotation IP_obj_Quotation)
        {
            System.UInt64 lcl_ui64_QuotationCode = 0;
            {
                SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new BML.WPMS.QuotationManager();
                System.UInt64 lcl_ui64_QuotationCodeTmp = lcl_obj_QuotationManager.Save(IP_obj_Quotation);

                return lcl_ui64_QuotationCodeTmp;

                return lcl_ui64_QuotationCode;
            }
        }

        public CCL.BusinessEntities.WPMS.Quotation Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;


            System.String lcl_str_SqlQuery = System.String.Format(@"select E.QUOTATION_CODE,E.QUOTATION_DATE,E.QUOTATION_DATE,E.STATUS,E.COM_NAME,E.COM_ADDRESS,E.COM_PHONE,E.CUSTOMER_REQ,E.BUYER_CODE,E.COM_EMAIL,E.COM_AMOUNT,D.BUYER_CODE,D.COMPANY_NAME,D.ADDRESS,D.PHONE,D.CONTACT_PERSON,D.EMAIL,D.COUNTRY
From WPMS_QUOTATION E
inner join WPMS_BUYER D 
on E.BUYER_CODE=D.BUYER_CODE where E.QUOTATION_CODE={0}", IP_ui64_Code);

            SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
            SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = lcl_obj_QuotationManager.Get(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;


            return lcl_obj_Quotation;
        }

        public CCL.BusinessEntities.WPMS.Quotation Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;
            lcl_obj_Quotation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>(() =>
            {
                SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
                SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = lcl_obj_QuotationManager.Get(IP_str_SqlQuery);
                return lcl_obj_QuotationTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Quotation;
        }

        public List<CCL.BusinessEntities.WPMS.Quotation> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_Quotation = null;
            lcl_obj_Quotation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>>(() =>
            {
                SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_QuotationTmp =
                    lcl_obj_QuotationManager.GetList(IP_str_SqlQuery);
                return lcl_obj_QuotationTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Quotation;
        }

        public int Update(CCL.BusinessEntities.WPMS.Quotation IP_obj_T)
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

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"select E.QUOTATION_CODE,E.QUOTATION_DATE,E.QUOTATION_DATE,E.STATUS,E.COM_NAME,E.COM_ADDRESS,E.COM_PHONE,E.CUSTOMER_REQ,E.BUYER_CODE,E.COM_EMAIL,E.COM_AMOUNT,D.BUYER_CODE,D.COMPANY_NAME,D.ADDRESS,D.PHONE,D.CONTACT_PERSON,D.EMAIL,D.COUNTRY
From WPMS_QUOTATION E
inner join WPMS_BUYER D 
on E.BUYER_CODE=D.BUYER_CODE where E.QUOTATION_CODE={0}", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;
        }


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> GetAllQuotation(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"select Quotation_Code,BUYER_CODE,QUOTATION_DATE,STATUS,CUSTOMER_REQ,COM_NAME,COM_ADDRESS,COM_PHONE,COM_EMAIL,COM_AMOUNT from WPMS_QUOTATION where Status={0}", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;

        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> GetAllCodeNameDate(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"select Quotation_Code,BUYER_CODE,QUOTATION_DATE,STATUS,CUSTOMER_REQ,COM_NAME,COM_ADDRESS,COM_PHONE,COM_EMAIL,COM_AMOUNT from WPMS_QUOTATION where Status={0}", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.QuotationManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.QuotationManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;

        }
    }
}