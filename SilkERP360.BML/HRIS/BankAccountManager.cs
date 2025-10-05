using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeBankAccountsManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>
    {
        public EmployeeBankAccountsManger()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeBankAccountsCode = 0;
            lcl_ui64_EmployeeBankAccountsCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_BankAccountCode = new System.Data.OracleClient.OracleParameter("v_BANK_ACCOUNT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_BankAccountCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BankAccountCode.Value = lcl_obj_EmployeeBankAccounts.BankAccountCode;
                System.Data.OracleClient.OracleParameter lcl_obj_BankAccountNumber = new System.Data.OracleClient.OracleParameter("v_BANK_ACCOUNT_NUMBER", System.Data.OracleClient.OracleType.NVarChar);
                lcl_obj_BankAccountNumber.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BankAccountNumber.Value = lcl_obj_EmployeeBankAccounts.BankAccountNumber;
                System.Data.OracleClient.OracleParameter lcl_obj_BankCode = new System.Data.OracleClient.OracleParameter("v_BANK_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_BankCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BankCode.Value = lcl_obj_EmployeeBankAccounts.BankCode;
                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeBankAccounts.EmployeeCode;
                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_EmployeeBankAccounts.IsDeleted;
                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_EmployeeBankAccounts.Status;
                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_BankAccountCode, lcl_obj_BankAccountNumber, lcl_obj_BankCode, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.EmployeeBankAccounts_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_BankAccountCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeBankAccountsCode;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts)
        {
            System.UInt64 lcl_ui64_EmployeeBankAccountsCode = 0;
            lcl_ui64_EmployeeBankAccountsCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_BankAccountCode = new System.Data.OracleClient.OracleParameter("v_BANK_ACCOUNT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_BankAccountCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BankAccountCode.Value = lcl_obj_EmployeeBankAccounts.BankAccountCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_BankAccountNumber = new System.Data.OracleClient.OracleParameter("v_BANK_ACCOUNT_NUMBER", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_BankAccountNumber.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BankAccountNumber.Value = lcl_obj_EmployeeBankAccounts.BankAccountNumber;
                    System.Data.OracleClient.OracleParameter lcl_obj_BankCode = new System.Data.OracleClient.OracleParameter("v_BANK_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_BankCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BankCode.Value = lcl_obj_EmployeeBankAccounts.BankCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeBankAccounts.EmployeeCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeeBankAccounts.IsDeleted;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_EmployeeBankAccounts.Status;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_BankAccountCode, lcl_obj_BankAccountNumber, lcl_obj_BankCode, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.EmployeeBankAccounts_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_BankAccountCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeBankAccountsCode;
        }
        public CCL.BusinessEntities.HRIS.EmployeeBankAccount Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts = null;
            lcl_obj_EmployeeBankAccounts = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_BANK_ACCOUNTS EMPLOYEE_BANK_ACCOUNTS_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeBankAccounts.Get(ID,DBManger)) : Error Retrieving EmployeeBankAccounts Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeBankAccounts;
        }

        public CCL.BusinessEntities.HRIS.EmployeeBankAccount Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts = null;
            lcl_obj_EmployeeBankAccounts = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_BANK_ACCOUNTS EMPLOYEE_BANK_ACCOUNTS_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeBankAccounts.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                    lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                    lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                    lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeBankAccounts;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> lcl_objlist_EmployeeBankAccounts = null;
            lcl_objlist_EmployeeBankAccounts = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeBankAccounts.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                        lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                        lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                        lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeBankAccounts;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> lcl_objlist_EmployeeBankAccounts = null;
            lcl_objlist_EmployeeBankAccounts = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeBankAccounts.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                    lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                    lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                    lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeBankAccounts;
        }
/// <summary>
/// ///////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <param name="IP_obj_DBManager"></param>
/// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeBankAccount Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts = null;
            lcl_obj_EmployeeBankAccounts = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeBankAccounts.Get(SqlQuery,DBManger)) : Error Retrieving EmployeeBankAccounts Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeBankAccounts;
        }
/// <summary>
/// ////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeBankAccount Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_EmployeeBankAccounts = null;
            lcl_obj_EmployeeBankAccounts = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeBankAccounts.Get(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount();
                    lcl_obj_Tmp.BankAccountCode = System.UInt64.Parse(lcl_obj_dr["BANK_ACCOUNT_CODE"].ToString());
                    lcl_obj_Tmp.BankAccountNumber = lcl_obj_dr["BANK_ACCOUNT_NUMBER"].ToString();
                    lcl_obj_Tmp.BankCode = System.UInt64.Parse(lcl_obj_dr["BANK_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeBankAccounts;
        }



     
    }
}