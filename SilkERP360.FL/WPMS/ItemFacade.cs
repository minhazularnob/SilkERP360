using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
   public class ItemFacade:SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.Item>
    {
       public ItemFacade()
       { 
       
       }

       public System.Collections.Generic.List<System.UInt64> SaveList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> IP_objLst_Items)
       {
           throw new NotImplementedException();
       }


       public ulong Save(CCL.BusinessEntities.WPMS.Item IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.Item> GetList(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public int Update(CCL.BusinessEntities.WPMS.Item IP_obj_T)
       {
           throw new NotImplementedException();
       }

       public int Update(string IP_str_SqlUpdateQuery)
       {
           throw new NotImplementedException();
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> GetAllDesignationWise(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_Item = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"Select it.ITEM_CODE,it.ITEM_CATAGORY_CODE,it.STATUS,it.WIDTH,it.GUSSET,it.LENGTH,it.THICKNESS,it.PROCESSING_COST,it.PRINTING_CHARGE,it.PUNCHOUT
,ct.catagory_name from wpms_item it 
inner join WPMS_ITEM_CATAGORY ct
on ct.ITEM_CATAGORY_CODE=it.ITEM_CATAGORY_CODE where ITEM_CODE={0}", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.ItemManager lcl_obj_ItemManager = new SilkERP360.BML.WPMS.ItemManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_ItemTmp =
               lcl_obj_ItemManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_ItemTmp;

           return lcl_obj_Item;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> Retrieve(System.UInt64 IP_str_SqlQuery)
       {

           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_Item = null;

           System.String lcl_str_SqlQuery = System.String.Format(@"Select it.ITEM_CODE,it.Buyer_CODE,it.ITEM_CATAGORY_CODE,it.STATUS,it.WIDTH,it.GUSSET,it.LENGTH,it.THICKNESS,it.PROCESSING_COST,it.PRINTING_CHARGE,it.PUNCHOUT  from wpms_item it inner join WPMS_ITEM_CATAGORY ct on ct.ITEM_CATAGORY_CODE=it.ITEM_CATAGORY_CODE where BUYER_CODE=6001000000000024 and it.ITEM_CATAGORY_CODE= {0}", IP_str_SqlQuery);
           SilkERP360.BML.WPMS.ItemManager lcl_obj_ItemManager = new SilkERP360.BML.WPMS.ItemManager();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_ItemTmp =
               lcl_obj_ItemManager.GetList(lcl_str_SqlQuery);
           return lcl_obj_ItemTmp;

           return lcl_obj_Item;
       }
    }
}
