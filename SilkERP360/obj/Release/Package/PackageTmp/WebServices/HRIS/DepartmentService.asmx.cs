using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for DepartmentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DepartmentService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetDepartmentCoresByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCores = lcl_obj_DepartmentFacade.GetDepartmentCoresByCompany(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_obj_DepartmentCores);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllDepartment(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_objLst_Department =
                    lcl_obj_DepartmentFacade.GetAllDepartmentWise(IP_ui64_CompanyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Department);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveDepartment(SilkERP360.CCL.BusinessEntities.HRIS.Department IP_Obj_Department)
        {
            try
            {
                string erorMessage = ValidateDepartment(IP_Obj_Department);

                if (!string.IsNullOrEmpty(erorMessage))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, erorMessage, false, false);

                }

                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new FL.HRIS.DepartmentFacade();
                System.UInt64 lcl_ui64_DepartmentCode = lcl_obj_DepartmentFacade.SaveDepartment(IP_Obj_Department);

                if (lcl_ui64_DepartmentCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Department Save Successfully", true, lcl_ui64_DepartmentCode);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateDepartment(SilkERP360.CCL.BusinessEntities.HRIS.Department IP_Obj_Department)
        {
            try
            {
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new FL.HRIS.DepartmentFacade();
                System.UInt64 lcl_ui64_DepartmentCode = lcl_obj_DepartmentFacade.UpdateDepartment(IP_Obj_Department);

                if (lcl_ui64_DepartmentCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Department Updated Successfully", true, lcl_ui64_DepartmentCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse DeleteDepartment(UInt64 IP_Ui64_DepartmentCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                bool isDeleted = lcl_obj_DepartmentFacade.DeleteDepartment(IP_Ui64_DepartmentCode);

                if (isDeleted)
                {
                    string message = "Department Deleted Successfully";
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, message, true, null);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", isDeleted, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        private string ValidateDepartment(Department departmentModel)
        {
            var errors = ObjectValidator.ValidateObject(departmentModel);
            return errors;
        }
    }
}
