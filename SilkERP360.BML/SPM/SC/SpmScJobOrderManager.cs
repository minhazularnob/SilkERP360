using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SC
{
    public class SpmScJobOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder>
    {
        public SpmScJobOrderManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScJobOrder IP_obj_SpmScJobOrder, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ScJobOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScJobOrder.GetSequence());
            lcl_ui64_ScJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmScJobOrder.ScJobOrderCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmScJobOrder.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScJobOrderCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SC.SpmScJobOrder IP_obj_SpmScJobOrder)
        {
            System.UInt64 lcl_ui64_ScJobOrderCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmScJobOrder.GetSequence());
            lcl_ui64_ScJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmScJobOrder.ScJobOrderCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmScJobOrder.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScJobOrderCode;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_SpmScJobOrder = null;
            lcl_obj_SpmScJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_JOB_ORDER WHERE SC_JOB_ORDER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScJobOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrder Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_SpmScJobOrder = null;
            lcl_obj_SpmScJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SC_JOB_ORDER WHERE SC_JOB_ORDER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                    lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScJobOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_SpmScJobOrder = null;
            lcl_obj_SpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmScJobOrder;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrder;
        }

        public CCL.BusinessEntities.SPM.SC.SpmScJobOrder Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_SpmScJobOrder = null;
            lcl_obj_SpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                    lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmScJobOrder;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmScJobOrder;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> lcl_objlist_SpmScJobOrderList = null;
            lcl_objlist_SpmScJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> lcl_objlist_TmpSpmScJobOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScJobOrderList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                    lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                    lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();
                    lcl_objlist_TmpSpmScJobOrderList.Add(lcl_obj_TmpSpmScJobOrder);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmScJobOrderList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScJobOrderList;
        }

        public List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> lcl_objlist_SpmScJobOrderList = null;
            lcl_objlist_SpmScJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder> lcl_objlist_TmpSpmScJobOrderList = new
                       System.Collections.Generic.List<CCL.BusinessEntities.SPM.SC.SpmScJobOrder>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpSpmScJobOrderList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_TmpSpmScJobOrder = new CCL.BusinessEntities.SPM.SC.SpmScJobOrder();
                        lcl_obj_TmpSpmScJobOrder.ScJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.ScPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SC_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.IssueDate = System.DateTime.Parse(lcl_obj_dr["ISSUE_DATE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_obj_TmpSpmScJobOrder.ScJobOrderRef = lcl_obj_dr["SC_JOB_ORDER_REF"].ToString();
                        lcl_obj_TmpSpmScJobOrder.Status = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_TmpSpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpSpmScJobOrder.PaperWeight = lcl_obj_dr["PAPER_WEIGHT"].ToString();
                        lcl_obj_TmpSpmScJobOrder.ArtWork = lcl_obj_dr["ART_WORK"].ToString();
                        lcl_obj_TmpSpmScJobOrder.Version = lcl_obj_dr["VERSION"].ToString();
                        lcl_objlist_TmpSpmScJobOrderList.Add(lcl_obj_TmpSpmScJobOrder);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmScJobOrderList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmScJobOrderList;
        }
    }
}
