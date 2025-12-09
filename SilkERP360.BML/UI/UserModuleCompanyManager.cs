using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    /// <summary>
    /// This class represents the USER_MODULE_COMPANY table which contains the Company data of a Module
    /// that a User is entitled to access
    /// </summary>
    public class UserModuleCompanyManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserModuleCompanyManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Gets the Companies of a Module that a User is permitted to access.
        /// Pre-Condition: IP_obj_DBManager must be initialized and opened.
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>On Success, List<UserModuleCompany> else null</returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> getUserModulesCompanyListForUser(System.UInt64 IP_ui64_UserCode,System.UInt64 IP_ui64_ModuleCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_objLst_UserModuleCompany = null;
            lcl_objLst_UserModuleCompany = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_objLst_TmpUserModuleCompany = 
                    new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModuleCompany>();
                System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULE_COMPANY where USER_CODE = {0} and STATUS = {2} AND IS_DELETED = 1 ", IP_ui64_UserCode, IP_ui64_ModuleCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserModuleCompanyReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_UserModuleCompanyReader.HasRows == false)
                {
                    //return empty list. Signifies, no company data access permission granted
                    return lcl_objLst_TmpUserModuleCompany;
                }
                //System.UInt64 lcl_ui64_ModuleCode = 0;
                System.UInt64 lcl_ui64_CompanyCode = 0;
                while (lcl_obj_UserModuleCompanyReader.Read())
                {
                    lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_UserModuleCompanyReader["COMPANY_CODE"].ToString());
                    lcl_objLst_TmpUserModuleCompany.Add(new CCL.BusinessEntities.UI.UserModuleCompany(IP_ui64_UserCode, IP_ui64_ModuleCode,lcl_ui64_CompanyCode));
                }
                lcl_obj_UserModuleCompanyReader.Close();
                return lcl_objLst_TmpUserModuleCompany;
            }, "BMLExceptionPolicy");
            return lcl_objLst_UserModuleCompany;
        }

        /// <summary>
        /// Gets the Companies of a Module that a User is permitted to access.
        /// Pre-Condition: IP_obj_DBManager must be initialized and opened.
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>On Success, List<UserModuleCompany> else null</returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> getUserModulesCompanyListForUser(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_objLst_UserModuleCompany = null;
            lcl_objLst_UserModuleCompany = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.UserModuleCompany> lcl_objLst_TmpUserModuleCompany =
                        new System.Collections.Generic.List<CCL.BusinessEntities.UI.UserModuleCompany>();
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULE_COMPANY where USER_CODE = {0} and STATUS = {2} AND IS_DELETED = 1 ", IP_ui64_UserCode, IP_ui64_ModuleCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserModuleCompanyReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_UserModuleCompanyReader.HasRows == false)
                    {
                        //return empty list. Signifies, no company data access permission granted
                        return lcl_objLst_TmpUserModuleCompany;
                    }
                    //System.UInt64 lcl_ui64_ModuleCode = 0;
                    System.UInt64 lcl_ui64_CompanyCode = 0;
                    while (lcl_obj_UserModuleCompanyReader.Read())
                    {
                        lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_UserModuleCompanyReader["COMPANY_CODE"].ToString());
                        lcl_objLst_TmpUserModuleCompany.Add(new CCL.BusinessEntities.UI.UserModuleCompany(IP_ui64_UserCode, IP_ui64_ModuleCode, lcl_ui64_CompanyCode));
                    }
                    lcl_obj_UserModuleCompanyReader.Close();
                    return lcl_objLst_TmpUserModuleCompany;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_UserModuleCompany;
        }
    }
}
