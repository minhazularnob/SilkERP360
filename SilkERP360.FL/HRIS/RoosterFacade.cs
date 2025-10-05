using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class RoosterFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public RoosterFacade()
        {
            this.Initialize();
        }

        public System.UInt64 SaveRoosterMaster(SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster IP_Obj_RoosterMaster)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.RoosterMasterManager lcl_obj_RoosterMasterManager = new BML.HRIS.RoosterMasterManager();
                System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_RoosterMasterManager.Save(IP_Obj_RoosterMaster);
                return lcl_ui64_EmployeeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }


        public System.UInt64 RemoveFromRooster(System.UInt64 IP_ui64_RoosterMasterCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.RoosterMasterManager lcl_obj_RoosterMasterManager = new BML.HRIS.RoosterMasterManager();
                System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_RoosterMasterManager.RemoveFromRooster(IP_ui64_RoosterMasterCode, IP_ui64_EmployeeCode);
                return lcl_ui64_EmployeeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }

        public System.UInt64 AddToRooster(System.UInt64 IP_ui64_RoosterMasterCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.RoosterMasterManager lcl_obj_RoosterMasterManager = new BML.HRIS.RoosterMasterManager();
                System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_RoosterMasterManager.AddToRooster(IP_ui64_RoosterMasterCode, IP_ui64_EmployeeCode);
                return lcl_ui64_EmployeeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }
    }
}
