using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for moduleAndMenuService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class moduleAndMenuService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveModule(SilkERP360.CCL.BusinessEntities.HRIS.Module IP_Obj_Module)
        {
            try
            {
                SilkERP360.FL.HRIS.ModuleFacade lcl_obj_ModuleFacade = new FL.HRIS.ModuleFacade();
                System.UInt64 lcl_ui64_ModuleCode = lcl_obj_ModuleFacade.SaveModule(IP_Obj_Module);

                if (lcl_ui64_ModuleCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Module Save Successfully", true, lcl_ui64_ModuleCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllModule(System.UInt64 IP_ui64_UserName)
        {
            try
            {
                SilkERP360.FL.HRIS.ModuleFacade lcl_obj_ModuleFacade = new SilkERP360.FL.HRIS.ModuleFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> lcl_objLst_Module =
                    lcl_obj_ModuleFacade.GetAllModuleWise(IP_ui64_UserName);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Module);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse AddToModule(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.ModuleFacade lcl_obj_ModuleFacede = new SilkERP360.FL.HRIS.ModuleFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_ModuleFacede.AddModule(IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Module permission Successfully", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse RemoveModulepermissin(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.ModuleFacade lcl_obj_ModuleFacede = new SilkERP360.FL.HRIS.ModuleFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_ModuleFacede.RemoveModule(IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, " Removed Module permission Successfully", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }

        }

        // Menu Permission

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.MenuPermissionFacade lcl_obj_MenuPermissionFacade = new SilkERP360.FL.HRIS.MenuPermissionFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_objLst_MenuPermission =
                    lcl_obj_MenuPermissionFacade.GetAllMenuWise(IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_MenuPermission);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse AddToMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.MenuPermissionFacade lcl_obj_ModuleFacede = new SilkERP360.FL.HRIS.MenuPermissionFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_ModuleFacede.AddMenu(IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Menu permission Successfully", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        //RemoveToMenu
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse RemoveToMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            try
            {
                SilkERP360.FL.HRIS.MenuPermissionFacade lcl_obj_ModuleFacede = new SilkERP360.FL.HRIS.MenuPermissionFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_ModuleFacede.RemoveMenu(IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Menu Removed permission Successfully", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveMenuPermissionList(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode,List<MenuPermissionItem> IP_MenuList)
        {
            try
            {
                SilkERP360.FL.HRIS.MenuPermissionFacade lcl_obj_ModuleFacede = new SilkERP360.FL.HRIS.MenuPermissionFacade();
                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_ModuleFacede.SaveMenuPermissionList(IP_ui64_ModuleCode, IP_ui64_EmployeeCode, IP_MenuList);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Menu permission Successfully", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }



    }
}
