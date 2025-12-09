using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.ReadService.SCPM
{
    public class SCDataProvider : System.IDisposable
    {
        #region SCPM.SC.SCSection
        public SilkERPDataService.Containers.SCPM.SC.SCSection GetSCSection(System.UInt64 IP_ui64_SectionCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SC.SCSection();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data for Section Code " + IP_ui64_SectionCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_SectionReader.Read();

                    SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection = new Containers.SCPM.SC.SCSection();
                    lcl_obj_SCSection._SectionCode = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                    lcl_obj_SCSection._CompanyCode = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCSection._Name = lcl_obj_SectionReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCSection._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_SectionReader["STATUS"].ToString())); 

                    lcl_obj_SectionReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_Section;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.SC.SCSection GetSCSection(System.UInt64 IP_ui64_SectionCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SC.SCSection();
               
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_SectionReader.HasRows == false)
                {
                    throw new System.Exception("Section Data for Section Code " + IP_ui64_SectionCode.ToString() + " Not Found in the SilkERP database!!!");
                }
                lcl_obj_SectionReader.Read();

                SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection = new Containers.SCPM.SC.SCSection();
                lcl_obj_SCSection._SectionCode = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                lcl_obj_SCSection._CompanyCode = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                lcl_obj_SCSection._Name = lcl_obj_SectionReader["NAME"].ToString();
                //Inactive Sections will not come in the result set
                lcl_obj_SCSection._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_SectionReader["STATUS"].ToString()));

                lcl_obj_SectionReader.Close();
   
                
                return lcl_obj_SCSection;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCSection> GetSCSectionList(System.String IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SC.SCSection>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_SectionReader.HasRows == false)
                {
                    throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                }
                while (lcl_obj_SectionReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection = new Containers.SCPM.SC.SCSection();
                    lcl_obj_SCSection._SectionCode = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                    lcl_obj_SCSection._CompanyCode = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCSection._Name = lcl_obj_SectionReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCSection._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_SectionReader["STATUS"].ToString()));
                    lcl_objList_SectionList.Add(lcl_obj_SCSection);
                }
                lcl_obj_SectionReader.Close();

                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCSection> GetSCSectionList(System.String IP_str_SqlQuery)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SC.SCSection>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_SectionReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection = new Containers.SCPM.SC.SCSection();
                        lcl_obj_SCSection._SectionCode = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                        lcl_obj_SCSection._CompanyCode = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCSection._Name = lcl_obj_SectionReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCSection._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_SectionReader["STATUS"].ToString()));
                        lcl_objList_SectionList.Add(lcl_obj_SCSection);
                    }
                    lcl_obj_SectionReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region SCPM.SC.SCProcess
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCProcess> GetSCProcessList(System.String IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SC.SCProcess>();
            try
            {
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Initialize();
                    lcl_obj_DBManager.Open();

                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_ProcessReader.HasRows == false)
                    {
                        throw new System.Exception("Process Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_ProcessReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SC.SCProcess lcl_obj_SCPMProcess = new Containers.SCPM.SC.SCProcess();
                        lcl_obj_SCPMProcess._ProcessCode = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                        lcl_obj_SCPMProcess._SectionCode = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMProcess._Name = lcl_obj_ProcessReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMProcess._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_ProcessReader["STATUS"].ToString()));
                        lcl_objList_ProcessList.Add(lcl_obj_SCPMProcess);
                    }
                    lcl_obj_ProcessReader.Close();
                    lcl_obj_DBManager.CloseReader();
                }
                return lcl_objList_ProcessList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }


        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCProcess> GetSCProcessList(System.String IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SC.SCProcess>();
            try
            {
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_ProcessReader.HasRows == false)
                {
                    throw new System.Exception("Process Data Not Found in the SilkERP database!!!");
                }
                while (lcl_obj_ProcessReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SC.SCProcess lcl_obj_SCPMProcess = new Containers.SCPM.SC.SCProcess();
                    lcl_obj_SCPMProcess._ProcessCode = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMProcess._SectionCode = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMProcess._Name = lcl_obj_ProcessReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMProcess._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_ProcessReader["STATUS"].ToString()));
                    lcl_objList_ProcessList.Add(lcl_obj_SCPMProcess);
                }
                lcl_obj_ProcessReader.Close();
                return lcl_objList_ProcessList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }


        }

        public SilkERPDataService.Containers.SCPM.SC.SCProcess GetSCProcess(System.UInt64 IP_ui64_ProcessCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SC.SCProcess lcl_obj_SCProcess = null;
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_ProcessReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data for Process Code " + IP_ui64_ProcessCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_ProcessReader.Read();

                    lcl_obj_SCProcess = new Containers.SCPM.SC.SCProcess();
                    lcl_obj_SCProcess._ProcessCode = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCProcess._SectionCode = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCProcess._Name = lcl_obj_ProcessReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCProcess._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_ProcessReader["STATUS"].ToString()));

                    lcl_obj_ProcessReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_SCProcess;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }

        public SilkERPDataService.Containers.SCPM.SC.SCProcess GetSCProcess(System.UInt64 IP_ui64_ProcessCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                              
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_ProcessReader.HasRows == false)
                {
                    throw new System.Exception("Section Data for Process Code " + IP_ui64_ProcessCode.ToString() + " Not Found in the SilkERP database!!!");
                }
                lcl_obj_ProcessReader.Read();

                SilkERPDataService.Containers.SCPM.SC.SCProcess lcl_obj_SCProcess = new Containers.SCPM.SC.SCProcess();
                lcl_obj_SCProcess._ProcessCode = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                lcl_obj_SCProcess._SectionCode = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                lcl_obj_SCProcess._Name = lcl_obj_ProcessReader["NAME"].ToString();
                //Inactive Sections will not come in the result set
                lcl_obj_SCProcess._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_ProcessReader["STATUS"].ToString()));

                lcl_obj_ProcessReader.Close();
            
                
                return lcl_obj_SCProcess;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }
        #endregion

        #region SCPM.SC.SCMachine
        public SilkERPDataService.Containers.SCPM.SC.SCMachine GetSCMachine(System.UInt64 IP_ui64_MachineCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = null;
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

                    lcl_obj_SCMachine = new Containers.SCPM.SC.SCMachine();
                    lcl_obj_SCMachine._MachineCode = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCMachine._CompanyCode = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCMachine._Name = lcl_obj_MachineReader["NAME"].ToString();
                    lcl_obj_SCMachine._ProcessCode = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                    lcl_obj_SCMachine._MeasurementUnit = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                    lcl_obj_SCMachine._SectionCode = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                    lcl_obj_SCMachine._CommittedThroughput = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_SCMachine._OptimumThroughput = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_SCMachine._TargetThroughput = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCMachine._Throughput = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                    /// If Machine is ON/OFF/ServiceIntervention
                    lcl_obj_SCMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCMachine._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_MachineReader["STATUS"].ToString()));

                    lcl_obj_SCMachine._AdditionalData.Add("MeasurementUnit", lcl_obj_SCMachine._MeasurementUnit.ToString());
                    
                    lcl_obj_MachineReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();

                }
                return lcl_obj_SCMachine;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }


        }

        public SilkERPDataService.Containers.SCPM.SC.SCMachine GetSCMachine(System.UInt64 IP_ui64_MachineCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = null;
               
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE MACHINE_CODE = {0} AND STATUS = {1}", IP_ui64_MachineCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_MachineReader.HasRows == false)
                {
                    throw new System.Exception("Section Data for Section Code " + IP_ui64_MachineCode.ToString() + " Not Found in the SilkERP database!!!");
                }
                lcl_obj_MachineReader.Read();

                lcl_obj_SCMachine = new Containers.SCPM.SC.SCMachine();
                lcl_obj_SCMachine._MachineCode = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                lcl_obj_SCMachine._CompanyCode = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                lcl_obj_SCMachine._Name = lcl_obj_MachineReader["NAME"].ToString();
                lcl_obj_SCMachine._ProcessCode = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                lcl_obj_SCMachine._MeasurementUnit = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                lcl_obj_SCMachine._SectionCode = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                lcl_obj_SCMachine._CommittedThroughput = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                lcl_obj_SCMachine._OptimumThroughput = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                lcl_obj_SCMachine._TargetThroughput = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                lcl_obj_SCMachine._Throughput = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                /// If Machine is ON/OFF/ServiceIntervention
                lcl_obj_SCMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                //Inactive Sections will not come in the result set
                lcl_obj_SCMachine._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_MachineReader["STATUS"].ToString()));
                lcl_obj_SCMachine._AdditionalData.Add("MeasurementUnit", lcl_obj_SCMachine._MeasurementUnit.ToString());
                lcl_obj_MachineReader.Close();
    
                
                return lcl_obj_SCMachine;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }


        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachine> GetSCMachineList(System.String IP_str_SqlQuery)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SC.SCMachine>();
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
                        SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = new Containers.SCPM.SC.SCMachine();
                        lcl_obj_SCMachine._MachineCode = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCMachine._CompanyCode = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCMachine._Name = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCMachine._ShortName = lcl_obj_MachineReader["SHORT_NAME"].ToString();
                        lcl_obj_SCMachine._ProcessCode = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCMachine._MeasurementUnit = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCMachine._SectionCode = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCMachine._CommittedThroughput = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._OptimumThroughput = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._TargetThroughput = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._Throughput = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCMachine._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_MachineReader["STATUS"].ToString()));
                        lcl_obj_SCMachine._AdditionalData.Add("MeasurementUnit", lcl_obj_SCMachine._MeasurementUnit.ToString());
                        lcl_objList_MachineList.Add(lcl_obj_SCMachine);
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

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachine> GetSCMachineList(System.String IP_str_SqlQuery,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachine> lcl_objList_MachineList = new System.Collections.Generic.List<Containers.SCPM.SC.SCMachine>();
                
                    //System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_MachineReader.HasRows == false)
                    {
                        //no machine found for the Process. return empty List
                        return lcl_objList_MachineList;
                    }
                    while (lcl_obj_MachineReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = new Containers.SCPM.SC.SCMachine();
                        lcl_obj_SCMachine._MachineCode = System.UInt64.Parse(lcl_obj_MachineReader["MACHINE_CODE"].ToString());
                        lcl_obj_SCMachine._CompanyCode = System.UInt64.Parse(lcl_obj_MachineReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCMachine._Name = lcl_obj_MachineReader["NAME"].ToString();
                        lcl_obj_SCMachine._ShortName = lcl_obj_MachineReader["SHORT_NAME"].ToString();
                        lcl_obj_SCMachine._ProcessCode = System.UInt64.Parse(lcl_obj_MachineReader["PROCESS_CODE"].ToString());

                        lcl_obj_SCMachine._MeasurementUnit = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.UInt32.Parse(lcl_obj_MachineReader["MEASUREMENT_UNIT"].ToString()));

                        lcl_obj_SCMachine._SectionCode = System.UInt64.Parse(lcl_obj_MachineReader["SECTION_CODE"].ToString());
                        lcl_obj_SCMachine._CommittedThroughput = System.UInt32.Parse(lcl_obj_MachineReader["COMMITTED_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._OptimumThroughput = System.UInt32.Parse(lcl_obj_MachineReader["OPTIMUM_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._TargetThroughput = System.UInt32.Parse(lcl_obj_MachineReader["TARGET_THROUGHPUT"].ToString());
                        lcl_obj_SCMachine._Throughput = System.UInt32.Parse(lcl_obj_MachineReader["THROUGHPUT_HR"].ToString());
                        /// If Machine is ON/OFF/ServiceIntervention
                        lcl_obj_SCMachine._OperationalStatus = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.UInt32.Parse(lcl_obj_MachineReader["OPERATIONAL_STATUS"].ToString()));
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCMachine._Status = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_MachineReader["STATUS"].ToString()));
                        lcl_obj_SCMachine._AdditionalData.Add("MeasurementUnit", lcl_obj_SCMachine._MeasurementUnit.ToString());
                        lcl_objList_MachineList.Add(lcl_obj_SCMachine);
                    }
                    lcl_obj_MachineReader.Close();
                return lcl_objList_MachineList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region SCPM.SC.SCMachineThroughput

        public SilkERPDataService.Containers.SCPM.DataStructure.SC.DayRangeMachineThroughput GetDaywiseMachineThroughputByDayRange(System.UInt64 IP_ui64_MachineCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.DataStructure.SC.DayRangeMachineThroughput lcl_obj_DayRangeMachineThroughput = null;
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Initialize();
                    lcl_obj_DBManager.Open();
                    SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_SCDataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                    SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = lcl_obj_SCDataProvider.GetSCMachine(IP_ui64_MachineCode, lcl_obj_DBManager);
                    lcl_obj_DayRangeMachineThroughput = new Containers.SCPM.DataStructure.SC.DayRangeMachineThroughput(lcl_obj_SCMachine,IP_dt_StartDate, IP_dt_EndDate);
                    //populate the consolidated Throughput
                    System.DateTime lcl_dt_ThroughputDate = IP_dt_StartDate;
                    System.String lcl_str_SqlQuery = System.String.Empty;
                    while (lcl_dt_ThroughputDate <= IP_dt_EndDate)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT SUM(TARGET_THROUGHPUT) AS TARGET_THROUGHPUT,SUM(THROUGHPUT_SHFT) AS THROUGHPUT_SHFT,SUM(WASTAGE) AS WASTAGE FROM SCPM_MACHINE_THROUGHPUT " +
                        "WHERE MACHINE_CODE = {0} AND THROUGHPUT_DT_TM = TO_DATE('{1}','dd/MM/yyyy')", IP_ui64_MachineCode, lcl_dt_ThroughputDate.ToString("dd/MM/yyyy"));
                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ThroughputReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                        if (!(lcl_obj_ThroughputReader.HasRows))
                        {
                            continue;
                        }
                        lcl_obj_ThroughputReader.Read();
                        SilkERPDataService.Containers.SCPM.DataStructure.SC.DaywiseMachineThroughput lcl_obj_DaywiseMachineThroughput =  
                            new SilkERPDataService.Containers.SCPM.DataStructure.SC.DaywiseMachineThroughput();
                        lcl_obj_DaywiseMachineThroughput._MachineCode = IP_ui64_MachineCode;
                        if ((lcl_obj_ThroughputReader["TARGET_THROUGHPUT"] == System.DBNull.Value) ||
                            (lcl_obj_ThroughputReader["THROUGHPUT_SHFT"] == System.DBNull.Value) ||
                            (lcl_obj_ThroughputReader["WASTAGE"] == System.DBNull.Value))
                        {
                            lcl_obj_DaywiseMachineThroughput._TargetThroughput = 0;
                            lcl_obj_DaywiseMachineThroughput._Throughput = 0;
                            lcl_obj_DaywiseMachineThroughput._Wastage = 0;
                        }
                        else
                        {
                            lcl_obj_DaywiseMachineThroughput._TargetThroughput = System.UInt32.Parse(lcl_obj_ThroughputReader["TARGET_THROUGHPUT"].ToString());
                            lcl_obj_DaywiseMachineThroughput._Throughput = System.Int32.Parse(lcl_obj_ThroughputReader["THROUGHPUT_SHFT"].ToString());
                            lcl_obj_DaywiseMachineThroughput._Wastage = System.UInt32.Parse(lcl_obj_ThroughputReader["WASTAGE"].ToString());
                        }
                        lcl_obj_DaywiseMachineThroughput._AdditionalData.Add("Date", lcl_dt_ThroughputDate.ToString("dd/MM"));
                        lcl_obj_DaywiseMachineThroughput._AdditionalData.Add("MeasurementUnit", lcl_obj_SCMachine._AdditionalData["MeasurementUnit"]);
                        lcl_obj_DayRangeMachineThroughput._DaywiseThroughputList.Add(lcl_obj_DaywiseMachineThroughput);
                        lcl_obj_ThroughputReader.Close();
                        lcl_obj_ThroughputReader.Dispose();
                        lcl_dt_ThroughputDate = lcl_dt_ThroughputDate.AddDays(1.0);
                    }
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_DayRangeMachineThroughput;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// The input Query must be a Join query between SCPM_MACHINE_THROUGHPUT and SHIFT table so that 
        /// the shift name can be extracted
        /// </summary>
        /// <param name="IP_str_SqlQuery">Join query between SCPM_MACHINE_THROUGHPUT and SHIFT</param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput> GetSCMachineThroughputList(System.String IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput> lcl_objList_SCMachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput>();
                //System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE_THROUGHPUT WHERE MACHINE_CODE = {0} AND (THROUGHPUT_DT_TM >= TO_DATE('{1}','dd/MM/yyyy') AND THROUGHPUT_DT_TM <= TO_DATE('{2}','dd/MM/yyyy')) ORDER BY THROUGHPUT_DT_TM ASC", IP_ui64_MachineCode, IP_dt_StartDate.ToString("dd/MM/yyyy"), IP_dt_EndDate.ToString("dd/MM/yyyy"));
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineThroughputReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_MachineThroughputReader.HasRows == false)
                {
                    //throw new System.Exception("Machine Throughput Data Not Found in the SilkERP database for the Machine!!!");
                    //Throughput data not found.return empty list
                    return lcl_objList_SCMachineThroughputList;
                }
                while (lcl_obj_MachineThroughputReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput lcl_obj_SCMachineThroughput = new SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput();
                    lcl_obj_SCMachineThroughput._ThroughputCode = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_THROUGHPUT_CODE"].ToString());
                    lcl_obj_SCMachineThroughput._MachineCode = System.UInt64.Parse(lcl_obj_MachineThroughputReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCMachineThroughput._ShiftCode = System.UInt64.Parse(lcl_obj_MachineThroughputReader["SHIFT_CODE"].ToString());
                    lcl_obj_SCMachineThroughput._TargetThroughput = System.UInt32.Parse(lcl_obj_MachineThroughputReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCMachineThroughput._Throughput = System.Int64.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_SHFT"].ToString());
                    lcl_obj_SCMachineThroughput._ThroughputDateTime = System.DateTime.Parse(lcl_obj_MachineThroughputReader["THROUGHPUT_DT_TM"].ToString());
                    lcl_obj_SCMachineThroughput._EntryEmployeeCode = System.UInt64.Parse(lcl_obj_MachineThroughputReader["ENTRY_EMP_CODE"].ToString());
                    lcl_obj_SCMachineThroughput._Remarks = lcl_obj_MachineThroughputReader["REMARKS"].ToString();
                    lcl_obj_SCMachineThroughput._EntryDateTime = System.DateTime.Parse(lcl_obj_MachineThroughputReader["ENTRY_DT_TM"].ToString());
                    lcl_obj_SCMachineThroughput._Wastage = System.UInt32.Parse(lcl_obj_MachineThroughputReader["WASTAGE"].ToString());
                    lcl_obj_SCMachineThroughput._DailySCPMMachineStatus = (Containers.SCPM.DailySCPMMachineStatus)System.UInt32.Parse(lcl_obj_MachineThroughputReader["DAILY_STATUS"].ToString());
                    lcl_obj_SCMachineThroughput._AdditionalData.Add("ShiftName", lcl_obj_MachineThroughputReader["SHIFT_NAME"].ToString());
                    lcl_objList_SCMachineThroughputList.Add(lcl_obj_SCMachineThroughput);
                }
                lcl_obj_MachineThroughputReader.Close();
                

                return lcl_objList_SCMachineThroughputList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput GetMachinewiseThroughputByDateRange(System.UInt64 IP_ui64_MachineCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Initialize();
                    lcl_obj_DBManager.Open();
                    SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_SCDataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                    SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = lcl_obj_SCDataProvider.GetSCMachine(IP_ui64_MachineCode,lcl_obj_DBManager);
                    SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput lcl_obj_MachinewiseThroughput = new SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput(lcl_obj_SCMachine);
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT SMT.*,SHFT.* FROM SCPM_MACHINE_THROUGHPUT SMT JOIN SHIFT SHFT ON SMT.SHIFT_CODE = SHFT.SHIFT_CODE WHERE SMT.MACHINE_CODE = {0} AND (SMT.THROUGHPUT_DT_TM >= TO_DATE('{1}','dd/MM/yyyy') AND SMT.THROUGHPUT_DT_TM <= TO_DATE('{2}','dd/MM/yyyy'))",IP_ui64_MachineCode,IP_dt_StartDate.ToString("dd/MM/yyyy"),IP_dt_EndDate.ToString("dd/MM/yyyy"));
                    lcl_obj_MachinewiseThroughput._MachineThroughputList = lcl_obj_SCDataProvider.GetSCMachineThroughputList(lcl_str_SqlQuery,lcl_obj_DBManager);
                    lcl_obj_DBManager.Close();
                    return lcl_obj_MachinewiseThroughput;
                }
              
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DataStructures
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput> GetAllSectionThroughputByDate(System.DateTime IP_dt_Date)
        {
            try
            {
                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_DataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput> lcl_obj_SectionwiseThroughputList = new System.Collections.Generic.List<Containers.SCPM.DataStructure.SC.SectionwiseThroughput>();
                //get list of all sections
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE STATUS = {0}",(System.Int32)SilkERP360.CCL.Enums.Status.Active);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCSection> lcl_obj_SectionList = lcl_obj_DataProvider.GetSCSectionList(lcl_str_SqlQuery, lcl_obj_DBManager);
                foreach (SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection in lcl_obj_SectionList)
                {
                    SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput lcl_obj_SectionwiseThroughput = lcl_obj_DataProvider.GetSectionThroughputByDate(lcl_obj_SCSection._SectionCode, IP_dt_Date, lcl_obj_DBManager);
                    lcl_obj_SectionwiseThroughputList.Add(lcl_obj_SectionwiseThroughput);
                }
                lcl_obj_DBManager.Close();
                return lcl_obj_SectionwiseThroughputList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput GetSectionThroughputByDate(System.UInt64 IP_ui64_SectionCode, System.DateTime IP_dt_Date, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput lcl_obj_SectionwiseThroughput = null;
                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_DataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                SilkERPDataService.Containers.SCPM.SC.SCSection lcl_obj_SCSection = lcl_obj_DataProvider.GetSCSection(IP_ui64_SectionCode, IP_obj_DBManager);
                lcl_obj_SectionwiseThroughput = new Containers.SCPM.DataStructure.SC.SectionwiseThroughput(lcl_obj_SCSection);
                //get all processes for this section
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0}",IP_ui64_SectionCode);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCProcess> lcl_obj_ProcessList = lcl_obj_DataProvider.GetSCProcessList(lcl_str_SqlQuery, IP_obj_DBManager);
                foreach (SilkERPDataService.Containers.SCPM.SC.SCProcess lcl_obj_SCProcess in lcl_obj_ProcessList)
                {
                    Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput lcl_obj_ProcesswiseThroughput = new Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput(lcl_obj_SCProcess);
                    //get all machines for this SCProcess
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0}", lcl_obj_SCProcess._ProcessCode);
                    System.Collections.Generic.List<Containers.SCPM.SC.SCMachine> lcl_obj_SCMachineList = lcl_obj_DataProvider.GetSCMachineList(lcl_str_SqlQuery, IP_obj_DBManager);
                     //lcl_obj_MachinewiseThroughput = null;
                    foreach (SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine in lcl_obj_SCMachineList)
                    {
                        //get throughput for each SCMachine
                        Containers.SCPM.DataStructure.SC.MachinewiseThroughput lcl_obj_MachinewiseThroughput = new Containers.SCPM.DataStructure.SC.MachinewiseThroughput(lcl_obj_SCMachine);
                        lcl_str_SqlQuery = System.String.Format("SELECT SMT.*,SHFT.* FROM SCPM_MACHINE_THROUGHPUT SMT JOIN SHIFT SHFT ON SMT.SHIFT_CODE = SHFT.SHIFT_CODE WHERE SMT.MACHINE_CODE = {0} AND SMT.THROUGHPUT_DT_TM = '{1}'", lcl_obj_SCMachine._MachineCode, IP_dt_Date.ToString("dd/MMMM/yyyy"));
                        System.Collections.Generic.List<Containers.SCPM.SC.SCMachineThroughput> lcl_obj_ThroughputList = lcl_obj_DataProvider.GetSCMachineThroughputList(lcl_str_SqlQuery, IP_obj_DBManager);
                        lcl_obj_MachinewiseThroughput._MachineThroughputList = lcl_obj_ThroughputList;
                        lcl_obj_ProcesswiseThroughput._MachinewiseThroughputList.Add(lcl_obj_MachinewiseThroughput);
                    }
                    lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList.Add(lcl_obj_ProcesswiseThroughput);
                }
                return lcl_obj_SectionwiseThroughput;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
