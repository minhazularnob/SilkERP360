using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.ReadService.SCPM
{
    public class SCPMMachineService
    {
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineSTRExt> GetMachineSTRExtThroughputByProcessDateRange(System.UInt64 IP_ui64_SectionCode, System.UInt64 IP_ui64_ProcessCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndTime)
        {
            try
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND SECTION_CODE = {1} AND STATUS = {2}", IP_ui64_ProcessCode, IP_ui64_SectionCode, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_SCPMMachine = this.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineSTRExt> lcl_objList_SCPMMachineSTRExt = new System.Collections.Generic.List<Containers.SCPM.DataStructure.SCPMMachineSTRExt>();
                foreach (SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine in lcl_objList_SCPMMachine)
                {
                    //get SCPMMachineSTRExt from MachineCode
                    SilkERPDataService.Containers.SCPM.SCPMMachineSTR lcl_obj_SCPMMachineSTR = this.GetMachineSTRByMachineCode(lcl_obj_SCPMMachine._MachineCode_UI64, lcl_obj_DBManager);
                    System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objList_MachineThroughput = this.GetMachineThroughputList(lcl_obj_SCPMMachine._MachineCode_UI64, IP_dt_StartDate, IP_dt_EndTime, lcl_obj_DBManager);
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineSTRExt lcl_obj_SCPMMachineSTRExt = new Containers.SCPM.DataStructure.SCPMMachineSTRExt(lcl_obj_SCPMMachineSTR);
                    lcl_obj_SCPMMachineSTRExt._SCPMMachineThroughput = lcl_objList_MachineThroughput;
                    lcl_objList_SCPMMachineSTRExt.Add(lcl_obj_SCPMMachineSTRExt);
                }
                lcl_obj_DBManager.Close();
                lcl_obj_DBManager.Dispose();
                return lcl_objList_SCPMMachineSTRExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt> GetMachineExtThroughputByProcessDateRange(System.UInt64 IP_ui64_SectionCode, System.UInt64 IP_ui64_ProcessCode,System.DateTime IP_dt_StartDate,System.DateTime IP_dt_EndTime)
        {
            try
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND SECTION_CODE = {1} AND STATUS = {2}",IP_ui64_ProcessCode,IP_ui64_SectionCode,(System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_SCPMMachine = this.GetList(lcl_str_SqlQuery,lcl_obj_DBManager);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt> lcl_objList_SCPMMachineExt = new System.Collections.Generic.List<Containers.SCPM.DataStructure.SCPMMachineExt>();
                foreach(SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine in lcl_objList_SCPMMachine)
                {
                    System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objList_MachineThroughput = this.GetMachineThroughputList(lcl_obj_SCPMMachine._MachineCode_UI64,IP_dt_StartDate,IP_dt_EndTime,lcl_obj_DBManager);
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt lcl_obj_SCPMMachineExt = new Containers.SCPM.DataStructure.SCPMMachineExt(lcl_obj_SCPMMachine);
                    lcl_obj_SCPMMachineExt._SCPMMachineThroughput = lcl_objList_MachineThroughput;
                    lcl_objList_SCPMMachineExt.Add(lcl_obj_SCPMMachineExt);
                }
                lcl_obj_DBManager.Close();
                lcl_obj_DBManager.Dispose();
                return lcl_objList_SCPMMachineExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> GetMachineThroughputList(System.UInt64 IP_ui64_MachineCode,System.DateTime IP_dt_StartDate,System.DateTime IP_dt_EndDate, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objList_MachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE_THROUGHPUT WHERE MACHINE_CODE = {0} AND (THROUGHPUT_DT_TM >= TO_DATE('{1}','dd/MM/yyyy') AND THROUGHPUT_DT_TM <= TO_DATE('{2}','dd/MM/yyyy')) ORDER BY THROUGHPUT_DT_TM ASC", IP_ui64_MachineCode, IP_dt_StartDate.ToString("dd/MM/yyyy"), IP_dt_EndDate.ToString("dd/MM/yyyy"));
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineThroughputReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_MachineThroughputReader.HasRows == false)
                {
                    //throw new System.Exception("Machine Throughput Data Not Found in the SilkERP database for the Machine!!!");
                    //Throughput data not found.return empty list
                    return lcl_objList_MachineThroughputList;
                }
                while (lcl_obj_MachineThroughputReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCMachineThroughput lcl_obj_SCPMMachineThroughput = new SilkERPDataService.Containers.SCPM.SCMachineThroughput();
                    lcl_obj_SCPMMachineThroughput._ThroughputCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_THROUGHPUT_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._ShiftCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["SHIFT_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineThroughputReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachineThroughput._Throughput_I64 = System.Int64.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_SHFT"].ToString());
                    lcl_obj_SCPMMachineThroughput._ThroughputDateTime_DT = System.DateTime.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_DT_TM"].ToString());
                    lcl_obj_SCPMMachineThroughput._EntryEmployeeCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["ENTRY_EMP_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._Remarks_STR = lcl_obj_MachineThroughputReader["REMARKS"].ToString();
                    lcl_obj_SCPMMachineThroughput._EntryDateTime_DT = System.DateTime.Parse(lcl_obj_MachineThroughputReader["ENTRY_DT_TM"].ToString());
                    lcl_obj_SCPMMachineThroughput._Wastage_UI32 = System.UInt32.Parse(lcl_obj_MachineThroughputReader["WASTAGE"].ToString());
                    lcl_obj_SCPMMachineThroughput._DailySCPMMachineStatus = (Containers.SCPM.DailySCPMMachineStatus)System.UInt32.Parse(lcl_obj_MachineThroughputReader["DAILY_STATUS"].ToString());
                    lcl_objList_MachineThroughputList.Add(lcl_obj_SCPMMachineThroughput);
                }
                lcl_obj_MachineThroughputReader.Close();

                return lcl_objList_MachineThroughputList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> GetMachineThroughputList(System.UInt64 IP_ui64_MachineCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objList_MachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE_THROUGHPUT WHERE MACHINE_CODE = {0}", IP_ui64_MachineCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineThroughputReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_MachineThroughputReader.HasRows == false)
                {
                    throw new System.Exception("Machine Throughput Data Not Found in the SilkERP database for the Machine!!!");
                }
                while (lcl_obj_MachineThroughputReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCMachineThroughput lcl_obj_SCPMMachineThroughput = new SilkERPDataService.Containers.SCPM.SCMachineThroughput();
                    lcl_obj_SCPMMachineThroughput._ThroughputCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_THROUGHPUT_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._ShiftCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["SHIFT_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineThroughputReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachineThroughput._Throughput_I64 = System.Int64.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_SHFT"].ToString());
                    lcl_obj_SCPMMachineThroughput._ThroughputDateTime_DT = System.DateTime.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_DT_TM"].ToString());
                    lcl_obj_SCPMMachineThroughput._EntryEmployeeCode_UI64 = System.UInt64.Parse(lcl_obj_MachineThroughputReader["ENTRY_EMP_CODE"].ToString());
                    lcl_obj_SCPMMachineThroughput._Remarks_STR = lcl_obj_MachineThroughputReader["REMARKS"].ToString();
                    lcl_obj_SCPMMachineThroughput._EntryDateTime_DT = System.DateTime.Parse(lcl_obj_MachineThroughputReader["ENTRY_DT_TM"].ToString());
                    lcl_obj_SCPMMachineThroughput._Wastage_UI32 = System.UInt32.Parse(lcl_obj_MachineThroughputReader["WASTAGE"].ToString());
                    lcl_obj_SCPMMachineThroughput._DailySCPMMachineStatus = (Containers.SCPM.DailySCPMMachineStatus)System.UInt32.Parse(lcl_obj_MachineThroughputReader["DAILY_STATUS"].ToString());
                    lcl_objList_MachineThroughputList.Add(lcl_obj_SCPMMachineThroughput);
                }
                lcl_obj_MachineThroughputReader.Close();

                return lcl_objList_MachineThroughputList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// /////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager">Open and Initialised DBManager</param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetList(System.String IP_str_SqlQuery,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_MachineReader.HasRows == false)
                {
                    //throw new System.Exception("Machine Data Not Found in the SilkERP database!!!");
                    //no machine found for the Process. return empty List
                    return lcl_objList_MachineList;
                }
                while (lcl_obj_MachineReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                    lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_SCPMMachine._ShortName_STR = lcl_obj_MachineReader["SHORT_NAME"].ToString();
                    lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                    lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                    lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                    /// If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                    lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                }
                lcl_obj_MachineReader.Close();
                          
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetList(System.String IP_str_SqlQuery)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    //System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        //no machine found for the Process. return empty List
                        return lcl_objList_MachineList;
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                        lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCPMMachine._ShortName_STR = lcl_obj_MachineReader["SHORT_NAME"].ToString();
                        lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                    }
                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.SCPMMachine GetMachineByMachineCode(System.UInt64 IP_ui64_MachineCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_Machine = new SilkERPDataService.Containers.SCPM.SCPMMachine();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0} AND STATUS = {1}", IP_ui64_MachineCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_MachineReader.Read();

                    SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                    lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());
            
                    lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                    lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                    /// If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;

                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_Machine;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }


        }

        public SilkERPDataService.Containers.SCPM.SCPMMachine GetMachineByMachineCode(System.UInt64 IP_ui64_MachineCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_Machine = new SilkERPDataService.Containers.SCPM.SCPMMachine();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0} AND STATUS = {1}", IP_ui64_MachineCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_MachineReader.Read();

                    SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                    lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                    lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                    lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                    /// If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;

                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                }
                return lcl_obj_Machine;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public SilkERPDataService.Containers.SCPM.SCPMMachineSTR GetMachineSTRByMachineCode(System.UInt64 IP_ui64_MachineCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMMachineSTR lcl_obj_MachineSTR = new SilkERPDataService.Containers.SCPM.SCPMMachineSTR();
                    //lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0} AND STATUS = {1}", IP_ui64_MachineCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_MachineReader.Read();

                   // SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                    lcl_obj_MachineSTR._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_MachineSTR._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_MachineSTR._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_MachineSTR._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                    lcl_obj_MachineSTR._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));
                    lcl_obj_MachineSTR._MeasurementUnit_STR = ((SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()))).ToString();

                    lcl_obj_MachineSTR._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_MachineSTR._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_MachineSTR._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_MachineSTR._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    // If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_MachineSTR._OperationalStatus_ENM = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    lcl_obj_MachineSTR._OperationalStatus_STR = ((SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()))).ToString();
                    //Inactive Sections will not come in the result set
                    
                    lcl_obj_MachineReader.Close();
                    //lcl_obj_DBManager.CloseReader();
                
                return lcl_obj_MachineSTR;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public SilkERPDataService.Containers.SCPM.SCPMMachineSTR GetMachineSTRByMachineCode(System.UInt64 IP_ui64_MachineCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMMachineSTR lcl_obj_MachineSTR = new SilkERPDataService.Containers.SCPM.SCPMMachineSTR();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0} AND STATUS = {1}", IP_ui64_MachineCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_MachineReader.Read();

                    // SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                    lcl_obj_MachineSTR._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_MachineSTR._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_MachineSTR._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_MachineSTR._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                    lcl_obj_MachineSTR._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));
                    lcl_obj_MachineSTR._MeasurementUnit_STR = ((SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()))).ToString();

                    lcl_obj_MachineSTR._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_MachineSTR._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_MachineSTR._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_MachineSTR._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    // If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_MachineSTR._OperationalStatus_ENM = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    lcl_obj_MachineSTR._OperationalStatus_STR = ((SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()))).ToString();
                    //Inactive Sections will not come in the result set

                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_MachineSTR;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetMachineListByProcess(System.UInt64 IP_ui64_ProcessCode)
        {

            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                        lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                    }
                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetMachineListByProcess(System.UInt64 IP_ui64_ProcessCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                        lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                    }
                    lcl_obj_MachineReader.Close();
                    IP_obj_DBManager.CloseReader();
                }
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetMachineListBySection(System.UInt64 IP_ui64_SectionCode)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                        lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                    }
                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> GetMachineListBySection(System.UInt64 IP_ui64_SectionCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SCPMMachine>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine = new Containers.SCPM.SCPMMachine();
                        lcl_obj_SCPMMachine._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCPMMachine._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMMachine._Name_STR = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCPMMachine._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCPMMachine._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCPMMachine._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMMachine._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCPMMachine._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCPMMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMMachine._Status = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_MachineList.Add(lcl_obj_SCPMMachine);
                    }
                    lcl_obj_MachineReader.Close();
                    IP_obj_DBManager.CloseReader();
                }
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        
        public SilkERPDataService.Containers.SCPM.SCPMMachineDetails GetMachineDetailByMachineCode(System.UInt64 IP_ui64_MachineCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMMachineDetails lcl_obj_MachineDtl = new SilkERPDataService.Containers.SCPM.SCPMMachineDetails();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0}", IP_ui64_MachineCode.ToString());
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineDtlReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_MachineDtlReader.HasRows == false)
                    {
                        throw new System.Exception("Machine Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_MachineDtlReader.Read();

                    //SilkERPDataService.Containers.SCPM.SCPMMachineDetails lcl_obj_SCPMMachineDtl = new Containers.SCPM.SCPMMachineDetails();
                    lcl_obj_MachineDtl._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineDtlReader["MACHINE_CODE"].ToString());
                    System.UInt64 lcl_ui64_CompanyCode = (System.UInt64.Parse(lcl_obj_MachineDtlReader["COMPANY_CODE"].ToString()));
                    lcl_obj_MachineDtl._Name_STR = lcl_obj_MachineDtlReader["NAME"].ToString();
                    System.UInt64 lcl_ui64_ProcessCode = (System.UInt64.Parse(lcl_obj_MachineDtlReader["PROCESS_CODE"].ToString()));

                    lcl_obj_MachineDtl._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineDtlReader["MEASUREMENT_UNIT"].ToString()));
                    System.UInt64 lcl_ui64_SectionCode = System.UInt64.Parse(lcl_obj_MachineDtlReader["SECTION_CODE"].ToString());
                    lcl_obj_MachineDtl._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineDtlReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_MachineDtl._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineDtlReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_MachineDtl._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineDtlReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_MachineDtl._Throughput_UI32 = System.UInt32.Parse(lcl_obj_MachineDtlReader["THROUGHPUT_HR"].ToString());
                    /// If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_MachineDtl._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineDtlReader["OPERATIONAL_STATUS"].ToString()));
                    //Inactive Sections will not come in the result set
                    lcl_obj_MachineDtl._Status = (SilkERP360.CCL.Enums.Status)(System.UInt32.Parse(lcl_obj_MachineDtlReader["STATUS"].ToString()));
                    lcl_obj_MachineDtlReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    //get CompanyCore, Process and Section object
                    SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = null;
                    using (SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager())
                    {
                        lcl_obj_CompanyCore = lcl_obj_CompanyManager.getCompanyCore(lcl_ui64_CompanyCode, lcl_obj_DBManager);
                    }

                    SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = null;
                    SilkERPDataService.ReadService.SCPM.SCPMProcessService lcl_obj_SCPMProcessService = new SilkERPDataService.ReadService.SCPM.SCPMProcessService();
                    lcl_obj_SCPMProcess = lcl_obj_SCPMProcessService.GetProcessByProcessCode(lcl_ui64_ProcessCode, lcl_obj_DBManager);

                    SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = null;
                    SilkERPDataService.ReadService.SCPM.SCPMSectionService lcl_obj_SCPMSectionService = new SilkERPDataService.ReadService.SCPM.SCPMSectionService();
                    lcl_obj_SCPMSection = lcl_obj_SCPMSectionService.GetSectionBySectionCode(lcl_ui64_SectionCode, lcl_obj_DBManager);

                    lcl_obj_MachineDtl._Section_OBJ = lcl_obj_SCPMSection;
                    lcl_obj_MachineDtl._Process_OBJ = lcl_obj_SCPMProcess;
                    lcl_obj_MachineDtl._Company_OBJ = lcl_obj_CompanyCore;
                                        
                    lcl_obj_DBManager.Close();
                    lcl_obj_DBManager.Dispose();
                }
                return lcl_obj_MachineDtl;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }



        public SilkERPDataService.Containers.SCPM.SCPMMachineDetails GetMachineDetailByMachineCode(System.UInt64 IP_ui64_MachineCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachineDetails> GetMachineDetailsListByProcess(System.UInt64 IP_ui64_ProcessCode)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachineDetails> GetMachineDetailsListByProcess(System.UInt64 IP_ui64_ProcessCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }
    }
}
