using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmProjectDataManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData>
    {
        public SpmSmProjectDataManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmProjectData IP_obj_SpmSmProjectData, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmProjectDataCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmProjectData.GetSequence());
            lcl_ui64_SmProjectDataCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmProjectData.SmProjectDateCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmProjectData.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProjectDataCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmProjectData IP_obj_SpmSmProjectData)
        {
            System.UInt64 lcl_ui64_SmProjectDataCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmProjectData.GetSequence());
            lcl_ui64_SmProjectDataCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmProjectData.SmProjectDateCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmProjectData.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmProjectDataCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProjectData Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_SpmSmProjectData = null;
            lcl_obj_SpmSmProjectData = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PROJECT_DATA WHERE SM_PROJECT_DATA_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmProjectData;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProjectData;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProjectData Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_SpmSmProjectData = null;
            lcl_obj_SpmSmProjectData = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PROJECT_DATA WHERE SM_PROJECT_DATA_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                    lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                    lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmProjectData;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProjectData;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProjectData Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_SpmSmProjectData = null;
            lcl_obj_SpmSmProjectData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmProjectData;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProjectData;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmProjectData Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_SpmSmProjectData = null;
            lcl_obj_SpmSmProjectData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                    lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                    lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmProjectData;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmProjectData;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> lcl_objlist_SpmSmProjectDataList = null;
            lcl_objlist_SpmSmProjectDataList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> lcl_objlist_TmpSpmSmProjectDataList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmProjectDataList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                    lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                    lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                    lcl_objlist_TmpSpmSmProjectDataList.Add(lcl_obj_TmpSpmSmProjectData);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmProjectDataList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmProjectDataList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> lcl_objlist_SpmSmProjectDataList = null;
            lcl_objlist_SpmSmProjectDataList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData> lcl_objlist_TmpSpmSmProjectDataList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmProjectData>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmProjectDataList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmProjectData lcl_obj_TmpSpmSmProjectData = new CCL.BusinessEntities.SPM.SM.SpmSmProjectData();
                        lcl_obj_TmpSpmSmProjectData.SmProjectDateCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_DATA_CODE"].ToString());
                        lcl_obj_TmpSpmSmProjectData.SmProjectCode = System.UInt64.Parse(lcl_obj_dr["SM_PROJECT_CODE"].ToString());
                        lcl_objlist_TmpSpmSmProjectDataList.Add(lcl_obj_TmpSpmSmProjectData);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmProjectDataList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmProjectDataList;
        }
    }
}
