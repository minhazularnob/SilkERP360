using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
namespace SilkERP360.SP.HRIS
{
    public class AttendanceProcessor : System.IDisposable
    {
        /// <summary>
        /// EXECUTION TIME OF THE DAY
        /// </summary>
        //public const System.String SCHEDULED_EXECUTION_TIME = "13:30:00";
        //public const System.String SCHEDULED_EXECUTION_TIME = "13:00:00";
        public const System.String SCHEDULED_EXECUTION_TIME = "16:20:00";
        //public const System.String SCHEDULED_EXECUTION_TIME = "16:54:00";
        //public const System.String SCHEDULED_EXECUTION_TIME = "18:50:00";

        private static System.DateTime m_dt_LastExecutionDateTime = System.DateTime.MinValue;
        public static System.DateTime LastExecutionDateTime
        {
            get { return AttendanceProcessor.m_dt_LastExecutionDateTime; }
            set { AttendanceProcessor.m_dt_LastExecutionDateTime = value; }
        }

        /// <summary>
        /// After processing the attendance, this object will contain the Attendance master
        /// This object will be used to generate HTML mail
        /// </summary>
        private SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster m_obj_AttendanceMaster;
        private System.DateTime m_dt_AttendanceDate;

        //private System.UInt64 m_ui64_CompanyCode;
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        //private ServiceLog m_obj_ServiceLog;
        private const System.Double ATTENDANCE_GRACE_PERIOD = 10.0;//10 Minutes
        private const System.Double LATE_ARRIVAL_GRACE_PERIOD = 180;//10 Minutes

        //private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> m_objLst_EmployeeProfile;

        /// <summary>
        /// Pre-Condition : DBManager is initialised and open
        /// </summary>
        /// <param name="IP_obj_DBManager"></param>
        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            //this.m_obj_ServiceLog = new ServiceLog();
            //this.m_obj_ServiceLog.Init(ServiceLogType.AttendanceProcessor);
            this.m_obj_DBManager = IP_obj_DBManager;
        }

        //        public void Init(System.UInt64 IP_ui64_CompanyCode, System.String IP_str_DatabaseConnectionString)
        //        {
        //            this.m_obj_ServiceLog = new ServiceLog();
        //            this.m_obj_ServiceLog.Init(ServiceLogType.AttendanceProcessor);
        //            try
        //            {
        //                this.m_ui64_CompanyCode = IP_ui64_CompanyCode;

        //                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
        //                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
        //                                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,0 IS_DELETED
        //                                                                                        FROM EMPLOYEE EMP 
        //                                                                                        JOIN EMPLOYEE_PERSONAL EMP_PER
        //                                                                                        ON EMP.EMPLOYEE_CODE = EMP_PER.EMPLOYEE_CODE
        //                                                                                        JOIN COMPANY COMP
        //                                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
        //                                                                                        JOIN DEPARTMENT DEPT
        //                                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
        //                                                                                        JOIN DESIGNATION DESIG
        //                                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
        //                                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
        //                                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
        //                                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DEPT.Rank,DESIG.Rank ASC", this.m_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
        //                this.m_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);
        //                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Employee Profile : " + this.m_objLst_EmployeeProfile.Count.ToString());


        //            }
        //            catch (System.Exception Ex)
        //            {
        //                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Initialization Error : " + Ex.Message);
        //            }
        //        }

