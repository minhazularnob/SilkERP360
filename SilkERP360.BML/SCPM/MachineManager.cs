using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class MachineManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
   SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>
    {
        public MachineManger()
        {
            this.Initialize();
        }
        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Machine> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Machine> lcl_list_details = null;
        //    lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Machine>>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            lcl_obj_DBManager.Open();
        //        }
        //        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
        //        if (!(dr.HasRows))
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Machine Data Found In The Database!!!");
        //        }
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Machine> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Machine>();
        //        while (dr.Read())
        //        {
        //            SilkERP360.CCL.BusinessEntities.SCPM.Machine lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.Machine();
        //            lcl_obj.MachineCode = System.UInt64.Parse(dr["MACHINE_CODE"].ToString());
        //            lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
        //            lcl_obj.Name = dr["NAME"].ToString();
        //            lcl_obj.ShortName = dr["SHORT_NAME"].ToString();
        //            lcl_obj.ProcessCode = System.UInt64.Parse(dr["PROCESS_CODE"].ToString());
        //            lcl_obj.ThroughputHr = System.UInt64.Parse(dr["THROUGHPUT_HR"].ToString());
        //            lcl_obj.MasurmentUnit = System.UInt64.Parse(dr["MASURMENT_UNIT"].ToString());
        //            lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
        //            lcl_obj_ListTmp.Add(lcl_obj);
        //        }
        //        dr.Close();
        //        return lcl_obj_ListTmp;
        //    }, "BMLExceptionPolicy");
        //    return lcl_list_details;
        //}

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Machine Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine();
                    lcl_obj.MachineCode = System.UInt64.Parse(dr["MACHINE_CODE"].ToString());
                    lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj.Name = dr["NAME"].ToString();
                    lcl_obj.ShortName = dr["SHORT_NAME"].ToString();
                    lcl_obj.ProcessCode = System.UInt64.Parse(dr["PROCESS_CODE"].ToString());
                    lcl_obj.Throughput_Hr = System.UInt32.Parse(dr["THROUGHPUT_HR"].ToString());
                    lcl_obj.CommittedThroughput = System.UInt32.Parse(dr["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj.OptimumThroughput = System.UInt32.Parse(dr["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj.Identifier = System.UInt32.Parse(dr["IDENTIFIER"].ToString());
                    lcl_obj.MeasurementUnit = (SilkERP360.CCL.Enums.SCPM.MachineOutputMeasurementUnit)System.UInt16.Parse(dr["MEASUREMENT_UNIT"].ToString());
                    lcl_obj.Status = (SilkERP360.CCL.Enums.Status)System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_obj.OperationalStatus = (SilkERP360.CCL.Enums.SCPM.MachineOperationalStatus)System.UInt16.Parse(dr["OPERATIONAL_STATUS"].ToString());
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        public List<CCL.BusinessEntities.SCPM.SCPMMachine> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(dr.HasRows))
                    {
                        //return Empty list
                        return lcl_obj_ListTmp;
                        //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Machine Data Found In The Database!!!");
                    }
                    
                    while (dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine();
                        lcl_obj.MachineCode = System.UInt64.Parse(dr["MACHINE_CODE"].ToString());
                        lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                        lcl_obj.Name = dr["NAME"].ToString();
                        lcl_obj.ShortName = dr["SHORT_NAME"].ToString();
                        lcl_obj.ProcessCode = System.UInt64.Parse(dr["PROCESS_CODE"].ToString());
                        lcl_obj.Throughput_Hr = System.UInt32.Parse(dr["THROUGHPUT_HR"].ToString());
                        lcl_obj.CommittedThroughput = System.UInt32.Parse(dr["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj.OptimumThroughput = System.UInt32.Parse(dr["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj.Identifier = (dr["IDENTIFIER"].ToString().Trim() == "") ? 0 : System.UInt32.Parse(dr["IDENTIFIER"].ToString());
                        lcl_obj.MeasurementUnit = (SilkERP360.CCL.Enums.SCPM.MachineOutputMeasurementUnit)System.UInt16.Parse(dr["MEASUREMENT_UNIT"].ToString());
                        lcl_obj.Status = (SilkERP360.CCL.Enums.Status)System.UInt16.Parse(dr["STATUS"].ToString());
                        lcl_obj.OperationalStatus = (SilkERP360.CCL.Enums.SCPM.MachineOperationalStatus)System.UInt16.Parse(dr["OPERATIONAL_STATUS"].ToString());
                        lcl_obj_ListTmp.Add(lcl_obj);
                    }
                    dr.Close();
                }
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine lcl_obj_Machine, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_Machine = 0;
            lcl_ui64_Machine = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_MachineCode = new OracleParameter("p_MACHINE_CODE", OracleDbType.Int64);
                lcl_obj_MachineCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MachineCode.Value = lcl_obj_Machine.MachineCode;
                OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Machine.CompanyCode;
                OracleParameter lcl_obj_Name = new OracleParameter("p_NAME", OracleDbType.NVarchar2, 512);
                lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Name.Value = lcl_obj_Machine.Name;
                OracleParameter lcl_obj_ShortName = new OracleParameter("p_SHORT_NAME", OracleDbType.NVarchar2, 256);
                lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShortName.Value = lcl_obj_Machine.ShortName;
                OracleParameter lcl_obj_ProcessCode = new OracleParameter("p_PROCESS_CODE", OracleDbType.Int64);
                lcl_obj_ProcessCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ProcessCode.Value = lcl_obj_Machine.ProcessCode;
                OracleParameter lcl_obj_ThroughputHr = new OracleParameter("p_THROUGHPUT_HR", OracleDbType.Int64);
                lcl_obj_ThroughputHr.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ThroughputHr.Value = lcl_obj_Machine.Throughput_Hr;
                OracleParameter lcl_obj_MasurmentUnit = new OracleParameter("p_MASURMENT_UNIT", OracleDbType.Int64);
                lcl_obj_MasurmentUnit.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MasurmentUnit.Value = lcl_obj_Machine.MeasurementUnit;
                OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Machine.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_MachineCode, lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_ShortName, lcl_obj_ProcessCode, lcl_obj_ThroughputHr, lcl_obj_MasurmentUnit, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.Machine_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_MachineCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_Machine;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine lcl_obj_Machine)
        {
            System.UInt64 lcl_ui64_Machine = 0;
            lcl_ui64_Machine = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_MachineCode = new OracleParameter("p_MACHINE_CODE", OracleDbType.Int64);
                    lcl_obj_MachineCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MachineCode.Value = lcl_obj_Machine.MachineCode;
                    OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Machine.CompanyCode;
                    OracleParameter lcl_obj_Name = new OracleParameter("p_NAME", OracleDbType.NVarchar2, 512);
                    lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Name.Value = lcl_obj_Machine.Name;
                    OracleParameter lcl_obj_ShortName = new OracleParameter("p_SHORT_NAME", OracleDbType.NVarchar2, 256);
                    lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShortName.Value = lcl_obj_Machine.ShortName;
                    OracleParameter lcl_obj_ProcessCode = new OracleParameter("p_PROCESS_CODE", OracleDbType.Int64);
                    lcl_obj_ProcessCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ProcessCode.Value = lcl_obj_Machine.ProcessCode;
                    OracleParameter lcl_obj_ThroughputHr = new OracleParameter("p_THROUGHPUT_HR", OracleDbType.Int64);
                    lcl_obj_ThroughputHr.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ThroughputHr.Value = lcl_obj_Machine.Throughput_Hr;
                    OracleParameter lcl_obj_MasurmentUnit = new OracleParameter("p_MASURMENT_UNIT", OracleDbType.Int64);
                    lcl_obj_MasurmentUnit.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MasurmentUnit.Value = lcl_obj_Machine.MeasurementUnit;
                    OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_Machine.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_MachineCode, lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_ShortName, lcl_obj_ProcessCode, lcl_obj_ThroughputHr, lcl_obj_MasurmentUnit, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.Machine_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_MachineCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_Machine;
        }


        public CCL.BusinessEntities.SCPM.SCPMMachine Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.SCPMMachine Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.SCPMMachine Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.SCPMMachine Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        
    }
}
