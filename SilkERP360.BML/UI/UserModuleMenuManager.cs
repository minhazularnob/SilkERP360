using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    /// <summary>
    /// This class manages the UserMenu class.
    /// </summary>
    public class UserModuleMenuManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserModuleMenuManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Function returns the Menus that a user is permitted to access
        /// Pre-Condition: DBManager must be initialized and opened.
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>On Success List<UserMenu></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> getUserModuleMenusListForUser(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_obj_UserModuleMenu = null;

            lcl_obj_UserModuleMenu = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_objLst_TmpUserModuleMenus = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu>();
                System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULE_MENUS where USER_CODE = {0} and MODULE_CODE = {1} and STATUS = {2} AND IS_DELETED = 1", IP_ui64_UserCode,IP_ui64_ModuleCode, SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_UserModuleMenusReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_UserModuleMenusReader.HasRows == false)
                {
                    //return empty object
                    return lcl_objLst_TmpUserModuleMenus;
                }
                else
                {
                    //lcl_objLst_TmpUserModuleMenus = new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModuleMenu>();
                   // System.UInt64 lcl_ui64_ModuleCode = 0;
                    System.UInt64 lcl_ui64_MenuCode = 0;
                    //CreateMenuList
                    SilkERP360.BML.UI.MenuManager lcl_obj_MenuManager = new SilkERP360.BML.UI.MenuManager();
                    while (lcl_obj_UserModuleMenusReader.Read())
                    {
                       // lcl_ui64_ModuleCode = System.UInt64.Parse(lcl_obj_UserMenusReader["MODULE_CODE"].ToString());
                        lcl_ui64_MenuCode = System.UInt64.Parse(lcl_obj_UserModuleMenusReader["MENU_CODE"].ToString());
                       lcl_objLst_TmpUserModuleMenus.Add(new SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu(IP_ui64_UserCode,IP_ui64_ModuleCode,lcl_ui64_MenuCode));
                    }
                    lcl_obj_UserModuleMenusReader.Close();
                    return lcl_objLst_TmpUserModuleMenus;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_UserModuleMenu;
        }


        /// <summary>
        /// Function returns the Menus that a user is permitted to access
        /// Pre-Condition: DBManager must be initialized and opened.
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
         /// <returns>On Success List<UserMenu></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> getUserModuleMenusListForUser(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_obj_UserModuleMenu = null;

            lcl_obj_UserModuleMenu = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    lcl_obj_DBManager.InternalResource.Initialize();
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_objLst_TmpUserModuleMenus = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu>();
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULE_MENUS where USER_CODE = {0} and MODULE_CODE = {1} and STATUS = {2} AND IS_DELETED = 1", IP_ui64_UserCode, IP_ui64_ModuleCode, SilkERP360.CCL.Enums.Status.Active);
                    System.Data.OracleClient.OracleDataReader lcl_obj_UserModuleMenusReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_UserModuleMenusReader.HasRows == false)
                    {
                        //return empty object
                        return lcl_objLst_TmpUserModuleMenus;
                    }
                    else
                    {
                        //lcl_objLst_TmpUserModuleMenus = new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModuleMenu>();
                        // System.UInt64 lcl_ui64_ModuleCode = 0;
                        System.UInt64 lcl_ui64_MenuCode = 0;
                        //CreateMenuList
                        SilkERP360.BML.UI.MenuManager lcl_obj_MenuManager = new SilkERP360.BML.UI.MenuManager();
                        while (lcl_obj_UserModuleMenusReader.Read())
                        {
                            // lcl_ui64_ModuleCode = System.UInt64.Parse(lcl_obj_UserMenusReader["MODULE_CODE"].ToString());
                            lcl_ui64_MenuCode = System.UInt64.Parse(lcl_obj_UserModuleMenusReader["MENU_CODE"].ToString());
                            lcl_objLst_TmpUserModuleMenus.Add(new SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu(IP_ui64_UserCode, IP_ui64_ModuleCode, lcl_ui64_MenuCode));
                        }
                        lcl_obj_UserModuleMenusReader.Close();
                        return lcl_objLst_TmpUserModuleMenus;
                    }
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_UserModuleMenu;
        }
    }
}
