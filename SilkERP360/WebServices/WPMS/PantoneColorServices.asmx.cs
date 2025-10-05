using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for PantoneColorServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PantoneColorServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Will Read Data from Pantone Text Database
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetColors()
        {
            int index = 0;
            try
            {
                System.String lcl_str_ColorDBPath = System.IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
                System.String lcl_str_ColorDBFilePath = lcl_str_ColorDBPath + @"\Colors.txt";
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Color> lcl_objLst_Colors = new List<CCL.BusinessEntities.WPMS.Color>();
                using (System.IO.StreamReader lcl_str_ColorDBReader = new StreamReader(lcl_str_ColorDBFilePath))
                {
                    System.String lcl_str_ColorBlock = System.String.Empty;
                    
                    while((lcl_str_ColorBlock = lcl_str_ColorDBReader.ReadLine()) != null)
                    {
                        System.String[] lcl_strArr_ColorBlockSegments = lcl_str_ColorBlock.Split(new System.Char[] { ',' });
                        SilkERP360.CCL.BusinessEntities.WPMS.Color lcl_obj_Color = new CCL.BusinessEntities.WPMS.Color();
                        lcl_obj_Color.Name = lcl_strArr_ColorBlockSegments[0];
                        lcl_obj_Color.PantoneCode = lcl_strArr_ColorBlockSegments[1];
                        lcl_obj_Color.Hex = lcl_strArr_ColorBlockSegments[2];
                        lcl_objLst_Colors.Add(lcl_obj_Color);
                        index++;
                    }
                    lcl_str_ColorDBReader.Close();
                }
                return new CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Colors);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.Error, -1, Ex.Message, true, null);
            }
        }
    }
}
