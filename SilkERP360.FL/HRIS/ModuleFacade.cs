using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class ModuleFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public ModuleFacade()
        {
            this.Initialize();
        }

        // SaveModule
        public System.UInt64 SaveModule(SilkERP360.CCL.BusinessEntities.HRIS.Module IP_Obj_Module)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.ModuleManager lcl_obj_ModuleManager = new BML.HRIS.ModuleManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_ModuleManager.Save(IP_Obj_Module);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> GetAllModuleWise(System.UInt64 IP_ui64_UserName)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> lcl_obj_Module = null;
            lcl_obj_Module = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select L.MODULE_CODE,MODULE_NAME,SHORT_NAME,nvl(Status,0)Status  from
                                                         (select MODULE_CODE,MODULE_NAME,SHORT_NAME  from module Where is_deleted=1)L
                                                         Left outer join
                                                        (Select A.user_code,module_code,1 Status from
                                                        (Select user_code,employee_code from users
                                                        Where user_code={0})A
                                                        Left outer join
                                                        (Select user_code,module_code from USER_MODULES
                                                        Where IS_DELETED=1)B on A.user_code=B.user_code)S on L.module_code=S.module_code order by L.MODULE_CODE ", IP_ui64_UserName);
                SilkERP360.BML.HRIS.ModuleManager lcl_obj_ModuleManager = new SilkERP360.BML.HRIS.ModuleManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> lcl_obj_ModuleTmp =
                    lcl_obj_ModuleManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_ModuleTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Module;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_ModuleCode"></param>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <returns></returns>

        public System.UInt64 AddModule(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.ModuleManager lcl_obj_RoosterMasterManager = new BML.HRIS.ModuleManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_RoosterMasterManager.AddModule(IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="IP_ui64_ModuleCode"></param>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <returns></returns>
        public System.UInt64 RemoveModule(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.ModuleManager lcl_obj_RoosterMasterManager = new BML.HRIS.ModuleManager();
                System.UInt64 lcl_ui64_ModuleCodeTmp = lcl_obj_RoosterMasterManager.RemoveModule(IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                return lcl_ui64_ModuleCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ModuleCode;
        }

        
    

    }
}
