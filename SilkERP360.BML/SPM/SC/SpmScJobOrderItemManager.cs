using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SC
{
    public class SpmScJobOrderItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>
    {

        public SpmScJobOrderItemManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem IP_obj_SpmScJobOrderItem, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ScJobOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScJobOrderItem.GetSequence());
            lcl_ui64_ScJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmScJobOrderItem.ScJobOrderItemCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmScJobOrderItem.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScJobOrderItemCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem IP_obj_SpmScJobOrderItem)
        {
            System.UInt64 lcl_ui64_ScJobOrderItemCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScJobOrderItem.GetSequence());
            lcl_ui64_ScJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
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
                    try
                    {
                        IP_obj_SpmScJobOrderItem.ScJobOrderItemCode = lcl_ui64_ID;
                        System.String lcl_str_SqlInsert = IP_obj_SpmScJobOrderItem.GenerateSqlInsert();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    }
                    catch (System.Exception Ex)
                    {
                        throw Ex;
                    }
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScJobOrderItemCode;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem = null;
            lcl_obj_SpmScJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_JOB_ORDER_ITEM WHERE SM_JOB_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
               
                //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScJobOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem = null;
            lcl_obj_SpmScJobOrderItem = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_JOB_ORDER_ITEM WHERE SC_JOB_ORDER_ITEM_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();

                    CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
                   
                    //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScJobOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem = null;
            lcl_obj_SpmScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
               
                //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScJobOrderItem;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrderItem;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem = null;
            lcl_obj_SpmScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
                   
                    //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScJobOrderItem;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrderItem;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> lcl_objlist_SpmScJobOrderItemList = null;
            lcl_objlist_SpmScJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> lcl_objlist_TmpSpmScJobOrderItemList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScJobOrderItemList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
                   
                    //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpSpmScJobOrderItemList.Add(lcl_obj_TmpSpmScJobOrderItem);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmScJobOrderItemList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScJobOrderItemList;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> lcl_objlist_SpmScJobOrderItemList = null;
            lcl_objlist_SpmScJobOrderItemList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem> lcl_objlist_TmpSpmScJobOrderItemList = new
                       System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpSpmScJobOrderItemList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_TmpSpmScJobOrderItem = new CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem();
                        lcl_obj_TmpSpmScJobOrderItem.ScJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.ScPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.HrnCover = (SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover)System.UInt16.Parse(lcl_obj_dr["HRN_COVER"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.OverPrint = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["OVER_PRINT"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.Wrapping = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["WRAPPING"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.OuterBox = System.UInt64.Parse(lcl_obj_dr["OUTER_BOX"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.BoxSlStart = System.UInt64.Parse(lcl_obj_dr["BOX_SL_START"].ToString());
                       
                        //lcl_obj_TmpSpmScJobOrderItem.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                        lcl_obj_TmpSpmScJobOrderItem.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmScJobOrderItem.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpSpmScJobOrderItem.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpSpmScJobOrderItemList.Add(lcl_obj_TmpSpmScJobOrderItem);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScJobOrderItemList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScJobOrderItemList;
        }
    }
}
