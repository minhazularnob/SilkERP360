using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SilkERP360
{
    public class Global : System.Web.HttpApplication
    {
        public const System.Int32 SESSION_TIMEOUT = 30; //2 Miniut
        protected void Application_Start(object sender, EventArgs e)
        {
            //SilkERP360.CCL.Misc.SilkWebService lcl_obj_SilkWebService = new SilkERP360.CCL.Misc.SilkWebService("WS1001", "UserService");

           // lcl_obj_SilkWebService.AddWebMethod(new SilkERP360.CCL.Misc.SilkWebMethod("WM0001", "Authenticate", "", ""));

            //SilkERP360.CCL.Misc.SilkWebServiceCollection.Add(lcl_obj_SilkWebService);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            ////A session is created when user logs into the system. Initially the session is treated as temporary
            ////session. So the timeout is set.
            ////After the user authenticates and log in, SESSION_TIMEOUT is set
            //System.Web.SessionState.HttpSessionState lcl_obj_Session = this.Session;
            //lcl_obj_Session.Timeout = SilkERP360.Global.TEMP_SESSION_TIMEOUT;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //System.Web.SessionState.HttpSessionState lcl_obj_Session = this.Session;
            ////check if session is a temporary session by checking if TMP_SEC_TKN key exists in Session
            //System.Object lcl_obj_TmpSecTkn = lcl_obj_Session["TMP_SEC_TKN"];
            //if (lcl_obj_TmpSecTkn != null)
            //{
            //    //The key TMP_SEC_TKN found.
            //    //Its a temporary Session
            //    //Remove TMP_SEC_TKN from TempRepository 
            //    System.Exception Ex = null;
            //    SilkERP360.CCL.Security.TempSecurityTokenRepository.Remove(lcl_obj_TmpSecTkn.ToString(),out Ex);
            //}

        }

        protected void Application_End(object sender, EventArgs e)
        {
           
        }
    }
}