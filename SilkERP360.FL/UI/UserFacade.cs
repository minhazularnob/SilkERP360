using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Web;


namespace SilkERP360.FL
{
    public class UserFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,System.Web.SessionState.IRequiresSessionState
    {
        public UserFacade()
        {
            //var lcl_obj_Container = new UnityContainer();
            //lcl_obj_Container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            //ExceptionManager lcl_obj_ExceptionManager = lcl_obj_Container.Resolve<ExceptionManager>();
            //ExceptionManagement Initialization
            this.Initialize();
        }

        public System.Boolean ChargePassword(System.String IP_str_UserName, System.String IP_str_NewPassword)
        {
            System.Boolean lcl_b_PasswordChanged = false;
            lcl_b_PasswordChanged = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.UI.UserManager lcl_obj_UserManager = new BML.UI.UserManager();
                lcl_b_PasswordChanged = lcl_obj_UserManager.ChangePassword(IP_str_UserName, IP_str_NewPassword);
                return lcl_b_PasswordChanged;
            }, "FLExceptionPolicy");
            return lcl_b_PasswordChanged; 
        }

        /// <summary>
        /// 2. Checks if User is Authentic
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <param name="OP_ui64_UserCode"></param>
        /// <returns>
        /// 1.If User Authentic, returns true and the UserCode in OP_ui64_UserCode
        /// 2. If Not, returns false and 0 in OP_ui64_UserCode
        /// </returns>
        public System.Boolean Authenticate(System.String IP_str_UserName, System.String IP_str_Password,out System.UInt64 OP_ui64_UserCode)
        {
            System.Boolean lcl_b_IsAuthentic = false;
            System.UInt64 lcl_ui64_UserCode = 0;
            lcl_b_IsAuthentic = this.ExceptionManager.Process<System.Boolean>(() =>
                {
                    SilkERP360.BML.UI.UserManager lcl_obj_UserManager = new BML.UI.UserManager();
                    lcl_b_IsAuthentic = lcl_obj_UserManager.Authenticate(IP_str_UserName, IP_str_Password, out lcl_ui64_UserCode);
                    return lcl_b_IsAuthentic;
                }, "FLExceptionPolicy");
            OP_ui64_UserCode = lcl_ui64_UserCode;
            return lcl_b_IsAuthentic; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SecurityToken"></param>
        /// <returns></returns>
        public SilkERP360.CCL.Misc.WSResponse Logout(System.String IP_str_SecurityToken)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
            lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySecurityToken(IP_str_SecurityToken);
                if (lcl_obj_AuthenticUserContext == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Fatal Error : Undefined", false, null);
                }
                SilkERP360.CCL.Repository.AuthenticUserContextRepository.Remove(lcl_obj_AuthenticUserContext);
                
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Successfully Logged Out!!", true, null);
            }, "FLExceptionPolicy");
            return lcl_obj_WSResponse; 
        }
    }
}
