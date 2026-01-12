using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace SilkERP360.UI
{
    /*public static class UILoader
    {
        private static Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager m_obj_ExceptionManager = null;
        private static Microsoft.Practices.Unity.UnityContainer m_obj_UnityContainer = null;
        private static System.Collections.Generic.List<SilkERP360.CCL.Repository.AuthenticUserContext> m_obj_Repository;
        static UILoader()
        {
            SilkERP360.UI.UILoader.m_obj_UnityContainer = new Microsoft.Practices.Unity.UnityContainer();
            SilkERP360.UI.UILoader.m_obj_UnityContainer.AddNewExtension<EnterpriseLibraryCoreExtension>();
            SilkERP360.UI.UILoader.m_obj_ExceptionManager = SilkERP360.UI.UILoader.m_obj_UnityContainer.Resolve<ExceptionManager>();
            
        }
        public static System.String LoadControl(System.String IP_str_ControlPath)
        {
            System.String lcl_str_ControlHTML = System.String.Empty;
            lcl_str_ControlHTML = SilkERP360.UI.UILoader.m_obj_ExceptionManager.Process<System.String>(() =>
                {
                    System.Web.UI.Page lcl_obj_Page = new System.Web.UI.Page();
                    System.Web.UI.UserControl lcl_obj_WebUserControl = (System.Web.UI.UserControl)lcl_obj_Page.LoadControl(IP_str_ControlPath);
                    lcl_obj_WebUserControl.EnableViewState = false;

                    System.Web.UI.HtmlControls.HtmlForm lcl_obj_HtmlForm = new System.Web.UI.HtmlControls.HtmlForm();
                    lcl_obj_HtmlForm.Controls.Add(lcl_obj_WebUserControl);
                    lcl_obj_Page.Controls.Add(lcl_obj_HtmlForm);

                    System.IO.StringWriter lcl_obj_TextWriter = new System.IO.StringWriter();
                    System.Web.HttpContext.Current.Server.Execute(lcl_obj_Page, lcl_obj_TextWriter, false);
                    return lcl_obj_TextWriter.ToString();
                },"UIExceptionPolicy");
            return lcl_str_ControlHTML;
        }
    }*/
}