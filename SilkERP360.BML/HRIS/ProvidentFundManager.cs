using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
    public class ProvidentFundManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund >
    {
        public ProvidentFundManager()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeePfCode = 0;
            lcl_ui64_EmployeePfCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_PfCode = new OracleParameter("v_PF_CODE", OracleDbType.Int64);
                lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfCode.Value = lcl_obj_EmployeePf.PfCode;
                OracleParameter lcl_obj_PfAccountNo = new OracleParameter("v_PF_ACCOUNT_NO", OracleDbType.NVarchar2);
                lcl_obj_PfAccountNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfAccountNo.Value = lcl_obj_EmployeePf.PfAccountNo;
                OracleParameter lcl_obj_PfPercentage = new OracleParameter("v_PF_PERCENTAGE", OracleDbType.Int64);
                lcl_obj_PfPercentage.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfPercentage.Value = lcl_obj_EmployeePf.PfPercentage;
                OracleParameter lcl_obj_PfStartDate = new OracleParameter("v_PF_START_DATE", OracleDbType.Date);
                lcl_obj_PfStartDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfStartDate.Value = lcl_obj_EmployeePf.PfStartDate;
                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_EmployeePf.IsDeleted;
                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_EmployeePf.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_PfCode, lcl_obj_PfAccountNo, lcl_obj_PfPercentage, lcl_obj_PfStartDate, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.EmployeePf_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_PfCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeePfCode;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf)
        {
            System.UInt64 lcl_ui64_EmployeePfCode = 0;
            lcl_ui64_EmployeePfCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_PfCode = new OracleParameter("v_PF_CODE", OracleDbType.Int64);
                    lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfCode.Value = lcl_obj_EmployeePf.PfCode;
                    OracleParameter lcl_obj_PfAccountNo = new OracleParameter("v_PF_ACCOUNT_NO", OracleDbType.NVarchar2);
                    lcl_obj_PfAccountNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfAccountNo.Value = lcl_obj_EmployeePf.PfAccountNo;
                    OracleParameter lcl_obj_PfPercentage = new OracleParameter("v_PF_PERCENTAGE", OracleDbType.Int64);
                    lcl_obj_PfPercentage.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfPercentage.Value = lcl_obj_EmployeePf.PfPercentage;
                    OracleParameter lcl_obj_PfStartDate = new OracleParameter("v_PF_START_DATE", OracleDbType.Date);
                    lcl_obj_PfStartDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfStartDate.Value = lcl_obj_EmployeePf.PfStartDate;
                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeePf.IsDeleted;
                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_EmployeePf.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_PfCode, lcl_obj_PfAccountNo, lcl_obj_PfPercentage, lcl_obj_PfStartDate, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.EmployeePf_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_PfCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeePfCode;
        }
        public CCL.BusinessEntities.HRIS.ProvidentFund Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf = null;
            lcl_obj_EmployeePf = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_PF EMPLOYEE_PF_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeePf.Get(ID,DBManger)) : Error Retrieving EmployeePf Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePf;
        }

        public CCL.BusinessEntities.HRIS.ProvidentFund Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf = null;
            lcl_obj_EmployeePf = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_PF EMPLOYEE_PF_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePf.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                    lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePf;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> lcl_objlist_EmployeePf = null;
            lcl_objlist_EmployeePf = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePf.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                        lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                        lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                        lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                        lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                        lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeePf;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> lcl_objlist_EmployeePf = null;
            lcl_objlist_EmployeePf = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePf.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                    lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeePf;
        }



        public CCL.BusinessEntities.HRIS.ProvidentFund Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf = null;
            lcl_obj_EmployeePf = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeePf.Get(SqlQuery,DBManger)) : Error Retrieving EmployeePf Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePf;
        }

        public CCL.BusinessEntities.HRIS.ProvidentFund Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_EmployeePf = null;
            lcl_obj_EmployeePf = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePf.Get(SqlQuery)) : No ProvidentFund Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund();
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.PfAccountNo = lcl_obj_dr["PF_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.PfPercentage = System.Decimal.Parse(lcl_obj_dr["PF_PERCENTAGE"].ToString());
                    lcl_obj_Tmp.PfStartDate = System.DateTime.Parse(lcl_obj_dr["PF_START_DATE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePf;
        }

       
    }
}