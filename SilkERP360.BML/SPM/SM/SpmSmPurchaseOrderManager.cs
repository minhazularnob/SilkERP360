using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmPurchaseOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>
    {
        public SpmSmPurchaseOrderManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder IP_obj_SpmSmPurchaseOrder, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPurchaseOrder.GetSequence());
            lcl_ui64_SmPurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmPurchaseOrder.SmPurchaseOrderCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmPurchaseOrder.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder IP_obj_SpmSmPurchaseOrder)
        {
            System.UInt64 lcl_ui64_SmPurchaseOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPurchaseOrder.GetSequence());
            lcl_ui64_SmPurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmPurchaseOrder.SmPurchaseOrderCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmPurchaseOrder.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPurchaseOrderCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_SpmSmPurchaseOrder = null;
            lcl_obj_SpmSmPurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PURCHASE_ORDER WHERE SM_PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.Remarks =lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPurchaseOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_SpmSmPurchaseOrder = null;
            lcl_obj_SpmSmPurchaseOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PURCHASE_ORDER WHERE SM_PURCHASE_ORDER_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                    lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPurchaseOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_SpmSmPurchaseOrder = null;
            lcl_obj_SpmSmPurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPurchaseOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_SpmSmPurchaseOrder = null;
            lcl_obj_SpmSmPurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                    lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPurchaseOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPurchaseOrder;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> lcl_objlist_SpmSmPurchaseOrderList = null;
            lcl_objlist_SpmSmPurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> lcl_objlist_TmpSpmSmPurchaseOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmPurchaseOrderList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                    lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_objlist_TmpSpmSmPurchaseOrderList.Add(lcl_obj_TmpSpmSmPurchaseOrder);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmPurchaseOrderList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPurchaseOrderList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> lcl_objlist_SpmSmPurchaseOrderList = null;
            lcl_objlist_SpmSmPurchaseOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder> lcl_objlist_TmpSpmSmPurchaseOrderList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmPurchaseOrderList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder lcl_obj_TmpSpmSmPurchaseOrder = new CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder();
                        lcl_obj_TmpSpmSmPurchaseOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrder.PoRefNumber = lcl_obj_dr["PO_REF_NUMBER"].ToString();
                        lcl_obj_TmpSpmSmPurchaseOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmSmPurchaseOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSpmSmPurchaseOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_objlist_TmpSpmSmPurchaseOrderList.Add(lcl_obj_TmpSpmSmPurchaseOrder);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmPurchaseOrderList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPurchaseOrderList;
        }
    }
}
