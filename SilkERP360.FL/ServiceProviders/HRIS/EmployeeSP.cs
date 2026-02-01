using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.HRIS
{
    public class EmployeeSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeSP()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> GetMiniEmplpoyeeProfileListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeMiniProfileListRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>>(() =>
            {
                SilkERP360.BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new SilkERP360.BML.Services.HRIS.EmployeeServices();
                lcl_obj_EmployeeService.Initialize();
                return lcl_obj_EmployeeService.GetMiniEmplpoyeeProfileListByCompany(IP_ui64_CompanyCode);
            }, "FLExceptionPolicy");
            return lcl_objLst_EmployeeMiniProfileListRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> GetAllActiveEmployeeByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeMiniProfileListRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>>(() =>
            {
                SilkERP360.BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new SilkERP360.BML.Services.HRIS.EmployeeServices();
                lcl_obj_EmployeeService.Initialize();
                return lcl_obj_EmployeeService.GetAllActiveEmployeeByCompany(IP_ui64_CompanyCode);
            }, "FLExceptionPolicy");
            return lcl_objLst_EmployeeMiniProfileListRet;
        }
    }
}
