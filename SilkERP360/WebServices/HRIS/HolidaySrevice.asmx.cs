using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for HolidaySrevice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   [System.Web.Script.Services.ScriptService]
    public class HolidaySrevice : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveHolidayMaster(SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster IP_Obj_HolidayMaster)
        {
            try
            {
                SilkERP360.FL.HRIS.HolidayFacade lcl_obj_HolidayMasterFacade = new FL.HRIS.HolidayFacade();
                System.UInt64 lcl_ui64_HolidayMasterID = lcl_obj_HolidayMasterFacade.SaveHolidayMaster(IP_Obj_HolidayMaster);
                if (lcl_ui64_HolidayMasterID > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Holiday information Saved Successfully", true, lcl_ui64_HolidayMasterID);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse DeleteHoliday(System.UInt64 IP_ui64_HolidayMasterCode)
        {
            try
            {
                SilkERP360.FL.HRIS.HolidayFacade lcl_obj_HolidayMasterFacade = new FL.HRIS.HolidayFacade();
                System.UInt64 lcl_ui64_HolidayMasterCode = lcl_obj_HolidayMasterFacade.DeletHoliday(IP_ui64_HolidayMasterCode);
                if (lcl_ui64_HolidayMasterCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Holiday information Deleted Successfully", true, lcl_ui64_HolidayMasterCode);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllHoliday(System.UInt64 IP_ui64_CompanyCode, System.String IP_str_SerchDate)
        {
            try
            {
                SilkERP360.FL.HRIS.HolidayFacade lcl_obj_HolidayFacade = new SilkERP360.FL.HRIS.HolidayFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_objLst_HolidayMaster =
                    lcl_obj_HolidayFacade.GetAllHolidayCompanyWise(IP_ui64_CompanyCode, IP_str_SerchDate);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_HolidayMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
