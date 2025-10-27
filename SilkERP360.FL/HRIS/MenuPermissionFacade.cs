using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class MenuPermissionFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase

    {
        public MenuPermissionFacade()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> GetAllMenuWise(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_obj_MenuPermission = null;
            lcl_obj_MenuPermission = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select A.menu_code,module_code,menu_name,parent_menu_code,ManuType,nvl(Status,0)Status From
                    (select menu_code,module_code,menu_name,parent_menu_code,case when menu_code=parent_menu_code then 'Main menu' else 'Sub Menu' End ManuType  From 
                    (select B.menu_code,B.module_code,B.menu_name,B.parent_menu_code From
                    (select menu_code,module_code,menu_name,parent_menu_code from menu
                    where parent_menu_code=0 And is_deleted=1)A

                    left outer join
                    (select menu_code,module_code,menu_name,parent_menu_code from menu
                    where is_deleted=1)B on A.menu_code=B.parent_menu_code

                    Union All
                    select menu_code,module_code,menu_name,menu_code as parent_menu_code from menu
                    where parent_menu_code=0)A Where MODULE_CODE={0})A 
                    Left Outer join
                    (Select MENU_CODE,1 Status  From USER_MODULE_MENUS  Where MODULE_CODE={0} And IS_DELETED=1  
                    And USER_CODE={1})B On A.MENU_CODE=B.MENU_CODE Order by parent_menu_code,A.menu_code", IP_ui64_ModuleCode, IP_ui64_EmployeeCode);

                SilkERP360.BML.HRIS.MenuPermissionManager lcl_obj_MenuPermissionManager = new SilkERP360.BML.HRIS.MenuPermissionManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_obj_MenuPermissionTmp =  lcl_obj_MenuPermissionManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_MenuPermissionTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_MenuPermission;
        }

        // Add Menu
        public System.UInt64 AddMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.MenuPermissionManager lcl_obj_RoosterMasterManager = new BML.HRIS.MenuPermissionManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_RoosterMasterManager.AddMenu(IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }

        public System.UInt64 RemoveMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.MenuPermissionManager lcl_obj_RoosterMasterManager = new BML.HRIS.MenuPermissionManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_RoosterMasterManager.RemoveMenu(IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }

        public System.UInt64 SaveMenuPermissionList(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode, List<MenuPermissionItem> IP_MenuList)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.MenuPermissionManager lcl_obj_RoosterMasterManager = new BML.HRIS.MenuPermissionManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_RoosterMasterManager.SaveMenuPermissionList(IP_ui64_ModuleCode, IP_ui64_EmployeeCode, IP_MenuList);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }
    }
}
