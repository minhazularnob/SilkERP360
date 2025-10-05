using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.WPMS
{
    public class ItemsSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public ItemsSP()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage> GetItemImageListByItem(System.UInt64 IP_ui64_ItemCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage> lcl_objLst_ItemImageList = null;
            lcl_objLst_ItemImageList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WPMS_ITEM_IMAGE WHERE ITEM_CODE = {0}", IP_ui64_ItemCode);
                SilkERP360.BML.WPMS.ItemImageManager lcl_obj_ItemImageManager = new BML.WPMS.ItemImageManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage> lcl_objLst_TmpItemImageList = lcl_obj_ItemImageManager.GetList(lcl_str_SqlQuery);
                return lcl_objLst_TmpItemImageList;
            }, "FLExceptionPolicy");
            return lcl_objLst_ItemImageList;
        }

        public System.UInt64 SaveItemImage(SilkERP360.CCL.BusinessEntities.WPMS.ItemImage IP_obj_ItemImage)
        {
            System.UInt64 lcl_ui64_ItemImageCode = 0;
            lcl_ui64_ItemImageCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.WPMS.ItemImageManager lcl_obj_ItemImageManager = new SilkERP360.BML.WPMS.ItemImageManager();
                lcl_obj_ItemImageManager.Initialize();
                System.UInt64 lcl_ui64_ItemImageCodeTmp = lcl_obj_ItemImageManager.Save(IP_obj_ItemImage);
                return lcl_ui64_ItemImageCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ItemImageCode;
        }

        public System.Boolean SaveItemInkList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk> IP_objLst_ItemInk)
        {
            System.Boolean lcl_b_Response = false;
            lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {

                SilkERP360.BML.WPMS.ItemInkManager lcl_obj_ItemInkManager = new SilkERP360.BML.WPMS.ItemInkManager();
                lcl_obj_ItemInkManager.Initialize();
                lcl_obj_ItemInkManager.SaveItemInkList(IP_objLst_ItemInk);
                return true;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.UInt64 SaveItemMasterBatch(SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch IP_obj_ItemMasterBatch)
        {

            System.UInt64 lcl_ui64_MasterBatchCode = 0;
            lcl_ui64_MasterBatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                SilkERP360.BML.WPMS.ItemMasterbatchManager lcl_obj_ItemMasterBatchManager = new SilkERP360.BML.WPMS.ItemMasterbatchManager();
                lcl_obj_ItemMasterBatchManager.Initialize();
                System.UInt64 lcl_ui64_MasterBatchCodeTmp = lcl_obj_ItemMasterBatchManager.Save(IP_obj_ItemMasterBatch);

                return lcl_ui64_MasterBatchCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_MasterBatchCode;
        }
    

        public SilkERP360.CCL.Misc.WSResponse SaveItemList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> IP_objLst_ItemList)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
            lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.BML.WPMS.ItemManager lcl_obj_ItemManager = new BML.WPMS.ItemManager();
                lcl_obj_ItemManager.SaveList(IP_objLst_ItemList);
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.Success, 0, "Item Configuration is Saved successfully in the database!", true, null);
                return lcl_obj_WSResponseTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WSResponse;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> GetItemListByBuyerAndItemCatagory(System.UInt64 IP_ui64_BuyerCode, System.UInt64 IP_ui64_ItemCatagoryCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_ItemList = null;
            lcl_objLst_ItemList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WPMS_ITEM WHERE BUYER_CODE = {0} AND ITEM_CATAGORY_CODE = {1}", IP_ui64_BuyerCode, IP_ui64_ItemCatagoryCode);
                SilkERP360.BML.WPMS.ItemManager lcl_obj_ItemManager = new BML.WPMS.ItemManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_TmpItemList = lcl_obj_ItemManager.GetList(lcl_str_SqlQuery);
                return lcl_objLst_TmpItemList;
            }, "FLExceptionPolicy");
            return lcl_objLst_ItemList;
        }

        public SilkERP360.CCL.BusinessEntities.WPMS.Item GetItemByCode(System.UInt64 IP_ui64_ItemCode)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Item lcl_obj_Item = null;
            lcl_obj_Item = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Item>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WPMS_ITEM WHERE ITEM_CODE = {0}", IP_ui64_ItemCode);
                SilkERP360.BML.WPMS.ItemManager lcl_obj_ItemManager = new BML.WPMS.ItemManager();
                SilkERP360.CCL.BusinessEntities.WPMS.Item lcl_obj_ItemTmp = lcl_obj_ItemManager.Get(IP_ui64_ItemCode);
                return lcl_obj_ItemTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Item;
        }
    }
}
