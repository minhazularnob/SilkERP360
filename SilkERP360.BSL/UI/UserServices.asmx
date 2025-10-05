using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace SilkERP360.BSL
{
    /// <summary>
    /// SERVICE_CODE = WS0001
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //o al Tlow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserServices : System.Web.Services.WebService,System.Web.SessionState.IRequiresSessionState
    {
        /// <summary>
        /// WEB_METHOD_CODE= WM0001
        /// 1. Authenticates the User
        /// 2. Creates the UserProfile
        /// 3. Sets the Security Context
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse Authenticate(System.String IP_str_UserName, System.String IP_str_Password)
        {
            try
            {
                SilkERP360.FL.UserFacade lcl_obj_UserFacade = new SilkERP360.FL.UserFacade();
                System.UInt64 lcl_ui64_UserCode = 0;
                System.Boolean lcl_b_IsAuthentic = lcl_obj_UserFacade.Authenticate(IP_str_UserName, IP_str_Password, out lcl_ui64_UserCode);
                if (lcl_b_IsAuthentic == true)
                {
                    //UserCode available
                    //Create UserProfile
                    SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = null;
                    using(SilkERP360.FL.UI.UserProfileFacade lcl_obj_UserProfileFacade = new SilkERP360.FL.UI.UserProfileFacade())
                    {
                        lcl_obj_UserProfile = lcl_obj_UserProfileFacade.CreateProfileForUser(lcl_ui64_UserCode);
                    }
                    if (lcl_obj_UserProfile == null)
                    {
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "FatalError : Contact SSL Support Team!!!", null, null);
                    }
                    //Generate Security Token
                    SilkERP360.FL.SecurityFacade lcl_obj_SecurityFacade = new SilkERP360.FL.SecurityFacade();
                    System.String lcl_str_SecurityToken = lcl_obj_SecurityFacade.GenerateSecurityToken();
                    if (lcl_str_SecurityToken == System.String.Empty)
                    {
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "FatalError : Contact SSL Support Team!!!", null, null);
                    }
                    //Mark the Session with Security Token
                    this.Session ["PASS_KEY"] = lcl_str_SecurityToken;
                    System.String lcl_str_SessionID = this.Session.SessionID;
                    SilkERP360.CCL.Security.AuthenticUserContextRepository.Add(new CCL.Security.AuthenticUserContext(lcl_str_SessionID, lcl_str_SecurityToken, lcl_obj_UserProfile));
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "INValid User", typeof(System.Boolean), true);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "AccessDenied : Username/Password did not match!!!", typeof(System.Boolean), false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, null, null);
            }
        }
    }
}
