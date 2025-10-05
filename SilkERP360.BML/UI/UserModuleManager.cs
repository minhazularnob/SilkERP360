using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    /// <summary>
    /// This class Manages the UserModule Class
    /// </summary>
    public class UserModuleManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserModuleManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Gets the Modules that a User is permitted to access.
        /// Pre-Condition: IP_obj_DBManager must be initialized and opened.
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>On Success, List<UserModule></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModule> getUserModulesForUser(System.UInt64 IP_ui64_UserCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModule> lcl_objLst_UserModules = null;
            lcl_objLst_UserModules = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModule>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModule> lcl_objLst_UserModulesTmp = null;
                System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULES where USER_CODE = {0} and STATUS = {1} AND IS_DELETED = 1", IP_ui64_UserCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_UserModulesReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_UserModulesReader.HasRows == false)
                {
                    //return empty list
                    return new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModule>();
                }
                lcl_objLst_UserModulesTmp = new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModule>();
                System.UInt64 lcl_ui64_ModuleCode = 0;
                while (lcl_obj_UserModulesReader.Read())
                {
                    lcl_ui64_ModuleCode = System.UInt64.Parse(lcl_obj_UserModulesReader["MODULE_CODE"].ToString());
                    lcl_objLst_UserModulesTmp.Add(new CCL.BusinessEntities.UI.UserModule(IP_ui64_UserCode, lcl_ui64_ModuleCode));
                }
                lcl_obj_UserModulesReader.Close();
                return lcl_objLst_UserModulesTmp;
            },"BMLExceptionPolicy");
            return lcl_objLst_UserModules;
        }
    }
}
