using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.FL.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// WEB SERVICE_CODE = WS0002
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeProfileByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.EmployeeSP lcl_obj_EmployeeSP = new SP.HRIS.EmployeeSP();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeSP.GetEmployeeProfileByEmployeeCode(IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeMiniProfileByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.EmployeeSP lcl_obj_EmployeeSP = new SP.HRIS.EmployeeSP();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = lcl_obj_EmployeeSP.GetMiniEmployeeProfile(IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_EmployeeProfileMini);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeMiniProfileListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.EmployeeSP lcl_obj_EmployeeSP = new FL.ServiceProviders.HRIS.EmployeeSP();
                lcl_obj_EmployeeSP.Initialize();
                
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMini =
                    lcl_obj_EmployeeSP.GetMiniEmplpoyeeProfileListByCompany(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfileMini);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllActiveEmployeeByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.EmployeeSP lcl_obj_EmployeeSP = new FL.ServiceProviders.HRIS.EmployeeSP();
                lcl_obj_EmployeeSP.Initialize();

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMini =
                    lcl_obj_EmployeeSP.GetMiniEmplpoyeeProfileListByCompany(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfileMini);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeProfileListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetEmployeeProfileListByCompanyCode(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeProfileListByDepartment(System.UInt64 IP_ui64_DepartmentCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetEmployeeProfileListByDepartmentCode(IP_ui64_DepartmentCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAvailableEmployeeProfileListByDepartment(System.UInt64 IP_ui64_DepartmentCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetAvailableEmployeeProfileListByDepartmentCode(IP_ui64_DepartmentCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetRoosterAvailableEmployeeProfileListByDepartment(System.UInt64 IP_ui64_DepartmentCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetRoosterAvailableEmployeeProfileListByDepartmentCode(IP_ui64_DepartmentCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetExistingRoosterEmployeeProfileListByDepartment(System.UInt64 IP_ui64_DepartmentCode,System.UInt64 IP_ui64_RoosterMasterCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetExistingRoosterEmployeeProfileListByDepartment(IP_ui64_DepartmentCode, IP_ui64_RoosterMasterCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeDataByDepartment(System.UInt64 IP_ui64_DepartmentCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeDataReader = lcl_obj_SqlFacade.ExecuteDataReader(@"select EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME From EMPLOYEE  Where DEPARTMENT_CODE=" + IP_ui64_DepartmentCode + " And  EMPLOYEE_STATUS =0 AND IS_DELETED = 1");
                if (!(lcl_obj_EmployeeDataReader.HasRows))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Employee List For The Selected Department Not Found!!!", false, null);
                }

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeMN> lcl_objLst_EmployeeMNList = new System.Collections.Generic.List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeMN>();
                while (lcl_obj_EmployeeDataReader.Read())
                {
                    lcl_objLst_EmployeeMNList.Add(new CCL.BusinessEntities.HRIS.DataStructures.EmployeeMN(System.UInt64.Parse(lcl_obj_EmployeeDataReader["EMPLOYEE_CODE"].ToString()),
                        lcl_obj_EmployeeDataReader["EMPLOYEE_ID"].ToString(),
                        lcl_obj_EmployeeDataReader["EMPLOYEE_NAME"].ToString()));
                }
                lcl_obj_SqlFacade.CloseReader();
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_objLst_EmployeeMNList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        /// <summary>
        /// Checks if the provided ACSCode exists in the database
        /// </summary>
        /// <param name="IP_str_ACSCode">ACSCode To Check</param>
        /// <returns>true if ACSCode exists else false. Value wrapped in WSResponse object</returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfACSCodeExists(System.String IP_str_ACSCode)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("SELECT COUNT(*) FROM EMPLOYEE WHERE EMPLOYEE_ACS_CODE = '{0}' AND IS_DELETED = 1", IP_str_ACSCode);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        /// <summary>
        /// Checks if the provided Roster exists in the database
        /// </summary>
        /// <param name="IP_str_ACSCode">ACSCode To Check</param>
        /// <returns>true if Roster exists else false. Value wrapped in WSResponse object</returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfRosterExists(System.String IP_srt_fromdate)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("select count(*)  from employee_rooster where is_deleted=1 and duty_date='{0}'", IP_srt_fromdate);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfVoterIDExists(System.String IP_str_VoterID)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("SELECT COUNT(*) FROM EMPLOYEE_PERSONAL WHERE CITIZEN_CARD_ID = '{0}' AND IS_DELETED = 1", IP_str_VoterID);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfEtinExists(System.String IP_str_eTinID)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("SELECT COUNT(*) FROM EMPLOYEE WHERE TIN = '{0}' AND IS_DELETED = 1", IP_str_eTinID);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        /// <summary>
        /// Passport Validation
        /// </summary>
        /// <param name="IP_str_PassPortID"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfPassPortNoExists(System.String IP_str_PassPortNo)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("SELECT COUNT(*) FROM EMPLOYEE_PERSONAL WHERE PASSPORT_NO = '{0}' AND IS_DELETED = 1", IP_str_PassPortNo 
                    );
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        /// <summary>
        /// Passport Validation
        /// </summary>
        /// <param name="IP_str_PassPortID"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse DownloadCertificate(ulong certificateCode)
        {
            try
            {
                EmployeeCertificate employeeCertificate = null;
                EmployeeFacade employeeFacade = new EmployeeFacade();
                employeeCertificate = employeeFacade.DownloadCertificate(certificateCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, employeeCertificate);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        /// <summary>
        /// /////////////
        /// </summary>
        /// <param name="IP_obj_EmployeeAppoinment"></param>
        /// <returns></returns>

        [System.Web.Services.WebMethod(EnableSession=true)]
        public SilkERP360.CCL.Misc.WSResponse SaveEmployeeAppoinment(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment IP_obj_EmployeeAppoinment)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeAppoinmentFacade lcl_obj_EmployeeAppoinmentFacade = new FL.HRIS.DataStructures.EmployeeAppoinmentFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeAppoinmentFacade.Save(IP_obj_EmployeeAppoinment);


                System.String lcl_str_Query = System.String.Format(@"select E.EMPLOYEE_ID,E.employee_name,d.degn_name,dp.DEPT_NAME,c.name,TO_char(JOINING_DATE,'dd-Mon-yyyy')JOINING_DATE From employee E 
                                                                        inner join DESIGNATION D on e.designation_code=d.designation_code
                                                                        inner join DEPARTMENT Dp on e.department_code=dp.department_code
                                                                        inner join COMPANY C on e.company_code=c.company_code
                                                                        where E.EMPLOYEE_CODE = {0} AND E.IS_DELETED = 1", lcl_ui64_EmployeeCode);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeIDReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_Query);
                lcl_obj_EmployeeIDReader.Read();
                System.String lcl_str_EmployeeID = lcl_obj_EmployeeIDReader["EMPLOYEE_ID"].ToString();
                System.String lcl_str_Company = lcl_obj_EmployeeIDReader["name"].ToString();
                System.String lcl_str_EmployeeName = lcl_obj_EmployeeIDReader["employee_name"].ToString();
                System.String lcl_str_Designation = lcl_obj_EmployeeIDReader["degn_name"].ToString();
                System.String lcl_str_Jdate = lcl_obj_EmployeeIDReader["JOINING_DATE"].ToString();
                System.String lcl_str_Department = lcl_obj_EmployeeIDReader["DEPT_NAME"].ToString();
                lcl_obj_SqlFacade.Close();

                if (lcl_ui64_EmployeeCode > 0)
                {
                    System.Text.StringBuilder lcl_obj_AppoinmentSummery = new System.Text.StringBuilder();
                    lcl_obj_AppoinmentSummery.Append("<table style='width:60%;'><caption>Appoinment Summery</caption>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Employee ID</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_EmployeeID);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Name</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_EmployeeName);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Designation</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Designation);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");


                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Date of Join</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Jdate);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Department</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Department);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Company</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Company);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");


                    lcl_obj_AppoinmentSummery.Append("</table>");
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success,0,"",  true, lcl_obj_AppoinmentSummery.ToString());
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateEmployeeAppoinment(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment IP_obj_EmployeeAppoinment)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeAppoinmentFacade lcl_obj_EmployeeAppoinmentFacade = new FL.HRIS.DataStructures.EmployeeAppoinmentFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeAppoinmentFacade.Save(IP_obj_EmployeeAppoinment);





                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Employee Informantion Edit Successfully", false, lcl_ui64_EmployeeCode);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse ChangeEmployeeStatus(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeStatusHistory IP_obj_EmployeeStatusHistory)
        {
            try
            {
                SilkERP360.FL.HRIS.EmployeeFacade lcl_obj_EmployeeFacade = new FL.HRIS.EmployeeFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeFacade.Save(IP_obj_EmployeeStatusHistory);
                if (lcl_ui64_EmployeeCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "The status of the Employee has been changed successfully!", true, lcl_ui64_EmployeeCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIifLeaveApp(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                System.String lcl_str_Query = System.String.Format("select count(*) from employee_leave_application where employee_code={0} and is_approved is null and is_recommended is  null", IP_ui64_EmployeeCode
                    );
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Object lcl_obj_Return = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_Query);
                lcl_obj_SqlFacade.Close();
                if (System.Int32.Parse(lcl_obj_Return.ToString()) > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetLeaveApplicationList(System.UInt64 IP_ui64_LeaveListCode, System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetLeaveApplicationList(IP_ui64_LeaveListCode, IP_ui64_CompanyCode);


                if (lcl_objLst_EmployeeProfile.Count() > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Data not found", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeIdCardInfo(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeIdCardInfo lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileFacade.GetEmployeeIdCardInfo(IP_ui64_EmployeeCode);


                if (lcl_objLst_EmployeeProfile != null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProfile);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Data not found", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetSalaryAditionDeduction(System.UInt64 IP_iu64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                    lcl_obj_EmployeeProfileFacade.GetEmployeeSalaryAddDed(IP_iu64_EmployeeCode);


                if (lcl_objLst_EmployeeProfile.Count() > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Salary changed successfully! ", true, lcl_objLst_EmployeeProfile);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Data not found", true, lcl_objLst_EmployeeProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

       


    }
}
