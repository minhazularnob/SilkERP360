using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    public class UserModuleMenuCompanyManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {

        public UserModuleMenuCompanyManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Gets the Provided Module details, Menu The User is permitted to access and The Companies which data the User is permitted
        /// to access.
        /// Pre-Condition : DBManager must be initialized and opened
        /// </summary>
        /// <param name="IP_ui64_UserCode">Code of the user whose permission is required</param>
        /// <param name="IP_ui64_ModuleCode">Code of the module whose details are to be retrieved</param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>if successfull, returns ModuleMenuCompany object else null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany getModuleMenuCompany(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompany = null;
            lcl_obj_ModuleMenuCompany = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany>(() =>
                {
                    SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompanyTmp = new SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany();
                    SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_Module = null;
                    using (SilkERP360.BML.UI.ModuleManager lcl_obj_ModuleManager = new SilkERP360.BML.UI.ModuleManager())
                    {
                        lcl_obj_Module = lcl_obj_ModuleManager.getModuleByCode(IP_ui64_ModuleCode, IP_obj_DBManager);
                        if (lcl_obj_Module == null)
                        {
                            //Requested ModuleCode not found
                            return null;
                        }
                    }
                    lcl_obj_ModuleMenuCompanyTmp.ModuleCode = IP_ui64_ModuleCode;
                    lcl_obj_ModuleMenuCompanyTmp.ModuleName = lcl_obj_Module.ModuleName;
                    lcl_obj_ModuleMenuCompanyTmp.ShortName = lcl_obj_Module.ShortName;
                    lcl_obj_ModuleMenuCompanyTmp.HomeLink = lcl_obj_Module.HomeLink;
                    //get UserModuleMenu collection for given User and Module
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_obj_UserModuleMenuList = null;
                    using (SilkERP360.BML.UI.UserModuleMenuManager lcl_obj_UserModuleMenuManager = new SilkERP360.BML.UI.UserModuleMenuManager())
                    {
                        lcl_obj_UserModuleMenuList = lcl_obj_UserModuleMenuManager.getUserModuleMenusListForUser(IP_ui64_UserCode, IP_ui64_ModuleCode, IP_obj_DBManager);
                        if (lcl_obj_UserModuleMenuList == null)
                        {
                            return lcl_obj_ModuleMenuCompanyTmp;
                        }
                    }

                    //Create the List of Permitted Menu Object list
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu> lcl_obj_MenuList = new System.Collections.Generic.List<CCL.BusinessEntities.UI.Menu>();
                    using (SilkERP360.BML.UI.MenuManager lcl_obj_MenuManager = new SilkERP360.BML.UI.MenuManager())
                    {
                        foreach (SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu lcl_obj_UserModuleMenu in lcl_obj_UserModuleMenuList)
                        {
                            System.UInt64 lcl_ui64_MenuCode = lcl_obj_UserModuleMenu.MenuCode;
                            SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_Menu = lcl_obj_MenuManager.getMenu(lcl_ui64_MenuCode, IP_obj_DBManager);
                            if (lcl_obj_Menu == null)
                            {
                                return null;
                            }
                            lcl_obj_MenuList.Add(lcl_obj_Menu);
                        }
                    }
                    if (lcl_obj_MenuList.Count == 0)
                    {
                        return null;
                    }
                    lcl_obj_ModuleMenuCompanyTmp.Menus = lcl_obj_MenuList;

                    //create the List of Companies whose data is accessible from this module by the user
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore> lcl_obj_CompanyCoreList =
                        new System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Base.CompanyCore>();
                    using (SilkERP360.BML.UI.UserModuleCompanyManager lcl_obj_UserModuleCompanyManager = new SilkERP360.BML.UI.UserModuleCompanyManager())
                    {
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_obj_UserModuleCompanyList =
                            lcl_obj_UserModuleCompanyManager.getUserModulesCompanyListForUser(IP_ui64_UserCode, IP_ui64_ModuleCode, IP_obj_DBManager);
                        if (lcl_obj_UserModuleCompanyList == null)
                        {
                            return null;
                        }
                        using (SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager())
                        {
                            foreach (SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany lcl_obj_UserModuleCompany in lcl_obj_UserModuleCompanyList)
                            {
                                System.UInt64 lcl_ui64_CompanyCode = lcl_obj_UserModuleCompany.CompanyCode;
                                SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = lcl_obj_CompanyManager.getCompanyCore(lcl_ui64_CompanyCode, IP_obj_DBManager);
                                if (lcl_obj_CompanyCore == null)
                                {
                                    return null;
                                }
                                lcl_obj_CompanyCoreList.Add(lcl_obj_CompanyCore);
                            }
                        }
                        lcl_obj_ModuleMenuCompanyTmp.Companys = lcl_obj_CompanyCoreList;
                    }
                    
                    return lcl_obj_ModuleMenuCompanyTmp;
                }, "BMLExceptionPolicy");
            return lcl_obj_ModuleMenuCompany;
        }
    }
}
