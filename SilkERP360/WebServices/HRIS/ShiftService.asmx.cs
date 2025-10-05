using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for ShiftService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ShiftService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetShift(System.UInt64 IP_ui64_ShiftCode)
        {
            try
            {
                SilkERP360.FL.HRIS.ShiftFacade lcl_obj_ShiftFacade = new SilkERP360.FL.HRIS.ShiftFacade();
                SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = lcl_obj_ShiftFacade.Get(IP_ui64_ShiftCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_obj_Shift);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }





        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveShift(SilkERP360.CCL.BusinessEntities.HRIS.Shift IP_Obj_Shift)
        {
            try
            {
                SilkERP360.FL.HRIS.ShiftFacade lcl_obj_ShiftFacade = new FL.HRIS.ShiftFacade();
                System.UInt64 lcl_ui64_ShiftCode = lcl_obj_ShiftFacade.SaveShift(IP_Obj_Shift);

                if (lcl_ui64_ShiftCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Shift Save Successfully", true, lcl_ui64_ShiftCode);
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
