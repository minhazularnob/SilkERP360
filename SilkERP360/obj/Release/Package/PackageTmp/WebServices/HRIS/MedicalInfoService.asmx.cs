using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for MedicalInfoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class MedicalInfoService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveMedicalInfo(SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo IP_Obj_MedicineInfo)
        {
            try
            {
                SilkERP360.FL.HRIS.MedicalInfoFacade lcl_obj_MedicaleFacade = new FL.HRIS.MedicalInfoFacade();
                System.UInt64 lcl_ui64_DesignationCode = lcl_obj_MedicaleFacade.Save(IP_Obj_MedicineInfo);

                if (lcl_ui64_DesignationCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Medical Information Save Successfully", true, lcl_ui64_DesignationCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public SilkERP360.CCL.Misc.WSResponse GetMedicalInfoData()
        //{
        //    try
        //    {
        //        SilkERP360.FL.HRIS.MedicalInfoFacade lcl_obj_MedicalInfoFacade = new SilkERP360.FL.HRIS.MedicalInfoFacade();
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objLst_MedicalInfo =
        //            lcl_obj_MedicalInfoFacade.GetMedicalInfoData();
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_MedicalInfo);
        //    }
        //    catch (System.Exception Ex)
        //    {
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
        //    }
        //}


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMedicalInfoData(System.UInt64 IP_iu64_EmployeeCode)
        {
            try
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"Select * From  MEDICALE_INFO
                where EMPLOYEE_CODE = {0} order by VISITED_DATE desc", IP_iu64_EmployeeCode);
                SilkERP360.FL.HRIS.MedicalInfoFacade lcl_obj_MedicalInfoFacade = new FL.HRIS.MedicalInfoFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objLst_MedicalInfo =
                    lcl_obj_MedicalInfoFacade.GetList(lcl_str_SqlQuery);


                if (lcl_objLst_MedicalInfo.Count() > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "MedicalInfo changed successfully! ", true, lcl_objLst_MedicalInfo);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Data not found", true, lcl_objLst_MedicalInfo);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Data not found", false, null);
            }
        }

    }
}
