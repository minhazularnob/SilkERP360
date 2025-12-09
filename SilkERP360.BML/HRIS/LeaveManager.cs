using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
    public class LeaveManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Leave>
    {
        public LeaveManger()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Leave, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_LeaveCode = 0;
            lcl_ui64_LeaveCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_LeaveCode = new OracleParameter("v_LEAVE_CODE", OracleDbType.Int64);
                lcl_obj_LeaveCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_LeaveCode.Value = lcl_obj_Leave.LeaveCode;
                OracleParameter lcl_obj_LeaveName = new OracleParameter("v_LEAVE_NAME", OracleDbType.NVarchar2);
                lcl_obj_LeaveName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_LeaveName.Value = lcl_obj_Leave.LeaveName;
                OracleParameter lcl_obj_ShortName = new OracleParameter("v_SHORT_NAME", OracleDbType.NVarchar2);
                lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShortName.Value = lcl_obj_Leave.ShortName;
                OracleParameter lcl_obj_NoOfDays = new OracleParameter("v_NO_OF_DAYS", OracleDbType.Int64);
                lcl_obj_NoOfDays.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_NoOfDays.Value = lcl_obj_Leave.NoOfDays;
                OracleParameter lcl_obj_CompanyCode = new OracleParameter("v_COMPANY_CODE", OracleDbType.Int64);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Leave.CompanyCode;
                OracleParameter lcl_obj_IsCarryForwarded = new OracleParameter("v_IS_CARRY_FORWARDED", OracleDbType.Int64);
                lcl_obj_IsCarryForwarded.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsCarryForwarded.Value = lcl_obj_Leave.IsCarryForwarded;
                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_Leave.IsDeleted;
                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Leave.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_LeaveCode, lcl_obj_LeaveName, lcl_obj_ShortName, lcl_obj_NoOfDays, lcl_obj_CompanyCode, lcl_obj_IsCarryForwarded, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.Leave_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_LeaveCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_LeaveCode;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Leave)
        {
            System.UInt64 lcl_ui64_LeaveCode = 0;
            lcl_ui64_LeaveCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_LeaveCode = new OracleParameter("v_LEAVE_CODE", OracleDbType.Int64);
                    lcl_obj_LeaveCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_LeaveCode.Value = lcl_obj_Leave.LeaveCode;
                    OracleParameter lcl_obj_LeaveName = new OracleParameter("v_LEAVE_NAME", OracleDbType.NVarchar2);
                    lcl_obj_LeaveName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_LeaveName.Value = lcl_obj_Leave.LeaveName;
                    OracleParameter lcl_obj_ShortName = new OracleParameter("v_SHORT_NAME", OracleDbType.NVarchar2);
                    lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShortName.Value = lcl_obj_Leave.ShortName;
                    OracleParameter lcl_obj_NoOfDays = new OracleParameter("v_NO_OF_DAYS", OracleDbType.Int64);
                    lcl_obj_NoOfDays.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_NoOfDays.Value = lcl_obj_Leave.NoOfDays;
                    OracleParameter lcl_obj_CompanyCode = new OracleParameter("v_COMPANY_CODE", OracleDbType.Int64);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Leave.CompanyCode;
                    OracleParameter lcl_obj_IsCarryForwarded = new OracleParameter("v_IS_CARRY_FORWARDED", OracleDbType.Int64);
                    lcl_obj_IsCarryForwarded.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsCarryForwarded.Value = lcl_obj_Leave.IsCarryForwarded;
                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_Leave.IsDeleted;
                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_Leave.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_LeaveCode, lcl_obj_LeaveName, lcl_obj_ShortName, lcl_obj_NoOfDays, lcl_obj_CompanyCode, lcl_obj_IsCarryForwarded, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.Leave_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_LeaveCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_LeaveCode;
        }
        public CCL.BusinessEntities.HRIS.Leave Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Leave lcl_obj_Leave = null;
            lcl_obj_Leave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Leave>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From LEAVE LEAVE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorLeave.Get(ID,DBManger)) : Error Retrieving Leave Data!");
                }
                lcl_obj_dr.Read();

                SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Leave();
                lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                lcl_obj_Tmp.LeaveName = lcl_obj_dr["LEAVE_NAME"].ToString();
                lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_Tmp.NoOfDays = System.UInt16.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString());
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.IsCarryForwarded = System.UInt16.Parse(lcl_obj_dr["IS_CARRY_FORWARDED"].ToString());
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Leave;
        }

        public CCL.BusinessEntities.HRIS.Leave Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Leave lcl_obj_Leave = null;
            lcl_obj_Leave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Leave>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From LEAVE LEAVE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Leave.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Leave();
                    lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                    lcl_obj_Tmp.LeaveName = lcl_obj_dr["LEAVE_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.NoOfDays = System.UInt32.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString());
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.IsCarryForwarded = System.UInt16.Parse(lcl_obj_dr["IS_CARRY_FORWARDED"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Leave;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objlist_Leave = null;
            lcl_objlist_Leave = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Leave.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Leave();
                        lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                        lcl_obj_Tmp.LeaveName = lcl_obj_dr["LEAVE_NAME"].ToString();
                        lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                        lcl_obj_Tmp.NoOfDays = System.UInt16.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString());
                        lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_Tmp.IsCarryForwarded = System.UInt64.Parse(lcl_obj_dr["IS_CARRY_FORWARDED"].ToString());
                        lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_Leave;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objlist_Leave = null;
            lcl_objlist_Leave = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Leave.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Leave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Leave();
                    lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                    lcl_obj_Tmp.LeaveName = lcl_obj_dr["LEAVE_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.NoOfDays = System.UInt16.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString());
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.IsCarryForwarded = System.UInt16.Parse(lcl_obj_dr["IS_CARRY_FORWARDED"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_Leave;
        }


        public CCL.BusinessEntities.HRIS.Leave Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Leave Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}