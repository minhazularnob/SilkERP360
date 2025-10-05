using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class RelationBuyerProductFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct>
    {
        public RelationBuyerProductFacade()
        { 
            
        
        }

        public ulong Save(CCL.BusinessEntities.WPMS.RelationBuyerProduct lcl_obj_RelationBuyerProduct)
        {
            System.UInt64 lcl_ui64_RelationBuyerProductCode = 0;
            {
                SilkERP360.BML.WPMS.RelationBuyerProductManager lcl_obj_RelationBuyerProductManager = new BML.WPMS.RelationBuyerProductManager();
                System.UInt64 lcl_ui64_RelationBuyerProductCodeTmp = lcl_obj_RelationBuyerProductManager.Save(lcl_obj_RelationBuyerProduct);

                return lcl_ui64_RelationBuyerProductCodeTmp;

                return lcl_ui64_RelationBuyerProductCode;
            }
        }

        public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.RelationBuyerProduct Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.RelationBuyerProduct> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.WPMS.RelationBuyerProduct IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"Select it.ITEM_CODE,it.ITEM_CATAGORY_CODE,it.STATUS,it.WIDTH,it.GUSSET,it.LENGTH,it.THICKNESS,it.PROCESSING_COST,it.PRINTING_CHARGE,it.PUNCHOUT
,ct.catagory_name from wpms_item it 
inner join WPMS_ITEM_CATAGORY ct
on ct.ITEM_CATAGORY_CODE=it.ITEM_CATAGORY_CODE where BUYER_CODE=6001000000000024 and ITEM_CODE={0}", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.ItemManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.ItemManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> GetAllDesignationWiseSize(System.UInt64 IP_str_SqlQuery)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> lcl_obj_Quotation = null;

            System.String lcl_str_SqlQuery = System.String.Format(@"select RELATION_CODE,FINISHED_PRODUCT_CODE,BUYER_CODE,PROCESSING_COST,PRINTING_CHARGE,STATUS,WIDTH,LENGTH,GUSSET,DENSITY,THICKNESS,SPECIFICATION_NAME,PUNCHOUT,ITEM_CODE from WPMS_RELATION_BUYER_PRODUCT where RELATION_CODE={0} and STATUS=1", IP_str_SqlQuery);
            SilkERP360.BML.WPMS.RelationBuyerProductManager lcl_obj_QuotationManager = new SilkERP360.BML.WPMS.RelationBuyerProductManager();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> lcl_obj_QuotationTmp =
                lcl_obj_QuotationManager.GetList(lcl_str_SqlQuery);
            return lcl_obj_QuotationTmp;

            return lcl_obj_Quotation;
        }
    }
}
