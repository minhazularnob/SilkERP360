using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CompanyService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveCompany(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_Obj_Company)
        {
            try
            {
                SilkERP360.FL.HRIS.CompanyFacade lcl_obj_CompanyFacade = new FL.HRIS.CompanyFacade();
                System.UInt64 lcl_ui64_CompanyCode = lcl_obj_CompanyFacade.SaveCompany(IP_Obj_Company);

                if (lcl_ui64_CompanyCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Company Save Successfully", true, lcl_ui64_CompanyCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

             [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllCompany()
        {
            try
            {
                SilkERP360.FL.HRIS.CompanyFacade lcl_obj_CompanyFacade = new SilkERP360.FL.HRIS.CompanyFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Company =
                    lcl_obj_CompanyFacade.GetAllCompanyWise();
                 return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Company);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }



    }
}
