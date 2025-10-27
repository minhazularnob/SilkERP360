using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                bool isInsert = IP_Obj_Company.CompanyCode == 0;
                string erorMessage = ValidateCompany(IP_Obj_Company);

                if (!string.IsNullOrEmpty(erorMessage))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, erorMessage, false, false);

                }

                SilkERP360.SP.HRIS.CompanyService lcl_obj_CompanyServiceSp = new SilkERP360.SP.HRIS.CompanyService();
                System.UInt64 lcl_ui64_CompanyCode = lcl_obj_CompanyServiceSp.SaveCompany(IP_Obj_Company);

                if (lcl_ui64_CompanyCode > 0)
                {
                    string message = isInsert ? "Company Saved Successfully" : "Company Updated Successfully";
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, message, true, lcl_ui64_CompanyCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse DeleteCompany(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_Obj_Company)
        {
            try
            {
                SilkERP360.SP.HRIS.CompanyService lcl_obj_CompanyServiceSp = new SilkERP360.SP.HRIS.CompanyService();
                bool isDeleted = lcl_obj_CompanyServiceSp.DeleteCompany(IP_Obj_Company);

                if (isDeleted)
                {
                    string message =  "Company Deleted Successfully";
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, message, true, null);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", isDeleted, false);

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
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Company = lcl_obj_CompanyFacade.GetAllCompanyWise();
                 return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Company);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        private string ValidateCompany(Company companyModel)
        {
            var errors = ObjectValidator.ValidateObject(companyModel);
            return errors;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllEmployee(UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                var employeeList = new List<SilkERP360.CCL.ModelClass.Employee>();
                SilkERP360.FL.HRIS.CompanyFacade lcl_obj_CompanyFacade = new SilkERP360.FL.HRIS.CompanyFacade();
                employeeList = lcl_obj_CompanyFacade.GetAllEmployeeList(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, employeeList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
