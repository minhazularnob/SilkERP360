using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for IncrementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class IncrementService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetIncrementHistoryByEmployee(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.IncrementServices lcl_obj_IncrementService = new SP.HRIS.IncrementServices();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_IncrementList = lcl_obj_IncrementService.GetIncrementListByEmployee(IP_ui64_EmployeeCode);
                if (lcl_objLst_IncrementList.Count == 0)
                {
                    return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, null);
                }
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_IncrementList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveIncrement(SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest IP_obj_Increment, List<ApproverDetail> IP_obj_ApproverDetails)
        {
            try
            {
                SilkERP360.SP.HRIS.IncrementServices lcl_obj_IncrementService = new SP.HRIS.IncrementServices();
                SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest lcl_obj_Increment = lcl_obj_IncrementService.SaveIncrement(IP_obj_Increment, IP_obj_ApproverDetails);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_obj_Increment);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }
    }
}
