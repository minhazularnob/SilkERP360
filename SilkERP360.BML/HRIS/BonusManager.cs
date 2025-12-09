using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class BonusManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Bonus>
    {
        public BonusManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Bonus IP_obj_Bonus, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_BonusCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Bonus.GetSequence());
            lcl_ui64_BonusCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Bonus.BonusCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_Bonus.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_BonusCode;
        }
        public ulong Save(CCL.BusinessEntities.HRIS.Bonus IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Bonus Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Bonus Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Bonus Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Bonus Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Bonus> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Bonus> lcl_objlist_BonusList = null;
            lcl_objlist_BonusList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Bonus>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Bonus> lcl_objlist_TmpBonusList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Bonus>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpBonusList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Bonus lcl_obj_TmpBonus = new CCL.BusinessEntities.HRIS.Bonus();
                    lcl_obj_TmpBonus.BonusCode = System.UInt64.Parse(lcl_obj_dr["BONUS_CODE"].ToString());
                    lcl_obj_TmpBonus.BonusMasterCode = System.UInt64.Parse(lcl_obj_dr["BONUS_MASTER_CODE"].ToString());
                    lcl_obj_TmpBonus.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpBonus.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_TmpBonus.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_TmpBonus.Designation = lcl_obj_dr["DESIGNATION"].ToString();
                    lcl_obj_TmpBonus.BankAccount = lcl_obj_dr["BANK_ACCOUNT"].ToString();
                    lcl_obj_TmpBonus.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());

                    lcl_obj_TmpBonus.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_TmpBonus.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_TmpBonus.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_TmpBonus.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_TmpBonus.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_TmpBonus.BonusAmount = System.Decimal.Parse(lcl_obj_dr["BONUS_AMOUNT"].ToString());

                    lcl_objlist_TmpBonusList.Add(lcl_obj_TmpBonus);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpBonusList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_BonusList;
        }

        public List<CCL.BusinessEntities.HRIS.Bonus> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
