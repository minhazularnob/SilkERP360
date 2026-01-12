using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.UI
{
    public class UIDynamicLoader : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {

        public UIDynamicLoader()
        {
            this.Initialize();
        }

        /// <summary>
        /// This function will dynamically load the WebControls
        /// </summary>
        /// <param name="IP_str_ControlPath">Absolute path to the WebControl</param>
        /// <returns>HTML of the WebControl</returns>
        public System.String Load(System.String IP_str_ControlPath)
        {
            System.String lcl_str_ControlHTML = System.String.Empty;
            lcl_str_ControlHTML = this.ExceptionManager.Process<System.String>(()=>
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
    }
}