using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for ProvidentFundServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProvidentFundServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Returns PFAccountProfile list,each of which contains All PFAccountTransactions of all times 
        /// for the concerned PFAccount, of selected company.
        /// Details of all accounts (Active/Settle) are provided.
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetPFAccountProfileForAllByAllDuration(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.SP.HRIS.ProvidentFundServices lcl_obj_PFServices = new SP.HRIS.ProvidentFundServices();
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfile = lcl_obj_PFServices.GetAllProvidentFundProfileAndTransactionsByAllDurationForCompany(IP_ui64_CompanyCode);
                if (lcl_objLst_EmployeeProvidentFundProfile.Count == 0)
                {
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "No Provident Fund Account Found For The Selected Company!!", true, lcl_objLst_EmployeeProvidentFundProfile);
                    return lcl_obj_WSResponse;
                }
                //lcl_obj_LeaveService.Initialize();
                lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeProvidentFundProfile);
                return lcl_obj_WSResponse;
            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetPFAccountProfileWithTransactionListByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.ProvidentFundServices lcl_obj_PFServices = new SP.HRIS.ProvidentFundServices();
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile = lcl_obj_PFServices.GetProvidentFundProfileAndTransactionsListByEmployeeCode(IP_ui64_EmployeeCode);
                if (lcl_obj_EmployeeProvidentFundProfile == null)
                {
                    lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "No Provident Fund Account Found For The Selected Employee!!", true, null);
                    return lcl_obj_WSResponse;
                }
                //lcl_obj_LeaveService.Initialize();
                lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_EmployeeProvidentFundProfile);
                return lcl_obj_WSResponse;
            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

    }
}
