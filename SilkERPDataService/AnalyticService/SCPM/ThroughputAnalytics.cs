using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.AnalyticService.SCPM
{
    public class ThroughputAnalytics
    {

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt> GetAvgSectionExtAll(System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                SilkERPDataService.ReadService.SCPM.SCPMSectionService lcl_obj_SectionService = new ReadService.SCPM.SCPMSectionService();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE STATUS = {0}", (System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                //GET LIST OF ACTIVE SECTIONS
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objLst_SCPMSection = lcl_obj_SectionService.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt> lcl_objLst_AvgSectionExt = new System.Collections.Generic.List<Containers.SCPM.DataStructure.SCPMAvgSectionExt>();
                foreach (SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection in lcl_objLst_SCPMSection)
                {
                    System.UInt64 lcl_ui64_SectionCode = lcl_obj_SCPMSection._SectionCode_UI64;
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt lcl_obj_SCPMAvgSectionExt = this.GetAvgSectionThroughputMachinewise(lcl_ui64_SectionCode, IP_dt_StartDate, IP_dt_EndDate, lcl_obj_DBManager);
                    lcl_objLst_AvgSectionExt.Add(lcl_obj_SCPMAvgSectionExt);
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                return lcl_objLst_AvgSectionExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt> GetSectionExtAll(System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                SilkERPDataService.ReadService.SCPM.SCPMSectionService lcl_obj_SectionService = new ReadService.SCPM.SCPMSectionService();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE STATUS = {0}", (System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                //GET LIST OF ACTIVE SECTIONS
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objLst_SCPMSection = lcl_obj_SectionService.GetList(lcl_str_SqlQuery,lcl_obj_DBManager);
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt> lcl_objLst_SectionExt = new System.Collections.Generic.List<Containers.SCPM.DataStructure.SCPMSectionExt>();
                foreach (SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection in lcl_objLst_SCPMSection)
                {
                    System.UInt64 lcl_ui64_SectionCode = lcl_obj_SCPMSection._SectionCode_UI64;
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt lcl_obj_SCPMSectionExt = this.GetSectionThroughputMachinewise(lcl_ui64_SectionCode, IP_dt_StartDate, IP_dt_EndDate, lcl_obj_DBManager);
                    lcl_objLst_SectionExt.Add(lcl_obj_SCPMSectionExt);
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                return lcl_objLst_SectionExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt GetAvgSectionThroughputMachinewise(System.UInt64 IP_ui64_SectionCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.ReadService.SCPM.SCPMSectionService lcl_obj_SectionService = new ReadService.SCPM.SCPMSectionService();
                SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = lcl_obj_SectionService.GetSectionBySectionCode(IP_ui64_SectionCode, IP_obj_DBManager);
                SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt lcl_obj_SCPMSectionExt = new Containers.SCPM.DataStructure.SCPMAvgSectionExt(lcl_obj_SCPMSection);
                System.String lcl_str_SqlQuery = System.String.Empty;
                //get List of Process that belongs to this Section
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0} AND STATUS={1}", IP_ui64_SectionCode.ToString(), (System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                SilkERPDataService.ReadService.SCPM.SCPMProcessService lcl_obj_SCPMProcessService = new ReadService.SCPM.SCPMProcessService();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objLst_SCPMProcesses = lcl_obj_SCPMProcessService.GetList(lcl_str_SqlQuery, IP_obj_DBManager);

                SilkERPDataService.ReadService.SCPM.SCPMMachineService lcl_obj_SCPMMachinesService = new ReadService.SCPM.SCPMMachineService();
                foreach (SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess in lcl_objLst_SCPMProcesses)
                {
                    //process each SCPMProcess
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgProcessExt lcl_obj_SCPMProcessExt = new Containers.SCPM.DataStructure.SCPMAvgProcessExt(lcl_obj_SCPMProcess);
                    System.UInt64 lcl_ui64_ProcessCode = lcl_obj_SCPMProcess._ProcessCode_UI64;
                    //get SCPMMachine list for each SCPMProcess 
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", lcl_ui64_ProcessCode, (System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                    System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objLst_SCPMMachine = lcl_obj_SCPMMachinesService.GetList(lcl_str_SqlQuery, IP_obj_DBManager);
                    //get MachineThroughput list for each Machine
                    foreach (SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine in lcl_objLst_SCPMMachine)
                    {
                        //process each Machine
                        //create SCPMMachineExt for the SCPMProcessExt
                        SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgMachineThroughput lcl_obj_SCPMAvgMachineThroughput = new Containers.SCPM.DataStructure.SCPMAvgMachineThroughput(lcl_obj_SCPMMachine);

                        //get throughput List for the Machine
                        System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objLst_MachineThroughput = lcl_obj_SCPMMachinesService.GetMachineThroughputList(lcl_obj_SCPMMachine._MachineCode_UI64, IP_dt_StartDate, IP_dt_EndDate, IP_obj_DBManager);
                        
                        System.Int32 lcl_i32_MachineThroughputCount = lcl_objLst_MachineThroughput.Count;
                        System.Int64 lcl_i64_TotalThroughput = 0;
                        System.Int64 lcl_i64_TotalTarget = 0;
                        foreach (SilkERPDataService.Containers.SCPM.SCMachineThroughput lcl_obj_MachineThroughput in lcl_objLst_MachineThroughput)
                        {
                            lcl_i64_TotalThroughput += lcl_obj_MachineThroughput._Throughput_I64;
                            lcl_i64_TotalTarget += lcl_obj_MachineThroughput._TargetThroughput_UI32;
                        }
                        if (lcl_i32_MachineThroughputCount == 0)
                        {
                            lcl_obj_SCPMAvgMachineThroughput._AvgTargetThroughput = 0;
                            lcl_obj_SCPMAvgMachineThroughput._AvgThroughput = 0;
                        }
                        else
                        {
                            lcl_obj_SCPMAvgMachineThroughput._AvgTargetThroughput = (System.Int64)(lcl_i64_TotalTarget / lcl_i32_MachineThroughputCount);
                            lcl_obj_SCPMAvgMachineThroughput._AvgThroughput = (System.Int64)(lcl_i64_TotalThroughput / lcl_i32_MachineThroughputCount);
                        }

                        lcl_obj_SCPMAvgMachineThroughput._SCMachineThroughputDetailList = lcl_objLst_MachineThroughput;
                        lcl_obj_SCPMProcessExt._SCPMAvgMachineThroughputList.Add(lcl_obj_SCPMAvgMachineThroughput);
                    }
                    lcl_obj_SCPMSectionExt._SCPMProcesses.Add(lcl_obj_SCPMProcessExt);
                }
                return lcl_obj_SCPMSectionExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt GetSectionThroughputMachinewise(System.UInt64 IP_ui64_SectionCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt lcl_obj_SCPMSectionExt = new Containers.SCPM.DataStructure.SCPMSectionExt();
                System.String lcl_str_SqlQuery = System.String.Empty;
                //get List of Process that belongs to this Section
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0} AND STATUS={1}",IP_ui64_SectionCode.ToString(),(System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                SilkERPDataService.ReadService.SCPM.SCPMProcessService lcl_obj_SCPMProcessService = new ReadService.SCPM.SCPMProcessService();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objLst_SCPMProcesses = lcl_obj_SCPMProcessService.GetList(lcl_str_SqlQuery, IP_obj_DBManager);

                SilkERPDataService.ReadService.SCPM.SCPMMachineService lcl_obj_SCPMMachinesService = new ReadService.SCPM.SCPMMachineService();
                foreach (SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess in lcl_objLst_SCPMProcesses)
                {
                    //process each SCPMProcess
                    SilkERPDataService.Containers.SCPM.DataStructure.SCPMProcessExt lcl_obj_SCPMProcessExt = new Containers.SCPM.DataStructure.SCPMProcessExt(lcl_obj_SCPMProcess);
                    System.UInt64 lcl_ui64_ProcessCode = lcl_obj_SCPMProcess._ProcessCode_UI64;
                    //get SCPMMachine list for each SCPMProcess 
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MACHINE WHERE PROCESS_CODE = {0} AND STATUS = {1}", lcl_ui64_ProcessCode, (System.Int32)(SilkERP360.CCL.Enums.Status.Active));
                    System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachine> lcl_objLst_SCPMMachine = lcl_obj_SCPMMachinesService.GetList(lcl_str_SqlQuery, IP_obj_DBManager);
                    //get MachineThroughput list for each Machine
                    foreach (SilkERPDataService.Containers.SCPM.SCPMMachine lcl_obj_SCPMMachine in lcl_objLst_SCPMMachine)
                    {
                        //process each Machine
                        //create SCPMMachineExt for the SCPMProcessExt
                        SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt lcl_obj_SCPMMachineExt = new Containers.SCPM.DataStructure.SCPMMachineExt(lcl_obj_SCPMMachine);

                        //get throughput List for the Machine
                        System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> lcl_objLst_MachineThroughput = lcl_obj_SCPMMachinesService.GetMachineThroughputList(lcl_obj_SCPMMachine._MachineCode_UI64,IP_dt_StartDate,IP_dt_EndDate, IP_obj_DBManager);
                        lcl_obj_SCPMMachineExt._SCPMMachineThroughput = lcl_objLst_MachineThroughput;

                        lcl_obj_SCPMProcessExt._SCPMProductionMachines.Add(lcl_obj_SCPMMachineExt);

                        
                    }
                    lcl_obj_SCPMSectionExt._SCPMProcesses.Add(lcl_obj_SCPMProcessExt);
                }
                return lcl_obj_SCPMSectionExt;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
