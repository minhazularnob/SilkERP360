using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// WEB SERVICE_CODE = WS0003
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AttendanceService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeewiseAttendanceByDateRange(System.UInt64 IP_ui64_EmployeeCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange lcl_obj_EmployeewiseAttendanceByDateRange = lcl_obj_AttendanceSP.GetEmployeewiseAttendanceByDateRange(IP_ui64_EmployeeCode, IP_dt_StartDate, IP_dt_EndDate);
                if (lcl_obj_EmployeewiseAttendanceByDateRange == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Unknown Error!!Contact SSL!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_EmployeewiseAttendanceByDateRange);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAttendanceSummery(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_DateFrom, System.DateTime IP_dt_DateUpto)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster lcl_obj_EmployeeAttendanceSummeryMaster = lcl_obj_AttendanceSP.GetAttendanceSummery(IP_ui64_CompanyCode, IP_dt_DateFrom, IP_dt_DateUpto);
                if (lcl_obj_EmployeeAttendanceSummeryMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Unknown Error!!Contact SSL!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_EmployeeAttendanceSummeryMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetBiometricTransactionByDateRange(System.UInt64 IP_ui64_EmployeeCode, System.DateTime IP_dt_StartDate,System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransaction = lcl_obj_AttendanceSP.GetBiometricTransactionListByDateRange(IP_ui64_EmployeeCode, IP_dt_StartDate, IP_dt_EndDate);
                if (lcl_objLst_BMSTransaction == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Invalid Employee", false, null);
                }
                if (lcl_objLst_BMSTransaction.Count == 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 2, "", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_objLst_BMSTransaction);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse AdjustOvertime(System.UInt64 IP_ui64_AttendanceCode, System.Int32 IP_i32_OvertimeAdjustment, System.UInt64 IP_ui64_OvertimeAdjustmentEmpCode, System.String IP_str_Remarks)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                System.Boolean lcl_b_Adjusted = lcl_obj_AttendanceSP.AdjustOvertime(IP_ui64_AttendanceCode,IP_i32_OvertimeAdjustment, IP_ui64_OvertimeAdjustmentEmpCode, IP_str_Remarks);
                if (lcl_b_Adjusted == false)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Employee is Not Overtime Eligible!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

       /// <summary>
       /// //
       /// 1. Check If Concerned employee is Overtime Eligble
       
       /// </summary>
       /// <param name="IP_ui64_AttendanceCode"></param>
       /// <param name="IP_enm_AttendanceStatus"></param>
       /// <param name="IP_i32_OvertimeAdjustment"></param>
       /// <param name="IP_str_Remarks"></param>
       /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateAttendanceStatus(System.UInt64 IP_ui64_AttendanceCode,SilkERP360.CCL.Enums.AttendanceStatus IP_enm_AttendanceStatus,System.String IP_str_Remarks)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                //Append Datetime stamp after Remarks
                IP_str_Remarks += " >> At " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString() + " ||";
                lcl_obj_AttendanceSP.UpdateAttendanceStatus(IP_ui64_AttendanceCode, IP_enm_AttendanceStatus, IP_str_Remarks);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAttendanceMaster(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_AttendanceDate)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                lcl_obj_AttendanceSP.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_obj_AttendanceSP.GetAttendanceMasterByCompanyDate(IP_ui64_CompanyCode, IP_dt_AttendanceDate);
                if (lcl_obj_AttendanceMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Attendance Has Not Yet Been Processed For Selected Company!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_AttendanceMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_Date"></param>
        /// <returns>
        /// WSResponse.ResponseCode = 0 -> All OK. Attendance processed and data found. Return AttendanceMaster
        /// WSResponse.ResponseCode = -1 -> Attendance Not Yet Processed
        /// WSResponse.ResponseCode = -100 -> Critical System Error
        /// </returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAttendanceByGroupAndDate(System.UInt64 IP_ui64_WorkGroupCode,System.DateTime IP_dt_AttendanceDate)
        {
            try
            {
                SilkERP360.SP.HRIS.AttendanceSP lcl_obj_AttendanceSP = new SP.HRIS.AttendanceSP();
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_obj_AttendanceSP.GetAttendanceMasterByWorkGroupAndDate(IP_ui64_WorkGroupCode, IP_dt_AttendanceDate);
                if (lcl_obj_AttendanceMaster == null)
                {
                    //Attendance Not Yet Processed
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "No Employee Has Been Assigned to the Shift or The Shift Attendance Has not yet been Processed!!!", false, null);
                }
                //all ok
                //SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_objLst_AttendanceMaster[0];
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_AttendanceMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_Date"></param>
        /// <returns>
        /// WSResponse.ResponseCode = 0 -> All OK. Attendance processed and data found. Return AttendanceMaster
        /// WSResponse.ResponseCode = -1 -> Attendance Not Yet Processed
        /// WSResponse.ResponseCode = -100 -> Critical System Error
        /// </returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAttendanceByDesignationAndDate(System.UInt64 IP_ui64_DesignationCode, System.DateTime IP_dt_AttendanceDate)
        {
            try
            {
                SilkERP360.SP.HRIS.AttendanceSP lcl_obj_AttendanceSP = new SP.HRIS.AttendanceSP();
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_obj_AttendanceSP.GetAttendanceMasterByDesignationAndDate(IP_ui64_DesignationCode, IP_dt_AttendanceDate);
                if (lcl_obj_AttendanceMaster == null)
                {
                    //Attendance Not Yet Processed
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "No Employee Found in the Database with the Selected Designation!!!", false, null);
                }
                //all ok
                //SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_objLst_AttendanceMaster[0];
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_AttendanceMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAttendanceByDesignationListAndDate(SilkERP360.CCL.Enums.WellpacSection IP_enm_Section, System.DateTime IP_dt_AttendanceDate)
        {
            try
            {
                System.Collections.Generic.List<System.UInt64> lcl_ui64Lst_DesignationCodes = new List<ulong>();

                switch (IP_enm_Section)
                {
                    case CCL.Enums.WellpacSection.AllSection:
                        break;
                    case CCL.Enums.WellpacSection.Blowing:
                        lcl_ui64Lst_DesignationCodes.Add(112000000057);
                        lcl_ui64Lst_DesignationCodes.Add(112000000058);
                        lcl_ui64Lst_DesignationCodes.Add(112000000059);
                        lcl_ui64Lst_DesignationCodes.Add(112000000060);
                        lcl_ui64Lst_DesignationCodes.Add(112000000261);
                        lcl_ui64Lst_DesignationCodes.Add(112000000210);
                        lcl_ui64Lst_DesignationCodes.Add(112000000061);
                        lcl_ui64Lst_DesignationCodes.Add(112000000062);
                        lcl_ui64Lst_DesignationCodes.Add(112000000064);
                        lcl_ui64Lst_DesignationCodes.Add(112000000247);
                        lcl_ui64Lst_DesignationCodes.Add(112000000063);
                        break;
                    case CCL.Enums.WellpacSection.Cutting:
                        lcl_ui64Lst_DesignationCodes.Add(112000000065);
                        lcl_ui64Lst_DesignationCodes.Add(112000000066);
                        lcl_ui64Lst_DesignationCodes.Add(112000000067);
                        lcl_ui64Lst_DesignationCodes.Add(112000000068);
                        lcl_ui64Lst_DesignationCodes.Add(112000000069);
                        lcl_ui64Lst_DesignationCodes.Add(112000000172);
                        lcl_ui64Lst_DesignationCodes.Add(112000000257);
                        break;
                    case CCL.Enums.WellpacSection.ManualWork:
                       // lcl_ui64Lst_DesignationCodes.Add(112000000073);
                       // lcl_ui64Lst_DesignationCodes.Add(112000000260);
                        
                        break;
                    case CCL.Enums.WellpacSection.Mixing:
                        lcl_ui64Lst_DesignationCodes.Add(112000000089);
                        lcl_ui64Lst_DesignationCodes.Add(112000000090);
                        lcl_ui64Lst_DesignationCodes.Add(112000000222);
                        lcl_ui64Lst_DesignationCodes.Add(112000000258);
                        break;
                    case CCL.Enums.WellpacSection.Packaging:
                        lcl_ui64Lst_DesignationCodes.Add(112000000070);
                        lcl_ui64Lst_DesignationCodes.Add(112000000223);
                        lcl_ui64Lst_DesignationCodes.Add(112000000259);
                        lcl_ui64Lst_DesignationCodes.Add(112000000252);
                        lcl_ui64Lst_DesignationCodes.Add(112000000286);
                        break;
                    case CCL.Enums.WellpacSection.ProductionSupervision:
                        lcl_ui64Lst_DesignationCodes.Add(112000000170);
                        lcl_ui64Lst_DesignationCodes.Add(112000000292);
                        break;
                    case CCL.Enums.WellpacSection.Recycle:
                        lcl_ui64Lst_DesignationCodes.Add(112000000072);
                        lcl_ui64Lst_DesignationCodes.Add(112000000073);
                        lcl_ui64Lst_DesignationCodes.Add(112000000221);
                        lcl_ui64Lst_DesignationCodes.Add(112000000167);
                        lcl_ui64Lst_DesignationCodes.Add(112000000260);
                        lcl_ui64Lst_DesignationCodes.Add(112000000071);
                        break;
                }

                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = null;
                if (lcl_ui64Lst_DesignationCodes.Count == 0)
                {
                    //ALL SECTION SELECTED
                    FL.ServiceProviders.HRIS.AttendanceSP lcl_obj_AttendanceSP = new FL.ServiceProviders.HRIS.AttendanceSP();
                    lcl_obj_AttendanceSP.Initialize();
                    lcl_obj_AttendanceMaster = lcl_obj_AttendanceSP.GetAttendanceMasterByCompanyDate(110000000002, IP_dt_AttendanceDate);
                }
                else
                {
                    SilkERP360.SP.HRIS.AttendanceSP lcl_obj_AttendanceSP = new SP.HRIS.AttendanceSP();
                    lcl_obj_AttendanceMaster = lcl_obj_AttendanceSP.GetAttendanceMasterByDesignationListAndDate(lcl_ui64Lst_DesignationCodes, IP_dt_AttendanceDate);
                }
                if (lcl_obj_AttendanceMaster == null)
                {
                    //Attendance Not Yet Processed
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "No Employee Found in the Database with the Selected Designation!!!", false, null);
                }
                //all ok
                //SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_objLst_AttendanceMaster[0];
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_AttendanceMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_Date"></param>
        /// <returns>
        /// WSResponse.ResponseCode = 0 -> All OK. Attendance processed and List<Attendance> returned
        /// WSResponse.ResponseCode = -1 -> WorkGroup not yet configured
        /// </returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse ProcessAttendanceByGroupAndDate(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_Date)
        {
            try
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE_MASTER WHERE WORK_GROUP_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_Date.ToString("dd/MM/yyyy"));
                SilkERP360.FL.HRIS.AttendanceMasterFacade lcl_obj_AttendanceMasterFacade = new FL.HRIS.AttendanceMasterFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objLst_AttendanceMaster = lcl_obj_AttendanceMasterFacade.GetList(lcl_str_SqlQuery);
                if ((lcl_objLst_AttendanceMaster == null) || (lcl_objLst_AttendanceMaster.Count == 0))
                {
                    //Attendance Not Yet Processed
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Attendance Not Yet Processed!!!", false, null);
                }
                //all ok
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = lcl_objLst_AttendanceMaster[0];
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_AttendanceMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveAttendance(SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster IP_obj_AttendanceMaster)
        {
            throw new NotImplementedException();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse ReceiveAttandaneceData(System.String IP_str_AttandenceData)
        {
            try
            {
                SilkERP360.CCL.BusinessEntities.HRIS.AcsFile lcl_obj_AcsFile = new SilkERP360.CCL.BusinessEntities.HRIS.AcsFile();
               
                //string CSVFilePathName = Ip_str_AttandenceData;
                string[] Lines = IP_str_AttandenceData.Split('\n');
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });

                //1st row must be column names; force lower case to ensure matching later on.
                
                for (int i = 1; i < Lines.GetLength(0)-1; i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });
                    SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow lcl_obj_AcsFileRow = new CCL.BusinessEntities.HRIS.AcsFileRow();
                    string cardid= Fields[10].ToString();
                    if (cardid != "FFFFFFFFFF")
                    {
                    lcl_obj_AcsFileRow.CardOREmpId = Fields[10].ToString().PadLeft(10,'0');
                    lcl_obj_AcsFileRow.ReaderName = Fields[9].ToString();
                    lcl_obj_AcsFileRow.TransactionType = (Fields[3] == SilkERP360.CCL.Enums.AccessControlTransactionType.Ca.ToString())
                        ? SilkERP360.CCL.Enums.AccessControlTransactionType.Ca : SilkERP360.CCL.Enums.AccessControlTransactionType.Cb;
                    //DateTime dd =Convert.ToDateTime(Fields[1].ToString("dd/mmm/yyyy"));
                    //string tt = Fields[2].ToString();
                        lcl_obj_AcsFileRow.TransectionDateTime =  Convert.ToDateTime(Fields[1].ToString() + " " + Fields[2].ToString());
                    lcl_obj_AcsFile.AcsFileRows.Add(lcl_obj_AcsFileRow);
                    }
                }
                SilkERP360.FL.HRIS.AcsFileFacade lcl_obj_AcsFileFacade = new SilkERP360.FL.HRIS.AcsFileFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_AcsFileFacade.Save(lcl_obj_AcsFile);

                

                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Data read Successfully", true, 0);
            }

            
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse AttandaneceProcess(SilkERP360.CCL.BusinessEntities.HRIS.Base.AttandanceCore IP_obj_AttandanceCore)
        {
            try
            {
                throw new NotImplementedException();

                //SilkERP360.FL.HRIS.AttandanceProcessFacade lcl_obj_AttandanceProcessFacade = new SilkERP360.FL.HRIS.AttandanceProcessFacade();
                //System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_AttandanceProcessFacade.SaveAttandanceProcess(IP_obj_AttandanceCore);
                //return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Attendance Processed Successfully", true, null);
            }


            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetInOutDepartmentwise(System.UInt64 IP_ui64_CompanyCode, System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_PunchDate)
        {
            try
            {
                throw new NotImplementedException();
                //SilkERP360.FL.HRIS.AttandanceProcessFacade lcl_obj_EmployeeAttendance = new SilkERP360.FL.HRIS.AttandanceProcessFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.ExtendedAttendanceData> lcl_objLst_EmployeeInOut =
                //    lcl_obj_EmployeeAttendance.GetInOutDepartmentwise(IP_ui64_CompanyCode, IP_ui64_DepartmentCode, IP_str_PunchDate);
                //return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeInOut);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


    }
}
