using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPSync
{
    public class SilkcardProductionReporter
    {

        public const string SCHEDULED_EXECUTION_TIME = "11:00:00";
        public static DateTime LastExecutionDateTime { get; set; }
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        //private ServiceLog m_obj_ServiceLog;

        /// <summary>
        /// Days production to report
        /// </summary>
        private System.DateTime m_dt_ProductionDate;
        private System.UInt64 m_ui64_CompanyCode;
        public SilkcardProductionReporter(System.DateTime IP_dt_ProductionDate, System.UInt64 IP_ui64_CompanyCode)
        {
            this.m_dt_ProductionDate = IP_dt_ProductionDate;
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
        }

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData("Silkcard Production Reported Error : " + Ex.Message);
            }
        }

        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {

            try
            {
                this.m_obj_DBManager = IP_obj_DBManager;
            }
            catch (System.Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData("Silkcard Production Reported Error : " + Ex.Message);
            }
        }

        /// <summary>
        /// Returns MachineThroughput Report in HTML for all Sections/Processes/Machines
        /// EVENT FLOW:
        /// 1. Get List Of All SCPM_SECTION
        /// 2. Get List Of SCPM_Process for each Section
        /// 3. Get List of all SCPM_Machines for each Processes
        /// 5. Get Throughput for all scpm_machines
        /// </summary>
        /// <returns></returns>
        public System.String GetSilkcardProductionReport()
        {
            try
            {
                if (this.m_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Open();
                }

                //Get List of All Sections
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE COMPANY_CODE = {0} ORDER BY SECTION_CODE ASC", this.m_ui64_CompanyCode);

                SilkERP360.BML.SCPM.SectionManger lcl_obj_SectionManager = new SilkERP360.BML.SCPM.SectionManger();
                lcl_obj_SectionManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_objLst_SectionList = lcl_obj_SectionManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_SCPMDataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();

                System.String lcl_str_ReportHTML = System.String.Empty;

                /*****************************************************************************************************************/
                lcl_str_ReportHTML = @"<style type='text/css'>
                                        .report_head
                                        {
                                            width:100%;
                                            font-size:12px;
                                        }
        
                                        .report_head tr
                                        {
            
                                        }
        
                                        .report_head tr td
                                        {
                                            border:1px solid #cccccc  ;
                                        }
        
                                        .report_header_label
                                        {
                                            text-align:left;
                                            /*border:1px solid #F8F8F8  ;*/
                                            font-weight:bold;
                                            font-family:Verdana;
                                            color: #ffffff;
                                            background-color:#66cc33;
                                            border:1px solid #cccccc;
                                            font-size:14px;
                                        }

                                        .report_header_text
                                        {
                                            text-align:left;
                                            border:1px solid #aaaaaa  ;
                                            background-color:#ffffff;
                                            color: #000;
                                            font-weight:normal;
                                            border:1px solid #aaaaaa;
                                            font-family:Verdana;
                                            font-size:12px;

                                        }

        
                                        .report_summery_label
                                        {
                                            text-align:right;
                                            color: #ffffff;
                                            background-color:#66cc33;
                                            font-weight:bold;
                                            border:1px solid #cccccc;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
        
                                        .report_summery_text
                                        {
                                            text-align:left;
                                            border:1px solid #aaaaaa  ;
                                            background-color:#ffffff;
                                            color: #000;
                                            font-weight:normal;
                                            border:1px solid #aaaaaa;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
        
                                        .report_grid_text
                                        {
                                            text-align:center;
                                             border:1px solid #cccccc  ;
                                            background-color:#FFFFFF;
                                            color: #000;
                                            font-weight:normal;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
                                        .report_grid_header
                                        {
                                            line-height:20px;
                                            text-align:center;
                                             border:1px solid #F8F8F8  ;
                                            background-color:#3399FF;
                                            color: #ffffff;
                                            font-weight:bold;
                                            font-size:12px;
                                            border:1px solid black;
                                            font-family:Verdana;
                                        }
                                        .report_body
                                        {
                                            width:100%;
                                            font-size:10px;
                                             font-family:Verdana;
            
                                        }
        
                                    </style>";

                lcl_str_ReportHTML += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Silkcard Production Management System (S.C.P.M)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Report Title : 
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                                <b>DAILY PRODUCTION REPORT (MACHINEWISE)</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               Report Date
                                                                            </td>
                                                                            <td class='report_header_text' style='text-align:left;'>
                                                                            {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Company :
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                            Silkways Card & Printing Ltd
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Production Date :
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                            {1}
                                                                            </td>
                                                                        </tr>
                                                                    </table><hr/>", System.DateTime.Today.ToLongDateString(),
                                                                            this.m_dt_ProductionDate.ToLongDateString());
                /**********************************************************************************************************************/


                foreach (SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj_Section in lcl_objLst_SectionList)
                {
                    SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput lcl_obj_SectionwiseThroughput = lcl_obj_SCPMDataProvider.GetSectionThroughputByDate(lcl_obj_Section.SectionCode, this.m_dt_ProductionDate, this.m_obj_DBManager);

                    foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput lcl_obj_ProcesswiseMachineThroughput in lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList)
                    {
                        //Process Details Available
                        lcl_str_ReportHTML += System.String.Format(@"<table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:20%'>
                                                                                Section :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%;'>
                                                                                <b>{0}</b>
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:20%'>
                                                                                Process :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%;'>
                                                                                <b>{1}</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>", lcl_obj_Section.Name, lcl_obj_ProcesswiseMachineThroughput._Name);
                        lcl_str_ReportHTML += @"<table id='GridTableStyle' class='report_body'>
                                                    <tr style=''>    
                                                        <td class='report_grid_header' style='width:5%'>
                                                            SL
                                                        </td>
                                                        <td class='report_grid_header' style='width:25%'>
                                                            Machine
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Cards/Sheets
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Wastage
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Wastage %
                                                        </td>
                                                        <td class='report_grid_header' style='width:40%'>
                                                            Remarks
                                                        </td>
                                                    </tr>";
                        //lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList
                        System.UInt32 lcl_ui32_Serial = 1;
                        foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput lcl_obj_MachinewiseThroughput in lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList)
                        {

                            System.Int64 lcl_i64_TotalThroughput = 0;
                            System.Int64 lcl_i64_TotalWastage = 0;
                            foreach (SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput lcl_obj_SCMachinewiseThroughput in lcl_obj_MachinewiseThroughput._MachineThroughputList)
                            {
                                if (lcl_obj_SCMachinewiseThroughput._Throughput < 0)
                                {
                                    continue;
                                }
                                lcl_i64_TotalThroughput += lcl_obj_SCMachinewiseThroughput._Throughput;
                                lcl_i64_TotalWastage += lcl_obj_SCMachinewiseThroughput._Wastage;
                                int a = 0;
                            }

                            System.Decimal lcl_dbl_WastagePercentage = 0;
                            if (lcl_i64_TotalThroughput > 0)
                            {
                                lcl_dbl_WastagePercentage = (lcl_i64_TotalWastage * 100) / lcl_i64_TotalThroughput;
                                lcl_dbl_WastagePercentage = System.Math.Round(lcl_dbl_WastagePercentage, 2);
                            }

                            System.String lcl_str_Remarks = System.String.Empty;
                            if ((lcl_i64_TotalThroughput > 0) && (lcl_dbl_WastagePercentage == 0))
                            {
                                lcl_str_Remarks = "<b><span style='color:green;'>Wstage % Negligible!</span></b>";
                            }
                            if ((lcl_i64_TotalThroughput > 0) && (lcl_dbl_WastagePercentage >= 1))
                            {
                                lcl_str_Remarks = "<b><span style='color:red;'>Wstage % Over Shot!</span></b>";
                            }
                            lcl_str_ReportHTML += System.String.Format(@"<tr style=''>    
                                                                            <td class='report_grid_text' style=''>
                                                                                {0}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {1}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {2}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {3}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {4}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {5}
                                                                            </td>
                                                                        </tr>", lcl_ui32_Serial.ToString(),
                                                                            lcl_obj_MachinewiseThroughput._Name,
                                                                            lcl_i64_TotalThroughput,
                                                                            lcl_i64_TotalWastage,
                                                                            lcl_dbl_WastagePercentage,
                                                                            lcl_str_Remarks);
                            lcl_ui32_Serial++;
                        }
                        lcl_str_ReportHTML += "</table><hr/>";
                    }
                }
                lcl_str_ReportHTML += "</div></div>";
                return lcl_str_ReportHTML;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Close();
                }
            }
        }

        /// <summary>
        /// Returns Empty String if mail is not required to be generated
        /// </summary>
        /// <returns></returns>
        public System.String GetSilkcardProductionReportWastageOnly()
        {
            try
            {
                if (this.m_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Open();
                }

                //Get List of All Sections
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE COMPANY_CODE = {0} ORDER BY SECTION_CODE ASC", this.m_ui64_CompanyCode);

                SilkERP360.BML.SCPM.SectionManger lcl_obj_SectionManager = new SilkERP360.BML.SCPM.SectionManger();
                lcl_obj_SectionManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_objLst_SectionList = lcl_obj_SectionManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_SCPMDataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();

                System.String lcl_str_ReportHTML = System.String.Empty;

                /*****************************************************************************************************************/

                /*********************************************************************************************************************************************************/
                //Check if wastage of any machine has gone beyond the tollerence limit. If it Has, proceed and generate mail else no need to proceed and mail
                System.Boolean lcl_b_WastagePercentageOvershoot = false;
                System.Int64 lcl_tmp_i64_TotalThroughput = 0;
                System.Int64 lcl_tmp_i64_TotalWastage = 0;
                foreach (SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj_Section in lcl_objLst_SectionList)
                {
                    SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput lcl_obj_SectionwiseThroughput = lcl_obj_SCPMDataProvider.GetSectionThroughputByDate(lcl_obj_Section.SectionCode, this.m_dt_ProductionDate, this.m_obj_DBManager);

                    foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput lcl_obj_ProcesswiseMachineThroughput in lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList)
                    {
                        foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput lcl_obj_MachinewiseThroughput in lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList)
                        {
                            foreach (SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput lcl_obj_SCMachinewiseThroughput in lcl_obj_MachinewiseThroughput._MachineThroughputList)
                            {
                                if (lcl_obj_SCMachinewiseThroughput._Throughput < 0)
                                {
                                    continue;
                                }
                                lcl_tmp_i64_TotalThroughput += lcl_obj_SCMachinewiseThroughput._Throughput;
                                lcl_tmp_i64_TotalWastage += lcl_obj_SCMachinewiseThroughput._Wastage;
                                int a = 0;
                            }

                            System.Decimal lcl_dbl_WastagePercentage = 0;
                            if (lcl_tmp_i64_TotalThroughput > 0)
                            {
                                lcl_dbl_WastagePercentage = (lcl_tmp_i64_TotalWastage * 100) / lcl_tmp_i64_TotalThroughput;
                                lcl_dbl_WastagePercentage = System.Math.Round(lcl_dbl_WastagePercentage, 2);
                            }
                            if ((lcl_tmp_i64_TotalThroughput > 0) && (lcl_dbl_WastagePercentage >= 1))
                            {
                                lcl_b_WastagePercentageOvershoot = true;
                            }
                        }
                    }
                }
                if (lcl_b_WastagePercentageOvershoot == false)
                {
                    return System.String.Empty;
                }
                /*********************************************************************************************************************************************************/

                lcl_str_ReportHTML = @"<style type='text/css'>
                                        .report_head
                                        {
                                            width:100%;
                                            font-size:12px;
                                        }
        
                                        .report_head tr
                                        {
            
                                        }
        
                                        .report_head tr td
                                        {
                                            border:1px solid #cccccc  ;
                                        }
        
                                        .report_header_label
                                        {
                                            text-align:left;
                                            /*border:1px solid #F8F8F8  ;*/
                                            font-weight:bold;
                                            font-family:Verdana;
                                            color: #ffffff;
                                            background-color:#66cc33;
                                            border:1px solid #cccccc;
                                            font-size:14px;
                                        }

                                        .report_header_text
                                        {
                                            text-align:left;
                                            border:1px solid #aaaaaa  ;
                                            background-color:#ffffff;
                                            color: #000;
                                            font-weight:normal;
                                            border:1px solid #aaaaaa;
                                            font-family:Verdana;
                                            font-size:12px;

                                        }

        
                                        .report_summery_label
                                        {
                                            text-align:right;
                                            color: #ffffff;
                                            background-color:#66cc33;
                                            font-weight:bold;
                                            border:1px solid #cccccc;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
        
                                        .report_summery_text
                                        {
                                            text-align:left;
                                            border:1px solid #aaaaaa  ;
                                            background-color:#ffffff;
                                            color: #000;
                                            font-weight:normal;
                                            border:1px solid #aaaaaa;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
        
                                        .report_grid_text
                                        {
                                            text-align:center;
                                             border:1px solid #cccccc  ;
                                            background-color:#FFFFFF;
                                            color: #000;
                                            font-weight:normal;
                                            font-family:Verdana;
                                            font-size:12px;
                                        }
                                        .report_grid_header
                                        {
                                            line-height:20px;
                                            text-align:center;
                                             border:1px solid #F8F8F8  ;
                                            background-color:#3399FF;
                                            color: #ffffff;
                                            font-weight:bold;
                                            font-size:12px;
                                            border:1px solid black;
                                            font-family:Verdana;
                                        }
                                        .report_body
                                        {
                                            width:100%;
                                            font-size:10px;
                                             font-family:Verdana;
            
                                        }
        
                                    </style>";

                lcl_str_ReportHTML += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Silkcard Production Management System (S.C.P.M)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Report Title : 
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                                <b>DAILY PRODUCTION REPORT (MACHINEWISE)</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               Report Date
                                                                            </td>
                                                                            <td class='report_header_text' style='text-align:left;'>
                                                                            {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Company :
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                            Silkways Card & Printing Ltd
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Production Date :
                                                                            </td>
                                                                            <td  class='report_header_text' style='text-align:left;'>
                                                                            {1}
                                                                            </td>
                                                                        </tr>
                                                                    </table><hr/>", System.DateTime.Today.ToLongDateString(),
                                                                            this.m_dt_ProductionDate.ToLongDateString());
                /**********************************************************************************************************************/


                foreach (SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj_Section in lcl_objLst_SectionList)
                {
                    SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput lcl_obj_SectionwiseThroughput = lcl_obj_SCPMDataProvider.GetSectionThroughputByDate(lcl_obj_Section.SectionCode, this.m_dt_ProductionDate, this.m_obj_DBManager);

                    foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput lcl_obj_ProcesswiseMachineThroughput in lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList)
                    {
                        //Process Details Available
                        lcl_str_ReportHTML += System.String.Format(@"<table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:20%'>
                                                                                Section :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%;'>
                                                                                <b>{0}</b>
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:20%'>
                                                                                Process :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%;'>
                                                                                <b>{1}</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>", lcl_obj_Section.Name, lcl_obj_ProcesswiseMachineThroughput._Name);
                        lcl_str_ReportHTML += @"<table id='GridTableStyle' class='report_body'>
                                                    <tr style=''>    
                                                        <td class='report_grid_header' style='width:5%'>
                                                            SL
                                                        </td>
                                                        <td class='report_grid_header' style='width:25%'>
                                                            Machine
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Cards/Sheets
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Wastage
                                                        </td>
                                                        <td class='report_grid_header' style='width:10%'>
                                                            Wastage %
                                                        </td>
                                                        <td class='report_grid_header' style='width:40%'>
                                                            Remarks
                                                        </td>
                                                    </tr>";
                        //lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList
                        System.UInt32 lcl_ui32_Serial = 1;
                        foreach (SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput lcl_obj_MachinewiseThroughput in lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList)
                        {

                            System.Int64 lcl_i64_TotalThroughput = 0;
                            System.Int64 lcl_i64_TotalWastage = 0;
                            foreach (SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput lcl_obj_SCMachinewiseThroughput in lcl_obj_MachinewiseThroughput._MachineThroughputList)
                            {
                                if (lcl_obj_SCMachinewiseThroughput._Throughput < 0)
                                {
                                    continue;
                                }
                                lcl_i64_TotalThroughput += lcl_obj_SCMachinewiseThroughput._Throughput;
                                lcl_i64_TotalWastage += lcl_obj_SCMachinewiseThroughput._Wastage;
                                int a = 0;
                            }

                            System.Decimal lcl_dbl_WastagePercentage = 0;
                            if (lcl_i64_TotalThroughput > 0)
                            {
                                lcl_dbl_WastagePercentage = (lcl_i64_TotalWastage * 100) / lcl_i64_TotalThroughput;
                                lcl_dbl_WastagePercentage = System.Math.Round(lcl_dbl_WastagePercentage, 2);
                            }

                            System.String lcl_str_Remarks = System.String.Empty;
                            if ((lcl_i64_TotalThroughput > 0) && (lcl_dbl_WastagePercentage == 0))
                            {
                                lcl_str_Remarks = "<b><span style='color:green;'>Wstage % Negligible!</span></b>";
                            }
                            if ((lcl_i64_TotalThroughput > 0) && (lcl_dbl_WastagePercentage >= 1))
                            {
                                lcl_str_Remarks = "<b><span style='color:red;'>Wstage % Over Shot!</span></b>";
                            }
                            lcl_str_ReportHTML += System.String.Format(@"<tr style=''>    
                                                                            <td class='report_grid_text' style=''>
                                                                                {0}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {1}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {2}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {3}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {4}
                                                                            </td>
                                                                            <td class='report_grid_text' style=''>
                                                                                {5}
                                                                            </td>
                                                                        </tr>", lcl_ui32_Serial.ToString(),
                                                                            lcl_obj_MachinewiseThroughput._Name,
                                                                            lcl_i64_TotalThroughput,
                                                                            lcl_i64_TotalWastage,
                                                                            lcl_dbl_WastagePercentage,
                                                                            lcl_str_Remarks);
                            lcl_ui32_Serial++;
                        }
                        lcl_str_ReportHTML += "</table><hr/>";
                    }
                }
                lcl_str_ReportHTML += "</div></div>";
                return lcl_str_ReportHTML;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Close();
                }
            }
        }

        public void MailSilkcardProductionReport()
        {
            try
            {
                List<string> lcl_objLst_MailListTo = new List<string>();
                List<string> lcl_objLst_MailListCC = new List<string>();
                //Common
                //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                lcl_objLst_MailListTo.Add("taj.sc@silkways.net");
                lcl_objLst_MailListTo.Add("emdad.sc@silkways.net");
                lcl_objLst_MailListTo.Add("bhuiyan.sc@silkways.net");
                //lcl_objLst_MailListTo.Add("hiron.sc@silkways.net");
                lcl_objLst_MailListCC.Add("manik@silkways.net");
                //lcl_objLst_MailListCC.Add("saif.sc@silkways.net");
                //lcl_objLst_MailListCC.Add("sarder@silkways.net");
                lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");

                SilkMailer lcl_obj_SilkMailer = new SilkMailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                System.String lcl_str_ReportHTML = this.GetSilkcardProductionReport();
                lcl_obj_SilkMailer.SendMail("SILKCARD DAILY PRODUCTION REPORT", lcl_str_ReportHTML);
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
