using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class WorkGroupManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>
    {

        public WorkGroupManager()
        {
            this.Initialize();
        }
       

        public ulong Save(CCL.BusinessEntities.HRIS.WorkGroup IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_WorkGroupCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WORKGROUP.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_WorkGroupCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.WorkGroupCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_WorkGroupCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.WorkGroup IP_obj_A)
        {
            System.UInt64 lcl_ui64_WorkGroupCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_WORKGROUP.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_WorkGroupCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_A.WorkGroupCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_WorkGroupCode;
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
            lcl_obj_WorkGroup = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroup>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From WORK_GROUP WHERE WORK_GROUP_CODE = {0} AND STATUS = 1", IP_ui64_Code,(System.Int16)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_TmpWorkGroup = new CCL.BusinessEntities.HRIS.WorkGroup();
                lcl_obj_TmpWorkGroup.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                lcl_obj_TmpWorkGroup.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpWorkGroup.WorkGroupName = lcl_obj_dr["WORK_GROUP_NAME"].ToString();
                lcl_obj_TmpWorkGroup.Status = (SilkERP360.CCL.Enums.Status)System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                 lcl_obj_dr.Close();
                 return lcl_obj_TmpWorkGroup;
            }, "BMLExceptionPolicy");
            return lcl_obj_WorkGroup;
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
            lcl_obj_WorkGroup = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.WorkGroup>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From WORK_GROUP WHERE WORK_GROUP_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_TmpWorkGroup = new CCL.BusinessEntities.HRIS.WorkGroup();
                    lcl_obj_TmpWorkGroup.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                    lcl_obj_TmpWorkGroup.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpWorkGroup.WorkGroupName = lcl_obj_dr["WORK_GROUP_NAME"].ToString();
                    lcl_obj_TmpWorkGroup.Status = (SilkERP360.CCL.Enums.Status)System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpWorkGroup;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_WorkGroup;
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.WorkGroup> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup> lcl_objlist_WorkGroupList = null;
            lcl_objlist_WorkGroupList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup> lcl_objlist_TmpWorkGroupList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpWorkGroupList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_TmpWorkGroup = new CCL.BusinessEntities.HRIS.WorkGroup();
                    lcl_obj_TmpWorkGroup.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                    lcl_obj_TmpWorkGroup.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpWorkGroup.WorkGroupName = lcl_obj_dr["WORK_GROUP_NAME"].ToString();
                    lcl_obj_TmpWorkGroup.Status = (SilkERP360.CCL.Enums.Status)System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpWorkGroupList.Add(lcl_obj_TmpWorkGroup);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpWorkGroupList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_WorkGroupList;
        }

        public List<CCL.BusinessEntities.HRIS.WorkGroup> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup> lcl_objlist_WorkGroupList = null;
            lcl_objlist_WorkGroupList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup> lcl_objlist_TmpWorkGroupList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.WorkGroup>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpWorkGroupList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_TmpWorkGroup = new CCL.BusinessEntities.HRIS.WorkGroup();
                        lcl_obj_TmpWorkGroup.WorkGroupCode = System.UInt64.Parse(lcl_obj_dr["WORK_GROUP_CODE"].ToString());
                        lcl_obj_TmpWorkGroup.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_TmpWorkGroup.WorkGroupName = lcl_obj_dr["WORK_GROUP_NAME"].ToString();
                        lcl_obj_TmpWorkGroup.Status = (SilkERP360.CCL.Enums.Status)System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpWorkGroupList.Add(lcl_obj_TmpWorkGroup);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpWorkGroupList;
                    
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_WorkGroupList;
        }
    }
}
