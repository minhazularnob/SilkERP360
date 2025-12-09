using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class BonusMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster>
    {
        public BonusMasterManager()
        {
            this.Initialize();
        }
        public ulong Save(CCL.BusinessEntities.HRIS.BonusMaster IP_obj_BonusMaster, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_BonusMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_BonusMaster.GetSequence());
            lcl_ui64_BonusMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_BonusMaster.BonusMasterCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_BonusMaster.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

                /*******************************************************************************************************************/
                //Save BonusList
                SilkERP360.BML.HRIS.BonusManager lcl_obj_BonusManager = new BonusManager();
                lcl_obj_BonusManager.Initialize();
                foreach (CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus in IP_obj_BonusMaster.BonusList)
                {
                    lcl_obj_Bonus.BonusMasterCode = lcl_ui64_ID;
                    lcl_obj_BonusManager.Save(lcl_obj_Bonus, lcl_obj_DBManager);
                }
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_BonusMasterCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.BonusMaster IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.BonusMaster Get(ulong IP_ui64_BonusMasterCode, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = null;
            lcl_obj_BonusMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.BonusMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM BONUS_MASTER WHERE BONUS_MASTER_CODE = {0}", IP_ui64_BonusMasterCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_TmpBonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
                lcl_obj_TmpBonusMaster.BonusMasterCode = System.UInt64.Parse(lcl_obj_dr["BONUS_MASTER_CODE"].ToString());
                lcl_obj_TmpBonusMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpBonusMaster.Occasion = (CCL.Enums.BonusOccasion)System.UInt32.Parse(lcl_obj_dr["OCCASION"].ToString());
                lcl_obj_TmpBonusMaster.Month = (CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["MONTH"].ToString());
                lcl_obj_TmpBonusMaster.Year = System.UInt32.Parse(lcl_obj_dr["YEAR"].ToString());
                lcl_obj_TmpBonusMaster.BonusDate = System.DateTime.Parse(lcl_obj_dr["BONUS_DATE"].ToString());
                lcl_obj_TmpBonusMaster.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpBonusMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpBonusMaster.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_dr.Close();

                //Get BonusList
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM BONUS WHERE BONUS_MASTER_CODE = {0}", IP_ui64_BonusMasterCode);
                SilkERP360.BML.HRIS.BonusManager lcl_obj_BonusManager = new BonusManager();
                lcl_obj_BonusManager.Initialize();
                lcl_obj_TmpBonusMaster.BonusList = lcl_obj_BonusManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);

                return lcl_obj_TmpBonusMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_BonusMaster;
        }

        public CCL.BusinessEntities.HRIS.BonusMaster Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.BonusMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.BonusMaster Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.BonusMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.BonusMaster> lcl_objlist_BonusMasterList = null;
            lcl_objlist_BonusMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.BonusMaster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.BonusMaster> lcl_objlist_TmpBonusMasterList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.BonusMaster>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpBonusMasterList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_TmpBonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
                    lcl_obj_TmpBonusMaster.BonusMasterCode = System.UInt64.Parse(lcl_obj_dr["BONUS_MASTER_CODE"].ToString());
                    lcl_obj_TmpBonusMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpBonusMaster.Occasion = (CCL.Enums.BonusOccasion)System.UInt32.Parse(lcl_obj_dr["OCCASION"].ToString());
                    lcl_obj_TmpBonusMaster.Month = (CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["MONTH"].ToString());
                    lcl_obj_TmpBonusMaster.Year = System.UInt32.Parse(lcl_obj_dr["YEAR"].ToString());
                    lcl_obj_TmpBonusMaster.BonusDate = System.DateTime.Parse(lcl_obj_dr["BONUS_DATE"].ToString());
                    lcl_obj_TmpBonusMaster.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpBonusMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpBonusMaster.Remarks = lcl_obj_dr["REMARKS"].ToString();

                    lcl_objlist_TmpBonusMasterList.Add(lcl_obj_TmpBonusMaster);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpBonusMasterList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_BonusMasterList;
        }

        public List<CCL.BusinessEntities.HRIS.BonusMaster> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
