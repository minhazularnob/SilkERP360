using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for StaffLoanService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StaffLoanService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveStaffLoan(StaffLoan IP_objLst_StaffLoan)
        {
            try
            {
                SilkERP360.SP.HRIS.StaffLoanService lcl_obj_staffLoanService = new SilkERP360.SP.HRIS.StaffLoanService();
                UInt64 lcl_obj_staffLoan = lcl_obj_staffLoanService.SaveStaffLoan(IP_objLst_StaffLoan);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Saved Successfully", true, lcl_obj_staffLoan);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeLoanList(System.UInt64 IP_ui64_companyCode)
        {
            try
            {
                SilkERP360.SP.HRIS.StaffLoanService lcl_obj_staffLoanService = new SilkERP360.SP.HRIS.StaffLoanService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> lcl_objLst_EmployeeTax = lcl_obj_staffLoanService.GetEmployeeLoanList(IP_ui64_companyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeTax);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
