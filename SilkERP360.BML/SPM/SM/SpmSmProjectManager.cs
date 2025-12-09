using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmProjectManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject>
    {
        public SpmSmProjectManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmProject IP_obj_SpmSmProject, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmProjectCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmProject.GetSequence());
            lcl_ui64_SmProjectCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmProject.SmProjectCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmProject.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProjectCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmProject IP_obj_SpmSmProject)
        {
            System.UInt64 lcl_ui64_SmProjectCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmProject.GetSequence());
            lcl_ui64_SmProjectCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmProject.SmProjectCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmProject.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProjectCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProject Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_SpmSmProject = null;
            lcl_obj_SpmSmProject = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmProject>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PROJECT WHERE SM_PROJECT_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new CCL.BusinessEntities.SPM.SM.SpmSmProject();
                lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
               
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmProject;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProject;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProject Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_SpmSmProject = null;
            lcl_obj_SpmSmProject = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmProject>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PROJECT WHERE SM_PROJECT_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new CCL.BusinessEntities.SPM.SM.SpmSmProject();
                    lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmProject;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProject;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProject Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_SpmSmProject = null;
            lcl_obj_SpmSmProject = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject();
                lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmProject;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProject;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProject Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_SpmSmProject = null;
            lcl_obj_SpmSmProject = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProject();
                    lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmProject;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProject;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmProject> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject> lcl_objlist_SpmSmProjectList = null;
            lcl_objlist_SpmSmProjectList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject> lcl_objlist_TmpSpmSmProjectList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmProjectList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new CCL.BusinessEntities.SPM.SM.SpmSmProject();
                    lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_objlist_TmpSpmSmProjectList.Add(lcl_obj_TmpSpmSmProject);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmProjectList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmProjectList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmProject> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject> lcl_objlist_SpmSmProjectList = null;
            lcl_objlist_SpmSmProjectList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject> lcl_objlist_TmpSpmSmProjectList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProject>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmProjectList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmProject lcl_obj_TmpSpmSmProject = new CCL.BusinessEntities.SPM.SM.SpmSmProject();
                        lcl_obj_TmpSpmSmProject.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                        lcl_obj_TmpSpmSmProject.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmProject.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmSmProject.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmProject.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                        lcl_objlist_TmpSpmSmProjectList.Add(lcl_obj_TmpSpmSmProject);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmProjectList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmProjectList;
        }
    }
}