        /// <summary>
        /// Pre-Condition: AttendanceMaster has been initialised
        /// </summary>
        public System.String GetHTMLReport(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_obj_Company)
        {
            try
            {
                System.String lcl_str_HTMLReport = "";
                //SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                //lcl_obj_CompanyManager.Initialize();
                ////this.m_obj_DBManager.Open();
                //SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = lcl_obj_CompanyManager.Get(IP_ui64_CompanyCode, this.m_obj_DBManager);

                /***********************************************************************************************************************/
                //AutoBot Remarks
                System.String lcl_str_AutoBotComment = System.String.Empty;
                System.UInt32 lcl_ui32_TotalManHourExpected = this.m_obj_AttendanceMaster.TotalExpectedManhourOff + this.m_obj_AttendanceMaster.TotalExpectedManhourOT;
                System.UInt32 lcl_ui32_TotalManhourServed = this.m_obj_AttendanceMaster.TotalManHourServedOff + this.m_obj_AttendanceMaster.TotalManHourServedOT;
                if (lcl_ui32_TotalManHourExpected > lcl_ui32_TotalManhourServed)
                {
                    //Calculate % of ManHour lost
                    System.UInt32 lcl_ui32_TotalManHourLost = lcl_ui32_TotalManHourExpected - lcl_ui32_TotalManhourServed;
                    System.Double lcl_dcm_ManHourLostPercentage = System.Math.Round((double)((lcl_ui32_TotalManHourLost * 100) / lcl_ui32_TotalManHourExpected), 2);
                    lcl_str_AutoBotComment += "Total Man Hour Lost : " + lcl_dcm_ManHourLostPercentage.ToString() + "%<br/>";


                }
                //Calculate % of Absence
                if (this.m_obj_AttendanceMaster.TotalAbsent > 0)
                {
                    System.Double lcl_dcm_AbsentPercentage = System.Math.Round((double)((this.m_obj_AttendanceMaster.TotalAbsent * 100) / this.m_obj_AttendanceMaster.TotalProcessed), 2);
                    lcl_str_AutoBotComment += "Total Absent : " + lcl_dcm_AbsentPercentage.ToString() + "%<br/>";
                }

                //Calculate % of Late
                if (this.m_obj_AttendanceMaster.TotalLate > 0)
                {
                    System.Double lcl_dcm_LatePercentage = System.Math.Round((double)((this.m_obj_AttendanceMaster.TotalLate * 100) / this.m_obj_AttendanceMaster.TotalProcessed), 2);
                    lcl_str_AutoBotComment += "Total Late : " + lcl_dcm_LatePercentage.ToString() + "%<br/>";
                }

                //Calculate Overtime Percentage Against O.T ManHour Served
                if ((this.m_obj_AttendanceMaster.TotalOvertime > 0) && (this.m_obj_AttendanceMaster.TotalManHourServedOT < this.m_obj_AttendanceMaster.TotalExpectedManhourOT))
                {
                    System.Double lcl_dcm_OTPercentage = System.Math.Round((double)(((this.m_obj_AttendanceMaster.TotalOvertime / 60) * 100) / (this.m_obj_AttendanceMaster.TotalExpectedManhourOT - this.m_obj_AttendanceMaster.TotalManHourServedOT)), 2);
                    lcl_str_AutoBotComment += "Total Overtime : " + lcl_dcm_OTPercentage.ToString() + "% Against Lost Man Hour.";
                }

                /***********************************************************************************************************************/

                lcl_str_HTMLReport = @"<style type='text/css'>
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
        }
        .report_grid_header
        {
            line-height:25px;
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#3399FF;
            color: #ffffff;
            font-weight:bold;
            font-size:14px;
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

                lcl_str_HTMLReport += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Human Resource Information System (H.R.I.S)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Report Title : 
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                Daily Attendance Report
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               Report Date
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Company :
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {1}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Attendance Date :
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {2}
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id='tblReportSummer' class='report_summery' style='width:100%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Total Employee :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:8%;'>
                                                                                {3}
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Total Leave :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:8%;'>
                                                                                {4}
                                                                            </td>
                                                                            <td class='report_summery_label' style='width:25%'>
                                                                                Total Holiday :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:8%;'>
                                                                                {5}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label'>
                                                                                Total Present :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {6}
                                                                            </td>
                                                                            <td class='report_summery_label'>
                                                                                Total Absent :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {7}
                                                                            </td>
                                                                            <td class='report_summery_label'>
                                                                                Total Late :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {8}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label'>
                                                                                Total Overtime :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {9}
                                                                            </td>
                                                                            <td class='report_summery_label'>
                                                                                Man. Hr. Expected :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {10}
                                                                            </td>
                                                                            <td class='report_summery_label'>
                                                                                Man Hr. Served :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {11}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>   
                                                                            <td class='report_summery_label'>
                                                                                Man. Hr. Expected (Non-O.T) :
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {12}
                                                                            </td> 
                                                                            <td class='report_summery_label'>
                                                                                Man Hr. Served (Non-O.T):
                                                                            </td>
                                                                            <td class='report_summery_text'>
                                                                                {13}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_summery_label' style='width:25%;font-weight:bold;'>
                                                                                Autobot Analytics :
                                                                            </td>
                                                                            <td colspan= '5' class='report_summery_text'  style='width:75%;text-align:left;font-weight:bold;'>
                                                                                {14}
                                                                            </td>
                                                                        </tr></table>", System.DateTime.Today.ToLongDateString(),
                                                                             IP_obj_Company.Name,
                                                                             this.m_dt_AttendanceDate.ToLongDateString(),
                                                                             this.m_obj_AttendanceMaster.AttendanceList.Count.ToString(),
                                                                             this.m_obj_AttendanceMaster.TotalLeave,
                                                                             this.m_obj_AttendanceMaster.TotalHoliday,
                                                                             this.m_obj_AttendanceMaster.TotalPresent,
                                                                             this.m_obj_AttendanceMaster.TotalAbsent,
                                                                             this.m_obj_AttendanceMaster.TotalLate,
                                                                             ((UInt32)(this.m_obj_AttendanceMaster.TotalOvertime / 60)).ToString() + ":" + ((UInt32)(this.m_obj_AttendanceMaster.TotalOvertime % 60)).ToString(),
                                                                             this.m_obj_AttendanceMaster.TotalExpectedManhourOT,
                                                                             this.m_obj_AttendanceMaster.TotalManHourServedOT,
                                                                             this.m_obj_AttendanceMaster.TotalExpectedManhourOff,
                                                                             this.m_obj_AttendanceMaster.TotalManHourServedOff,
                                                                             lcl_str_AutoBotComment);
                lcl_str_HTMLReport += @"<br />
                                        <table id='GridTableStyle' class='report_body'>
                                            <tr style=''>    
                                                <td class='report_grid_header' style='width:5%'>
                                                    SL
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    ID
                                                </td>
                                                <td class='report_grid_header' style='width:25%'>
                                                    EMPLOYEE
                                                </td>
                                                <td class='report_grid_header' style='width:20%'>
                                                    IN
                                                </td>
                                                <td class='report_grid_header' style='width:20%'>
                                                    OUT
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    D.HOUR
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    O.T
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    N.Allow
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    STATUS
                                                </td>
                                             </tr>";

                System.UInt32 lcl_ui32_Sequence = 1;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance in this.m_obj_AttendanceMaster.AttendanceList)
                {
                    System.String lcl_str_EmployeeDetails = lcl_obj_Attendance.EmployeeName + " [" + lcl_obj_Attendance.Designation + "]";
                    System.String lcl_str_In = lcl_obj_Attendance.DutyFrom.ToString("dd/M/yyyy hh:mm:ss tt") + " [" + lcl_obj_Attendance.InThrough + "]";
                    System.String lcl_str_Out = lcl_obj_Attendance.DutyUpto.ToString("dd/M/yyyy hh:mm:ss tt") + " [" + lcl_obj_Attendance.OutThrough + "]";

                    if (lcl_obj_Attendance.DutyFrom == System.DateTime.MinValue)
                    {
                        lcl_str_In = "XXXXXXXXXXXX";
                    }
                    if (lcl_obj_Attendance.DutyUpto == System.DateTime.MinValue)
                    {
                        lcl_str_Out = "XXXXXXXXXXXX";
                    }

                    System.UInt32 lcl_ui32_DutyHour = (UInt32)lcl_obj_Attendance.DutyMinutes / 60;
                    System.UInt32 lcl_ui32_DutyMinute = (UInt32)lcl_obj_Attendance.DutyMinutes % 60;
                    System.String lcl_str_DutyHour = lcl_ui32_DutyHour.ToString() + ":" + lcl_ui32_DutyMinute.ToString();

                    System.String lcl_str_OvertimeAuto = ((UInt32)(lcl_obj_Attendance.OvertimeAuto / 60)).ToString() + ":" + ((UInt32)(lcl_obj_Attendance.OvertimeAuto % 60)).ToString();
                    System.String lcl_str_TotalOvertime = ((UInt32)(lcl_obj_Attendance.OvertimeTotal / 60)).ToString() + ":" + ((UInt32)(lcl_obj_Attendance.OvertimeTotal % 60)).ToString();

                    System.String lcl_str_Status = System.String.Empty;
                    switch (lcl_obj_Attendance.AttnStatus)
                    {
                        case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT:
                            lcl_str_Status = "A";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND:
                            lcl_str_Status = "A.N.D";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY:
                            lcl_str_Status = "H";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.LATE:
                        case SilkERP360.CCL.Enums.AttendanceStatus.LATE_APPROVED:
                            lcl_str_Status = "L";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.OUTSIDE_DUTY:
                            lcl_str_Status = "O.S.D";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.ON_FOREIGN_TOUR:
                            lcl_str_Status = "O.F.T";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE:
                            lcl_str_Status = "O.L";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.PRESENT:
                            lcl_str_Status = "P";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY:
                            lcl_str_Status = "S.C.H";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND:
                            lcl_str_Status = "W";
                            break;
                        case SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                            lcl_str_Status = "W.O.H";
                            break;
                    }

                    lcl_str_HTMLReport += System.String.Format(@"<tr style=''>    
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
                                                <td class='report_grid_text' style=''>
                                                    {6}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {7}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {8}
                                                </td>
                                             </tr>", lcl_ui32_Sequence.ToString(),
                                                   lcl_obj_Attendance.EmployeeId,
                                                   lcl_str_EmployeeDetails,
                                                   lcl_str_In,
                                                   lcl_str_Out,
                                                   lcl_str_DutyHour,
                                                   lcl_str_OvertimeAuto,
                                                   lcl_obj_Attendance.NightAllowance.ToString() + ".00",
                                                   lcl_str_Status);
                    lcl_ui32_Sequence++;

                }
                lcl_str_HTMLReport += "</table></div></div>";
                return lcl_str_HTMLReport;


            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }



        /// <summary>
        /// 1. Set Attendance Date
        /// 2. Get EmployeeProfile For all Temporary/Probation/Regular Employees and process EmployeeProfile by Profile
        /// 3. Get Work Schedule For the Employee from Work_Group_Operation_Master
        ///     a. Get Date's Work_Group_Operation_Master For all WorkGroups
        ///     b. Get Work_Group_Operation_History List For Every Work_Group_Operation_Master
        /// Logic:
        ///     a. If WorkGroup schedule not found, Check LeaveApplication
        ///         if LeaveApplication found, set status ON_LEAVE
        ///         if Neither Found, set status ABSENT_NO_DATA_FOUND
        ///     b. If WorkGroup Schedule Found
        ///         ->Check BMS_TRANSACTION  and Process Attendance
        ///         -> Update WorkGroupMaster Entity
        ///
        /// 
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_dt_AttendanceDate"></param>
        /// <returns></returns>
        //        public void Process(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_AttendanceDate)
        //        {
        //            this.m_dt_AttendanceDate = IP_dt_AttendanceDate;
        //            System.Double lcl_dbl_TotalOvertimeAmount = 0;
        //            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
        //            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = null;
        //            System.Text.StringBuilder lcl_sb_LogBuilder = new StringBuilder();
        //            try
        //            {
        //                /***************************************************************************************************************************/
        //                //Database Connections
        //                //SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp; Password=silkerp");
        //                //lcl_obj_DBManager.Initialize();
        //                this.m_obj_DBManager.Open();
        //                /***************************************************************************************************************************/
        //                //Check If Attendance Has Already been generated
        //                System.String lcl_str_SqlQuery = System.String.Format("SELECT COUNT(ATTENDANCE_MASTER_CODE) FROM ATTENDANCE_MASTER WHERE COMPANY_CODE = {0} AND ATTENDANCE_DATE=TO_DATE('{1}','dd/mm/yyyy')", IP_ui64_CompanyCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
        //                System.Object lcl_obj_NumAttendanceMaster = this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
        //                System.String lcl_str_NumAttendanceMaster = lcl_obj_NumAttendanceMaster.ToString();
        //                System.Int32 lcl_ui32_NumAttendanceMaster = System.Int32.Parse(lcl_str_NumAttendanceMaster);
        //                if (lcl_ui32_NumAttendanceMaster > 0)
        //                {
        //                    //Attendance has been processed
        //                    return;
        //                }

        //                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
        //                lcl_sb_LogBuilder.AppendLine("Daily Attendance Process : " + System.DateTime.Today.ToLongDateString());
        //                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
        //                //Employee Profile Generate

        //                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
        //                lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
        //                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,0 IS_DELETED
        //                                                                        FROM EMPLOYEE EMP 
        //                                                                        JOIN EMPLOYEE_PERSONAL EMP_PER
        //                                                                        ON EMP.EMPLOYEE_CODE = EMP_PER.EMPLOYEE_CODE
        //                                                                        JOIN COMPANY COMP
        //                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
        //                                                                        JOIN DEPARTMENT DEPT
        //                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
        //                                                                        JOIN DESIGNATION DESIG
        //                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
        //                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
        //                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
        //                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
        //                lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);
        //                if (lcl_objLst_EmployeeProfile == null)
        //                {
        //                    lcl_sb_LogBuilder.AppendLine("No Active Employees Found To Process Attendance!!!");
        //                    return;
        //                }
        //                lcl_sb_LogBuilder.AppendLine("Company : " + lcl_objLst_EmployeeProfile[0].Company.Name);
        //                lcl_sb_LogBuilder.AppendLine("Total Employee Processing : " + lcl_objLst_EmployeeProfile.Count.ToString());
        //                //lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");

        //                //get Date's WorkGroupMasters
        //                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
        //                lcl_obj_WorkGroupOperationMasterManager.Initialize();
        //                SilkERP360.BML.HRIS.AttendanceMasterManager lcl_obj_AttendanceMasterManager = new SilkERP360.BML.HRIS.AttendanceMasterManager();
        //                lcl_obj_AttendanceMasterManager.Initialize();
        //                SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
        //                lcl_obj_AttendanceMasterManager.Initialize();
        //                SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
        //                lcl_obj_EmployeeLeaveApplicationManager.Initialize();

        //                lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WHERE WORK_DATE = TO_DATE('{0}','dd/mm/yyyy')", IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
        //                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objLst_WorkGroupMasterList = lcl_obj_WorkGroupOperationMasterManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

        //                //Attendance Repository

        //                lcl_obj_AttendanceMaster.CompanyCode = IP_ui64_CompanyCode;
        //                lcl_obj_AttendanceMaster.AttendaneDate = IP_dt_AttendanceDate;
        //                int counter = 0;
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //                {
        //                    if (lcl_obj_EmployeeProfile.EmployeeID == "OFC1106468")
        //                    {
        //                        int h = 0;
        //                    }
        //                    counter++;
        //                    Console.WriteLine("Processing " + counter.ToString() + " Name : " + lcl_obj_EmployeeProfile.EmployeeName);

        //                    SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_EmpWorkGroupOperationMaster = null;
        //                    System.TimeSpan lcl_obj_DutyHour = System.TimeSpan.MinValue;
        //                    //System.TimeSpan lcl_obj_OvertimeHour = System.TimeSpan.MinValue;

        //                    lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
        //                    lcl_sb_LogBuilder.AppendLine("Employee Id : " + lcl_obj_EmployeeProfile.EmployeeID + " | Name : " + lcl_obj_EmployeeProfile.EmployeeName);
        //                    System.DateTime lcl_obj_DutyStartDateTime;
        //                    System.UInt32 lcl_ui32_DutyHour = 0;
        //                    System.DateTime lcl_obj_DutyEndDateTime;
        //                    SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = new SilkERP360.CCL.BusinessEntities.HRIS.Attendance();
        //                    lcl_obj_Attendance.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                    lcl_obj_Attendance.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
        //                    lcl_obj_Attendance.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
        //                    lcl_obj_Attendance.Department = lcl_obj_EmployeeProfile.Department.Name;
        //                    lcl_obj_Attendance.Designation = lcl_obj_EmployeeProfile.Designation.Name;
        //                    lcl_obj_Attendance.AttendaneDate = IP_dt_AttendanceDate;
        //                    lcl_obj_Attendance.PaidPerHour = Math.Round(lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104, 2);
        //                    lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.None;
        //                    lcl_obj_Attendance.StatusOverrideEmployeeCode = 0;

        //                    //lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
        //                    //                                            "WHERE ELA.EMPLOYEE_CODE = {0} AND ELA.LEAVE_START_DATE >= TO_DATE('{1}','dd/mm/yyyy') " +
        //                    //                                            " AND ELA.LEAVE_END_DATE <= TO_DATE('{2}','dd/mm/yyyy')", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
        //                    //SELECT * FROM SILKERP_DEV.EMPLOYEE_LEAVE_APPLICATION ELA WHERE ELA.EMPLOYEE_CODE = 101000000022 AND TO_DATE('05/1/2015','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE
        //                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
        //                                                            "WHERE ELA.EMPLOYEE_CODE = {0} AND TO_DATE('{1}','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
        //                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_EmployeeLeaveApplication =
        //                                        lcl_obj_EmployeeLeaveApplicationManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

        //                    if (!((lcl_objLst_EmployeeLeaveApplication == null) || (lcl_objLst_EmployeeLeaveApplication.Count == 0)))
        //                    {
        //                        //Leave Application Found and Employee on Leave
        //                        lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
        //                        lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
        //                        lcl_obj_Attendance.DutyMinutes = 0;
        //                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE;
        //                        lcl_sb_LogBuilder.AppendLine("Status : ON LEAVE");
        //                        lcl_obj_Attendance.WorkGroupOperationMasterCode = 0;
        //                        //lcl_obj_AttendanceMaster.TotalLeave += 1;
        //                        lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                    }
        //                    else
        //                    {
        //                        //1. Figure out Which WorkGroupOperationMaster Employee is assigned in
        //                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM " +
        //                                                                "JOIN WORK_GROUP_OPERATION_HISTORY WGOH " +
        //                                                                "ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE " +
        //                                                                "WHERE WGOH.EMPLOYEE_CODE = {0} AND WGOM.WORK_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
        //                        lcl_obj_EmpWorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);

        //                        if (lcl_obj_EmpWorkGroupOperationMaster == null)
        //                        {
        //                            //STRAY EMPLOYEE : NOT ASSIGNED TO ANY WORKGROUP
        //                            lcl_sb_LogBuilder.AppendLine("Not Assigned To Any WorkGroup!");
        //                            lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
        //                            lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
        //                            lcl_obj_Attendance.DutyMinutes = 0;
        //                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
        //                            lcl_sb_LogBuilder.AppendLine("Status : ON LEAVE");
        //                            //lcl_obj_AttendanceMaster.TotalAbsent += 1;
        //                            lcl_obj_Attendance.WorkGroupOperationMasterCode = 0;
        //                            lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                        }
        //                        else
        //                        {
        //                            //WorkGroup found for Employee
        //                            lcl_obj_Attendance.WorkGroupOperationMasterCode = lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode;
        //                            System.String lcl_str_DutyStartDateTime = IP_dt_AttendanceDate.ToString("dd/MM/yyyy") + " " + lcl_obj_EmpWorkGroupOperationMaster.DutyStartFrom;
        //                            lcl_obj_DutyStartDateTime = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        //                            System.DateTime lcl_obj_DutyStartSearchDateTime = lcl_obj_DutyStartDateTime.Subtract(new TimeSpan(1, 0, 0));//search for access transaction from 1 hour before start of duty
        //                            lcl_ui32_DutyHour = lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                            lcl_obj_DutyEndDateTime = lcl_obj_DutyStartDateTime.AddHours(lcl_ui32_DutyHour);

        //                            System.DateTime lcl_obj_DutyEndSearchDateTime = System.DateTime.MinValue;
        //                            if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                            {
        //                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddMinutes((double)lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit);
        //                                //Add ADDITIONAL 60 MIN TO EXIT TIME
        //                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddMinutes(60);
        //                            }
        //                            else
        //                            {
        //                                //FOR NON OVERTIME ELIGIBLE EMPLOYEES
        //                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddHours(8);
        //                            }
        //                            //GET IN & OUT FOR BIOMETRIC ACCESS
        //                            lcl_obj_Attendance.DutyScheduleFrom = lcl_obj_DutyStartDateTime;
        //                            lcl_obj_Attendance.DutyScheduleUpto = lcl_obj_DutyEndDateTime;
        //                            //CHECK BMS_TRANSACTION 
        //                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_TRANSACTION WHERE (TRAN_DATE_TIME >= TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am')) AND (TRAN_DATE_TIME <= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am')) AND EMPLOYEE_ID = '{2}' ORDER BY TRAN_DATE_TIME ASC", lcl_obj_DutyStartSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_DutyEndSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_EmployeeProfile.EmployeeID);
        //                            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_BMSRowReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

        //                            if (!(lcl_obj_BMSRowReader.HasRows))
        //                            {
        //                                //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
        //                                lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
        //                                lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
        //                                lcl_obj_Attendance.DutyMinutes = 0;
        //                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT;
        //                                if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff))
        //                                {
        //                                    //WorkGroup Has been off. No Need to Check Employee Attendance
        //                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY;
        //                                }
        //                                if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff)
        //                                {
        //                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND;
        //                                }

        //                                if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff)
        //                                {
        //                                    //WorkGroup Has been off. No Need to Check Employee Attendance
        //                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY;
        //                                }
        //                                lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                lcl_obj_BMSRowReader.Close();
        //                            }
        //                            else
        //                            {
        //                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction>();
        //                                while (lcl_obj_BMSRowReader.Read())
        //                                {
        //                                    SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction();
        //                                    lcl_obj_BMSTransaction.EmployeeId = lcl_obj_BMSRowReader["EMPLOYEE_ID"].ToString();
        //                                    lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSRowReader["READER_CODE"].ToString();
        //                                    lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSRowReader["READER_NAME"].ToString();
        //                                    //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["READER_CODE"].ToString(),"dd/M/yyyy hh:mm:ss TT",CultureInfo.InvariantCulture);
        //                                    System.String aj = lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString();
        //                                    //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString(), "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        //                                    lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString());
        //                                    lcl_objLst_BMSTransaction.Add(lcl_obj_BMSTransaction);
        //                                }
        //                                lcl_obj_BMSRowReader.Close();
        //                                SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_InBMSTransaction = lcl_objLst_BMSTransaction[0];
        //                                SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_OutBMSTransaction = lcl_objLst_BMSTransaction[(lcl_objLst_BMSTransaction.Count - 1)];
        //                                //Employees IN & OUT time sorted
        //                                //SORTED : DUTY_FROM/DUTY_UPTO/DUTY_HOUR/OVERTIME
        //                                lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;
        //                                lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;
        //                                lcl_obj_DutyHour = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyFrom);
        //                                //lcl_obj_OvertimeHour = lcl_obj_DutyHour;// lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_DutyEndDateTime);
        //                                lcl_obj_Attendance.DutyMinutes = lcl_obj_DutyHour.TotalMinutes;
        //                                lcl_obj_Attendance.DutyMinutes = Math.Round(lcl_obj_Attendance.DutyMinutes);
        //                                lcl_obj_Attendance.InThrough = lcl_obj_InBMSTransaction.ReaderName;
        //                                lcl_obj_Attendance.InDoorNo = System.UInt32.Parse(lcl_obj_InBMSTransaction.ReaderNo);
        //                                lcl_obj_Attendance.OutThrough = lcl_obj_OutBMSTransaction.ReaderName;
        //                                lcl_obj_Attendance.OutDoorNo = System.UInt32.Parse(lcl_obj_OutBMSTransaction.ReaderNo);
        //                                if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff) ||
        //                                    (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.DutyOnHoliday))
        //                                {
        //                                    //WorkGroup Has been off. No Need to Check Employee Attendance
        //                                    lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;//.Parse("01\01\01");
        //                                    lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;// Parse("01\01\01");
        //                                    lcl_obj_Attendance.DutyMinutes = lcl_obj_Attendance.DutyMinutes;
        //                                    ///Check For WorkOnHoliday Status
        //                                    ///////////////////////////////////////////////////////////////////////
        //                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY;
        //                                    lcl_sb_LogBuilder.AppendLine("Status : HOLIDAY");
        //                                    lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                }
        //                                else
        //                                {
        //                                    //get AssessmentStatus of Employee
        //                                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0} AND EMPLOYEE_CODE = {1}", lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode, lcl_obj_EmployeeProfile.EmployeeCode);
        //                                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGOperationHistoryReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

        //                                    if (!(lcl_obj_WGOperationHistoryReader.HasRows))
        //                                    {
        //                                        //Employee Not Assigned To Any WorkGroup. Mark ABSENT
        //                                        //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
        //                                        lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
        //                                        lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
        //                                        lcl_obj_Attendance.InThrough = "";
        //                                        lcl_obj_Attendance.OutThrough = "";
        //                                        lcl_obj_Attendance.DutyMinutes = 0;
        //                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
        //                                        lcl_sb_LogBuilder.AppendLine("Status : ABSENT");
        //                                        lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                        lcl_obj_WGOperationHistoryReader.Close();
        //                                    }
        //                                    else
        //                                    {
        //                                        lcl_obj_WGOperationHistoryReader.Read();
        //                                        //Get Assessment Status Of Employee
        //                                        SilkERP360.CCL.Enums.AssessmentStatus lcl_enm_EmployeeAttendanceAssessmentStatus = (SilkERP360.CCL.Enums.AssessmentStatus)System.UInt32.Parse(lcl_obj_WGOperationHistoryReader["ASSESSMENT_STATUS"].ToString());
        //                                        lcl_obj_WGOperationHistoryReader.Close();

        //                                        /////Check for WORK_ON_HOLIDAY


        //                                        //PROCESS BASED ON REQUESTED ASSESSMENT_STATUS
        //                                        if (lcl_enm_EmployeeAttendanceAssessmentStatus == SilkERP360.CCL.Enums.AssessmentStatus.LateArrivalRequested)
        //                                        {
        //                                            //Process with late arrival request
        //                                            System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.LATE_ARRIVAL_GRACE_PERIOD);
        //                                            System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
        //                                            if (lcl_i32_Comparison == -1)
        //                                            {
        //                                                //Employee Late
        //                                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;
        //                                                lcl_sb_LogBuilder.AppendLine("Status : LATE");
        //                                                lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                            }
        //                                            else
        //                                            {
        //                                                //Employee Present and Ontime
        //                                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
        //                                                lcl_sb_LogBuilder.AppendLine("Status : PRESNT");
        //                                                lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            //PROCESS EMPLOYEE WITH REGULAR ASSESSMENT_STATUS
        //                                            //Process with regular arrival
        //                                            System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.ATTENDANCE_GRACE_PERIOD);
        //                                            System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
        //                                            if (lcl_i32_Comparison == -1)
        //                                            {
        //                                                //Employee On time
        //                                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
        //                                                lcl_sb_LogBuilder.AppendLine("Status : PRESENT");
        //                                                lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                            }
        //                                            else
        //                                            {
        //                                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;
        //                                                lcl_sb_LogBuilder.AppendLine("Status : LATE");
        //                                                lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                #region PROCESS OVERTIME
        //                                if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                                {
        //                                    lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.Automated;
        //                                    if (lcl_obj_Attendance.AttnStatus == SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
        //                                    {
        //                                        lcl_obj_Attendance.OvertimeAuto = lcl_obj_Attendance.DutyMinutes;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (lcl_obj_Attendance.DutyUpto > lcl_obj_Attendance.DutyScheduleUpto)
        //                                        {
        //                                            System.TimeSpan lcl_obj_Overtime = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyScheduleUpto);
        //                                            lcl_obj_Attendance.OvertimeAuto = lcl_obj_Overtime.TotalMinutes;
        //                                        }
        //                                    }
        //                                    if (lcl_obj_EmpWorkGroupOperationMaster != null)
        //                                    {
        //                                        if (lcl_obj_Attendance.OvertimeAuto > lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit)
        //                                        {
        //                                            lcl_obj_Attendance.OvertimeAuto = lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit;
        //                                        }
        //                                    }
        //                                    /***************************************************************************************************/
        //                                    //Deduct OT if employee is more than 4 hours late
        //                                    if ((lcl_obj_Attendance.DutyFrom - lcl_obj_Attendance.DutyScheduleFrom).Hours > 4)
        //                                    {
        //                                        lcl_obj_Attendance.OvertimeAuto = 0;
        //                                        lcl_obj_Attendance.OvertimeTotal = 0;
        //                                        lcl_obj_Attendance.Remarks = "O.T Deducted due to late by more than 4 hours";
        //                                    }
        //                                    /***************************************************************************************************/

        //                                    lcl_obj_Attendance.OvertimeTotal = lcl_obj_Attendance.OvertimeAuto;
        //                                    lcl_obj_AttendanceMaster.TotalOvertime += (uint)lcl_obj_Attendance.OvertimeTotal;
        //                                    //System.Double lcl_dbl_OvertimeAmount = (double)((lcl_obj_Attendance.OvertimeTotal / 60) * lcl_obj_Attendance.PaidPerHour);
        //                                    //lcl_dbl_TotalOvertimeAmount += lcl_dbl_OvertimeAmount;
        //                                }
        //                                #endregion PROCESS OVERTIME
        //                            }
        //                        }
        //                    }
        //                    #region SUMMERIZE ATTENDANCE MASTER



        //                    lcl_obj_AttendanceMaster.TotalProcessed += 1;
        //                    switch (lcl_obj_Attendance.AttnStatus)
        //                    {
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT:
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND:
        //                            lcl_obj_AttendanceMaster.TotalAbsent += 1;
        //                            //FULL WORK HOUR LOST
        //                            if (lcl_obj_EmpWorkGroupOperationMaster != null)
        //                            {
        //                                if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOT += 0;
        //                                }
        //                                else
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOff += 0;
        //                                }
        //                            }
        //                            break;
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.LATE:
        //                            lcl_obj_AttendanceMaster.TotalLate += 1;
        //                            lcl_obj_AttendanceMaster.TotalPresent += 1;
        //                            if (lcl_obj_EmpWorkGroupOperationMaster != null)
        //                            {
        //                                if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOT += (uint)((lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal) / 60);
        //                                }
        //                                else
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOff += (uint)(lcl_obj_Attendance.DutyMinutes / 60);
        //                                }
        //                            }
        //                            break;
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY:
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY:
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND:
        //                            lcl_obj_AttendanceMaster.TotalHoliday += 1;
        //                            break;
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.PRESENT:
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
        //                            lcl_obj_AttendanceMaster.TotalPresent += 1;
        //                            if (lcl_obj_EmpWorkGroupOperationMaster != null)
        //                            {
        //                                if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOT += (uint)((lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal) / 60);
        //                                }
        //                                else
        //                                {
        //                                    lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
        //                                    lcl_obj_AttendanceMaster.TotalManHourServedOff += (uint)(lcl_obj_Attendance.DutyMinutes / 60);
        //                                }
        //                            }
        //                            break;
        //                        case SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE:
        //                            lcl_obj_AttendanceMaster.TotalLeave += 1;
        //                            break;
        //                    }
        //                    #endregion SUMMERIZE ATTENDANCE MASTER

        //                    #region WORKHOUR SUMMERY

        //                    #endregion WORKHOUR SUMMERY
        //                }


        //                lcl_obj_AttendanceMaster.EntryEmployeeCode = 0;
        //                lcl_obj_AttendanceMasterManager.Save(lcl_obj_AttendanceMaster, this.m_obj_DBManager);
        //                //Update WorkGroupOperationMaster IsProcessed flag which signifies if the attendance for the WorkGroupOperationMaster
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster in lcl_objLst_WorkGroupMasterList)
        //                {
        //                    lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_MASTER SET IS_PROCESSED = {0} WHERE WG_OPERATION_MASTER_CODE = {1}", (System.UInt16)SilkERP360.CCL.Enums.YesNo.Yes, lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
        //                    this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
        //                }
        //                //Attendance Has been processed
        //                this.m_obj_DBManager.CommitTransaction();
        //                this.m_obj_AttendanceMaster = lcl_obj_AttendanceMaster;
        //                int a1 = 0;
        //            }
        //            catch (System.Exception Ex)
        //            {
        //                if (this.m_obj_DBManager != null)
        //                {
        //                    this.m_obj_DBManager.RollbackTransaction();
        //                }
        //                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Critical Error : " + Ex.Message);
        //                throw Ex;
        //                //Console.WriteLine(Ex.Message);
        //                //Console.ReadKey();
        //            }
        //            finally
        //            {
        //                if (this.m_obj_DBManager != null)
        //                {
        //                    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
        //                    {
        //                        this.m_obj_DBManager.CommitTransaction();
        //                        this.m_obj_DBManager.Close();
        //                    }
        //                }
        //                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
        //                //this.m_obj_ServiceLog.Close();
        //            }
        //        }

        public void Process(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_AttendanceDate)
        {
            this.m_dt_AttendanceDate = IP_dt_AttendanceDate;
            ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Starting Attendance Process...");
            System.Double lcl_dbl_TotalOvertimeAmount = 0;
            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = null;
            //System.Text.StringBuilder lcl_sb_LogBuilder = new StringBuilder();
            try
            {
                /***************************************************************************************************************************/
                //Database Connections
                //SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp; Password=silkerp");
                //lcl_obj_DBManager.Initialize();
                //this.m_obj_DBManager.Open();
                /***************************************************************************************************************************/
                //Check If Attendance Has Already been generated
                System.String lcl_str_SqlQuery = System.String.Format("SELECT COUNT(ATTENDANCE_MASTER_CODE) FROM ATTENDANCE_MASTER WHERE COMPANY_CODE = {0} AND ATTENDANCE_DATE=TO_DATE('{1}','dd/mm/yyyy')", IP_ui64_CompanyCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Executing Query : " + lcl_str_SqlQuery);
                System.Object lcl_obj_NumAttendanceMaster = this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                System.String lcl_str_NumAttendanceMaster = lcl_obj_NumAttendanceMaster.ToString();
                System.Int32 lcl_ui32_NumAttendanceMaster = System.Int32.Parse(lcl_str_NumAttendanceMaster);
                if (lcl_ui32_NumAttendanceMaster > 0)
                {
                    //Attendance has been processed
                    return;
                }

                //CHECK IF COMPANY HAS NO EMPLOYEE
                //lcl_str_SqlQuery = System.String.Format("SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3})", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                //ServiceLog.LogData("SQL : " + lcl_str_SqlQuery);
                ////ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Executing Query : " + lcl_str_SqlQuery);
                //System.Object lcl_obj_NumberOfEmployee = this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                //System.String lcl_str_NumberOfEmployee = lcl_obj_NumberOfEmployee.ToString();
                //System.Int32 lcl_ui32_NumberOfEmployee = System.Int32.Parse(lcl_str_NumberOfEmployee);

                //if (lcl_ui32_NumberOfEmployee == 0)
                //{
                //    ServiceLog.LogData("**************************************************************************************************************************************************************************");
                //    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => NO EMPLOYEE FOUND IN COMPANY ");
                //    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => ATTENDANCE PROCESS TERMINATED FOR");
                //    ServiceLog.LogData("**************************************************************************************************************************************************************************");
                //    return;
                //}

                //Employee Profile Generate

                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetEmployeeProfilesByCompany(IP_ui64_CompanyCode, this.m_obj_DBManager);
                //if ((lcl_objLst_EmployeeProfile.Count == 0) || (lcl_objLst_EmployeeProfile == null))
                //{
                //    ServiceLog.LogData("**************************************************************************************************************************************************************************");
                //    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => NO EMPLOYEE FOUND IN COMPANY : " + lcl_objLst_EmployeeProfile[0].Company.Name + " Date :" + System.DateTime.Today.ToLongDateString());
                //    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => ATTENDANCE PROCESS TERMINATED FOR : " + lcl_objLst_EmployeeProfile[0].Company.Name + " Date :" + System.DateTime.Today.ToLongDateString());
                //    ServiceLog.LogData("**************************************************************************************************************************************************************************");
                //    return;
                //}
                System.GC.Collect();
                ServiceLog.LogData("**************************************************************************************************************************************************************************");
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Daily Attendance Process For : " + lcl_objLst_EmployeeProfile[0].Company.Name + " Date :" + System.DateTime.Today.ToLongDateString());
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => --------------------------------------------------------------------------------------------------------------");
                if (lcl_objLst_EmployeeProfile == null)
                {
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => No Active Employees Found To Process Attendance!!!");
                    return;
                }
                if (lcl_objLst_EmployeeProfile.Count == 0)
                {
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => No Active Employees Found To Process Attendance!!!");
                    return;
                }
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Employee Processing : " + lcl_objLst_EmployeeProfile.Count.ToString());
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => --------------------------------------------------------------------------------------------------------------");

                //get Date's WorkGroupMasters
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                lcl_obj_WorkGroupOperationMasterManager.Initialize();
                SilkERP360.BML.HRIS.AttendanceMasterManager lcl_obj_AttendanceMasterManager = new SilkERP360.BML.HRIS.AttendanceMasterManager();
                lcl_obj_AttendanceMasterManager.Initialize();
                SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
                lcl_obj_AttendanceMasterManager.Initialize();
                SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                lcl_obj_EmployeeLeaveApplicationManager.Initialize();

                lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WGOM.WORK_GROUP_CODE = WG.WORK_GROUP_CODE WHERE WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_ui64_CompanyCode);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objLst_WorkGroupMasterList = lcl_obj_WorkGroupOperationMasterManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                //Attendance Repository

                lcl_obj_AttendanceMaster.CompanyCode = IP_ui64_CompanyCode;
                lcl_obj_AttendanceMaster.AttendaneDate = IP_dt_AttendanceDate;
                int counter = 0;
                if (lcl_objLst_EmployeeProfile.Count > 0)
                {
                    System.Int32 lcl_i32_ProfileCounter = 0;
                    System.Int32 lcl_i32_TotalProfile = lcl_objLst_EmployeeProfile.Count;
                    /***************************************************************************************************************/
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WG.WORK_GROUP_CODE = WGOM.WORK_GROUP_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_ui64_CompanyCode);
                    //Get WorkGroup Operation master for the attendance date
                    System.Data.DataSet lcl_ds_WorkGroupOperationMaster = new System.Data.DataSet("WorkGroupOperationMaster");

                    System.String lcl_str_Query = System.String.Format("SELECT WGOM.* FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WG.WORK_GROUP_CODE = WGOM.WORK_GROUP_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_ui64_CompanyCode);
                    OracleCommand lcl_obj_WGOMCommand = new OracleCommand(lcl_str_Query, this.m_obj_DBManager.Connection);
                    lcl_obj_WGOMCommand.Transaction = this.m_obj_DBManager.Transaction;


                    OracleDataAdapter lcl_obj_WGOMAdapter = new OracleDataAdapter(lcl_obj_WGOMCommand);
                    lcl_obj_WGOMAdapter.FillSchema(lcl_ds_WorkGroupOperationMaster, System.Data.SchemaType.Source, "WORK_GROUP_OPERATION_MASTER");
                    lcl_obj_WGOMAdapter.Fill(lcl_ds_WorkGroupOperationMaster, "WORK_GROUP_OPERATION_MASTER");

                    lcl_str_Query = System.String.Format("SELECT WGOH.* FROM WORK_GROUP_OPERATION_HISTORY WGOH JOIN WORK_GROUP_OPERATION_MASTER WGOM ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy')", IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                    OracleCommand lcl_obj_WGOHCommand = new OracleCommand(lcl_str_Query, this.m_obj_DBManager.Connection);
                    lcl_obj_WGOHCommand.Transaction = this.m_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_WGOHAdapter = new OracleDataAdapter(lcl_obj_WGOHCommand);
                    lcl_obj_WGOHAdapter.FillSchema(lcl_ds_WorkGroupOperationMaster, System.Data.SchemaType.Source, "WORK_GROUP_OPERATION_HISTORY");
                    lcl_obj_WGOHAdapter.Fill(lcl_ds_WorkGroupOperationMaster, "WORK_GROUP_OPERATION_HISTORY");
                    /***************************************************************************************************************/
                    /***************************************************************************************************************/
                    //GET ALL LEAVE APPLICATIONS FOR AttendanceDate
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
                                                                "WHERE TO_DATE('{0}','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE", IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_LeaveApplicationsRepository =
                                        lcl_obj_EmployeeLeaveApplicationManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);


                    /***************************************************************************************************************/
                    ServiceLog.Flush();
                    GC.Collect();

                    /***************************************************************************************************************/
                    ServiceLog.Flush();
                    System.GC.Collect();
                    for (lcl_i32_ProfileCounter = 0; lcl_i32_ProfileCounter < lcl_i32_TotalProfile; lcl_i32_ProfileCounter++)
                    {
                        if (lcl_i32_ProfileCounter == 9)
                        {
                            int k = 0;
                        }
                        //Always Take Profile of Index 0
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_objLst_EmployeeProfile[lcl_i32_ProfileCounter];
                        if (lcl_obj_EmployeeProfile.JoiningDate > IP_dt_AttendanceDate)
                        {
                            continue;
                        }
                        //SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_objLst_EmployeeProfile[0];
                        //if (lcl_obj_EmployeeProfile.EmployeeID == "OFC1106468")
                        //{
                        //    int h = 0;
                        //}
                        counter++;
                        if (counter == 228)
                        {
                            int o = 0;
                        }
                        Console.WriteLine("Processing " + counter.ToString() + " Name : " + lcl_obj_EmployeeProfile.EmployeeName);

                        SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_EmpWorkGroupOperationMaster = null;
                        System.TimeSpan lcl_obj_DutyHour = System.TimeSpan.MinValue;
                        //System.TimeSpan lcl_obj_OvertimeHour = System.TimeSpan.MinValue;

                        //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => --------------------------------------------------------------------------------------------------------------");
                        //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Employee Id : " + lcl_obj_EmployeeProfile.EmployeeID + " | Name : " + lcl_obj_EmployeeProfile.EmployeeName);
                        System.DateTime lcl_obj_DutyStartDateTime; 
                        System.UInt32 lcl_ui32_DutyHour = 0;
                        System.DateTime lcl_obj_DutyEndDateTime;
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = new SilkERP360.CCL.BusinessEntities.HRIS.Attendance();
                        lcl_obj_Attendance.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        lcl_obj_Attendance.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                        lcl_obj_Attendance.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                        lcl_obj_Attendance.Department = lcl_obj_EmployeeProfile.Department.Name;
                        lcl_obj_Attendance.Designation = lcl_obj_EmployeeProfile.Designation.Name;
                        lcl_obj_Attendance.AttendaneDate = IP_dt_AttendanceDate;
                        lcl_obj_Attendance.PaidPerHour = Math.Round(lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104, 2);
                        lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.None;
                        lcl_obj_Attendance.StatusOverrideEmployeeCode = 0;

                        //lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
                        //                                            "WHERE ELA.EMPLOYEE_CODE = {0} AND ELA.LEAVE_START_DATE >= TO_DATE('{1}','dd/mm/yyyy') " +
                        //                                            " AND ELA.LEAVE_END_DATE <= TO_DATE('{2}','dd/mm/yyyy')", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                        //SELECT * FROM SILKERP_DEV.EMPLOYEE_LEAVE_APPLICATION ELA WHERE ELA.EMPLOYEE_CODE = 101000000022 AND TO_DATE('05/1/2015','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE
                        //lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
                        //                                        "WHERE ELA.EMPLOYEE_CODE = {0} AND TO_DATE('{1}','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                        //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_EmployeeLeaveApplication =
                        //                    lcl_obj_EmployeeLeaveApplicationManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_EmployeeLeaveApplication = null;
                        if (lcl_objLst_LeaveApplicationsRepository != null)
                        {
                            lcl_objLst_EmployeeLeaveApplication = lcl_objLst_LeaveApplicationsRepository.Where(m => m.EmployeeCode == lcl_obj_EmployeeProfile.EmployeeCode).ToList();
                        }

                        if (!((lcl_objLst_EmployeeLeaveApplication == null) || (lcl_objLst_EmployeeLeaveApplication.Count == 0)))
                        {
                            //Leave Application Found and Employee on Leave
                            lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
                            lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
                            lcl_obj_Attendance.DutyMinutes = 0;
                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE;
                            //lcl_sb_LogBuilder.AppendLine("Status : O.L");
                            lcl_obj_Attendance.WorkGroupOperationMasterCode = 0;
                            //lcl_obj_AttendanceMaster.TotalLeave += 1;
                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                            //lcl_obj_EmployeeProfile = null;
                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                        }
                        else
                        {
                            //1. Figure out Which WorkGroupOperationMaster Employee is assigned in
                            //lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM " +
                            //                                        "JOIN WORK_GROUP_OPERATION_HISTORY WGOH " +
                            //                                        "ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE " +
                            //                                        "WHERE WGOH.EMPLOYEE_CODE = {0} AND WGOM.WORK_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                            /************************************************************************************************************************/
                            System.Data.DataRow[] lcl_objArr_WorkGroupOperationHistory = lcl_ds_WorkGroupOperationMaster.Tables["WORK_GROUP_OPERATION_HISTORY"].Select("EMPLOYEE_CODE = " + lcl_obj_EmployeeProfile.EmployeeCode);

                            if (lcl_objArr_WorkGroupOperationHistory.Length == 0)
                            {
                                lcl_obj_EmpWorkGroupOperationMaster = null;
                            }
                            else
                            {
                                System.Data.DataRow lcl_obj_WorkGroupOperationHistory = lcl_objArr_WorkGroupOperationHistory[0];
                                System.String lcl_str_WGOperationMasterCode = lcl_obj_WorkGroupOperationHistory["WG_OPERATION_MASTER_CODE"].ToString();
                                System.Data.DataRow[] lcl_objArr_WorkGroupOperationMaster = lcl_ds_WorkGroupOperationMaster.Tables["WORK_GROUP_OPERATION_MASTER"].Select("WG_OPERATION_MASTER_CODE = " + lcl_str_WGOperationMasterCode);

                                //Must be removed
                                if (lcl_objArr_WorkGroupOperationMaster.Length == 0)
                                {
                                    continue;
                                }

                                System.Data.DataRow lcl_obj_WorkGroupOperationMaster = lcl_objArr_WorkGroupOperationMaster[0];
                                lcl_obj_EmpWorkGroupOperationMaster = new SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                                lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["WG_OPERATION_MASTER_CODE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["WORK_GROUP_CODE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_WorkGroupOperationMaster["WORK_DATE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["WORKER_STRENGTH"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_WorkGroupOperationMaster["OPERATIONAL_STATUS"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["IS_PROCESSED"].ToString()));
                                lcl_obj_EmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_PRESENT"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_ABSENT"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_LATE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_LEAVE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_OFF"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_WorkGroupOperationMaster["DUTY_START_FROM"].ToString();
                                lcl_obj_EmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["DUTY_HOUR"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["OVERTIME_LIMIT"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["IS_PROCESSED_FOR_SALARY"].ToString()));
                                lcl_obj_EmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["DAY_ATTRIBUTE"].ToString()));
                                lcl_obj_EmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["ENTRY_EMPLOYEE_CODE"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_MAN_HOUR"].ToString());
                                lcl_obj_EmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_OVERTIME"].ToString());
                            }
                            /************************************************************************************************************************/
                            //lcl_obj_EmpWorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);

                            if (lcl_obj_EmpWorkGroupOperationMaster == null)
                            {
                                //STRAY EMPLOYEE : NOT ASSIGNED TO ANY WORKGROUP
                                //lcl_sb_LogBuilder.AppendLine("Not Assigned To Any WorkGroup!");
                                lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
                                lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
                                lcl_obj_Attendance.DutyMinutes = 0;
                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
                                //lcl_sb_LogBuilder.AppendLine("Status : A.N.D");
                                //lcl_obj_AttendanceMaster.TotalAbsent += 1;
                                lcl_obj_Attendance.WorkGroupOperationMasterCode = 0;
                                //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                //lcl_obj_EmployeeProfile = null;
                                //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                            }
                            else
                            {
                                //WorkGroup found for Employee
                                //If Employee From Silkcard/Wellpac and Belongs to 30010000060 / 30010000072 (OUTSIDE DUTY) 
                                if ((lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode == 30010000060) ||
                                    (lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode == 30010000072) ||
                                    (lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode == 30010000086))
                                {
                                    lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
                                    lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
                                    lcl_obj_Attendance.DutyMinutes = 0;
                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.OUTSIDE_DUTY;
                                    //lcl_sb_LogBuilder.AppendLine("Status : O.S.D");
                                    lcl_obj_Attendance.WorkGroupOperationMasterCode = lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode;
                                    //lcl_obj_AttendanceMaster.TotalLeave += 1;
                                    //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                    //lcl_obj_EmployeeProfile = null;
                                    //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                }
                                else
                                {

                                    lcl_obj_Attendance.WorkGroupOperationMasterCode = lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode;
                                    System.String lcl_str_DutyStartDateTime = IP_dt_AttendanceDate.ToString("dd/MM/yyyy") + " " + lcl_obj_EmpWorkGroupOperationMaster.DutyStartFrom;
                                    lcl_obj_DutyStartDateTime = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                    System.DateTime lcl_obj_DutyStartSearchDateTime = lcl_obj_DutyStartDateTime.Subtract(new TimeSpan(4, 0, 0));//search for access transaction from 4 hour before start of duty
                                    lcl_ui32_DutyHour = lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                    lcl_obj_DutyEndDateTime = lcl_obj_DutyStartDateTime.AddHours(lcl_ui32_DutyHour);

                                    System.DateTime lcl_obj_DutyEndSearchDateTime = System.DateTime.MinValue;
                                    if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                    {
                                        switch (lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit)
                                        {
                                            case 180:
                                            case 300:
                                                //Overtime Limit 3HR. Regular Working Day
                                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddMinutes((double)lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit);
                                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddMinutes(60);
                                                break;
                                            case 720:
                                            case 660:
                                                //Overtime Limit 12H. Holiday/Weekend
                                                //To have O.T on holiday, employees must come within the working hour
                                                 lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddMinutes(480.0);
                                                //lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddMinutes(60);
                                                break;
                                            default:
                                                lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddMinutes(480.0);
                                                break;
                                        }

                                        
                                        //Add ADDITIONAL 60 MIN TO EXIT TIME
                                        
                                    }
                                    else
                                    {
                                        //FOR NON OVERTIME ELIGIBLE EMPLOYEES
                                        lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddHours(8);
                                    }
                                    //GET IN & OUT FOR BIOMETRIC ACCESS
                                    lcl_obj_Attendance.DutyScheduleFrom = lcl_obj_DutyStartDateTime;
                                    lcl_obj_Attendance.DutyScheduleUpto = lcl_obj_DutyEndDateTime;
                                    //CHECK BMS_TRANSACTION 
                                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_REPOSITORY WHERE (TRAN_DATE_TIME >= TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am')) AND (TRAN_DATE_TIME <= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am')) AND RTRIM(EMPLOYEE_ID) = '{2}' ORDER BY TRAN_DATE_TIME ASC", lcl_obj_DutyStartSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_DutyEndSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_EmployeeProfile.EmployeeID.Trim());
                                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_BMSRowReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                                    if (!(lcl_obj_BMSRowReader.HasRows))
                                    {
                                        //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
                                        lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
                                        lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
                                        lcl_obj_Attendance.DutyMinutes = 0;
                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT;
                                        if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff))
                                        {
                                            //WorkGroup Has been off. No Need to Check Employee Attendance
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY;
                                            //lcl_sb_LogBuilder.AppendLine("Status : H");
                                        }
                                        if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff)
                                        {
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND;
                                            //lcl_sb_LogBuilder.AppendLine("Status : W");
                                        }

                                        if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff)
                                        {
                                            //WorkGroup Has been off. No Need to Check Employee Attendance
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY;
                                            //lcl_sb_LogBuilder.AppendLine("Status : S.C.H");
                                        }
                                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                        //lcl_obj_EmployeeProfile = null;
                                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        lcl_obj_BMSRowReader.Close();
                                    }
                                    else
                                    {
                                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction>();
                                        while (lcl_obj_BMSRowReader.Read())
                                        {
                                            SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction();
                                            lcl_obj_BMSTransaction.EmployeeId = lcl_obj_BMSRowReader["EMPLOYEE_ID"].ToString();
                                            lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSRowReader["READER_CODE"].ToString();
                                            lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSRowReader["READER_NAME"].ToString();
                                            //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["READER_CODE"].ToString(),"dd/M/yyyy hh:mm:ss TT",CultureInfo.InvariantCulture);
                                            System.String aj = lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString();
                                            //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString(), "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                            lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString());
                                            lcl_objLst_BMSTransaction.Add(lcl_obj_BMSTransaction);
                                        }
                                        lcl_obj_BMSRowReader.Close();
                                        /*************************************************************************************************************************************/
                                        //Date: June 14, 2015 -> Implement Bio-metric filter for all employees of Silkcard except Management department
                                        /*************************************************************************************************************************************/
                                        SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_InBMSTransaction = lcl_objLst_BMSTransaction[0];
                                        SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_OutBMSTransaction = lcl_objLst_BMSTransaction[(lcl_objLst_BMSTransaction.Count - 1)];
                                        //Employees IN & OUT time sorted
                                        //SORTED : DUTY_FROM/DUTY_UPTO/DUTY_HOUR/OVERTIME
                                        lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;
                                        lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;
                                        lcl_obj_DutyHour = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyFrom);
                                        //lcl_obj_OvertimeHour = lcl_obj_DutyHour;// lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_DutyEndDateTime);
                                        lcl_obj_Attendance.DutyMinutes = lcl_obj_DutyHour.TotalMinutes;
                                        lcl_obj_Attendance.DutyMinutes = Math.Round(lcl_obj_Attendance.DutyMinutes);
                                        lcl_obj_Attendance.InThrough = lcl_obj_InBMSTransaction.ReaderName;
                                        lcl_obj_Attendance.InDoorNo = System.UInt32.Parse(lcl_obj_InBMSTransaction.ReaderNo);
                                        lcl_obj_Attendance.OutThrough = lcl_obj_OutBMSTransaction.ReaderName;
                                        lcl_obj_Attendance.OutDoorNo = System.UInt32.Parse(lcl_obj_OutBMSTransaction.ReaderNo);
                                        if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff) ||
                                            (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.DutyOnHoliday))
                                        {
                                            //WorkGroup Has been off. No Need to Check Employee Attendance
                                            lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;//.Parse("01\01\01");
                                            lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;// Parse("01\01\01");
                                            lcl_obj_Attendance.DutyMinutes = lcl_obj_Attendance.DutyMinutes;
                                            ///Check For WorkOnHoliday Status
                                            ///////////////////////////////////////////////////////////////////////
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY;
                                            //lcl_sb_LogBuilder.AppendLine("Status : W.O.H");
                                            /******************************************************************************************************************************/
                                            //WORK_ON_HOLIDAY Rechecking
                                            //Reset DutyEndSearchDateTime
                                            if (lcl_obj_Attendance.AttnStatus == SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
                                            {
                                                //A.I->9 hours added
                                                if (lcl_ui32_DutyHour == 0)
                                                {
                                                    lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddHours(9.0);
                                                }
                                                else
                                                {
                                                    lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddHours(6.0);
                                                }
                                                lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_REPOSITORY WHERE (TRAN_DATE_TIME >= TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am')) AND (TRAN_DATE_TIME <= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am')) AND RTRIM(EMPLOYEE_ID) = '{2}' ORDER BY TRAN_DATE_TIME ASC", lcl_obj_DutyStartSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_DutyEndSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_EmployeeProfile.EmployeeID.Trim());
                                                lcl_obj_BMSRowReader.Close();
                                                lcl_obj_BMSRowReader = null;
                                                lcl_obj_BMSRowReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                                                while (lcl_obj_BMSRowReader.Read())
                                                {
                                                    SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction();
                                                    lcl_obj_BMSTransaction.EmployeeId = lcl_obj_BMSRowReader["EMPLOYEE_ID"].ToString();
                                                    lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSRowReader["READER_CODE"].ToString();
                                                    lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSRowReader["READER_NAME"].ToString();
                                                    //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["READER_CODE"].ToString(),"dd/M/yyyy hh:mm:ss TT",CultureInfo.InvariantCulture);
                                                    System.String aj = lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString();
                                                    //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString(), "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                                    lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString());
                                                    lcl_objLst_BMSTransaction.Add(lcl_obj_BMSTransaction);
                                                }
                                                lcl_obj_BMSRowReader.Close();
                                                lcl_obj_InBMSTransaction = lcl_objLst_BMSTransaction[0];
                                                lcl_obj_OutBMSTransaction = lcl_objLst_BMSTransaction[(lcl_objLst_BMSTransaction.Count - 1)];

                                                lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;//.Parse("01\01\01");
                                                lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;// Parse("01\01\01");
                                                lcl_obj_Attendance.DutyMinutes = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyFrom).TotalMinutes;

                                                lcl_obj_Attendance.InThrough = lcl_obj_InBMSTransaction.ReaderName;
                                                lcl_obj_Attendance.InDoorNo = System.UInt32.Parse(lcl_obj_InBMSTransaction.ReaderNo);
                                                lcl_obj_Attendance.OutThrough = lcl_obj_OutBMSTransaction.ReaderName;
                                                lcl_obj_Attendance.OutDoorNo = System.UInt32.Parse(lcl_obj_OutBMSTransaction.ReaderNo);
                                            }
                                            /******************************************************************************************************************************/
                                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                            //lcl_obj_EmployeeProfile = null;
                                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        }
                                        else
                                        {
                                            //get AssessmentStatus of Employee
                                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0} AND EMPLOYEE_CODE = {1}", lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode, lcl_obj_EmployeeProfile.EmployeeCode);
                                            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGOperationHistoryReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                                            if (!(lcl_obj_WGOperationHistoryReader.HasRows))
                                            {
                                                //Employee Not Assigned To Any WorkGroup. Mark ABSENT
                                                //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
                                                lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
                                                lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
                                                lcl_obj_Attendance.InThrough = "";
                                                lcl_obj_Attendance.OutThrough = "";
                                                lcl_obj_Attendance.DutyMinutes = 0;
                                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
                                                //lcl_sb_LogBuilder.AppendLine("Status : A");
                                                //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                                //lcl_obj_EmployeeProfile = null;
                                                //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                                lcl_obj_WGOperationHistoryReader.Close();
                                            }
                                            else
                                            {
                                                lcl_obj_WGOperationHistoryReader.Read();
                                                //Get Assessment Status Of Employee
                                                SilkERP360.CCL.Enums.AssessmentStatus lcl_enm_EmployeeAttendanceAssessmentStatus = (SilkERP360.CCL.Enums.AssessmentStatus)System.UInt32.Parse(lcl_obj_WGOperationHistoryReader["ASSESSMENT_STATUS"].ToString());
                                                lcl_obj_WGOperationHistoryReader.Close();

                                                /////Check for WORK_ON_HOLIDAY


                                                //PROCESS BASED ON REQUESTED ASSESSMENT_STATUS
                                                if (lcl_enm_EmployeeAttendanceAssessmentStatus == SilkERP360.CCL.Enums.AssessmentStatus.LateArrivalRequested)
                                                {
                                                    //Process with late arrival request
                                                    System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.LATE_ARRIVAL_GRACE_PERIOD);
                                                    System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
                                                    if (lcl_i32_Comparison == -1)
                                                    {
                                                        //Employee Late
                                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
                                                        lcl_obj_Attendance.Remarks = "Late Arrival Requested";
                                                        //lcl_sb_LogBuilder.AppendLine("Status : L");
                                                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                                        //lcl_obj_EmployeeProfile = null;
                                                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                                    }
                                                    else
                                                    {
                                                        //Employee Present and Ontime
                                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;
                                                        lcl_obj_Attendance.Remarks = "Late Arrival Requested";
                                                        //lcl_sb_LogBuilder.AppendLine("Status : P");
                                                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                                        //lcl_obj_EmployeeProfile = null;
                                                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                                    }
                                                }
                                                else
                                                {
                                                    //PROCESS EMPLOYEE WITH REGULAR ASSESSMENT_STATUS
                                                    //Process with regular arrival
                                                    System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.ATTENDANCE_GRACE_PERIOD);
                                                    System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
                                                    if (lcl_i32_Comparison == -1)
                                                    {
                                                        //Employee On time
                                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
                                                        //lcl_sb_LogBuilder.AppendLine("Status : P");
                                                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                                        //lcl_obj_EmployeeProfile = null;
                                                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                                    }
                                                    else
                                                    {
                                                        
                                                        
                                                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;

                                                        
                                                        //lcl_sb_LogBuilder.AppendLine("Status : L");
                                                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                                        //lcl_obj_EmployeeProfile = null;
                                                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                                    }
                                                }

                                                /*************************************************************************************************************************************/
                                                /*************************************************************************************************************************************/
                                                ////Filter To Check if Silkcard Employee subjected to Bio-Metric scan or not. If Transaction found but no scan on Bio-metric
                                                ////reader no 393, append N.B.M.S (No Biometric scan on Reader 393(Silkcard)/313(Corporate Office)/392 (Wellpac). Subject to checking) in Remarks Field
                                                //if (lcl_obj_EmployeeProfile.Company.CompanyCode == 110000000001)
                                                //{
                                                //    System.Boolean lcl_b_BiometricFingerScanFound = false;
                                                //    foreach (SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_Transaction in lcl_objLst_BMSTransaction)
                                                //    {
                                                //        /*if ((lcl_obj_Transaction.ReaderNo.Trim().Equals("393")) || 
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("313")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("392")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2897")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2896")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("3035")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("3034")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2624")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2623")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2866")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("2865")))*/
                                                //        if ((lcl_obj_Transaction.ReaderNo.Trim().Equals("393")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("313")) ||
                                                //            (lcl_obj_Transaction.ReaderNo.Trim().Equals("392")))
                                                //        {
                                                //            //Bio-Metric Scan Found on Reader 393/313/392
                                                //            lcl_b_BiometricFingerScanFound = true;
                                                //            break;
                                                //        }
                                                //    }
                                                //    if (lcl_b_BiometricFingerScanFound == false)
                                                //    {
                                                //        //Bio-Mteric Scan on Reader 393 Not Found
                                                //        lcl_obj_Attendance.Remarks += "|| N.B.M.S";
                                                //    }
                                                //}

                                                //If an employees scan is not found in any of the bio-metric readers at Silkcard,Wellpac or Corporate office, he/she will me marked
                                                //absent straight away even if his/her presence is found in others doors
                                                
                                                System.Boolean lcl_b_BiometricFingerScanFound = false;
                                                foreach (SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_Transaction in lcl_objLst_BMSTransaction)
                                                {
                                                    /*if ((lcl_obj_Transaction.ReaderNo.Trim().Equals("393")) || 
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("313")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("392")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2897")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2896")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("3035")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("3034")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2624")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2623")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2866")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("2865")))*/
                                                    if ((lcl_obj_Transaction.ReaderNo.Trim().Equals("393")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("313")) ||
                                                        (lcl_obj_Transaction.ReaderNo.Trim().Equals("392")))
                                                    {
                                                        //Bio-Metric Scan Found on Reader 393/313/392
                                                        lcl_b_BiometricFingerScanFound = true;
                                                        break;
                                                    }
                                                }
                                                if (lcl_b_BiometricFingerScanFound == false)
                                                {
                                                    //Bio-Mteric Scan on Reader 393 Not Found
                                                    //lcl_obj_Attendance.Remarks += "|| N.B.M.S";
                                                    //lcl_obj_Attendance.AttnStatus = CCL.Enums.AttendanceStatus.ABSENT;
                                                }
                                                
                                                
                                                /*************************************************************************************************************************************/
                                                /*************************************************************************************************************************************/
                                            }

                                        }

                                        #region NIGHT ALLOWANCE
                                        //DISCONTINUED
                                        /*if (lcl_obj_EmployeeProfile.NightBillEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                        {
                                            System.Boolean lcl_b_NightDuty = false;
                                            if ((lcl_obj_Attendance.DutyFrom != System.DateTime.MinValue) && (lcl_obj_Attendance.DutyUpto != System.DateTime.MinValue))
                                            {
                                                for (System.DateTime lcl_dt_DutyDateTime = lcl_obj_Attendance.DutyFrom; lcl_dt_DutyDateTime <= lcl_obj_Attendance.DutyUpto; lcl_dt_DutyDateTime = lcl_dt_DutyDateTime.AddHours(1.0))
                                                {
                                                    if (((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(1, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(2, 0, 0))) || //1 AM
                                                        ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(2, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(3, 0, 0))) || //2 AM
                                                        ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(3, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(4, 0, 0))) || //3 AM
                                                        ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(4, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(5, 0, 0)))) //4 AM
                                                    {
                                                        lcl_b_NightDuty = true;

                                                    }
                                                }
                                                if (lcl_b_NightDuty == true)
                                                {
                                                    //lcl_obj_Attendance.NightAllowance = 30;
                                                }
                                            }
                                        }*/
                                        #endregion
                                        #region PROCESS OVERTIME
                                        if (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.ABSENT)
                                        {
                                            //IF REGULAR ABSENT / NO BIO-METRIC SCAN ABSENT, NO NEED TO CALCULATE O.T
                                            if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                            {
                                                lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.Automated;
                                                if (lcl_obj_Attendance.AttnStatus == SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
                                                {
                                                    lcl_obj_Attendance.OvertimeAuto = lcl_obj_Attendance.DutyMinutes;
                                                }
                                                else
                                                {
                                                    if (lcl_obj_Attendance.DutyUpto > lcl_obj_Attendance.DutyScheduleUpto)
                                                    {
                                                        System.TimeSpan lcl_obj_Overtime = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyScheduleUpto);
                                                        lcl_obj_Attendance.OvertimeAuto = lcl_obj_Overtime.TotalMinutes;
                                                    }
                                                }
                                                if (lcl_obj_EmpWorkGroupOperationMaster != null)
                                                {
                                                    if (lcl_obj_Attendance.OvertimeAuto > lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit)
                                                    {
                                                        lcl_obj_Attendance.OvertimeAuto = lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit;
                                                    }
                                                }
                                                /***************************************************************************************************/
                                                //Deduct OT if employee is more than 4 hours late except on WORK_ON_HOLIDAY
                                                if (lcl_obj_Attendance.AttnStatus != SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
                                                {
                                                    if ((lcl_obj_Attendance.DutyFrom - lcl_obj_Attendance.DutyScheduleFrom).Hours > 4)
                                                    {
                                                        lcl_obj_Attendance.OvertimeAuto = 0;
                                                        lcl_obj_Attendance.OvertimeTotal = 0;
                                                        lcl_obj_Attendance.Remarks = "O.T Deducted due to late by more than 4 hours";
                                                    }
                                                }
                                                /***************************************************************************************************/

                                                lcl_obj_Attendance.OvertimeTotal = lcl_obj_Attendance.OvertimeAuto;
                                                lcl_obj_AttendanceMaster.TotalOvertime += (uint)lcl_obj_Attendance.OvertimeTotal;
                                                //System.Double lcl_dbl_OvertimeAmount = (double)((lcl_obj_Attendance.OvertimeTotal / 60) * lcl_obj_Attendance.PaidPerHour);
                                                //lcl_dbl_TotalOvertimeAmount += lcl_dbl_OvertimeAmount;
                                            }
                                        }

                                        #endregion PROCESS OVERTIME
                                    }
                                }
                            }

                        }
                        #region SUMMERIZE ATTENDANCE MASTER
                        lcl_obj_AttendanceMaster.TotalProcessed += 1;
                        switch (lcl_obj_Attendance.AttnStatus)
                        {
                            case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT:
                            case SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND:
                                lcl_obj_AttendanceMaster.TotalAbsent += 1;
                                //FULL WORK HOUR LOST
                                if (lcl_obj_EmpWorkGroupOperationMaster != null)
                                {
                                    if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOT += 0;
                                    }
                                    else
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOff += 0;
                                    }
                                }
                                break;
                            case SilkERP360.CCL.Enums.AttendanceStatus.LATE:
                                lcl_obj_AttendanceMaster.TotalLate += 1;
                                lcl_obj_AttendanceMaster.TotalPresent += 1;
                                if (lcl_obj_EmpWorkGroupOperationMaster != null)
                                {
                                    if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOT += (uint)((lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal) / 60);
                                    }
                                    else
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOff += (uint)(lcl_obj_Attendance.DutyMinutes / 60);
                                    }
                                }
                                break;
                            case SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY:
                            case SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY:
                            case SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND:
                                lcl_obj_AttendanceMaster.TotalHoliday += 1;
                                break;
                            case SilkERP360.CCL.Enums.AttendanceStatus.PRESENT:
                            case SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                            case SilkERP360.CCL.Enums.AttendanceStatus.OUTSIDE_DUTY:
                                lcl_obj_AttendanceMaster.TotalPresent += 1;
                                if (lcl_obj_EmpWorkGroupOperationMaster != null)
                                {
                                    if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOT += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOT += (uint)((lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal) / 60);
                                    }
                                    else
                                    {
                                        lcl_obj_AttendanceMaster.TotalExpectedManhourOff += lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                                        lcl_obj_AttendanceMaster.TotalManHourServedOff += (uint)(lcl_obj_Attendance.DutyMinutes / 60);
                                    }
                                }
                                break;
                            case SilkERP360.CCL.Enums.AttendanceStatus.ON_LEAVE:
                                lcl_obj_AttendanceMaster.TotalLeave += 1;
                                break;
                        }

                        //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Status : " + lcl_obj_Attendance.AttnStatus.ToString());
                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                        //lcl_obj_EmployeeProfile = null;
                        lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                        #endregion SUMMERIZE ATTENDANCE MASTER

                        #region WORKHOUR SUMMERY

                        #endregion WORKHOUR SUMMERY
                        System.GC.Collect();
                    }
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Present : " + lcl_obj_AttendanceMaster.TotalPresent);
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Absent : " + lcl_obj_AttendanceMaster.TotalAbsent);
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Late : " + lcl_obj_AttendanceMaster.TotalLate);
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total On Leave : " + lcl_obj_AttendanceMaster.TotalLeave);
                    lcl_obj_AttendanceMaster.EntryEmployeeCode = 0;
                    this.m_obj_AttendanceMaster = lcl_obj_AttendanceMaster;
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Saving Attendance to Database!!!");
                    lcl_obj_AttendanceMasterManager.Save(lcl_obj_AttendanceMaster, this.m_obj_DBManager);
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Saved Successful!!!");
                    //Update WorkGroupOperationMaster IsProcessed flag which signifies if the attendance for the WorkGroupOperationMaster
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Updating WorkGroup!!!");
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster in lcl_objLst_WorkGroupMasterList)
                    {
                        lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_MASTER SET IS_PROCESSED = {0} WHERE WG_OPERATION_MASTER_CODE = {1}", (System.UInt16)SilkERP360.CCL.Enums.YesNo.Yes, lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                        this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                    }
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Update Successful!!!");
                    //Attendance Has been processed
                    this.m_obj_DBManager.CommitTransaction();
                    int a1 = 0;
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Total Attendance Processed : " + lcl_obj_AttendanceMaster.AttendanceList.Count.ToString());
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Processed Successfully!!!" + lcl_obj_AttendanceMaster.AttendanceList.Count.ToString());
                    ServiceLog.LogData("**************************************************************************************************************************************************************************");
                    ServiceLog.Flush();
                }
                else
                {
                    //No Profile Found
                    ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => No Employee Profile Found For The Company!!!No Attendance.");
                }

            }
            catch (System.Exception Ex)
            {
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Error : " + Ex.Message);
                throw Ex;
            }
            finally
            {
                //if (this.m_obj_DBManager != null)
                //{
                //    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                //    {
                //        this.m_obj_DBManager.CommitTransaction();
                //        this.m_obj_DBManager.Close();
                //    }
                //}
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
            }
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.Attendance Process(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile IP_obj_EmployeeProfile, System.DateTime IP_dt_AttendanceDate)
        {
            this.m_dt_AttendanceDate = IP_dt_AttendanceDate;
            System.Double lcl_dbl_TotalOvertimeAmount = 0;
            //SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
            //System.Text.StringBuilder lcl_sb_LogBuilder = new StringBuilder();
            try
            {
                /***************************************************************************************************************************/
                //Database Connections
                //SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp; Password=silkerp");
                //lcl_obj_DBManager.Initialize();
                //this.m_obj_DBManager.Open();
                /***************************************************************************************************************************/

                //Employee Profile Generate

                //get Date's WorkGroupMasters
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                lcl_obj_WorkGroupOperationMasterManager.Initialize();
                SilkERP360.BML.HRIS.AttendanceMasterManager lcl_obj_AttendanceMasterManager = new SilkERP360.BML.HRIS.AttendanceMasterManager();
                lcl_obj_AttendanceMasterManager.Initialize();
                SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
                lcl_obj_AttendanceMasterManager.Initialize();
                SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                lcl_obj_EmployeeLeaveApplicationManager.Initialize();

                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WGOM.WORK_GROUP_CODE = WG.WORK_GROUP_CODE WHERE WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_obj_EmployeeProfile.Company.CompanyCode);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objLst_WorkGroupMasterList = lcl_obj_WorkGroupOperationMasterManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);


                lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WG.WORK_GROUP_CODE = WGOM.WORK_GROUP_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_obj_EmployeeProfile.Company.CompanyCode);
                //Get WorkGroup Operation master for the attendance date
                System.Data.DataSet lcl_ds_WorkGroupOperationMaster = new System.Data.DataSet("WorkGroupOperationMaster");

                System.String lcl_str_Query = System.String.Format("SELECT WGOM.* FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP WG ON WG.WORK_GROUP_CODE = WGOM.WORK_GROUP_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy') AND WG.COMPANY_CODE = {1}", IP_dt_AttendanceDate.ToString("dd/M/yyyy"), IP_obj_EmployeeProfile.Company.CompanyCode);
                OracleCommand lcl_obj_WGOMCommand = new OracleCommand(lcl_str_Query, this.m_obj_DBManager.Connection);
                lcl_obj_WGOMCommand.Transaction = this.m_obj_DBManager.Transaction;

                OracleDataAdapter lcl_obj_WGOMAdapter = new OracleDataAdapter(lcl_obj_WGOMCommand);
                lcl_obj_WGOMAdapter.FillSchema(lcl_ds_WorkGroupOperationMaster, System.Data.SchemaType.Source, "WORK_GROUP_OPERATION_MASTER");
                lcl_obj_WGOMAdapter.Fill(lcl_ds_WorkGroupOperationMaster, "WORK_GROUP_OPERATION_MASTER");

                lcl_str_Query = System.String.Format("SELECT WGOH.* FROM WORK_GROUP_OPERATION_HISTORY WGOH JOIN WORK_GROUP_OPERATION_MASTER WGOM ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE WHERE WGOM.WORK_DATE = TO_DATE('{0}','dd/mm/yyyy')", IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                OracleCommand lcl_obj_WGOHCommand = new OracleCommand(lcl_str_Query, this.m_obj_DBManager.Connection);
                lcl_obj_WGOHCommand.Transaction = this.m_obj_DBManager.Transaction;

                OracleDataAdapter lcl_obj_WGOHAdapter = new OracleDataAdapter(lcl_obj_WGOHCommand);
                lcl_obj_WGOHAdapter.FillSchema(lcl_ds_WorkGroupOperationMaster, System.Data.SchemaType.Source, "WORK_GROUP_OPERATION_HISTORY");
                lcl_obj_WGOHAdapter.Fill(lcl_ds_WorkGroupOperationMaster, "WORK_GROUP_OPERATION_HISTORY");
                /***************************************************************************************************************/
                /***************************************************************************************************************/
                //GET ALL LEAVE APPLICATIONS FOR AttendanceDate
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION ELA " +
                                                            "WHERE TO_DATE('{0}','dd/mm/yyyy') BETWEEN ELA.LEAVE_START_DATE AND ELA.LEAVE_END_DATE", IP_dt_AttendanceDate.ToString("dd/M/yyyy"));
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_LeaveApplicationsRepository =
                                    lcl_obj_EmployeeLeaveApplicationManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);
                /***************************************************************************************************************/
                ServiceLog.Flush();
                System.GC.Collect();

                SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_EmpWorkGroupOperationMaster = null;
                System.TimeSpan lcl_obj_DutyHour = System.TimeSpan.MinValue;
                //System.TimeSpan lcl_obj_OvertimeHour = System.TimeSpan.MinValue;

                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => --------------------------------------------------------------------------------------------------------------");
                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Employee Id : " + lcl_obj_EmployeeProfile.EmployeeID + " | Name : " + lcl_obj_EmployeeProfile.EmployeeName);
                System.DateTime lcl_obj_DutyStartDateTime;
                System.UInt32 lcl_ui32_DutyHour = 0;
                System.DateTime lcl_obj_DutyEndDateTime;
                SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = new SilkERP360.CCL.BusinessEntities.HRIS.Attendance();
                lcl_obj_Attendance.EmployeeCode = IP_obj_EmployeeProfile.EmployeeCode;
                lcl_obj_Attendance.EmployeeId = IP_obj_EmployeeProfile.EmployeeID;
                lcl_obj_Attendance.EmployeeName = IP_obj_EmployeeProfile.EmployeeName;
                lcl_obj_Attendance.Department = IP_obj_EmployeeProfile.Department.Name;
                lcl_obj_Attendance.Designation = IP_obj_EmployeeProfile.Designation.Name;
                lcl_obj_Attendance.AttendaneDate = IP_dt_AttendanceDate;
                lcl_obj_Attendance.PaidPerHour = Math.Round(IP_obj_EmployeeProfile.SalaryStructure.Basic / 104, 2);
                lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.None;
                lcl_obj_Attendance.StatusOverrideEmployeeCode = 0;

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication> lcl_objLst_EmployeeLeaveApplication = lcl_objLst_LeaveApplicationsRepository.Where(m => m.EmployeeCode == IP_obj_EmployeeProfile.EmployeeCode).ToList();

                System.Data.DataRow[] lcl_objArr_WorkGroupOperationHistory = lcl_ds_WorkGroupOperationMaster.Tables["WORK_GROUP_OPERATION_HISTORY"].Select("EMPLOYEE_CODE = " + IP_obj_EmployeeProfile.EmployeeCode);

                if (lcl_objArr_WorkGroupOperationHistory.Length == 0)
                {
                    lcl_obj_EmpWorkGroupOperationMaster = null;
                }
                else
                {
                    System.Data.DataRow lcl_obj_WorkGroupOperationHistory = lcl_objArr_WorkGroupOperationHistory[0];
                    System.Data.DataRow lcl_obj_WorkGroupOperationMaster = lcl_ds_WorkGroupOperationMaster.Tables["WORK_GROUP_OPERATION_MASTER"].Select("WG_OPERATION_MASTER_CODE = " + lcl_obj_WorkGroupOperationHistory["WG_OPERATION_MASTER_CODE"].ToString())[0];
                    lcl_obj_EmpWorkGroupOperationMaster = new SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster();
                    lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["WG_OPERATION_MASTER_CODE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["WORK_GROUP_CODE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.WorkDate = System.DateTime.Parse(lcl_obj_WorkGroupOperationMaster["WORK_DATE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.WorkerStrength = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["WORKER_STRENGTH"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int16.Parse(lcl_obj_WorkGroupOperationMaster["OPERATIONAL_STATUS"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["IS_PROCESSED"].ToString()));
                    lcl_obj_EmpWorkGroupOperationMaster.TotalPresent = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_PRESENT"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalAbsent = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_ABSENT"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalLate = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_LATE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalLeave = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_LEAVE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalOff = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_OFF"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.DutyStartFrom = lcl_obj_WorkGroupOperationMaster["DUTY_START_FROM"].ToString();
                    lcl_obj_EmpWorkGroupOperationMaster.DutyHour = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["DUTY_HOUR"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["OVERTIME_LIMIT"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.IsSalaryProcessed = (SilkERP360.CCL.Enums.YesNo)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["IS_PROCESSED_FOR_SALARY"].ToString()));
                    lcl_obj_EmpWorkGroupOperationMaster.DayAttribute = (SilkERP360.CCL.Enums.DayAttribute)(System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["DAY_ATTRIBUTE"].ToString()));
                    lcl_obj_EmpWorkGroupOperationMaster.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_WorkGroupOperationMaster["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalManHour = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_MAN_HOUR"].ToString());
                    lcl_obj_EmpWorkGroupOperationMaster.TotalOvertime = System.UInt32.Parse(lcl_obj_WorkGroupOperationMaster["TOTAL_OVERTIME"].ToString());
                }
                /************************************************************************************************************************/
                //lcl_obj_EmpWorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);

                if (lcl_obj_EmpWorkGroupOperationMaster == null)
                {
                    //STRAY EMPLOYEE : NOT ASSIGNED TO ANY WORKGROUP
                    //lcl_sb_LogBuilder.AppendLine("Not Assigned To Any WorkGroup!");
                    lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
                    lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
                    lcl_obj_Attendance.DutyMinutes = 0;
                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
                    //lcl_sb_LogBuilder.AppendLine("Status : A.N.D");
                    //lcl_obj_AttendanceMaster.TotalAbsent += 1;
                    lcl_obj_Attendance.WorkGroupOperationMasterCode = 0;
                    //lcl_objLst_EmployeeProfile.RemoveAt(0);
                    //lcl_obj_EmployeeProfile = null;
                    //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                }
                else
                {
                    //WorkGroup found for Employee
                    //If Employee From Silkcard and Belongs to 30010000060 (OUTSIDE DUTY)
                    if (lcl_obj_EmpWorkGroupOperationMaster.WorkGroupCode == 30010000060)
                    {
                        lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01\01\01");
                        lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01\01\01");
                        lcl_obj_Attendance.DutyMinutes = 0;
                        lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.OUTSIDE_DUTY;
                        //lcl_sb_LogBuilder.AppendLine("Status : O.S.D");
                        lcl_obj_Attendance.WorkGroupOperationMasterCode = lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode;
                        //lcl_obj_AttendanceMaster.TotalLeave += 1;
                        //lcl_objLst_EmployeeProfile.RemoveAt(0);
                        //lcl_obj_EmployeeProfile = null;
                        //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                    }
                    else
                    {

                        lcl_obj_Attendance.WorkGroupOperationMasterCode = lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode;
                        System.String lcl_str_DutyStartDateTime = IP_dt_AttendanceDate.ToString("dd/MM/yyyy") + " " + lcl_obj_EmpWorkGroupOperationMaster.DutyStartFrom;
                        lcl_obj_DutyStartDateTime = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        System.DateTime lcl_obj_DutyStartSearchDateTime = lcl_obj_DutyStartDateTime.Subtract(new TimeSpan(1, 0, 0));//search for access transaction from 1 hour before start of duty
                        lcl_ui32_DutyHour = lcl_obj_EmpWorkGroupOperationMaster.DutyHour;
                        lcl_obj_DutyEndDateTime = lcl_obj_DutyStartDateTime.AddHours(lcl_ui32_DutyHour);

                        System.DateTime lcl_obj_DutyEndSearchDateTime = System.DateTime.MinValue;
                        if (IP_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                        {
                            lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddMinutes((double)lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit);
                            //Add ADDITIONAL 60 MIN TO EXIT TIME
                            lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddMinutes(60);
                        }
                        else
                        {
                            //FOR NON OVERTIME ELIGIBLE EMPLOYEES
                            lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndDateTime.AddHours(8);
                        }
                        //GET IN & OUT FOR BIOMETRIC ACCESS
                        lcl_obj_Attendance.DutyScheduleFrom = lcl_obj_DutyStartDateTime;
                        lcl_obj_Attendance.DutyScheduleUpto = lcl_obj_DutyEndDateTime;
                        //CHECK BMS_TRANSACTION 
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_REPOSITORY WHERE (TRAN_DATE_TIME >= TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am')) AND (TRAN_DATE_TIME <= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am')) AND RTRIM(EMPLOYEE_ID) = '{2}' ORDER BY TRAN_DATE_TIME ASC", lcl_obj_DutyStartSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_DutyEndSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), IP_obj_EmployeeProfile.EmployeeID.Trim());
                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_BMSRowReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                        if (!(lcl_obj_BMSRowReader.HasRows))
                        {
                            //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
                            lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
                            lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
                            lcl_obj_Attendance.DutyMinutes = 0;
                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT;
                            if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff))
                            {
                                //WorkGroup Has been off. No Need to Check Employee Attendance
                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.HOLIDAY;
                                //lcl_sb_LogBuilder.AppendLine("Status : H");
                            }
                            if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff)
                            {
                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WEEKEND;
                                //lcl_sb_LogBuilder.AppendLine("Status : W");
                            }

                            if (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff)
                            {
                                //WorkGroup Has been off. No Need to Check Employee Attendance
                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY;
                                //lcl_sb_LogBuilder.AppendLine("Status : S.C.H");
                            }
                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                            //lcl_obj_EmployeeProfile = null;
                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                            lcl_obj_BMSRowReader.Close();
                        }
                        else
                        {
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction>();
                            while (lcl_obj_BMSRowReader.Read())
                            {
                                SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction();
                                lcl_obj_BMSTransaction.EmployeeId = lcl_obj_BMSRowReader["EMPLOYEE_ID"].ToString();
                                lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSRowReader["READER_CODE"].ToString();
                                lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSRowReader["READER_NAME"].ToString();
                                //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["READER_CODE"].ToString(),"dd/M/yyyy hh:mm:ss TT",CultureInfo.InvariantCulture);
                                System.String aj = lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString();
                                //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString(), "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString());
                                lcl_objLst_BMSTransaction.Add(lcl_obj_BMSTransaction);
                            }
                            lcl_obj_BMSRowReader.Close();
                            SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_InBMSTransaction = lcl_objLst_BMSTransaction[0];
                            SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_OutBMSTransaction = lcl_objLst_BMSTransaction[(lcl_objLst_BMSTransaction.Count - 1)];
                            //Employees IN & OUT time sorted
                            //SORTED : DUTY_FROM/DUTY_UPTO/DUTY_HOUR/OVERTIME
                            lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;
                            lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;
                            lcl_obj_DutyHour = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyFrom);
                            //lcl_obj_OvertimeHour = lcl_obj_DutyHour;// lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_DutyEndDateTime);
                            lcl_obj_Attendance.DutyMinutes = lcl_obj_DutyHour.TotalMinutes;
                            lcl_obj_Attendance.DutyMinutes = Math.Round(lcl_obj_Attendance.DutyMinutes);
                            lcl_obj_Attendance.InThrough = lcl_obj_InBMSTransaction.ReaderName;
                            lcl_obj_Attendance.InDoorNo = System.UInt32.Parse(lcl_obj_InBMSTransaction.ReaderNo);
                            lcl_obj_Attendance.OutThrough = lcl_obj_OutBMSTransaction.ReaderName;
                            lcl_obj_Attendance.OutDoorNo = System.UInt32.Parse(lcl_obj_OutBMSTransaction.ReaderNo);
                            if ((lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.HolidayOff) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.Off) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ScheduledOff) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.WeekendOff) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.ShiftChangeOff) ||
                                (lcl_obj_EmpWorkGroupOperationMaster.OperationalStatus == SilkERP360.CCL.Enums.WorkGroupOperationalStatus.DutyOnHoliday))
                            {
                                //WorkGroup Has been off. No Need to Check Employee Attendance
                                lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;//.Parse("01\01\01");
                                lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;// Parse("01\01\01");
                                lcl_obj_Attendance.DutyMinutes = lcl_obj_Attendance.DutyMinutes;
                                ///Check For WorkOnHoliday Status
                                ///////////////////////////////////////////////////////////////////////
                                lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY;
                                //lcl_sb_LogBuilder.AppendLine("Status : W.O.H");
                                /******************************************************************************************************************************/
                                //WORK_ON_HOLIDAY Rechecking
                                //Reset DutyEndSearchDateTime
                                if (lcl_obj_Attendance.AttnStatus == SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
                                {
                                    //A.I->12 hours added
                                    if (lcl_ui32_DutyHour == 0)
                                    {
                                        lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddHours(12.0);
                                    }
                                    else
                                    {
                                        lcl_obj_DutyEndSearchDateTime = lcl_obj_DutyEndSearchDateTime.AddHours(6.0);
                                    }
                                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_REPOSITORY WHERE (TRAN_DATE_TIME >= TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am')) AND (TRAN_DATE_TIME <= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am')) AND RTRIM(EMPLOYEE_ID) = '{2}' ORDER BY TRAN_DATE_TIME ASC", lcl_obj_DutyStartSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), lcl_obj_DutyEndSearchDateTime.ToString("dd/M/yyyy hh:mm:ss tt"), IP_obj_EmployeeProfile.EmployeeID.Trim());
                                    lcl_obj_BMSRowReader.Close();
                                    lcl_obj_BMSRowReader = null;
                                    lcl_obj_BMSRowReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                                    while (lcl_obj_BMSRowReader.Read())
                                    {
                                        SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction();
                                        lcl_obj_BMSTransaction.EmployeeId = lcl_obj_BMSRowReader["EMPLOYEE_ID"].ToString();
                                        lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSRowReader["READER_CODE"].ToString();
                                        lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSRowReader["READER_NAME"].ToString();
                                        //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["READER_CODE"].ToString(),"dd/M/yyyy hh:mm:ss TT",CultureInfo.InvariantCulture);
                                        System.String aj = lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString();
                                        //lcl_obj_BMSTransaction.TranDateTime = System.DateTime.ParseExact(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString(), "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                        lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSRowReader["TRAN_DATE_TIME"].ToString());
                                        lcl_objLst_BMSTransaction.Add(lcl_obj_BMSTransaction);
                                    }
                                    lcl_obj_BMSRowReader.Close();
                                    lcl_obj_InBMSTransaction = lcl_objLst_BMSTransaction[0];
                                    lcl_obj_OutBMSTransaction = lcl_objLst_BMSTransaction[(lcl_objLst_BMSTransaction.Count - 1)];

                                    lcl_obj_Attendance.DutyFrom = lcl_obj_InBMSTransaction.TranDateTime;//.Parse("01\01\01");
                                    lcl_obj_Attendance.DutyUpto = lcl_obj_OutBMSTransaction.TranDateTime;// Parse("01\01\01");
                                    lcl_obj_Attendance.DutyMinutes = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyFrom).TotalMinutes;

                                    lcl_obj_Attendance.InThrough = lcl_obj_InBMSTransaction.ReaderName;
                                    lcl_obj_Attendance.InDoorNo = System.UInt32.Parse(lcl_obj_InBMSTransaction.ReaderNo);
                                    lcl_obj_Attendance.OutThrough = lcl_obj_OutBMSTransaction.ReaderName;
                                    lcl_obj_Attendance.OutDoorNo = System.UInt32.Parse(lcl_obj_OutBMSTransaction.ReaderNo);
                                }
                                /******************************************************************************************************************************/
                                //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                //lcl_obj_EmployeeProfile = null;
                                //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                            }
                            else
                            {
                                //get AssessmentStatus of Employee
                                lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0} AND EMPLOYEE_CODE = {1}", lcl_obj_EmpWorkGroupOperationMaster.WorkGroupOperationMasterCode, IP_obj_EmployeeProfile.EmployeeCode);
                                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGOperationHistoryReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                                if (!(lcl_obj_WGOperationHistoryReader.HasRows))
                                {
                                    //Employee Not Assigned To Any WorkGroup. Mark ABSENT
                                    //Employee Scheduled For WorkGroup BUT NO ACTIVITY FOUND -> ABSENT
                                    lcl_obj_Attendance.DutyFrom = System.DateTime.MinValue;//.Parse("01/01/01");
                                    lcl_obj_Attendance.DutyUpto = System.DateTime.MinValue;//.Parse("01/01/01");
                                    lcl_obj_Attendance.InThrough = "";
                                    lcl_obj_Attendance.OutThrough = "";
                                    lcl_obj_Attendance.DutyMinutes = 0;
                                    lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND;
                                    //lcl_sb_LogBuilder.AppendLine("Status : A");
                                    //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                    //lcl_obj_EmployeeProfile = null;
                                    //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                    lcl_obj_WGOperationHistoryReader.Close();
                                }
                                else
                                {
                                    lcl_obj_WGOperationHistoryReader.Read();
                                    //Get Assessment Status Of Employee
                                    SilkERP360.CCL.Enums.AssessmentStatus lcl_enm_EmployeeAttendanceAssessmentStatus = (SilkERP360.CCL.Enums.AssessmentStatus)System.UInt32.Parse(lcl_obj_WGOperationHistoryReader["ASSESSMENT_STATUS"].ToString());
                                    lcl_obj_WGOperationHistoryReader.Close();

                                    /////Check for WORK_ON_HOLIDAY
                                    //PROCESS BASED ON REQUESTED ASSESSMENT_STATUS
                                    if (lcl_enm_EmployeeAttendanceAssessmentStatus == SilkERP360.CCL.Enums.AssessmentStatus.LateArrivalRequested)
                                    {
                                        //Process with late arrival request
                                        System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.LATE_ARRIVAL_GRACE_PERIOD);
                                        System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
                                        if (lcl_i32_Comparison == -1)
                                        {
                                            //Employee Late
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
                                            lcl_obj_Attendance.Remarks = "Late Arrival Requested";
                                            //lcl_sb_LogBuilder.AppendLine("Status : L");
                                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                            //lcl_obj_EmployeeProfile = null;
                                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        }
                                        else
                                        {
                                            //Employee Present and Ontime
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;
                                            lcl_obj_Attendance.Remarks = "Late Arrival Requested";
                                            //lcl_sb_LogBuilder.AppendLine("Status : P");
                                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                            //lcl_obj_EmployeeProfile = null;
                                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        }
                                    }
                                    else
                                    {
                                        //PROCESS EMPLOYEE WITH REGULAR ASSESSMENT_STATUS
                                        //Process with regular arrival
                                        System.DateTime lcl_obj_DutyStartDateTimeWithGracePeriod = lcl_obj_DutyStartDateTime.AddMinutes(AttendanceProcessor.ATTENDANCE_GRACE_PERIOD);
                                        System.Int32 lcl_i32_Comparison = System.TimeSpan.Compare(lcl_obj_InBMSTransaction.TranDateTime.TimeOfDay, lcl_obj_DutyStartDateTimeWithGracePeriod.TimeOfDay);
                                        if (lcl_i32_Comparison == -1)
                                        {
                                            //Employee On time
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.PRESENT;
                                            //lcl_sb_LogBuilder.AppendLine("Status : P");
                                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                            //lcl_obj_EmployeeProfile = null;
                                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        }
                                        else
                                        {
                                            lcl_obj_Attendance.AttnStatus = SilkERP360.CCL.Enums.AttendanceStatus.LATE;
                                            //lcl_sb_LogBuilder.AppendLine("Status : L");
                                            //lcl_objLst_EmployeeProfile.RemoveAt(0);
                                            //lcl_obj_EmployeeProfile = null;
                                            //lcl_obj_AttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                                        }
                                    }
                                }

                            }

                            #region NIGHT ALLOWANCE
                            if (IP_obj_EmployeeProfile.NightBillEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                            {
                                System.Boolean lcl_b_NightDuty = false;
                                if ((lcl_obj_Attendance.DutyFrom != System.DateTime.MinValue) && (lcl_obj_Attendance.DutyUpto != System.DateTime.MinValue))
                                {
                                    for (System.DateTime lcl_dt_DutyDateTime = lcl_obj_Attendance.DutyFrom; lcl_dt_DutyDateTime <= lcl_obj_Attendance.DutyUpto; lcl_dt_DutyDateTime = lcl_dt_DutyDateTime.AddHours(1.0))
                                    {
                                        if (((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(1, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(2, 0, 0))) || //1 AM
                                            ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(2, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(3, 0, 0))) || //2 AM
                                            ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(3, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(4, 0, 0))) || //3 AM
                                            ((lcl_dt_DutyDateTime.TimeOfDay > new TimeSpan(4, 0, 0)) && (lcl_dt_DutyDateTime.TimeOfDay < new TimeSpan(5, 0, 0)))) //4 AM
                                        {
                                            lcl_b_NightDuty = true;

                                        }
                                    }
                                    if (lcl_b_NightDuty == true)
                                    {
                                        lcl_obj_Attendance.NightAllowance = 30;
                                    }
                                }
                            }
                            #endregion
                            #region PROCESS OVERTIME
                            if (IP_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                            {
                                lcl_obj_Attendance.OvertimeEntryType = SilkERP360.CCL.Enums.OvertimeEntryType.Automated;
                                if (lcl_obj_Attendance.AttnStatus == SilkERP360.CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY)
                                {
                                    lcl_obj_Attendance.OvertimeAuto = lcl_obj_Attendance.DutyMinutes;
                                }
                                else
                                {
                                    if (lcl_obj_Attendance.DutyUpto > lcl_obj_Attendance.DutyScheduleUpto)
                                    {
                                        System.TimeSpan lcl_obj_Overtime = lcl_obj_Attendance.DutyUpto.Subtract(lcl_obj_Attendance.DutyScheduleUpto);
                                        lcl_obj_Attendance.OvertimeAuto = lcl_obj_Overtime.TotalMinutes;
                                    }
                                }
                                if (lcl_obj_EmpWorkGroupOperationMaster != null)
                                {
                                    if (lcl_obj_Attendance.OvertimeAuto > lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit)
                                    {
                                        lcl_obj_Attendance.OvertimeAuto = lcl_obj_EmpWorkGroupOperationMaster.OvertimeLimit;
                                    }
                                }
                                /***************************************************************************************************/
                                //Deduct OT if employee is more than 4 hours late
                                if ((lcl_obj_Attendance.DutyFrom - lcl_obj_Attendance.DutyScheduleFrom).Hours > 4)
                                {
                                    lcl_obj_Attendance.OvertimeAuto = 0;
                                    lcl_obj_Attendance.OvertimeTotal = 0;
                                    lcl_obj_Attendance.Remarks = "O.T Deducted due to late by more than 4 hours";
                                }
                                /***************************************************************************************************/

                                lcl_obj_Attendance.OvertimeTotal = lcl_obj_Attendance.OvertimeAuto;
                                //System.Double lcl_dbl_OvertimeAmount = (double)((lcl_obj_Attendance.OvertimeTotal / 60) * lcl_obj_Attendance.PaidPerHour);
                                //lcl_dbl_TotalOvertimeAmount += lcl_dbl_OvertimeAmount;
                            }

                            #endregion PROCESS OVERTIME
                        }
                    }
                }
                System.GC.Collect();
                return lcl_obj_Attendance;
            }
            catch (System.Exception Ex)
            {
                ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Error : " + Ex.Message);
                throw Ex;
            }
            finally
            {
                //if (this.m_obj_DBManager != null)
                //{
                //    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                //    {
                //        this.m_obj_DBManager.CommitTransaction();
                //        this.m_obj_DBManager.Close();
                //    }
                //}
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
            }
        }

        public void Dispose()
        {
            //if (this.m_obj_DBManager != null)
            //{
            //    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
            //    {
            //        this.m_obj_DBManager.CommitTransaction();
            //        this.m_obj_DBManager.Close();
            //    }
            //}
            //this.m_obj_ServiceLog.();
            ServiceLog.Flush();
            //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
            //this.m_obj_ServiceLog.Close();
        }
    }
}
