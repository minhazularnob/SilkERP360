using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    class IncrementMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.IncrementMaster>
    {
        public IncrementMasterManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.HRIS.IncrementMaster IP_obj_IncrementMaster, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_IncrementMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_IncrementMaster.GetSequence());
            lcl_ui64_IncrementMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_IncrementMaster.IncrementMasterCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_IncrementMaster.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

                /*************************************************************************************************/
                //Save Increment List
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment in IP_obj_IncrementMaster.IncrementList)
                {
                    //lcl_obj_Increment.IncrementMasterCode = lcl_ui64_ID;
                    lcl_str_SqlInsert = lcl_obj_Increment.GenerateSqlInsert();
                    lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                }
                /*************************************************************************************************/

                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementMasterCode;
        }
        public ulong Save(CCL.BusinessEntities.HRIS.IncrementMaster IP_obj_IncrementMaster)
        {
            System.UInt64 lcl_ui64_IncrementMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_IncrementMaster.GetSequence());
            lcl_ui64_IncrementMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                //SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
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

                    IP_obj_IncrementMaster.IncrementMasterCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_IncrementMaster.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);

                    /*************************************************************************************************/
                    //Save Increment List
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment in IP_obj_IncrementMaster.IncrementList)
                    {
                        //lcl_obj_Increment.IncrementMasterCode = lcl_ui64_ID;
                        lcl_str_SqlInsert = lcl_obj_Increment.GenerateSqlInsert();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    }
                    /*************************************************************************************************/
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementMasterCode;
        }

        public CCL.BusinessEntities.HRIS.IncrementMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster = null;
            lcl_obj_IncrementMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.IncrementMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From INCREMENT_MASTER WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                lcl_obj_dr.Close();
                /*****************************************************************************************************************/
                //Retrieve IncrementList
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                lcl_obj_TmpIncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                /*****************************************************************************************************************/
                return lcl_obj_TmpIncrementMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_IncrementMaster;
        }

        public CCL.BusinessEntities.HRIS.IncrementMaster Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster = null;
            lcl_obj_IncrementMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.IncrementMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From INCREMENT_MASTER WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                    lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    /*****************************************************************************************************************/
                    //Retrieve IncrementList
                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                    lcl_obj_TmpIncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    /*****************************************************************************************************************/
                    return lcl_obj_TmpIncrementMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_IncrementMaster;
        }

        public CCL.BusinessEntities.HRIS.IncrementMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster = null;
            lcl_obj_IncrementMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.IncrementMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                //System.String lcl_str_SqlQuery = System.String.Format("Select * From INCREMENT_MASTER WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                lcl_obj_dr.Close();
                /*****************************************************************************************************************/
                //Retrieve IncrementList
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                IP_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", lcl_obj_TmpIncrementMaster.IncrementMasterCode);
                lcl_obj_TmpIncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(IP_str_SqlQuery, lcl_obj_DBManager);
                /*****************************************************************************************************************/
                return lcl_obj_TmpIncrementMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_IncrementMaster;
        }

        public CCL.BusinessEntities.HRIS.IncrementMaster Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster = null;
            lcl_obj_IncrementMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.IncrementMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    //System.String lcl_str_SqlQuery = System.String.Format("Select * From INCREMENT_MASTER WHERE INCREMENT_MASTER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                    lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    /*****************************************************************************************************************/
                    //Retrieve IncrementList
                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                    IP_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", lcl_obj_TmpIncrementMaster.IncrementMasterCode);
                    lcl_obj_TmpIncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(IP_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    /*****************************************************************************************************************/
                    return lcl_obj_TmpIncrementMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_IncrementMaster;
        }

        public List<CCL.BusinessEntities.HRIS.IncrementMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster> lcl_objlist_IncrementMasterList = null;
            lcl_objlist_IncrementMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster> lcl_objlist_TmpIncrementMasterList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpIncrementMasterList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                    lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_objlist_TmpIncrementMasterList.Add(lcl_obj_TmpIncrementMaster);
                }
                lcl_obj_dr.Close();
                /***********************************************************************************************************************/
                //Retrieve IncrementList For Each Increment Master
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                System.String lcl_str_SqlQuery = System.String.Empty;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster in lcl_objlist_TmpIncrementMasterList)
                {
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", lcl_obj_IncrementMaster.IncrementMasterCode);
                    lcl_obj_IncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                }
                /***********************************************************************************************************************/
                return lcl_objlist_TmpIncrementMasterList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementMasterList;
        }

        public List<CCL.BusinessEntities.HRIS.IncrementMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster> lcl_objlist_IncrementMasterList = null;
            lcl_objlist_IncrementMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster> lcl_objlist_TmpIncrementMasterList = new
                       System.Collections.Generic.List<CCL.BusinessEntities.HRIS.IncrementMaster>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpIncrementMasterList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_TmpIncrementMaster = new CCL.BusinessEntities.HRIS.IncrementMaster();
                        lcl_obj_TmpIncrementMaster.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                        lcl_obj_TmpIncrementMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_TmpIncrementMaster.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                        lcl_obj_TmpIncrementMaster.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                        lcl_objlist_TmpIncrementMasterList.Add(lcl_obj_TmpIncrementMaster);
                    }
                    lcl_obj_dr.Close();
                    /***********************************************************************************************************************/
                    //Retrieve IncrementList For Each Increment Master
                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new IncrementManager();
                    System.String lcl_str_SqlQuery = System.String.Empty;
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.IncrementMaster lcl_obj_IncrementMaster in lcl_objlist_TmpIncrementMasterList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_INCREMENT WHERE INCREMENT_MASTER_CODE = {0}", lcl_obj_IncrementMaster.IncrementMasterCode);
                        lcl_obj_IncrementMaster.IncrementList = lcl_obj_IncrementManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    }
                    /***********************************************************************************************************************/
                    return lcl_objlist_TmpIncrementMasterList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementMasterList;
        }
    }
}
