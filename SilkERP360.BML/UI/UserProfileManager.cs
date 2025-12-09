using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    /// <summary>
    /// This Class creates the Profile for the authenticated user
    /// </summary>
    public class UserProfileManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserProfileManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>
        /// 0.All Success, UserProfile Object
        /// </returns>
        public SilkERP360.CCL.BusinessEntities.UI.UserProfile CreateProfileForUser(System.UInt64 IP_ui64_UserCode)
        {
            SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = null;
            lcl_obj_UserProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.UserProfile>(() =>
                {
                    System.UInt64 lcl_ui64_CompanyCode = 0;
                    System.UInt64 lcl_ui64_DepartmentCode = 0;
                    System.UInt64 lcl_ui64_DesignationCode = 0;
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT USR_MOD.MODULE_CODE,MOD.MODULE_NAME,MOD.SHORT_NAME,MOD.HOME_LINK," +
                        "USR_MOD.USER_CODE,USR.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.DESIGNATION_CODE,EMP.DEPARTMENT_CODE," +
                        "EMP.COMPANY_CODE,USR.USER_NAME,USR.PASSWORD,USR.ACCESS_LEVEL FROM USER_MODULES USR_MOD JOIN MODULE MOD " +
                        "ON USR_MOD.MODULE_CODE = MOD.MODULE_CODE JOIN USERS USR ON USR_MOD.USER_CODE = USR.USER_CODE " +
                        "JOIN EMPLOYEE EMP ON USR.EMPLOYEE_CODE = EMP.EMPLOYEE_CODE " +
                        "WHERE USR_MOD.USER_CODE = {0} AND USR_MOD.STATUS = 1 AND USR_MOD.IS_DELETED = 1",IP_ui64_UserCode);

                    
                    SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfileTmp = new SilkERP360.CCL.BusinessEntities.UI.UserProfile();
                    //get permitted modules
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        lcl_obj_DBManager.InternalResource.Initialize();
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }
                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_UserReader.HasRows == false)
                        {
                            return null;
                        }
                        lcl_obj_UserReader.Read();
                        //GET USER CREDENTIALS.ALL ROWS CONTAIN SAME DATA WITH DIFFERENCE IN MODULE_CODE ONLY
                        lcl_obj_UserProfileTmp.UserCode = IP_ui64_UserCode;
                        lcl_obj_UserProfileTmp.UserName = lcl_obj_UserReader["USER_NAME"].ToString();
                        lcl_obj_UserProfileTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_UserReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_UserProfileTmp.EmployeeID = lcl_obj_UserReader["EMPLOYEE_ID"].ToString();
                        lcl_obj_UserProfileTmp.EmployeeName = lcl_obj_UserReader["EMPLOYEE_NAME"].ToString();
                        lcl_obj_UserProfileTmp.Password = lcl_obj_UserReader["PASSWORD"].ToString();
                        lcl_obj_UserProfileTmp.AccessLevel = System.UInt16.Parse(lcl_obj_UserReader["ACCESS_LEVEL"].ToString());
                        lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_UserReader["COMPANY_CODE"].ToString());
                        lcl_ui64_DesignationCode = System.UInt64.Parse(lcl_obj_UserReader["DESIGNATION_CODE"].ToString());
                        lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_obj_UserReader["DEPARTMENT_CODE"].ToString());
                        
                        

                        SilkERP360.BML.UI.UserModuleMenuManager lcl_obj_UserModuleMenuManager = new SilkERP360.BML.UI.UserModuleMenuManager();
                        do
                        {
                            SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompany = new SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany();
                            //MODULE_CODE WISE LOOP
                            //Permitted Module
                            System.UInt64 lcl_ui64_ModuleCode = System.UInt64.Parse(lcl_obj_UserReader["Module_Code"].ToString());
                            System.String lcl_str_ModuleName = lcl_obj_UserReader["Module_Name"].ToString();
                            System.String lcl_str_ShortName = lcl_obj_UserReader["Short_Name"].ToString();
                            System.String lcl_str_HomeLink = lcl_obj_UserReader["Home_Link"].ToString();

                            lcl_obj_ModuleMenuCompany.ModuleCode = lcl_ui64_ModuleCode;
                            lcl_obj_ModuleMenuCompany.ModuleName = lcl_str_ModuleName;
                            lcl_obj_ModuleMenuCompany.ShortName = lcl_str_ShortName;
                            lcl_obj_ModuleMenuCompany.HomeLink = lcl_str_HomeLink;
                            
                            //GET PERMITTED MENUS
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu> lcl_objLst_Menus = new System.Collections.Generic.List<CCL.BusinessEntities.UI.Menu>();

                            lcl_str_SqlQuery = System.String.Format("SELECT USR_MOD_MNU.MENU_CODE,MNU.MENU_NAME,MNU.MENU_LINK,MNU.MENU_LABEL,MNU.PARENT_MENU_CODE " +
                                                                    "FROM USERS USR JOIN USER_MODULE_MENUS USR_MOD_MNU ON USR.USER_CODE = USR_MOD_MNU.USER_CODE " +
                                                                    "JOIN MENU MNU ON USR_MOD_MNU.MENU_CODE = MNU.MENU_CODE " +
                                                                    "WHERE USR_MOD_MNU.USER_CODE = {0} AND USR_MOD_MNU.MODULE_CODE = {1} AND USR_MOD_MNU.STATUS = 1 " +
                                                                    "AND USR_MOD_MNU.IS_DELETED = 1",IP_ui64_UserCode,lcl_ui64_ModuleCode);

                            using (var lcl_obj_DBManagerTmp = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                            {
                                lcl_obj_DBManagerTmp.InternalResource.Initialize();
                                if (lcl_obj_DBManagerTmp.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                                {
                                    lcl_obj_DBManagerTmp.InternalResource.Open();
                                }

                                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MenuReader = lcl_obj_DBManagerTmp.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                                if (lcl_obj_MenuReader.HasRows == true)
                                {
                                    while (lcl_obj_MenuReader.Read())
                                    {
                                        SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_Menu = new SilkERP360.CCL.BusinessEntities.UI.Menu();
                                        lcl_obj_Menu.MenuCode = System.UInt64.Parse(lcl_obj_MenuReader["Menu_Code"].ToString());
                                        lcl_obj_Menu.ModuleCode = lcl_ui64_ModuleCode;
                                        lcl_obj_Menu.MenuName = lcl_obj_MenuReader["Menu_Name"].ToString();
                                        lcl_obj_Menu.MenuLabel = lcl_obj_MenuReader["Menu_Label"].ToString();
                                        lcl_obj_Menu.Link = lcl_obj_MenuReader["Menu_Link"].ToString();
                                        System.String lcl_str_ParentMenuCode = lcl_obj_MenuReader["Parent_Menu_Code"].ToString();
                                        lcl_obj_Menu.ParentMenuCode = (lcl_str_ParentMenuCode == "") ? null : (System.Nullable<System.UInt64>)System.UInt64.Parse(lcl_str_ParentMenuCode);
                                        lcl_objLst_Menus.Add(lcl_obj_Menu);
                                    }
                                    lcl_obj_MenuReader.Close();
                                }

                                lcl_obj_ModuleMenuCompany.Menus = lcl_objLst_Menus;

                                //get the list of Permitted Companies for this module
                                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Base.CompanyCore> lcl_objLst_Companies = new System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Base.CompanyCore>();
                                lcl_str_SqlQuery = System.String.Format("SELECT COM.COMPANY_CODE,COM.NAME FROM COMPANY COM JOIN USER_MODULE_COMPANY USR_MOD_COM " +
                                        "ON COM.COMPANY_CODE = USR_MOD_COM.COMPANY_CODE WHERE USR_MOD_COM.USER_CODE = {0} " +
                                        "AND USR_MOD_COM.MODULE_CODE = {1} AND USR_MOD_COM.STATUS = 1 AND USR_MOD_COM.IS_DELETED = 1",IP_ui64_UserCode,lcl_ui64_ModuleCode);

                                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManagerTmp.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                                if (lcl_obj_CompanyReader.HasRows == true)
                                {
                                    while (lcl_obj_CompanyReader.Read())
                                    {
                                        System.UInt64 lcl_ui64_CompanyCodeTmp = System.UInt64.Parse(lcl_obj_CompanyReader["Company_Code"].ToString());
                                        System.String lcl_str_CompanyName = lcl_obj_CompanyReader["Name"].ToString();
                                        lcl_objLst_Companies.Add(new CCL.BusinessEntities.HRIS.Base.CompanyCore(lcl_ui64_CompanyCodeTmp, lcl_str_CompanyName));
                                    }
                                    lcl_obj_CompanyReader.Close();
                                }

                                lcl_obj_ModuleMenuCompany.Companys = lcl_objLst_Companies;

                                //get CompanyCore Object that the user belongs to
                                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                                SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_Company = lcl_obj_CompanyManager.getCompanyCore(lcl_ui64_CompanyCode, lcl_obj_DBManagerTmp.InternalResource);

                                //get DepartmentCore Object that the user belongs to
                                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                                SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_Department = lcl_obj_DepartmentManager.GetDepartmentCore(lcl_ui64_DepartmentCode, lcl_obj_DBManagerTmp.InternalResource);

                                //get DepartmentCore Object that the user belongs to
                                SilkERP360.BML.HRIS.DesignationManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.DesignationManager();
                                SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore lcl_obj_Designation = lcl_obj_DesignationManager.getDesignationCore(lcl_ui64_DesignationCode, lcl_obj_DBManagerTmp.InternalResource);

                                //get EmployeeImage
                                SilkERP360.BML.HRIS.EmployeeManager lcl_obj_EmployeeManager = new SilkERP360.BML.HRIS.EmployeeManager();
                                lcl_obj_UserProfileTmp.Image = lcl_obj_EmployeeManager.GetEmployeeImageFromCode(lcl_obj_UserProfileTmp.EmployeeCode, lcl_obj_DBManagerTmp.InternalResource);
                                lcl_obj_UserProfileTmp.Company = lcl_obj_Company;

                                lcl_obj_UserProfileTmp.Designation = lcl_obj_Designation;
                                lcl_obj_UserProfileTmp.Department = lcl_obj_Department;
                            }
                            lcl_obj_UserProfileTmp.ModuleMenusCompanies.Add(lcl_obj_ModuleMenuCompany);
                        }while(lcl_obj_UserReader.Read());
                    }
                    return lcl_obj_UserProfileTmp;
                }, "BMLExceptionPolicy");
            return lcl_obj_UserProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>
        /// 0.All Success, UserProfile Object
        /// </returns>
        //public SilkERP360.CCL.BusinessEntities.UI.UserProfile CreateProfileForUser(System.UInt64 IP_ui64_UserCode)
        //{
        //    SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = null;
        //    lcl_obj_UserProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.UserProfile>(() =>
        //        {
        //            SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfileTmp = new SilkERP360.CCL.BusinessEntities.UI.UserProfile();
        //            //get permitted modules
        //            using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
        //            {
        //                lcl_obj_DBManager.InternalResource.Initialize();
        //                if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
        //                {
        //                    lcl_obj_DBManager.InternalResource.Open();
        //                }

        //                //populate User details
        //                using (SilkERP360.BML.UI.UserManager lcl_obj_UserManager = new SilkERP360.BML.UI.UserManager())
        //                {
        //                    SilkERP360.CCL.BusinessEntities.UI.User lcl_obj_User = lcl_obj_UserManager.getUser(IP_ui64_UserCode, lcl_obj_DBManager.InternalResource);
        //                    if (lcl_obj_User == null)
        //                    {
        //                        return null;
        //                    }
        //                    lcl_obj_UserProfileTmp.EmployeeCode = lcl_obj_User.EmployeeCode;
        //                    lcl_obj_UserProfileTmp.UserCode = lcl_obj_User.UserCode;
        //                    lcl_obj_UserProfileTmp.UserName = lcl_obj_User.UserName;
        //                    lcl_obj_UserProfileTmp.Password = lcl_obj_User.Password;
        //                    lcl_obj_UserProfileTmp.AccessLevel = lcl_obj_User.AccessLevel;
        //                    using (SilkERP360.BML.HRIS.EmployeeManager lcl_obj_EmployeeManager = new SilkERP360.BML.HRIS.EmployeeManager())
        //                    {
        //                        lcl_obj_UserProfileTmp.EmployeeName = lcl_obj_EmployeeManager.getEmployeeName(lcl_obj_UserProfileTmp.EmployeeCode, lcl_obj_DBManager.InternalResource);
        //                        if (lcl_obj_UserProfileTmp.EmployeeName == System.String.Empty)
        //                        {
        //                            lcl_obj_UserProfileTmp.EmployeeName = "NO NAME";
        //                        }
        //                    }
        //                }
        //                lcl_obj_UserProfileTmp.ModuleMenusCompanies = new System.Collections.Generic.List<CCL.BusinessEntities.UI.ModuleMenuCompany>();
        //                using (SilkERP360.BML.UI.UserModuleManager lcl_obj_UserModuleManager = new SilkERP360.BML.UI.UserModuleManager())
        //                {
        //                    //get Permitted Modules of User
        //                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModule> lcl_objLst_PermittedUserModules = lcl_obj_UserModuleManager.getUserModulesForUser(lcl_obj_UserProfileTmp.UserCode,lcl_obj_DBManager.InternalResource);
        //                    if (lcl_objLst_PermittedUserModules.Count == 0)
        //                    {
        //                        //return empty list.the user is not permitted to access any module
        //                        return lcl_obj_UserProfileTmp;
        //                    }
        //                    SilkERP360.BML.UI.MenuManager lcl_obj_MenuManager = new SilkERP360.BML.UI.MenuManager();
        //                    SilkERP360.BML.UI.UserModuleCompanyManager lcl_obj_UserModuleCompanyManager = new SilkERP360.BML.UI.UserModuleCompanyManager();
        //                    SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
        //                    //User has permitted modules
        //                    using(SilkERP360.BML.UI.UserModuleMenuManager lcl_obj_UserModuleMenuManager = new SilkERP360.BML.UI.UserModuleMenuManager())
        //                    {
        //                        using(SilkERP360.BML.UI.ModuleManager lcl_obj_ModuleManager = new SilkERP360.BML.UI.ModuleManager())
        //                        {
        //                            foreach (SilkERP360.CCL.BusinessEntities.UI.UserModule lcl_obj_UserModule in lcl_objLst_PermittedUserModules)
        //                            {
        //                                SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_Module = lcl_obj_ModuleManager.getModuleByCode(lcl_obj_UserModule.ModuleCode);
        //                                SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompany = new SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany();
        //                                lcl_obj_ModuleMenuCompany.ModuleCode = lcl_obj_Module.ModuleCode;
        //                                lcl_obj_ModuleMenuCompany.ModuleName = lcl_obj_Module.ModuleName;
        //                                lcl_obj_ModuleMenuCompany.ShortName = lcl_obj_Module.ShortName;
        //                                lcl_obj_ModuleMenuCompany.HomeLink = lcl_obj_Module.HomeLink;

        //                                //get permitted menus for each permitted Module
        //                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu> lcl_objLst_UserModuleMenu =
        //                                lcl_obj_UserModuleMenuManager.getUserModuleMenusListForUser(IP_ui64_UserCode, lcl_obj_UserModule.ModuleCode, lcl_obj_DBManager.InternalResource);
        //                                if (lcl_objLst_UserModuleMenu.Count == 0)
        //                                {
        //                                    //The user is permitted to access Module but no menu has yet been permitted
        //                                    //return empty list.the user is not permitted to access any menu
        //                                    //lcl_obj_UserProfileTmp.ModuleMenusCompanies = new System.Collections.Generic.List<CCL.BusinessEntities.UI.ModuleMenuCompany>();
        //                                    lcl_obj_UserProfileTmp.ModuleMenusCompanies.Add(lcl_obj_ModuleMenuCompany);
        //                                    return lcl_obj_UserProfileTmp;
        //                                }
        //                                //permitted menu found for module
        //                                foreach (SilkERP360.CCL.BusinessEntities.UI.UserModuleMenu lcl_obj_UserModuleMenu in lcl_objLst_UserModuleMenu)
        //                                {
        //                                    System.UInt64 lcl_ui64_MenuCode = lcl_obj_UserModuleMenu.MenuCode;
        //                                    SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_Menu = lcl_obj_MenuManager.getMenu(lcl_ui64_MenuCode);
        //                                    lcl_obj_ModuleMenuCompany.Menus.Add(lcl_obj_Menu);
        //                                }

        //                                //get the Permitted Company for the user that the user is allowed to access from the module
        //                                //get permitted menus for each permitted Module
        //                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_objLst_UserModuleCompany =
        //                                lcl_obj_UserModuleCompanyManager.getUserModulesCompanyListForUser(IP_ui64_UserCode, lcl_obj_UserModule.ModuleCode, lcl_obj_DBManager.InternalResource);
        //                                if (lcl_objLst_UserModuleCompany.Count == 0)
        //                                {
        //                                    //The user is permitted to access Module but no Company Data has yet been permitted
        //                                    //return empty list.the user is not permitted to access any CompanyData
        //                                    lcl_obj_UserProfileTmp.ModuleMenusCompanies.Add(lcl_obj_ModuleMenuCompany);
        //                                    return lcl_obj_UserProfileTmp;
        //                                }
        //                                //permitted company found for module
        //                                foreach (SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany lcl_obj_UserModuleCompany in lcl_objLst_UserModuleCompany)
        //                                {
        //                                    System.UInt64 lcl_ui64_CompanyCode = lcl_obj_UserModuleCompany.CompanyCode;
        //                                    SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = lcl_obj_CompanyManager.getCompanyCore(lcl_ui64_CompanyCode);
        //                                    lcl_obj_ModuleMenuCompany.Companys.Add(lcl_obj_CompanyCore);
        //                                }
        //                                lcl_obj_UserProfileTmp.ModuleMenusCompanies.Add(lcl_obj_ModuleMenuCompany);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            return lcl_obj_UserProfileTmp;

        //        }, "BMLExceptionPolicy");
        //    return lcl_obj_UserProfile;
        //}
    }
}
