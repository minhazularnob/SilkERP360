using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
   public class SpmSmJobOrderItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>
    {
        public SpmSmJobOrderItemManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem IP_obj_SpmSmJobOrderItem, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmJobOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmJobOrderItem.GetSequence());
            lcl_ui64_SmJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmJobOrderItem.SmJobOrderItemCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmJobOrderItem.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmJobOrderItemCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem IP_obj_SpmSmJobOrderItem)
        {
            System.UInt64 lcl_ui64_SmJobOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmJobOrderItem.GetSequence());
            lcl_ui64_SmJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_SpmSmJobOrderItem.SmJobOrderItemCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmJobOrderItem.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmJobOrderItemCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem = null;
            lcl_obj_SpmSmJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_JOB_ORDER_ITEM WHERE SM_JOB_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());                

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmJobOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem = null;
            lcl_obj_SpmSmJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_JOB_ORDER_ITEM WHERE SM_JOB_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmJobOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem = null;
            lcl_obj_SpmSmJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmJobOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem = null;
            lcl_obj_SpmSmJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmJobOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrderItem;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> lcl_objlist_SpmSmJobOrderItemList = null;
            lcl_objlist_SpmSmJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> lcl_objlist_TmpSpmSmJobOrderItemList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmJobOrderItemList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                    lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                    lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpSpmSmJobOrderItemList.Add(lcl_obj_TmpSpmSmJobOrderItem);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmJobOrderItemList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmJobOrderItemList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> lcl_objlist_SpmSmJobOrderItemList = null;
            lcl_objlist_SpmSmJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem> lcl_objlist_TmpSpmSmJobOrderItemList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmJobOrderItemList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_TmpSpmSmJobOrderItem = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem();
                        lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.SmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.HlrDesc = lcl_obj_dr["HLR_DESC"].ToString();
                        lcl_obj_TmpSpmSmJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.ChipSize = System.UInt64.Parse(lcl_obj_dr["CHIP_SIZE"].ToString());
                        lcl_obj_TmpSpmSmJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpSpmSmJobOrderItemList.Add(lcl_obj_TmpSpmSmJobOrderItem);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmJobOrderItemList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmJobOrderItemList;
        }
    }
}
