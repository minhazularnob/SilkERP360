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
    public class UserServices : SilkERP360.CCL.Misc.SilkWebService, System.Web.SessionState.IRequiresSessionState
    {
        public UserServices()
        {
            this.Initialize();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse ChangePassword(System.String IP_str_Username, System.String IP_str_OldPassword, System.String IP_str_NewPassword)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;

            try
            {
                SilkERP360.FL.UserFacade lcl_obj_UserFacade = new FL.UserFacade();
                System.UInt64 lcl_ui64_UserCode = 0;
                if (lcl_obj_UserFacade.Authenticate(IP_str_Username, IP_str_OldPassword, out lcl_ui64_UserCode) == false)
                {
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Password Change Failed : Username/Current Password did not match!!!", false, null);
                }
                else
                {
                    if (lcl_obj_UserFacade.ChargePassword(IP_str_Username, IP_str_NewPassword) == false)
                    {
                        lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Password Change Failed : Unknown Error!!!", false, null);
                    }
                    else
                    {
                        lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Password Changed Successfully!!!", true, null);
                    }
                }
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, Ex.Message, false, null);
            }
        }
        /// <summary>
        /// WEB_METHOD_CODE= WM0001
        /// 1. Authenticates the User
        /// 2. Creates the UserProfile
        /// 3. Sets the Security Context
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession=true)]
        public SilkERP360.CCL.Misc.WSResponse Authenticate(System.String IP_str_Username, System.String IP_str_Password)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;

            try
            {
                SilkERP360.FL.UserFacade lcl_obj_UserFacade = new SilkERP360.FL.UserFacade();

                System.UInt64 lcl_ui64_UserCode = 0;
                System.Boolean lcl_b_IsAuthentic = false;
                lcl_b_IsAuthentic = lcl_obj_UserFacade.Authenticate(IP_str_Username.ToLower(), IP_str_Password, out lcl_ui64_UserCode);
                
                if (lcl_b_IsAuthentic == true)
                {
                    //UserCode available
                    //Mark the Session with Temporary Security Token
                    System.String lcl_str_IPAddress = this.Context.Request.UserHostAddress;
                    System.String lcl_str_SessionID = this.Context.Session.SessionID.ToUpper();
                    
                    //Generate Security Token
                    SilkERP360.FL.SecurityFacade lcl_obj_SecurityFacade = new SilkERP360.FL.SecurityFacade();
                    System.String lcl_str_SecurityToken = lcl_obj_SecurityFacade.GenerateSecurityToken();
                    if (lcl_str_SecurityToken == System.String.Empty)
                    {
                        lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "FatalError : Error creating Security Descriptor!!!Contact SSL Support Team!!!", false, null);
                        return lcl_obj_WSResponse;
                    }
                    
                   // this.Session["SEC_TKN"] = lcl_str_SecurityToken;
                    //this.Session["S_ID"] = this.Session.SessionID;
                    //lcl_obj_Session["SEC_TKN"] = lcl_str_SecurityToken;
                    
                    //Create UserProfile

                    SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = null;
                    using (SilkERP360.FL.UI.UserProfileFacade lcl_obj_UserProfileFacade = new SilkERP360.FL.UI.UserProfileFacade())
                    {
                        lcl_obj_UserProfile = lcl_obj_UserProfileFacade.CreateProfileForUser(lcl_ui64_UserCode);
                    }
                    if (lcl_obj_UserProfile == null)
                    {
                        lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "FatalError : UserProfile Cannot Be Created!!!Contact SSL Support Team!!!", false, null);
                        return lcl_obj_WSResponse;
                    }
                    SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = new CCL.Repository.AuthenticUserContext(lcl_str_SessionID, lcl_str_SecurityToken, lcl_str_IPAddress, lcl_obj_UserProfile);
                    this.Session["USR_CNTXT"] = lcl_obj_AuthenticUserContext;
                    //SilkERP360.CCL.Repository.AuthenticUserContextRepository.Add(new CCL.Repository.AuthenticUserContext(lcl_str_SessionID, lcl_str_SecurityToken, lcl_str_IPAddress, lcl_obj_UserProfile));
                    //lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Valid User", true, lcl_obj_UserProfile);
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, this.Session.SessionID, true, lcl_obj_UserProfile);

                }
                else
                {
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "AccessDenied : Username/Password did not match!!!", false, null);
                }
                return lcl_obj_WSResponse;
            }
            catch(SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException pEx)
            {
                lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, 0, pEx.Message, false, null);
                return lcl_obj_WSResponse;
            }
         
        }

        /// <summary>
        /// WEB_METHOD_CODE= WM0003
        /// Logs a User Out
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse Logout()
        {
            try
            {
                SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = (SilkERP360.CCL.Repository.AuthenticUserContext)this.Session["USR_CNTXT"];
                //Get Security Token from Incoming Session
                //this.Session.Remove("SEC_TKN");

                if (lcl_obj_AuthenticUserContext == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -101, "Session Expired!!!", false, null);
                }
                this.Session.Remove("USR_CNTXT");
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Logout Successful!!!", true, null);
            }
            catch (System.Exception Ex)
            {
                SilkERP360.CCL.ExceptionManagement.ExceptionHandlers.BSLExceptionHandler lcl_obj_BSLExceptionHandler = new CCL.ExceptionManagement.ExceptionHandlers.BSLExceptionHandler();
                return lcl_obj_BSLExceptionHandler.HandleException(Ex);
               // return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Fatal Error : " + Ex.Message, false, null);
            }
        }

        /// <summary>
        /// WEB_METHOD_CODE= WM0003
        /// Logs a User Out
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse RefreshSession()
        {
            return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Session Refreshed!!!", true, null);
        }
    }
}
