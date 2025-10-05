using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmJobOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>
    {
        public SpmSmJobOrderManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmJobOrder IP_obj_SpmSmJobOrder, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmJobOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmJobOrder.GetSequence());
            lcl_ui64_SmJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmJobOrder.SmJobOrderCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmJobOrder.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmJobOrderCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmJobOrder IP_obj_SpmSmJobOrder)
        {
            System.UInt64 lcl_ui64_SmJobOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmJobOrder.GetSequence());
            lcl_ui64_SmJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmJobOrder.SmJobOrderCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmJobOrder.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmJobOrderCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_SpmSmJobOrder = null;
            lcl_obj_SpmSmJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_JOB_ORDER WHERE SM_JOB_ORDER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmJobOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrder Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_SpmSmJobOrder = null;
            lcl_obj_SpmSmJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_JOB_ORDER WHERE SM_JOB_ORDER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                    lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmJobOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_SpmSmJobOrder = null;
            lcl_obj_SpmSmJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmJobOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrder;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmJobOrder Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_SpmSmJobOrder = null;
            lcl_obj_SpmSmJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                    lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmJobOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmJobOrder;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> lcl_objlist_SpmSmJobOrderList = null;
            lcl_objlist_SpmSmJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> lcl_objlist_TmpSpmSmJobOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmJobOrderList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                    lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                    lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_objlist_TmpSpmSmJobOrderList.Add(lcl_obj_TmpSpmSmJobOrder);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmJobOrderList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmJobOrderList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> lcl_objlist_SpmSmJobOrderList = null;
            lcl_objlist_SpmSmJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder> lcl_objlist_TmpSpmSmJobOrderList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmJobOrder>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmJobOrderList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmJobOrder lcl_obj_TmpSpmSmJobOrder = new CCL.BusinessEntities.SPM.SM.SpmSmJobOrder();
                        lcl_obj_TmpSpmSmJobOrder.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.JobOrderNumber = lcl_obj_dr["JOB_ORDER_NUMBER"].ToString();
                        lcl_obj_TmpSpmSmJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_TmpSpmSmJobOrder.Renarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_objlist_TmpSpmSmJobOrderList.Add(lcl_obj_TmpSpmSmJobOrder);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmJobOrderList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmJobOrderList;
        }
    }
}
