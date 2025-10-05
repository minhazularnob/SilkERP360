using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmPurchaseOrderItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>
    {
        public SpmSmPurchaseOrderItemManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem IP_obj_SpmSmPurchaseOrderItem, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPurchaseOrderItem.GetSequence());
            lcl_ui64_SmPurchaseOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmPurchaseOrderItem.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderItemCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem IP_obj_SpmSmPurchaseOrderItem)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPurchaseOrderItem.GetSequence());
            lcl_ui64_SmPurchaseOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_SpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmPurchaseOrderItem.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderItemCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_SpmSmPurchaseOrderItem = null;
            lcl_obj_SpmSmPurchaseOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PURCHASE_ORDER_ITEM WHERE SM_PURCHASE_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPurchaseOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_SpmSmPurchaseOrderItem = null;
            lcl_obj_SpmSmPurchaseOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                   
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PURCHASE_ORDER_ITEM WHERE SM_PURCHASE_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPurchaseOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_SpmSmPurchaseOrderItem = null;
            lcl_obj_SpmSmPurchaseOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPurchaseOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_SpmSmPurchaseOrderItem = null;
            lcl_obj_SpmSmPurchaseOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPurchaseOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrderItem;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> lcl_objlist_SpmSmPurchaseOrderItemList = null;
            lcl_objlist_SpmSmPurchaseOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> lcl_objlist_TmpSpmSmPurchaseOrderItemList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmPurchaseOrderItemList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpSpmSmPurchaseOrderItemList.Add(lcl_obj_TmpSpmSmPurchaseOrderItem);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmPurchaseOrderItemList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPurchaseOrderItemList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> lcl_objlist_SpmSmPurchaseOrderItemList = null;
            lcl_objlist_SpmSmPurchaseOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem> lcl_objlist_TmpSpmSmPurchaseOrderItemList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmPurchaseOrderItemList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_TmpSpmSmPurchaseOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem();
                        lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                        lcl_obj_TmpSpmSmPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmSmPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpSpmSmPurchaseOrderItemList.Add(lcl_obj_TmpSpmSmPurchaseOrderItem);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmPurchaseOrderItemList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPurchaseOrderItemList;
        }
    }
}
