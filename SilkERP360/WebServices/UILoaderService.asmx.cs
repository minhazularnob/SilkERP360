using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices
{
    /// <summary>
    /// WEB SERVICE_CODE = WS0001
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //o al Tlow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UILoaderService : SilkERP360.CCL.Misc.SilkWebService, System.Web.SessionState.IRequiresSessionState
    {
        public UILoaderService()
        {
            this.Initialize();
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public SilkERP360.CCL.Misc.WSResponse GetUIFromPath(System.String IP_str_VirtualPath)
        {
            try
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                //this.Session["comp_c"] = IP_ui64_CompanyCode.ToString();
                SilkERP360.UI.UIDynamicLoader lcl_obj_DynamicLoader = new SilkERP360.UI.UIDynamicLoader();
                System.String lcl_str_ControlHTML = lcl_obj_DynamicLoader.Load(IP_str_VirtualPath);
                if (this.Context.Response.StatusCode == 500)
                {
                    //Status Code 500 set in the UIExceptionHandler
                    System.String lcl_str_ErrorMessage = this.Session["err_msg"].ToString();
                    this.Session.Remove("err_msg");
                    lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_str_ErrorMessage, false, null);
                    return lcl_obj_WSResponse;
                }
                lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_str_ControlHTML);
                return lcl_obj_WSResponse;
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException uiEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uiEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException uipEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uipEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, pEx.Message, false, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionLogger lcl_obj_ExceptionManager = new SilkERP360.CCL.ExceptionManagement.ExceptionLogger();
                System.String lcl_str_ErrorMessage = lcl_obj_ExceptionManager.LogException(Ex);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, lcl_str_ErrorMessage, false, null);
            }

        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public SilkERP360.CCL.Misc.WSResponse GetUI(System.UInt64 IP_ui64_CompanyCode,System.String IP_str_VirtualPath)
        {
            try
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                this.Session["comp_c"] = IP_ui64_CompanyCode.ToString();
                SilkERP360.UI.UIDynamicLoader lcl_obj_DynamicLoader = new SilkERP360.UI.UIDynamicLoader();
                System.String lcl_str_ControlHTML = lcl_obj_DynamicLoader.Load(IP_str_VirtualPath);
                if (this.Context.Response.StatusCode == 500)
                {
                    //Status Code 500 set in the UIExceptionHandler
                    System.String lcl_str_ErrorMessage = this.Session["err_msg"].ToString();
                    this.Session.Remove("err_msg");
                    lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_str_ErrorMessage, false, null);
                    return lcl_obj_WSResponse;
                }
                lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_str_ControlHTML);
                return lcl_obj_WSResponse;
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException uiEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uiEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException uipEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uipEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, pEx.Message, false, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionLogger lcl_obj_ExceptionManager = new SilkERP360.CCL.ExceptionManagement.ExceptionLogger();
                System.String lcl_str_ErrorMessage = lcl_obj_ExceptionManager.LogException(Ex);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, lcl_str_ErrorMessage, false, null);
            }
            
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_ui64_DepartmentCode"></param>
        /// <param name="IP_str_VirtualPath"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(enableSession: true)]
        public SilkERP360.CCL.Misc.WSResponse GetUIBydepartment(System.UInt64 IP_ui64_CompanyCode, System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_VirtualPath)
        {
            try
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                this.Session["comp_c"] = IP_ui64_CompanyCode.ToString();
                this.Session["Dept_c"] = IP_ui64_DepartmentCode.ToString();
                SilkERP360.UI.UIDynamicLoader lcl_obj_DynamicLoader = new SilkERP360.UI.UIDynamicLoader();
                System.String lcl_str_ControlHTML = lcl_obj_DynamicLoader.Load(IP_str_VirtualPath);
                if (this.Context.Response.StatusCode == 500)
                {
                    //Status Code 500 set in the UIExceptionHandler
                    System.String lcl_str_ErrorMessage = this.Session["err_msg"].ToString();
                    this.Session.Remove("err_msg");
                    lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_str_ErrorMessage, false, null);
                    return lcl_obj_WSResponse;
                }
                lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_str_ControlHTML);
                return lcl_obj_WSResponse;
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException uiEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uiEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException uipEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uipEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, pEx.Message, false, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionLogger lcl_obj_ExceptionManager = new SilkERP360.CCL.ExceptionManagement.ExceptionLogger();
                System.String lcl_str_ErrorMessage = lcl_obj_ExceptionManager.LogException(Ex);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, lcl_str_ErrorMessage, false, null);
            }

        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <param name="IP_str_VirtualPath"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(enableSession: true)]
        public SilkERP360.CCL.Misc.WSResponse GetUIByEmployee(System.UInt64 IP_ui64_EmployeeCode, System.String IP_str_VirtualPath)
        {
            try
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;

                this.Session["emp_c"] = IP_ui64_EmployeeCode.ToString();
                SilkERP360.UI.UIDynamicLoader lcl_obj_DynamicLoader = new SilkERP360.UI.UIDynamicLoader();
                System.String lcl_str_ControlHTML = lcl_obj_DynamicLoader.Load(IP_str_VirtualPath);
                if (this.Context.Response.StatusCode == 500)
                {
                    //Status Code 500 set in the UIExceptionHandler
                    System.String lcl_str_ErrorMessage = this.Session["err_msg"].ToString();
                    this.Session.Remove("err_msg");
                    lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_str_ErrorMessage, false, null);
                    return lcl_obj_WSResponse;
                }
                lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_str_ControlHTML);
                return lcl_obj_WSResponse;
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException uiEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uiEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException uipEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uipEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, pEx.Message, false, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionLogger lcl_obj_ExceptionManager = new SilkERP360.CCL.ExceptionManagement.ExceptionLogger();
                System.String lcl_str_ErrorMessage = lcl_obj_ExceptionManager.LogException(Ex);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, lcl_str_ErrorMessage, false, null);
            }

        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public SilkERP360.CCL.Misc.WSResponse GetUIByEmployeeComp(System.UInt64 IP_ui64_CompanyCode,System.UInt64 IP_ui64_EmployeeCode, System.String IP_str_VirtualPath)
        {
            try
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                this.Session["comp_c"] = IP_ui64_CompanyCode.ToString();
                this.Session["emp_c"] = IP_ui64_EmployeeCode.ToString();
                SilkERP360.UI.UIDynamicLoader lcl_obj_DynamicLoader = new SilkERP360.UI.UIDynamicLoader();
                System.String lcl_str_ControlHTML = lcl_obj_DynamicLoader.Load(IP_str_VirtualPath);
                if (this.Context.Response.StatusCode == 500)
                {
                    //Status Code 500 set in the UIExceptionHandler
                    System.String lcl_str_ErrorMessage = this.Session["err_msg"].ToString();
                    this.Session.Remove("err_msg");
                    lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_str_ErrorMessage, false, null);
                    return lcl_obj_WSResponse;
                }
                lcl_obj_WSResponse = new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_str_ControlHTML);
                return lcl_obj_WSResponse;
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException uiEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uiEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException uipEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, uipEx.Message, false, null);
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, pEx.Message, false, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionLogger lcl_obj_ExceptionManager = new SilkERP360.CCL.ExceptionManagement.ExceptionLogger();
                System.String lcl_str_ErrorMessage = lcl_obj_ExceptionManager.LogException(Ex);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, lcl_str_ErrorMessage, false, null);
            }

        }
    }
}
