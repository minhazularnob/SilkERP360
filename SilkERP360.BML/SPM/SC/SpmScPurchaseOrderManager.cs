using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SC
{
    public class SpmScPurchaseOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>
    {
        public SpmScPurchaseOrderManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder IP_obj_SpmScPurchaseOrder, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScPurchaseOrder.GetSequence());
            lcl_ui64_SmPurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmScPurchaseOrder.ScPurchaseOrderCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmScPurchaseOrder.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder IP_obj_SpmScPurchaseOrder)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScPurchaseOrder.GetSequence());
            lcl_ui64_SmPurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmScPurchaseOrder.ScPurchaseOrderCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmScPurchaseOrder.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderCode;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_SpmScPurchaseOrder = null;
            lcl_obj_SpmScPurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_PURCHASE_ORDER WHERE SC_PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScPurchaseOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_SpmScPurchaseOrder = null;
            lcl_obj_SpmScPurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_PURCHASE_ORDER WHERE SC_PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                    lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());

                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScPurchaseOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_SpmScPurchaseOrder = null;
            lcl_obj_SpmScPurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>(() =>
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
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScPurchaseOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_SpmScPurchaseOrder = null;
            lcl_obj_SpmScPurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                    lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScPurchaseOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScPurchaseOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>Empty List<> if No data found, else the List<></returns>
        public List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> lcl_objlist_SpmScPurchaseOrderList = null;
            lcl_objlist_SpmScPurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> lcl_objlist_TmpSpmScPurchaseOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScPurchaseOrderList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                    lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_objlist_TmpSpmScPurchaseOrderList.Add(lcl_obj_TmpSpmScPurchaseOrder);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmScPurchaseOrderList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScPurchaseOrderList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>Empty List<> if No data found, else the List<></returns>
        public List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> lcl_objlist_SpmScPurchaseOrderList = null;
            lcl_objlist_SpmScPurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder> lcl_objlist_TmpSpmScPurchaseOrderList = new
                       System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpSpmScPurchaseOrderList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_TmpSpmScPurchaseOrder = new CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder();
                        lcl_obj_TmpSpmScPurchaseOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                        lcl_obj_TmpSpmScPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmScPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSpmScPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_objlist_TmpSpmScPurchaseOrderList.Add(lcl_obj_TmpSpmScPurchaseOrder);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScPurchaseOrderList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScPurchaseOrderList;
        }
    }
}
