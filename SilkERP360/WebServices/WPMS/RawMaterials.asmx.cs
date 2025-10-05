using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for RawMaterials
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RawMaterials : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveItems(SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials IP_obj_RawMaterials)
        {
            try
            {
               
                try
                {
                    SilkERP360.FL.WPMS.RawMaterialsFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawMaterialsFacade();
                    System.UInt64 lcl_ui64_RawMaterialsFacade = lcl_obj_RawMaterialsFacade.Save(IP_obj_RawMaterials);
                    if (lcl_ui64_RawMaterialsFacade > 0)
                    {
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "RawMaterials Saved Successfully", true, lcl_ui64_RawMaterialsFacade);
                    }
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

                }

                catch (System.Exception Ex)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
                }
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadProductInfo(System.UInt64 IP_obj_ddlProductName)
        {
            try
            {

               SilkERP360.FL.WPMS.RawMaterialsFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawMaterialsFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_RawMaterials =
                lcl_obj_RawMaterialsFacade.GetAllDesignationWise(IP_obj_ddlProductName);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RawMaterials);
               
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadUpdateProductPrice(System.UInt64 IP_str_ddlProductCode)
        {
            try
            {

                //SilkERP360.FL.WPMS.RawProductFacade lcl_obj_RawProductFacade = new FL.WPMS.RawProductFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objList = new List<CCL.BusinessEntities.WPMS.RawProduct>();
                //lcl_obj_RawProductFacade.GetAllDesignationWise(IP_obj_ddlProductName);

                SilkERP360.FL.WPMS.RawMaterialsFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawMaterialsFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_RawMaterials =
                lcl_obj_RawMaterialsFacade.GetUpdateProductPrice(IP_str_ddlProductCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RawMaterials);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadSubProduct(System.UInt64 IP_str_ddlProductCode)
        {
            try
            {
                SilkERP360.FL.WPMS.RawSubFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawSubFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_objLst_RawMaterials =
                lcl_obj_RawMaterialsFacade.GetAllSubProductWise(IP_str_ddlProductCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RawMaterials);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveEmployeeAppoinment(System.UInt64 IP_obj_ddlProductName)
        {
            try
            {
                           System.String lcl_str_Query = System.String.Format(@"select e.RM_CODE,e.RM_NAME,d.MONTH,d.PRICE_M_TON From WPMS_RAW_PRODUCT E 
inner join WPMS_RAW_MATERIAL D on e.RM_CODE=d.rm_code where e.RM_CODE={0}", IP_obj_ddlProductName);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeIDReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_Query);
                lcl_obj_EmployeeIDReader.Read();
                System.String lcl_str_RMCode = lcl_obj_EmployeeIDReader["RM_CODE"].ToString();
                System.String lcl_str_RMName = lcl_obj_EmployeeIDReader["RM_NAME"].ToString();
                System.String lcl_str_Month = lcl_obj_EmployeeIDReader["MONTH"].ToString();
                System.String lcl_str_Price = lcl_obj_EmployeeIDReader["PRICE_M_TON"].ToString();
              
                lcl_obj_SqlFacade.Close();

                    System.Text.StringBuilder lcl_obj_AppoinmentSummery = new System.Text.StringBuilder();
                    lcl_obj_AppoinmentSummery.Append("<table style='width:60%;'><caption>Appoinment Summery</caption>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Employee ID</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_RMCode);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Name</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Month);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Designation</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_Price);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");
                    
                    lcl_obj_AppoinmentSummery.Append("<tr style='width:100%;'><td style='width:30%;'>Company</td><td style='width:70%;'>");
                    lcl_obj_AppoinmentSummery.Append(lcl_str_RMName);
                    lcl_obj_AppoinmentSummery.Append("</td></tr>");

                    lcl_obj_AppoinmentSummery.Append("</table>");
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_EmployeeIDReader);
             

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadAllProductInfo(System.DateTime IP_str_Month)
        {
            try
            {

                //SilkERP360.FL.WPMS.RawProductFacade lcl_obj_RawProductFacade = new FL.WPMS.RawProductFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objList = new List<CCL.BusinessEntities.WPMS.RawProduct>();
                //lcl_obj_RawProductFacade.GetAllDesignationWise(IP_obj_ddlProductName);

                SilkERP360.FL.WPMS.RawMaterialsFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawMaterialsFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_RawMaterials =
                lcl_obj_RawMaterialsFacade.GetAllDesignationWise2(IP_str_Month);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RawMaterials);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

    }
}
