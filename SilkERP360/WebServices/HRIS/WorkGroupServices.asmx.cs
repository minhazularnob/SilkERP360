using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for WorkGroupServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WorkGroupServices : System.Web.Services.WebService
    {



        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateWorkGroupOperationMaster(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile IP_obj_WorkGroupOperationMasterProfile)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroupSP.Initialize();
                System.Int32 Response = lcl_obj_WorkGroupSP.UpdateWorkGroupOperationMaster(IP_obj_WorkGroupOperationMasterProfile);
                if (Response == -1)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -1, "Status : Edit/Update Denied!!Attendance Has already been processed!!!", true, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Status : Edit/Update Successful!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetWorkGroupSchedule(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> lcl_objLst_WorkGroupOperationMasterProfile = lcl_obj_WorkGroupSP.GetWorkGroupSchedules(IP_ui64_CompanyCode, IP_dt_Date);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : Employees Included In The Work Group!!!", true, lcl_objLst_WorkGroupOperationMasterProfile);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeWorkGroupScheduleByDate(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> lcl_objLst_EmployeeWorkGroupSchedule = lcl_obj_WorkGroupSP.GetEmployeeWorkGroupScheduleByDate(IP_ui64_CompanyCode, IP_dt_Date);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : Employees Included In The Work Group!!!", true, lcl_objLst_EmployeeWorkGroupSchedule);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SynchronizeEmployeeInclusion(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_IncludedWorkGroupOperationHistory)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroupSP.SynchronizeEmployeeInclusion(IP_objLst_IncludedWorkGroupOperationHistory);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : Employees Included In The Work Group!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SynchronizeEmployeeRemoval(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroupSP.SynchronizeEmployeeRemoval(IP_objLst_DeletableWorkGroupOperationHistory);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : Employees Removed From The Work Group!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SynchronizeEmployeeAssessmentStatus(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_UpdateableWorkGroupOperationHistory)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroupSP.SynchronizeEmployeeAssessmentStatus(IP_objLst_UpdateableWorkGroupOperationHistory);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : Assessment Status Of Employees Has Been Synchronised!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SynchronizeWorkGroupOperationMaster(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_InsertableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_EditableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroupSP.SynchronizeWorkGroupOperationHistory(IP_objLst_InsertableWorkGroupOperationHistory,
                                                                         IP_objLst_EditableWorkGroupOperationHistory,
                                                                         IP_objLst_DeletableWorkGroupOperationHistory);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : WorkGroup Operation Master Synchronised Successfully!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        //public SilkERP360.CCL.Misc.WSResponse Synchronize


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveWorkGroupOperationMaster(SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_WorkGroupOperationMaster)
        {
            try
            {
                SilkERP360.FL.HRIS.WorkGroupOperationMasterFacade lcl_obj_WorkGroupOperationMasterFacade = new FL.HRIS.WorkGroupOperationMasterFacade();
                System.UInt64 lcl_ui64_Code = lcl_obj_WorkGroupOperationMasterFacade.Save(IP_obj_WorkGroupOperationMaster);
                IP_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode = lcl_ui64_Code;
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Success : WorkGroup Operation Master Configured Successfully!!!", true, IP_obj_WorkGroupOperationMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveWorkGroupOperationMasterByDateRange(System.DateTime IP_dt_DateFrom, System.DateTime IP_dt_DateUpto, SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_WorkGroupOperationMaster)
        {
            try
            {
                SilkERP360.SP.HRIS.WorkGroupServices lcl_obj_WorkGroupServices = new SP.HRIS.WorkGroupServices();
                lcl_obj_WorkGroupServices.Initialize();
                lcl_obj_WorkGroupServices.SaveWorkGroupOperationMasterByDateRange(IP_dt_DateFrom, IP_dt_DateUpto, IP_obj_WorkGroupOperationMaster);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, 0, "Designated WorkGroup Has Benn Configured Successfully for the date range specified!!!", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetWorkGroupDetailsByDate(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_Date)
        {
            try
            {
                SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
                SilkERP360.FL.ServiceProviders.HRIS.WorkGroupSP lcl_obj_WorkGroupSP = new FL.ServiceProviders.HRIS.WorkGroupSP();
                lcl_obj_WorkGroup = lcl_obj_WorkGroupSP.ProvideWorkGroupDetailsByDate(IP_ui64_WorkGroupCode, IP_dt_Date);

                if (lcl_obj_WorkGroup == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Fatal Error : Invalid Work Group Selected!!!", true, null);
                }
                if (lcl_obj_WorkGroup.WorkGroupOperationMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -2, "Operational Info : Work Group Master Has Not Yet Been Configured!!!", true, null);
                }
                if (lcl_obj_WorkGroup.WorkGroupOperationMaster.WorkGroupOperationHistoryCollection.Count == 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -3, "Operational Info : Work Group Master Configured. But No Employee Has Been Included!!!", true, lcl_obj_WorkGroup.WorkGroupOperationMaster);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Operational Info : Work Group Data Retrieved Successfully!!!", true, lcl_obj_WorkGroup.WorkGroupOperationMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_CompanyCode">Which company Work Group the employee is included</param>
        /// <param name="IP_str_EmployeeId"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckEmployeeProfileAndWorkGroupSchedule(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_WorkDate, System.String IP_str_EmployeeId)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
            System.String lcl_str_Message = System.String.Empty;
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = null;
            System.String lcl_str_SqlQuery = System.String.Empty;
            System.UInt64 lcl_ui64_EmployeeCode = 0;
            System.String lcl_str_EmployeeId = IP_str_EmployeeId.ToUpper();
            IP_str_EmployeeId = lcl_str_EmployeeId;
            try
            {
                if (IP_str_EmployeeId.Trim() == "")
                {
                    lcl_str_Message = System.String.Format("Operational Error : Blank Employee ID provided");
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, lcl_str_Message, true, null);
                }
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
                if (!r.IsMatch(IP_str_EmployeeId))
                {
                    //If File line contains anything other than only alpha numeric character
                    //Refuse File

                    lcl_str_Message = System.String.Format("Operational Error : Invalid Characters Found In '{0}'!!!", IP_str_EmployeeId);
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -2, lcl_str_Message, true, null);
                    //return lcl_obj_WSResponse;
                }
                lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE WHERE EMPLOYEE_ID = '{0}'", IP_str_EmployeeId);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    //Employee ID does not exist in the database
                    //Refuse File Upload
                    lcl_str_Message = System.String.Format("Operational Error : The Employee Id '{0}' is Invalid!!!", IP_str_EmployeeId);
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -3, lcl_str_Message, true, null);
                    //return lcl_obj_WSResponse;
                }
                else
                {
                    //Employee ID exist in the database
                    lcl_obj_EmployeeReader.Read();
                    lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                    //Check if employee belongs to selected company
                    System.UInt64 lcl_ui64_TmpCompanyCode = System.UInt64.Parse(lcl_obj_EmployeeReader["COMPANY_CODE"].ToString());
                    if (lcl_ui64_TmpCompanyCode != IP_ui64_CompanyCode)
                    {
                        lcl_str_Message = System.String.Format("Operational Error : The Employee Id '{0}' does not belong to the selected company!!!", IP_str_EmployeeId);
                        lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -4, lcl_str_Message, true, null);
                        //return lcl_obj_WSResponse;
                    }
                    else
                    {
                        //check if Employee is active
                        SilkERP360.CCL.Enums.EmployeeStatus lcl_enm_EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)System.Int16.Parse(lcl_obj_EmployeeReader["EMPLOYEE_STATUS"].ToString());
                        if (!((lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Regular) || (lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Probation) || (lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Temporary)))
                        {
                            //Inactive Employee Id found in file
                            lcl_str_Message = System.String.Format("Operational Error : The Employee Id '{0}' has either resigned or been terminated!!!", IP_str_EmployeeId);
                            lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -5, lcl_str_Message, true, null);
                            //return lcl_obj_WSResponse;
                        }
                        else
                        {
                            //EmployeeId ok
                            lcl_obj_EmployeeReader.Close();
                            //Check if Employee Id already assigned to a WorkGroup for the particular date
                            lcl_str_SqlQuery = System.String.Format("SELECT WG_OP_MSTR.*, WG_OP_HSTRY.* " +
                                                                    "FROM WORK_GROUP_OPERATION_MASTER WG_OP_MSTR JOIN WORK_GROUP_OPERATION_HISTORY WG_OP_HSTRY " +
                                                                    "ON WG_OP_MSTR.WG_OPERATION_MASTER_CODE = WG_OP_HSTRY.WG_OPERATION_MASTER_CODE " +
                                                                    "WHERE WG_OP_MSTR.WORK_DATE = TO_DATE('{0}','DD/MM/YYYY') AND WG_OP_HSTRY.EMPLOYEE_CODE = {1} AND IS_DELETED = 0", IP_dt_WorkDate.ToString("dd/MM/yyyy"), lcl_ui64_EmployeeCode);

                            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupOperationReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);

                            if (lcl_obj_WorkGroupOperationReader.HasRows)
                            {
                                //employee already assigned to a WorkGroup 
                                lcl_str_Message = System.String.Format("Operational Error : The Employee Id '{0}' has already been assigned to a WorkGroup on '{1}'", IP_str_EmployeeId, IP_dt_WorkDate.ToString("dd/MM/yyyy"));
                                lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -6, lcl_str_Message, true, null);
                                //return lcl_obj_WSResponse;
                            }
                            else
                            {
                                lcl_obj_WorkGroupOperationReader.Close();
                                //File OK and all Employee Ids OK.Get EmployeeProfile for employees
                                //If control comes to point,All Employee Ids ok.
                                //Generate EmployeeProfile for each uploaded employee
                                lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.*,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        WHERE EMP.EMPLOYEE_ID = ('{0}')", IP_str_EmployeeId);
                                SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                                //always returns a single object
                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileFacade.GetListWithoutImage(lcl_str_SqlQuery);
                                //lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileFacade.GetListWithoutImage(lcl_str_SqlQuery);
                                if ((lcl_objLst_EmployeeProfile.Count == 0) || (lcl_objLst_EmployeeProfile == null))
                                {
                                    //Could not find Employee Profile
                                    lcl_str_Message = System.String.Format("Operational Error : Profile Could Not Be generated for the Employee Id '{0}' !!!", IP_str_EmployeeId);
                                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -7, lcl_str_Message, true, null);
                                    //return lcl_obj_WSResponse;
                                }
                                else
                                {

                                    //ALL OK. ALL PROFILE FOUND
                                    lcl_str_Message = System.String.Format("Profile Generation Successfull : Employee Id '{0}'", IP_str_EmployeeId);
                                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_objLst_EmployeeProfile[0];
                                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, lcl_str_Message, true, lcl_obj_EmployeeProfile);
                                }
                            }
                        }
                    }
                }
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
