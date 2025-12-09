using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    
    public class ScJOManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScJO>
    {
        public ScJOManager()
        {
            this.Initialize();
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No SCJO Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScJO lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScJO();
                    lcl_obj.ScJOCode = System.UInt64.Parse(dr["SC_J_O_CODE"].ToString());
                    lcl_obj.ScJONo = dr["SC_J_O_NO"].ToString();
                    lcl_obj.Telco = dr["TELCO"].ToString();
                    lcl_obj.ProductionStatus = System.UInt64.Parse(dr["PRODUCTION_STATUS"].ToString());
                    lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> lcl_list_details = null;
        //    lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO>>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            lcl_obj_DBManager.Open();
        //        }
        //        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
        //        if (!(dr.HasRows))
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No SCJO Data Found In The Database!!!");
        //        }
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScJO>();
        //        while (dr.Read())
        //        {
        //            SilkERP360.CCL.BusinessEntities.SCPM.ScJO lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScJO();
        //            lcl_obj.ScJOCode = System.UInt64.Parse(dr["SC_J_O_CODE"].ToString());
        //            lcl_obj.ScJONo = dr["SC_J_O_NO"].ToString();
        //            lcl_obj.Telco = dr["TELCO"].ToString();
        //            lcl_obj.ProductionStatus = System.UInt64.Parse(dr["PRODUCTION_STATUS"].ToString());
        //            lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
        //            lcl_obj_ListTmp.Add(lcl_obj);
        //        }
        //        dr.Close();
        //        return lcl_obj_ListTmp;
        //    }, "BMLExceptionPolicy");
        //    return lcl_list_details;
        //}
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScJO lcl_obj_SCJO, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SCJO = 0;
            lcl_ui64_SCJO = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_ScJOCode = new OracleParameter("p_SC_J_O_CODE", OracleDbType.Int64);
                lcl_obj_ScJOCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScJOCode.Value = lcl_obj_SCJO.ScJOCode;
                OracleParameter lcl_obj_ScJONo = new OracleParameter("p_SC_J_O_NO", OracleDbType.NVarchar2, 256);
                lcl_obj_ScJONo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScJONo.Value = lcl_obj_SCJO.ScJONo;
                OracleParameter lcl_obj_Telco = new OracleParameter("p_TELCO", OracleDbType.NVarchar2, 256);
                lcl_obj_Telco.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Telco.Value = lcl_obj_SCJO.Telco;
                OracleParameter lcl_obj_ProductionStatus = new OracleParameter("p_PRODUCTION_STATUS", OracleDbType.Int64);
                lcl_obj_ProductionStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ProductionStatus.Value = lcl_obj_SCJO.ProductionStatus;
                OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_SCJO.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ScJOCode, lcl_obj_ScJONo, lcl_obj_Telco, lcl_obj_ProductionStatus, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.SCJO_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_ScJOCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_SCJO;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScJO lcl_obj_SCJO)
        {
            System.UInt64 lcl_ui64_SCJO = 0;
            lcl_ui64_SCJO = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_ScJOCode = new OracleParameter("p_SC_J_O_CODE", OracleDbType.Int64);
                    lcl_obj_ScJOCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScJOCode.Value = lcl_obj_SCJO.ScJOCode;
                    OracleParameter lcl_obj_ScJONo = new OracleParameter("p_SC_J_O_NO", OracleDbType.NVarchar2, 256);
                    lcl_obj_ScJONo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScJONo.Value = lcl_obj_SCJO.ScJONo;
                    OracleParameter lcl_obj_Telco = new OracleParameter("p_TELCO", OracleDbType.NVarchar2, 256);
                    lcl_obj_Telco.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Telco.Value = lcl_obj_SCJO.Telco;
                    OracleParameter lcl_obj_ProductionStatus = new OracleParameter("p_PRODUCTION_STATUS", OracleDbType.Int64);
                    lcl_obj_ProductionStatus.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ProductionStatus.Value = lcl_obj_SCJO.ProductionStatus;
                    OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_SCJO.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ScJOCode, lcl_obj_ScJONo, lcl_obj_Telco, lcl_obj_ProductionStatus, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.SCJO_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_ScJOCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SCJO;
        }

        public CCL.BusinessEntities.SCPM.ScJO Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScJO Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScJO Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScJO Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.ScJO> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
