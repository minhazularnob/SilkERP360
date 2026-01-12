using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SilkERP360.UI.Base
{
    public class SilkViewManager
    {
        public static SilkERP360.UI.Base.ContentsResponse RenderView(System.String IP_str_ControlPath)
        {
            return RenderView(IP_str_ControlPath, null);
        }

        public static ContentsResponse RenderView(System.String IP_str_ControlPath, System.Object IP_str_Data)
        {
            try
            {
                SilkERP360.UI.Base.SilkPage pageHolder = new SilkERP360.UI.Base.SilkPage();
                SilkERP360.UI.Base.SilkWebUserControl viewControl = (SilkERP360.UI.Base.SilkWebUserControl)pageHolder.LoadControl(IP_str_ControlPath);

                if (viewControl == null)
                    return ContentsResponse.Empty;

                if (IP_str_Data != null)
                {
                    viewControl.Data = IP_str_Data;
                }

                //lcl_obj_HTML_Form.Controls.Add(viewControl);
                pageHolder.Controls.Add(viewControl);
                
                string result = "";
                using (StringWriter output = new StringWriter())
                {
                    HttpContext.Current.Server.Execute(pageHolder, output, false);
                    result = output.ToString();
                }

                return new ContentsResponse(result, viewControl.StartupScript, viewControl.CustomStyleSheet);
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}