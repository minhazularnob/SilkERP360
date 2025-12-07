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
                var loggedInUser = HttpContext.Current.Session["USR_CNTXT"];
                SilkERP360.SP.HRIS.IncrementServices lcl_obj_IncrementService = new SP.HRIS.IncrementServices();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_IncrementList = lcl_obj_IncrementService.GetIncrementListByEmployee(IP_ui64_EmployeeCode, ((SilkERP360.CCL.Repository.AuthenticUserContext)loggedInUser).UserProfile.EmployeeCode);
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

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateIncrementStatusForApprover(UInt64 IP_ui64_PromotionHistoryCode, int status)
        {
            try
            {
                var loggedInUser = HttpContext.Current.Session["USR_CNTXT"];

                SilkERP360.SP.HRIS.IncrementServices locl_obj_incrementService = new SilkERP360.SP.HRIS.IncrementServices();
                System.UInt64 lcl_ui64_approver_detail_code = locl_obj_incrementService.UpdateIncrementStatusForApprover(IP_ui64_PromotionHistoryCode, ((SilkERP360.CCL.Repository.AuthenticUserContext)loggedInUser).UserProfile.EmployeeCode, status);

                if (lcl_ui64_approver_detail_code > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Updated Successfully", true, lcl_ui64_approver_detail_code);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetTokenStatus(string token)
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService locl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                int status = locl_obj_promotionHistoryService.GetTokenStatus(token);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, status, "", true, status);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateIncrementStatusForApproverFromMail(UInt64 IP_ui64_incrementCode, int status, UInt64 employeeCode, string token)
        {
            try
            {
                var loggedInUser = HttpContext.Current.Session["USR_CNTXT"];

                SilkERP360.SP.HRIS.IncrementServices locl_obj_incrementService = new SilkERP360.SP.HRIS.IncrementServices();
                System.UInt64 lcl_ui64_approver_detail_code = locl_obj_incrementService.UpdateIncrementStatusForApprover(IP_ui64_incrementCode, employeeCode, status, token);

                if (lcl_ui64_approver_detail_code > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Updated Successfully", true, lcl_ui64_approver_detail_code);
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
