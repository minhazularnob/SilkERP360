using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScPersoISODataManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>
    {
        public ScpmScPersoISODataManager()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISOData IP_obj_ScPersoISOData, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ScPersoISODataCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PERSO_DATA.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_ScPersoISODataCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScPersoISOData.ScPersoISODataCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScPersoISOData.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScPersoISODataCode;
         }

        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISOData IP_obj_ScPersoISODataO)
        {
            System.UInt64 lcl_ui64_ScPersoISODataCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PERSO_DATA.NEXTVAL AS ID FROM DUAL", IP_obj_ScPersoISODataO.GetSequence());
            lcl_ui64_ScPersoISODataCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_ScPersoISODataO.ScPersoISODataCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_ScPersoISODataO.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScPersoISODataCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PERSO_ISO_DATA WHERE SC_PERSO_ISO_DATA_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                
               lcl_obj_dr.Close();
                return lcl_obj_TmpScPersoISOData;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PERSO_ISO_DATA WHERE SC_PERSO_ISO_DATA_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                    lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScPersoISOData;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
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
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                lcl_obj_dr.Close();

                return lcl_obj_TmpScPersoISOData;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                    lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScPersoISOData;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_objlist_ScPersoISODataList = null;
            lcl_objlist_ScPersoISODataList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_objlist_TmpScPersoISODataList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpScPersoISODataList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                    lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_objlist_TmpScPersoISODataList.Add(lcl_obj_TmpScPersoISOData);
                }
                lcl_obj_dr.Close();


                return lcl_objlist_TmpScPersoISODataList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScPersoISODataList;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_objlist_ScPersoISODataList = null;
            lcl_objlist_ScPersoISODataList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_objlist_TmpScPersoISODataList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpScPersoISODataList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_TmpScPersoISOData = new CCL.BusinessEntities.SCPM.ScpmScPersoISOData();
                        lcl_obj_TmpScPersoISOData.ScPersoISODataCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_DATA_CODE"].ToString());
                        lcl_obj_TmpScPersoISOData.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                        lcl_obj_TmpScPersoISOData.Quantity = System.UInt32.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpScPersoISOData.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                        lcl_obj_TmpScPersoISOData.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                        lcl_obj_TmpScPersoISOData.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                        lcl_objlist_TmpScPersoISODataList.Add(lcl_obj_TmpScPersoISOData);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpScPersoISODataList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScPersoISODataList;
        }
    }
}
