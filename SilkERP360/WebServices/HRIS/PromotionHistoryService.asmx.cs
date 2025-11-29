using SilkERP360.CCL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for PromotionHistoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PromotionHistoryService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SavePromotionHistory(SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory IP_Obj_PromotionHistory)
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService locl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.UInt64 lcl_ui64_promotionHistoryCode = locl_obj_promotionHistoryService.SavePromotionHistory(IP_Obj_PromotionHistory);

                if (lcl_ui64_promotionHistoryCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Saved Successfully", true, lcl_ui64_promotionHistoryCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllPromotionHistory(System.UInt64 IP_ui64_companyCode)
        {
            try
            {
                var loggedInUser = HttpContext.Current.Session["USR_CNTXT"];

                SilkERP360.SP.HRIS.PromotionHistoryService lcl_obj_DesignationFacade = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_objLst_Designation =
                    lcl_obj_DesignationFacade.GetAllPromotionHistory(IP_ui64_companyCode, ((SilkERP360.CCL.Repository.AuthenticUserContext)loggedInUser).UserProfile.EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Designation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllApprovers()
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService locl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> lcl_objLst_ApproverList =
                    locl_obj_promotionHistoryService.GetAllApprovers();
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_ApproverList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdatePromotionStatusForApprover(UInt64 IP_ui64_PromotionHistoryCode, int status)
        {
            try
            {
                var loggedInUser = HttpContext.Current.Session["USR_CNTXT"];

                SilkERP360.SP.HRIS.PromotionHistoryService locl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.UInt64 lcl_ui64_approver_detail_code = locl_obj_promotionHistoryService.UpdatePromotionStatusForApprover(IP_ui64_PromotionHistoryCode, ((SilkERP360.CCL.Repository.AuthenticUserContext)loggedInUser).UserProfile.EmployeeCode, status);

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
        public SilkERP360.CCL.Misc.WSResponse UpdatePromotionStatusForApproverFromMail(UInt64 IP_ui64_PromotionHistoryCode, int status, UInt64 employeeCode,string token)
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService lcl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.UInt64 lcl_ui64_approver_detail_code = lcl_obj_promotionHistoryService.UpdatePromotionStatusForApprover(IP_ui64_PromotionHistoryCode, employeeCode, status, token);
                    
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success,0,"Successful",true,lcl_ui64_approver_detail_code);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error,-100,Ex.Message,false,null);
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
    }
}