using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM
{
    public class SpmProductMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster>
    {
        public ulong Save(CCL.BusinessEntities.SPM.SpmProductMaster IP_obj_SpmProductMaster, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmProductMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmProductMaster.GetSequence());
            lcl_ui64_SmProductMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmProductMaster.SpmProductCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmProductMaster.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProductMasterCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SpmProductMaster IP_obj_SpmProductMaster)
        {
            System.UInt64 lcl_ui64_SmProductMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmProductMaster.GetSequence());
            lcl_ui64_SmProductMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmProductMaster.SpmProductCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmProductMaster.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProductMasterCode;
        }

        public CCL.BusinessEntities.SPM.SpmProductMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = null;
            lcl_obj_SpmProductMaster = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SpmProductMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_PRODUCT_MASTER WHERE SPM_PRODUCT_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new CCL.BusinessEntities.SPM.SpmProductMaster();
                lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());


                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmProductMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmProductMaster;
        }

        public CCL.BusinessEntities.SPM.SpmProductMaster Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = null;
            lcl_obj_SpmProductMaster = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SpmProductMaster>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_PRODUCT_MASTER WHERE SPM_PRODUCT_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new CCL.BusinessEntities.SPM.SpmProductMaster();
                    lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                    lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                    lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmProductMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmProductMaster;
        }

        public CCL.BusinessEntities.SPM.SpmProductMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = null;
            lcl_obj_SpmProductMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster();
                lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmProductMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmProductMaster;
        }

        public CCL.BusinessEntities.SPM.SpmProductMaster Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = null;
            lcl_obj_SpmProductMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster();
                    lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                    lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                    lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmProductMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmProductMaster;
        }

        public List<CCL.BusinessEntities.SPM.SpmProductMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objlist_SpmProductMasterList = null;
            lcl_objlist_SpmProductMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objlist_TmpSpmProductMasterList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmProductMasterList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new CCL.BusinessEntities.SPM.SpmProductMaster();
                    lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SPM_PRODUCT_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                    lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                    lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                    lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_objlist_TmpSpmProductMasterList.Add(lcl_obj_TmpSpmProductMaster);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmProductMasterList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmProductMasterList;
        }

        public List<CCL.BusinessEntities.SPM.SpmProductMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objlist_SpmProductMasterList = null;
            lcl_objlist_SpmProductMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objlist_TmpSpmProductMasterList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmProductMaster>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmProductMasterList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_TmpSpmProductMaster = new CCL.BusinessEntities.SPM.SpmProductMaster();
                        lcl_obj_TmpSpmProductMaster.SpmProductCode = System.UInt64.Parse(lcl_obj_dr["SM_PRODUCT_CODE"].ToString());
                        lcl_obj_TmpSpmProductMaster.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmProductMaster.ProductName = lcl_obj_dr["PRODUCT_NAME"].ToString();
                        lcl_obj_TmpSpmProductMaster.Description = lcl_obj_dr["DESCRIPTION"].ToString();
                        lcl_obj_TmpSpmProductMaster.ProductType = (SilkERP360.CCL.Enums.SPM.SPMProductType)System.UInt16.Parse(lcl_obj_dr["PRODUCT_TYPE"].ToString());
                        lcl_obj_TmpSpmProductMaster.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                        lcl_objlist_TmpSpmProductMasterList.Add(lcl_obj_TmpSpmProductMaster);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmProductMasterList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmProductMasterList;
        }
    }
}
