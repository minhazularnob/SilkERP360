using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeEntitleLeaveManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>
    {
        public EmployeeEntitleLeaveManger()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeEntitleLeaveCode = 0;
            lcl_ui64_EmployeeEntitleLeaveCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEntitleLeave.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_LeaveCode = new System.Data.OracleClient.OracleParameter("p_LEAVE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_LeaveCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_LeaveCode.Value = lcl_obj_EmployeeEntitleLeave.LeaveCode;

                System.Data.OracleClient.OracleParameter lcl_obj_Balance = new System.Data.OracleClient.OracleParameter("p_BALANCE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Balance.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Balance.Value = lcl_obj_EmployeeEntitleLeave.Balance;

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_LeaveCode, lcl_obj_Balance, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_ENTITLE_LEAVE_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeEntitleLeaveCode;
        }


        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeEntitleLeaveCode = 0;
            lcl_ui64_EmployeeEntitleLeaveCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEntitleLeave.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_LeaveCode = new System.Data.OracleClient.OracleParameter("p_LEAVE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_LeaveCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_LeaveCode.Value = lcl_obj_EmployeeEntitleLeave.LeaveCode;

                System.Data.OracleClient.OracleParameter lcl_obj_Balance = new System.Data.OracleClient.OracleParameter("p_BALANCE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Balance.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Balance.Value = lcl_obj_EmployeeEntitleLeave.Balance;

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_LeaveCode, lcl_obj_Balance, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMP_UPDT_ENTITLE_LEAVE_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeEntitleLeaveCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave)
        {
            System.UInt64 lcl_ui64_EmployeeEntitleLeaveCode = 0;
            lcl_ui64_EmployeeEntitleLeaveCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEntitleLeave.EmployeeCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_LeaveCode = new System.Data.OracleClient.OracleParameter("v_LEAVE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_LeaveCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_LeaveCode.Value = lcl_obj_EmployeeEntitleLeave.LeaveCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_Balance = new System.Data.OracleClient.OracleParameter("v_BALANCE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Balance.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Balance.Value = lcl_obj_EmployeeEntitleLeave.Balance;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeeEntitleLeave.IsDeleted;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_EmployeeEntitleLeave.Status;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_LeaveCode, lcl_obj_Balance, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.EmployeeEntitleLeave_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeEntitleLeaveCode;
        }
        public CCL.BusinessEntities.HRIS.EmployeeEntitledLeave Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave = null;
            lcl_obj_EmployeeEntitleLeave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_ENTITLE_LEAVE EMPLOYEE_ENTITLE_LEAVE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeEntitleLeave.Get(ID,DBManger)) : Error Retrieving EmployeeEntitleLeave Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeEntitleLeave;
        }

        public CCL.BusinessEntities.HRIS.EmployeeEntitledLeave Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave = null;
            lcl_obj_EmployeeEntitleLeave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_ENTITLE_LEAVE EMPLOYEE_ENTITLE_LEAVE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeEntitleLeave.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                    lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeEntitleLeave;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> lcl_objlist_EmployeeEntitleLeave = null;
            lcl_objlist_EmployeeEntitleLeave = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeEntitleLeave.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>();
                    while (lcl_obj_dr.Read())
                    {
                       // SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                        lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                        lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_dr.Close();
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeEntitleLeave;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> lcl_objlist_EmployeeEntitleLeave = null;
            lcl_objlist_EmployeeEntitleLeave = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeEntitleLeave.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                    lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeEntitleLeave;
        }



        public CCL.BusinessEntities.HRIS.EmployeeEntitledLeave Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave = null;
            lcl_obj_EmployeeEntitleLeave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeEntitleLeave.Get(SqlQuery,DBManger)) : Error Retrieving EmployeeEntitleLeave Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeEntitleLeave;
        }

        public CCL.BusinessEntities.HRIS.EmployeeEntitledLeave Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitleLeave = null;
            lcl_obj_EmployeeEntitleLeave = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeEntitleLeave.Get(SqlQuery)) : No EmployeeEntitledLeave Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.LeaveCode = System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString());
                    lcl_obj_Tmp.Balance = System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeEntitleLeave;
        }
                
    }
}