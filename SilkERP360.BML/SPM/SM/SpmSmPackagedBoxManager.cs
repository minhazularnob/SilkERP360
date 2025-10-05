using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmPackagedBoxManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>
    {
        public SpmSmPackagedBoxManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox IP_obj_SpmSmPackagedBox, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPackagedBoxCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPackagedBox.GetSequence());
            lcl_ui64_SmPackagedBoxCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmPackagedBox.SmPackagedBoxCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmPackagedBox.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPackagedBoxCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox IP_obj_SpmSmPackagedBox)
        {
            System.UInt64 lcl_ui64_SmPackagedBoxCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPackagedBox.GetSequence());
            lcl_ui64_SmPackagedBoxCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmPackagedBox.SmPackagedBoxCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmPackagedBox.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPackagedBoxCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_SpmSmPackagedBox = null;
            lcl_obj_SpmSmPackagedBox = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PACKAGED_BOX WHERE SM_PACKAGED_BOX_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());                           

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPackagedBox;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBox;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_SpmSmPackagedBox = null;
            lcl_obj_SpmSmPackagedBox = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PACKAGED_BOX WHERE SM_PACKAGED_BOX_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                    lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPackagedBox;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBox;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_SpmSmPackagedBox = null;
            lcl_obj_SpmSmPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPackagedBox;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBox;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_SpmSmPackagedBox = null;
            lcl_obj_SpmSmPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                    lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPackagedBox;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBox;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> lcl_objlist_SpmSmPackagedBoxList = null;
            lcl_objlist_SpmSmPackagedBoxList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> lcl_objlist_TmpSpmSmPackagedBoxList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmPackagedBoxList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                    lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                    lcl_objlist_TmpSpmSmPackagedBoxList.Add(lcl_obj_TmpSpmSmPackagedBox);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmPackagedBoxList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPackagedBoxList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> lcl_objlist_SpmSmPackagedBoxList = null;
            lcl_objlist_SpmSmPackagedBoxList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox> lcl_objlist_TmpSpmSmPackagedBoxList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmPackagedBoxList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox lcl_obj_TmpSpmSmPackagedBox = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBox();
                        lcl_obj_TmpSpmSmPackagedBox.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                        lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmPackagedBox.SmPurchaseOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_PURCHASE_ORDER_ITEM_CODE"].ToString());
                        lcl_obj_TmpSpmSmPackagedBox.SmJobOrderCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpSpmSmPackagedBox.SmJobOrderItemCode = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_ITEM_CODE"].ToString());
                        lcl_objlist_TmpSpmSmPackagedBoxList.Add(lcl_obj_TmpSpmSmPackagedBox);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmPackagedBoxList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPackagedBoxList;
        }
    }
}
