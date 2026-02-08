using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeLeaveAccountManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>
    {
        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveAccount IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_LeaveAccountCode = 0;
            
            lcl_ui64_LeaveAccountCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("select max(leave_account_code)+1 as ID from EMPLOYEE_LEAVE_ACCOUNT");

                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.LeaveAccountCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_LeaveAccountCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveAccount IP_obj_A)
        {
            System.UInt64 lcl_ui64_LeaveAccountCode = 0;

            lcl_ui64_LeaveAccountCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("select max(leave_account_code)+1 from EMPLOYEE_LEAVE_ACCOUNT");
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

                    IP_obj_A.LeaveAccountCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_LeaveAccountCode;
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveAccount Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount= null;
            lcl_obj_EmployeeLeaveAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_LEAVE_ACCOUNT WHERE LEAVE_ACCOUNT_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpEmployeeLeaveAccount;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeLeaveAccount;
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveAccount Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = null;
            lcl_obj_EmployeeLeaveAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_LEAVE_ACCOUNT WHERE LEAVE_ACCOUNT_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                    lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpEmployeeLeaveAccount;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeLeaveAccount;
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveAccount Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = null;
            lcl_obj_EmployeeLeaveAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>(() =>
            {
                
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpEmployeeLeaveAccount;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeLeaveAccount;
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveAccount Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = null;
            lcl_obj_EmployeeLeaveAccount = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                    lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpEmployeeLeaveAccount;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeLeaveAccount;
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> lcl_objlist_EmployeeLeaveAccountList = null;
            lcl_objlist_EmployeeLeaveAccountList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> lcl_objlist_TmpEmployeeLeaveAccountList = new
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpEmployeeLeaveAccountList;
                }
                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                    lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                    lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                    lcl_objlist_TmpEmployeeLeaveAccountList.Add(lcl_obj_TmpEmployeeLeaveAccount);
                }
                lcl_obj_dr.Close();
                lcl_obj_DBManager.Close();
                return lcl_objlist_TmpEmployeeLeaveAccountList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeLeaveAccountList;
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> lcl_objlist_EmployeeLeaveAccountList = null;
            lcl_objlist_EmployeeLeaveAccountList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> lcl_objlist_TmpEmployeeLeaveAccountList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpEmployeeLeaveAccountList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_TmpEmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                        lcl_obj_TmpEmployeeLeaveAccount.LeaveAccountCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_ACCOUNT_CODE"].ToString());
                        lcl_obj_TmpEmployeeLeaveAccount.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpEmployeeLeaveAccount.CL = System.UInt32.Parse(lcl_obj_dr["CL"].ToString());
                        lcl_obj_TmpEmployeeLeaveAccount.SL = System.UInt32.Parse(lcl_obj_dr["SL"].ToString());
                        lcl_obj_TmpEmployeeLeaveAccount.ML = System.UInt32.Parse(lcl_obj_dr["ML"].ToString());
                        lcl_obj_TmpEmployeeLeaveAccount.EL = System.UInt32.Parse(lcl_obj_dr["EL"].ToString());
                        lcl_objlist_TmpEmployeeLeaveAccountList.Add(lcl_obj_TmpEmployeeLeaveAccount);
                    }
                    lcl_obj_dr.Close();
                    lcl_obj_DBManager.InternalResource.Close();
                    return lcl_objlist_TmpEmployeeLeaveAccountList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeLeaveAccountList;
        }
    }
}
