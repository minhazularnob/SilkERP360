using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for SalaryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SalaryService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse GetSalaryStructureByEmployee(System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.SP.HRIS.SalaryService lcl_obj_SalaryService = new SP.HRIS.SalaryService();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = lcl_obj_SalaryService.GetSalaryStructureByEmployee(IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_EmployeeSalaryStructure);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -1, Ex.Message, true, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse SetSalaryPrinterParameters(System.UInt64 IP_ui64_CompanyCode, CCL.Enums.Month IP_enm_SalaryMonth, System.UInt32 IP_ui32_Year)
        {
            try
            {
                this.Context.Session["SAL_COMP_CODE"] = IP_ui64_CompanyCode.ToString();//Code of the company whose salary is to be printed
                this.Context.Session["SAL_MONTH"] = ((int)IP_enm_SalaryMonth).ToString();
                this.Context.Session["SAL_YEAR"] = IP_ui32_Year.ToString();
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -1, Ex.Message, true, null);
            }
        }

        /// <summary>
        /// If Is SalaryProcessed == true -> Return the SalaryMaster object
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_end_SalaryMonth"></param>
        /// <param name="IP_ui16_SalaryYear"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse IsSalaryProcessed(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.SalarySP lcl_obj_SalarySP = new FL.ServiceProviders.HRIS.SalarySP();
                lcl_obj_SalarySP.Initialize();
                System.Boolean lcl_b_Response = lcl_obj_SalarySP.IsSalaryProcessed(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_b_Response);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }


        /// <summary>
        /// ///
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_end_SalaryMonth"></param>
        /// <param name="IP_ui16_SalaryYear"></param>
        /// <param name="IP_ui64_AbsentWaivedEmployeeCodes">Code of those employees whos Absent deduction has been waived</param>
        /// <param name="IP_ui64_LateWaivedEmployeeCodes">Code of those employees whos Late deduction has been waived</param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse GenerateSalary(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear,System.DateTime IP_dt_SalaryCycleFrom,System.DateTime IP_dt_SalaryCycleUpto,SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.SalarySP lcl_obj_SalarySP = new FL.ServiceProviders.HRIS.SalarySP();
                lcl_obj_SalarySP.Initialize();
                CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = lcl_obj_SalarySP.GenerateSalary(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear, IP_dt_SalaryCycleFrom, IP_dt_SalaryCycleUpto, IP_obj_SalaryMaster);
                if (lcl_obj_SalaryMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Fatal Error : Contact R&D!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_SalaryMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "", false, Ex.Message);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse GetSalaryMaster(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.SalarySP lcl_obj_SalarySP = new FL.ServiceProviders.HRIS.SalarySP();
                lcl_obj_SalarySP.Initialize();
                CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = lcl_obj_SalarySP.GetSalaryMaster(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear);
                if (lcl_obj_SalaryMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Fatal Error : Contact R&D!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_SalaryMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "", false, Ex.Message);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public CCL.Misc.WSResponse SaveSalary(SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            try
            {
                SilkERP360.FL.ServiceProviders.HRIS.SalarySP lcl_obj_SalarySP = new FL.ServiceProviders.HRIS.SalarySP();
                lcl_obj_SalarySP.Initialize();
                System.Boolean resp = lcl_obj_SalarySP.SaveSalary(IP_obj_SalaryMaster);
                if (resp == false)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Fatal Error : Contact R&D!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, "", false, Ex.Message);
            }
        }
    }
}
