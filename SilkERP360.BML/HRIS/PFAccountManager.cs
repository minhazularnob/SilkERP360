using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class PFAccountManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>
    {
        public PFAccountManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.HRIS.PFAccount IP_obj_PFAccount, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_PFAccountNumber = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_PFAccount.GetSequence());
            lcl_ui64_PFAccountNumber = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_PFAccount.PFAccountNumber = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_PFAccount.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_PFAccountNumber;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.PFAccount IP_obj_PFAccount)
        {
            System.UInt64 lcl_ui64_PFAccountNumber = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_PFAccount.GetSequence());
            lcl_ui64_PFAccountNumber = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_PFAccount.PFAccountNumber = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_PFAccount.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_PFAccountNumber;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.PFAccount>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT WHERE PF_ACCOUNT_NUMBER = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new CCL.BusinessEntities.HRIS.PFAccount();
                lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
               
                lcl_obj_dr.Close();
                return lcl_obj_TmpPFAccount;
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.PFAccount>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT WHERE PF_ACCOUNT_NUMBER = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new CCL.BusinessEntities.HRIS.PFAccount();
                    lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                    lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpPFAccount;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>(() =>
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
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccount();
                lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpPFAccount;
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>(() =>
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
                    SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccount();
                    lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                    lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpPFAccount;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccount> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount> lcl_objlist_PFAccount = null;
            lcl_objlist_PFAccount = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount> lcl_objlist_TmpPFAccountList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpPFAccountList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new CCL.BusinessEntities.HRIS.PFAccount();
                    lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                    lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_objlist_TmpPFAccountList.Add(lcl_obj_TmpPFAccount);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpPFAccountList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_PFAccount;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccount> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount> lcl_objlist_PFAccountList = null;
            lcl_objlist_PFAccountList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount> lcl_objlist_TmpPFAccountList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccount>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpPFAccountList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.PFAccount lcl_obj_TmpPFAccount = new CCL.BusinessEntities.HRIS.PFAccount();
                        lcl_obj_TmpPFAccount.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                        lcl_obj_TmpPFAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpPFAccount.AccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(lcl_obj_dr["ACCOUNT_STATUS"].ToString());
                        lcl_obj_TmpPFAccount.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpPFAccount.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_objlist_TmpPFAccountList.Add(lcl_obj_TmpPFAccount);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpPFAccountList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_PFAccountList;
        }
    }
}
