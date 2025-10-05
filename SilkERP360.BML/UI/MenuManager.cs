using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    public class MenuManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public MenuManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Saves the IP_obj_Menu in the Database
        /// </summary>
        /// <param name="IP_obj_Menu"></param>
        /// <returns></returns>
        public System.Boolean Save(SilkERP360.CCL.BusinessEntities.UI.Menu IP_obj_Menu,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            this.ExceptionManager.Process(() =>
            {
                if (IP_obj_Menu.Validate() == false)
                {
                   
                }

            }, "BMLExceptionPolicy");
            return false;
        }

        /// <summary>
        /// Returns a Menu Object where MenuCode = IP_ui64_MenuCode
        /// </summary>
        /// <param name="IP_ui64_MenuCode">Code Of The menu</param>
        /// <returns>On Success Menu object, else null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.Menu getMenu(System.UInt64 IP_ui64_MenuCode,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_Menu = null;
            lcl_obj_Menu = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.Menu>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("Select * From Menu Where MENU_CODE = {0} and STATUS = {1} AND IS_DELETED = 1", IP_ui64_MenuCode, SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_MenuReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_MenuReader.Read();
                if (lcl_obj_MenuReader.HasRows == false)
                {
                    return null;
                }
                SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_MenuTmp = new SilkERP360.CCL.BusinessEntities.UI.Menu();
                lcl_obj_MenuTmp.MenuCode = System.UInt64.Parse(lcl_obj_MenuReader["MENU_CODE"].ToString());
                lcl_obj_MenuTmp.MenuName = lcl_obj_MenuReader["MENU_NAME"].ToString();
                lcl_obj_MenuTmp.MenuLabel = lcl_obj_MenuReader["MENU_LABEL"].ToString();
                lcl_obj_MenuTmp.Link = lcl_obj_MenuReader["MENU_LINK"].ToString();
                lcl_obj_MenuTmp.ModuleCode = System.UInt64.Parse(lcl_obj_MenuReader["MODULE_CODE"].ToString());
                return lcl_obj_MenuTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Menu;
        }

        /// <summary>
        /// Returns a Menu Object where MenuCode = IP_ui64_MenuCode
        /// Gets it's DBManager from the pool
        /// </summary>
        /// <param name="IP_ui64_MenuCode">Code Of The menu</param>
        /// <returns>On Success Menu object, else null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.Menu getMenu(System.UInt64 IP_ui64_MenuCode)
        {
            SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_Menu = null;
            SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_MenuTmp = null;
            lcl_obj_Menu = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.Menu>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From Menu Where MENU_CODE = {0} and STATUS = {1} AND IS_DELETED = 1", IP_ui64_MenuCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                    System.Data.OracleClient.OracleDataReader lcl_obj_MenuReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_MenuReader.Read();
                    if (lcl_obj_MenuReader.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_MenuTmp = new SilkERP360.CCL.BusinessEntities.UI.Menu();
                    lcl_obj_MenuTmp.MenuCode = System.UInt64.Parse(lcl_obj_MenuReader["MENU_CODE"].ToString());
                    lcl_obj_MenuTmp.MenuName = lcl_obj_MenuReader["MENU_NAME"].ToString();
                    lcl_obj_MenuTmp.MenuLabel = lcl_obj_MenuReader["MENU_LABEL"].ToString();
                    lcl_obj_MenuTmp.Link = lcl_obj_MenuReader["MENU_LINK"].ToString();
                    lcl_obj_MenuTmp.ModuleCode = System.UInt64.Parse(lcl_obj_MenuReader["MODULE_CODE"].ToString());
                }
                return lcl_obj_MenuTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Menu;
        }

        /// <summary>
        /// Returns a List<Menu> object for the Module with ModuleCode = IP_ui64_ModuleCode
        /// </summary>
        /// <param name="IP_ui64_ModuleCode">Code of the Module which Menus is to be retrieved</param>
        /// <returns></returns>
        //public SilkERP360.CCL.BusinessEntities.UI.Menu getMenusByModule(System.UInt64 IP_ui64_ModuleCode)
        //{
        //    this.ExceptionManager.Process(() =>
        //    {

        //    }, "BMLExceptionPolicy");
        //}
        
    }
}
