using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for TaxService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class TaxService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetEmployeeTaxList(System.UInt64 IP_ui64_companyCode)
        {
            try
            {
                SilkERP360.SP.HRIS.EmployeeTaxService lcl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.EmployeeTaxService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> lcl_objLst_EmployeeTax = lcl_obj_promotionHistoryService.GetEmployeeTaxList(IP_ui64_companyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_EmployeeTax);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveEmployeeTaxList(List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> IP_objLst_EmployeeTax)
        {
            try
            {
                SilkERP360.SP.HRIS.EmployeeTaxService lcl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.EmployeeTaxService();
                UInt64 lcl_obj_EmployeeTax = lcl_obj_promotionHistoryService.SaveEmployeeTax(IP_objLst_EmployeeTax);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Saved Successfully", true, lcl_obj_EmployeeTax);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}