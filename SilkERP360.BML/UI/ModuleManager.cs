using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    public class ModuleManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public ModuleManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

              
        /// <summary>
        /// Returns the details of the Module with ModuleCode = IP_ui64_ModuleCode
        /// Pre-Condition : DBManager must be initialized and Open
        /// </summary>
        /// <param name="IP_ui64_ModuleCode">Code of the module that is to be retrieved</param>
        /// <returns>On success Module object, else the null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.Module getModuleByCode(System.UInt64 IP_ui64_ModuleCode)
        {
            SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_Module = null;
            lcl_obj_Module = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.Module>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_ModuleTmp = new SilkERP360.CCL.BusinessEntities.UI.Module();
                        System.String lcl_str_SqlQuery = System.String.Format("Select * From MODULE where MODULE_CODE = {0} AND STATUS = {1}", IP_ui64_ModuleCode, SilkERP360.CCL.Enums.Status.Active);
                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ModuleReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_ModuleReader.HasRows == false)
                        {
                            return null;
                        }
                        else
                        {
                            lcl_obj_ModuleReader.Read();
                            lcl_obj_Module.ModuleCode = IP_ui64_ModuleCode;
                            lcl_obj_Module.ModuleName = lcl_obj_ModuleReader["MODULE_NAME"].ToString();
                            lcl_obj_Module.ShortName = lcl_obj_ModuleReader["SHORT_NAME"].ToString();
                            lcl_obj_Module.HomeLink = lcl_obj_ModuleReader["HOME_LINK"].ToString();
                            return lcl_obj_ModuleTmp;
                        }
                    }
                }, "BMLExceptionPolicy");
            return lcl_obj_Module;
        }

        /// <summary>
        /// Returns the details of the Module with ModuleCode = IP_ui64_ModuleCode
        /// Pre-Condition : DBManager must be initialized and Open
        /// </summary>
        /// <param name="IP_ui64_ModuleCode">Code of the module that is to be retrieved</param>
        /// <returns>On success Module object, else the null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.Module getModuleByCode(System.UInt64 IP_ui64_ModuleCode,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_Module = null;
            lcl_obj_Module = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.Module>(() =>
            {
                SilkERP360.CCL.BusinessEntities.UI.Module lcl_obj_ModuleTmp = new SilkERP360.CCL.BusinessEntities.UI.Module();
                System.String lcl_str_SqlQuery = System.String.Format("Select * From MODULE where MODULE_CODE = {0} AND STATUS = {1} AND IS_DELETED = 1", IP_ui64_ModuleCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ModuleReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_ModuleReader.HasRows == false)
                {
                    return null;
                }
                else
                {
                    lcl_obj_ModuleReader.Read();
                    lcl_obj_Module.ModuleCode = IP_ui64_ModuleCode;
                    lcl_obj_Module.ModuleName = lcl_obj_ModuleReader["MODULE_NAME"].ToString();
                    lcl_obj_Module.ShortName = lcl_obj_ModuleReader["SHORT_NAME"].ToString();
                    lcl_obj_Module.HomeLink = lcl_obj_ModuleReader["HOME_LINK"].ToString();
                    return lcl_obj_ModuleTmp;
                }
                
            }, "BMLExceptionPolicy");
            return lcl_obj_Module;
        }

        /// <summary>
        /// Returns A List<Module> object of All the modules where Status = Active
        /// </summary>
        /// <returns>List<Module></returns>
        //public SilkERP360.CCL.Misc.FunctionResponse getActiveModules()
        //{
        //    this.ExceptionManager.Process(() =>
        //    {

        //    }, "BMLExceptionPolicy");
        //}
    }
}
