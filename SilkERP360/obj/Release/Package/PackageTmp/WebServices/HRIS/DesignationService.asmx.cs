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
    /// Summary description for DesignationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DesignationService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetDesignationDetails(System.UInt64 IP_ui64_DesignationCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DesignationFacade lcl_obj_DesignationFacade = new SilkERP360.FL.HRIS.DesignationFacade();
                SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = lcl_obj_DesignationFacade.Get(IP_ui64_DesignationCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", true, lcl_obj_Designation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateDesignation(SilkERP360.CCL.BusinessEntities.HRIS.Designation IP_Obj_Designation)
        {
            try
            {
                string erorMessage = ValidateDesignation(IP_Obj_Designation);

                if (!string.IsNullOrEmpty(erorMessage))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, erorMessage, false, false);

                }

                SilkERP360.FL.HRIS.DesignationFacade lcl_obj_DesignationFacade = new FL.HRIS.DesignationFacade();
                System.UInt64 lcl_ui64_DesignationCode = lcl_obj_DesignationFacade.UpdateDesignation(IP_Obj_Designation);

                if (lcl_ui64_DesignationCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Designation Updated Successfully", true, lcl_ui64_DesignationCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllDesignation(System.UInt64 IP_ui64_companyCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DesignationFacade lcl_obj_DesignationFacade = new SilkERP360.FL.HRIS.DesignationFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_objLst_Designation =
                    lcl_obj_DesignationFacade.GetAllDesignationWise(IP_ui64_companyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Designation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse DeleteDesignation(UInt64 IP_Ui64_designationCode)
        {
            try
            {
                SilkERP360.FL.HRIS.DesignationFacade lcl_obj_designationFacade = new SilkERP360.FL.HRIS.DesignationFacade();
                bool isDeleted = lcl_obj_designationFacade.DeleteDesignation(IP_Ui64_designationCode);

                if (isDeleted)
                {
                    string message = "Designation Deleted Successfully";
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
        public SilkERP360.CCL.Misc.WSResponse SaveDesignation(SilkERP360.CCL.BusinessEntities.HRIS.Designation IP_Obj_Designation)
        {
            try
            {
                string erorMessage = ValidateDesignation(IP_Obj_Designation);

                if (!string.IsNullOrEmpty(erorMessage))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, erorMessage, false, false);

                }

                SilkERP360.FL.HRIS.DesignationFacade lcl_obj_DesignationFacade = new FL.HRIS.DesignationFacade();
                System.UInt64 lcl_ui64_DesignationCode = lcl_obj_DesignationFacade.SaveDesignation(IP_Obj_Designation);

                if (lcl_ui64_DesignationCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Designation Save Successfully", true, lcl_ui64_DesignationCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        private string ValidateDesignation(Designation designationModel)
        {
            var errors = ObjectValidator.ValidateObject(designationModel);
            return errors;
        }


    }
}
