using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SC
{
    public class SpmScPurchaseOrderItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>
    {
        public SpmScPurchaseOrderItemManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem IP_obj_SpmScPurchaseOrderItem, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScPurchaseOrderItem.GetSequence());
            lcl_ui64_SmPurchaseOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmScPurchaseOrderItem.ScPurchaseOrderItemCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmScPurchaseOrderItem.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderItemCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem IP_obj_SpmScPurchaseOrderItem)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScPurchaseOrderItem.GetSequence());
            lcl_ui64_SmPurchaseOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmScPurchaseOrderItem.ScPurchaseOrderItemCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmScPurchaseOrderItem.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderItemCode;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem = null;
            lcl_obj_SpmScPurchaseOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_PURCHASE_ORDER_ITEM WHERE SC_PURCHASE_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScPurchaseOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem = null;
            lcl_obj_SpmScPurchaseOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_PURCHASE_ORDER_ITEM WHERE SC_PURCHASE_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScPurchaseOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem = null;
            lcl_obj_SpmScPurchaseOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>(() =>
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
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScPurchaseOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem = null;
            lcl_obj_SpmScPurchaseOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScPurchaseOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrderItem;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> lcl_objlist_SpmScPurchaseOrderItemList = null;
            lcl_objlist_SpmScPurchaseOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> lcl_objlist_TmpSpmScPurchaseOrderItemList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScPurchaseOrderItemList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpSpmScPurchaseOrderItemList.Add(lcl_obj_TmpSpmScPurchaseOrderItem);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmScPurchaseOrderItemList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScPurchaseOrderItemList;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> lcl_objlist_SpmScPurchaseOrderItemList = null;
            lcl_objlist_SpmScPurchaseOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> lcl_objlist_TmpSpmScPurchaseOrderItemList = new
                       System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpSpmScPurchaseOrderItemList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_TmpSpmScPurchaseOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem();
                        lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.MeasurementUnit = (SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit)System.UInt16.Parse(lcl_obj_dr["UNIT_OF_MEASUREMENT"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.Denomination = (SilkERP360.CCL.Enums.SPM.ScratchCardDenomination)System.UInt16.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                        lcl_obj_TmpSpmScPurchaseOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.DeliveryStartDate = System.DateTime.Parse(lcl_obj_dr["DELIVERY_START_DATE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.ExpiryDate = System.DateTime.Parse(lcl_obj_dr["EXPIRY_DATE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmScPurchaseOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpSpmScPurchaseOrderItemList.Add(lcl_obj_TmpSpmScPurchaseOrderItem);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScPurchaseOrderItemList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScPurchaseOrderItemList;
        }
    }
}
