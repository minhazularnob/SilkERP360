using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for SalaryAddDedService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class SalaryAddDedService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveSalaryAdditionDeduction(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_Obj_SalaryAdditionDeduction)
        {
            try
            {
                SilkERP360.FL.HRIS.SalaryAddDedFacade lcl_obj_SalaryAdditionDeductionFacade = new FL.HRIS.SalaryAddDedFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_SalaryAdditionDeductionFacade.SaveSalaryAdditionDeduction(IP_Obj_SalaryAdditionDeduction);

                if (lcl_ui64_EmployeeCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Done successfully ", true, lcl_ui64_EmployeeCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetSalaryAditionDeductionListByEmployee(System.UInt64 IP_iu64_EmployeeCode)
        {
            try
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"Select * From  SALARY_ADDITION_DEDUCTION
                where EMPLOYEE_CODE = {0} order by Effective_Month desc", IP_iu64_EmployeeCode);
                SilkERP360.FL.HRIS.SalaryAddDedFacade lcl_obj_SalaryAddDedFacade = new FL.HRIS.SalaryAddDedFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAddDed =
                    lcl_obj_SalaryAddDedFacade.GetList(lcl_str_SqlQuery);


                if (lcl_objLst_SalaryAddDed.Count() > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Salary changed successfully! ", true, lcl_objLst_SalaryAddDed);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Data not found", true, lcl_objLst_SalaryAddDed);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Data not found", false, null);
            }
        }

    }
}
