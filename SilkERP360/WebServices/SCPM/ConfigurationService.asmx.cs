using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for ConfigurationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ConfigurationService : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetProcessesBySection(System.String IP_str_SectionCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_PROCESS WHERE SECTION_CODE = {0}", IP_str_SectionCode);
                System.Data.OracleClient.OracleDataReader lcl_obj_ProcessReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_ProcessReader.HasRows == false)
                {
                    throw new System.Exception("No Production Process was found for the selected Section!!!");
                }
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess> lcl_objLst_Process = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMProcess>();
                while (lcl_obj_ProcessReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCPMProcess lcl_obj_SCPMProcess = new SilkERPDataService.Containers.SCPM.SCPMProcess();
                    lcl_obj_SCPMProcess._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMProcess._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_ProcessReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMProcess._Name_STR = lcl_obj_ProcessReader["NAME"].ToString();
                    lcl_obj_SCPMProcess._Status_ENM = (SilkERP360.CCL.Enums.Status)(System.Int32.Parse(lcl_obj_ProcessReader["STATUS"].ToString()));
                    lcl_objLst_Process.Add(lcl_obj_SCPMProcess);
                }
                //lcl_obj_ProcessReader.Close();
                lcl_obj_SqlFacade.CloseReader();
                lcl_obj_SqlFacade.Close();

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Data Retrieved Successfully!!!", false, lcl_objLst_Process);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMachinesSTRByProcess(System.String IP_str_ProcessCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT MACH.*,SEC.NAME AS SEC_NAME,PRC.NAME AS PRC_NAME,COMP.NAME AS COMP_NAME " +
                                                                      "FROM SCPM_MACHINE MACH JOIN SCPM_SECTION SEC ON MACH.SECTION_CODE = SEC.SECTION_CODE " +
                                                                      "JOIN SCPM_PROCESS PRC ON MACH.PROCESS_CODE = PRC.PROCESS_CODE " +
                                                                      "JOIN COMPANY COMP ON MACH.COMPANY_CODE = COMP.COMPANY_CODE " + 
                                                                      "WHERE MACH.PROCESS_CODE = {0} AND MACH.OPERATIONAL_STATUS = 1", IP_str_ProcessCode);
                System.Data.OracleClient.OracleDataReader lcl_obj_MachineSTRReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_MachineSTRReader.HasRows == false)
                {
                    throw new System.Exception("No Machine was found for the selected Process!!!");
                }
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachineSTR> lcl_objLst_SCPMMachineSTR = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMMachineSTR>();
                while (lcl_obj_MachineSTRReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCPMMachineSTR lcl_obj_SCPMMachineSTR = new SilkERPDataService.Containers.SCPM.SCPMMachineSTR();
                    lcl_obj_SCPMMachineSTR._MachineCode_UI64 = System.UInt64.Parse(lcl_obj_MachineSTRReader["MACHINE_CODE"].ToString());
                    lcl_obj_SCPMMachineSTR._Name_STR = lcl_obj_MachineSTRReader["NAME"].ToString();
                    lcl_obj_SCPMMachineSTR._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_MachineSTRReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMMachineSTR._CompanyName_STR = lcl_obj_MachineSTRReader["COMP_NAME"].ToString();
                    lcl_obj_SCPMMachineSTR._ProcessCode_UI64 = System.UInt64.Parse(lcl_obj_MachineSTRReader["PROCESS_CODE"].ToString());
                    lcl_obj_SCPMMachineSTR._ProcessName_STR = lcl_obj_MachineSTRReader["PRC_NAME"].ToString();
                    lcl_obj_SCPMMachineSTR._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_MachineSTRReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMMachineSTR._SectionName_STR = lcl_obj_MachineSTRReader["SEC_NAME"].ToString();
                    lcl_obj_SCPMMachineSTR._MeasurementUnit_ENM = (SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.Int32.Parse(lcl_obj_MachineSTRReader["MEASUREMENT_UNIT"].ToString()));
                    lcl_obj_SCPMMachineSTR._MeasurementUnit_STR = ((SilkERPDataService.Containers.SCPM.MachineMeasurementUnit)(System.Int32.Parse(lcl_obj_MachineSTRReader["MEASUREMENT_UNIT"].ToString()))).ToString();
                    lcl_obj_SCPMMachineSTR._CommittedThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineSTRReader["COMMITTED_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachineSTR._OptimumThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineSTRReader["OPTIMUM_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachineSTR._TargetThroughput_UI32 = System.UInt32.Parse(lcl_obj_MachineSTRReader["TARGET_THROUGHPUT"].ToString());
                    lcl_obj_SCPMMachineSTR._OperationalStatus_ENM = (SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.Int32.Parse(lcl_obj_MachineSTRReader["OPERATIONAL_STATUS"].ToString()));
                    lcl_obj_SCPMMachineSTR._OperationalStatus_STR = ((SilkERPDataService.Containers.SCPM.MachineOperationalStatus)(System.Int32.Parse(lcl_obj_MachineSTRReader["OPERATIONAL_STATUS"].ToString()))).ToString();

                    lcl_objLst_SCPMMachineSTR.Add(lcl_obj_SCPMMachineSTR);
                }
                //lcl_obj_ProcessReader.Close();
                lcl_obj_SqlFacade.CloseReader();
                lcl_obj_SqlFacade.Close();

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Data Retrieved Successfully!!!", false, lcl_objLst_SCPMMachineSTR);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMachinesSTRByMachineCode(System.String IP_str_MachineCode)
        {
            try
            {
                SilkERPDataService.ReadService.SCPM.SCPMMachineService lcl_obj_MachineService = new SilkERPDataService.ReadService.SCPM.SCPMMachineService();
                SilkERPDataService.Containers.SCPM.SCPMMachineSTR lcl_obj_MachineSTR = lcl_obj_MachineService.GetMachineSTRByMachineCode(System.UInt64.Parse(IP_str_MachineCode));
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Data Retrieved Successfully!!!", false, lcl_obj_MachineSTR);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
