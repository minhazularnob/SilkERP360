using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace SilkERP360.WebServices.HRIS
{

    /// <summary>
    /// WEB SERVICE_CODE = WS0005
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LeaveService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CancelLeaveApplication(System.UInt64 IP_ui64_LeaveApplicationCode, System.UInt64 IP_ui64_CancelEmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.LeaveService lcl_obj_LeaveService = new SP.HRIS.LeaveService();
                //lcl_obj_LeaveService.Initialize();
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = lcl_obj_LeaveService.CancelLeaveApplication(IP_ui64_LeaveApplicationCode, IP_ui64_CancelEmployeeCode);
                return lcl_obj_WSResponse;
            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeLeaveProfileByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.LeaveSP lcl_obj_LeaveServiceProvider = new SilkERP360.FL.ServiceProviders.HRIS.LeaveSP();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile = lcl_obj_LeaveServiceProvider.GetEmployeeLeaveProfile(IP_ui64_EmployeeCode);
                //var lcl_str_LeaveListJson = new JavaScriptSerializer().Serialize (lcl_objLst_EmployeeLeaveList);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_obj_EmployeeLeaveProfile);
            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }



        }



        /// <summary>
        /// WEB_METHOD_CODE= WM0001
        /// 1. employee leave list
        /// 2. Creates the UserProfile
        /// 3. Sets the Security Context
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <returns></returns> 
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeLeaveList(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.EmployeeLeaveFacade lcl_obj_EmployeeLeaveFacade = new FL.HRIS.EmployeeLeaveFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objLst_EmployeeLeaveList = lcl_obj_EmployeeLeaveFacade.GetEmployeeLeaveList(IP_ui64_CompanyCode);
                //var lcl_str_LeaveListJson = new JavaScriptSerializer().Serialize (lcl_objLst_EmployeeLeaveList);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_EmployeeLeaveList);
            }
       
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
            
        
    
    }
         [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeLeaveListPersonal(System.UInt64 IP_ui64_CompanyCode, System.UInt64 IP_ui64_EmployeeCode)

        {
            try
            {
                SilkERP360.FL.HRIS.EmployeeLeaveFacade lcl_obj_EmployeeLeaveFacade = new FL.HRIS.EmployeeLeaveFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objLst_EmployeeLeaveList = lcl_obj_EmployeeLeaveFacade.GetEmployeeLeaveListPersonal(IP_ui64_CompanyCode,IP_ui64_EmployeeCode);
                //var lcl_str_LeaveListJson = new JavaScriptSerializer().Serialize (lcl_objLst_EmployeeLeaveList);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_EmployeeLeaveList);
            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }



        }

     [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveEmployeeLeaveApplication(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveApplication)
        {
            try
            {

                SilkERP360.FL.ServiceProviders.HRIS.LeaveSP lcl_obj_LeaveServiceSP = new SilkERP360.FL.ServiceProviders.HRIS.LeaveSP();
                lcl_obj_LeaveServiceSP.Initialize();
                System.UInt64 lcl_ui64_LeaveAppCode = lcl_obj_LeaveServiceSP.SaveLeaveApplication(IP_obj_EmployeeLeaveApplication);
                //Get EmployeeLeaveProfile
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile = lcl_obj_LeaveServiceSP.GetEmployeeLeaveProfile(IP_obj_EmployeeLeaveApplication.EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Leave Application Saved Successfully!!Please do the manual deduction in case of Unpaid leave!!", false, lcl_obj_EmployeeLeaveProfile);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

     [System.Web.Services.WebMethod(EnableSession = true)]
     public SilkERP360.CCL.Misc.WSResponse SaveEmployeeLeaveApproved(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveApproved)
     {
         try
         {
             SilkERP360.FL.HRIS.EmployeeLeaveFacade lcl_obj_EmployeeLeaveFacade = new FL.HRIS.EmployeeLeaveFacade();
             System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeLeaveFacade.UpdateLeaveApproved(IP_obj_EmployeeLeaveApproved);

             if (lcl_ui64_EmployeeCode == 0)
             {
                 return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Leave Application Approved", true, lcl_ui64_EmployeeCode);
             }

             return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

         }
         catch (System.Exception Ex)
         {
             return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
         }
     }
     [System.Web.Services.WebMethod(EnableSession = true)]
     public SilkERP360.CCL.Misc.WSResponse UpdateLeaveRecomanded(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveRecommended)
     {
         try
         {
             SilkERP360.FL.HRIS.EmployeeLeaveFacade lcl_obj_EmployeeLeaveFacade = new FL.HRIS.EmployeeLeaveFacade();
             System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeLeaveFacade.UpdateLeaveRecomanded(IP_obj_EmployeeLeaveRecommended);

             if (lcl_ui64_EmployeeCode == 0)
             {
                 return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Leave Application Recomanded", true, lcl_ui64_EmployeeCode);
             }

             return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

         }
         catch (System.Exception Ex)
         {
             return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
         }
     }
    }
    }
