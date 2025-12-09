using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.ReadService.SCPM
{
    public class SCPMProcessService
    {

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> GetList(System.String IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SCPMProcess>();
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
                        SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                        lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                        lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
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

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> GetList(System.String IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SCPMProcess>();
            try
            {
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_ProcessReader.HasRows == false)
                {
                    throw new System.Exception("Process Data Not Found in the SilkERP database!!!");
                }
                while (lcl_obj_ProcessReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                    lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
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

        public SilkERPDataService.Containers.SCPM.SCPMProcess GetProcessByProcessCode(System.UInt64 IP_ui64_ProcessCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SCPMProcess();
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

                    SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                    lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;

                    lcl_obj_ProcessReader.Close();
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

        public SilkERPDataService.Containers.SCPM.SCPMProcess GetProcessByProcessCode(System.UInt64 IP_ui64_ProcessCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SCPMProcess();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE PROCESS_CODE = {0} AND STATUS = {1}", IP_ui64_ProcessCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_ProcessReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data for Process Code " + IP_ui64_ProcessCode.ToString() + " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_ProcessReader.Read();

                    SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                    lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;

                    lcl_obj_ProcessReader.Close();
                    lcl_obj_DBManager.CloseReader();
                }
                return lcl_obj_Section;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> GetProcessListBySection(System.UInt64 IP_ui64_SectionCode)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SCPMProcess>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_ProcessReader.HasRows == false)
                    {
                        throw new System.Exception("Process Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_ProcessReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                        lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                        lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_ProcessList.Add(lcl_obj_SCPMProcess);
                    }
                    lcl_obj_ProcessReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_ProcessList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> GetProcessListBySection(System.UInt64 IP_ui64_SectionCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objList_ProcessList = new System.Collections.Generic.List<Containers.SCPM.SCPMProcess>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProcessReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_ProcessReader.HasRows == false)
                    {
                        throw new System.Exception("Process Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_ProcessReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new Containers.SCPM.SCPMProcess();
                        lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                        lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMProcess._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_ProcessList.Add(lcl_obj_SCPMProcess);
                    }
                    lcl_obj_ProcessReader.Close();
                    IP_obj_DBManager.CloseReader();
                }
                return lcl_objList_ProcessList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

            
        }
    }
}
