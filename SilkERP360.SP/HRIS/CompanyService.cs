using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class CompanyService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public CompanyService()
        {
            this.Initialize();
        }

        public System.UInt64 SaveCompany(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_Obj_Company)
        {
            System.UInt64 lcl_ui64_CompanyCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_HolidayMasterManager = new BML.HRIS.CompanyManager();
                System.UInt64 lcl_ui64_CompanyCodeTmp = lcl_obj_HolidayMasterManager.Save(IP_Obj_Company);
                return lcl_ui64_CompanyCodeTmp;
            }, "SPExceptionPolicy");
            return lcl_ui64_CompanyCode;
        }

        public bool DeleteCompany(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_Obj_Company)
        {
            bool isDeleted = this.ExceptionManager.Process<bool>(() =>
            {
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_HolidayMasterManager = new BML.HRIS.CompanyManager();
                isDeleted = lcl_obj_HolidayMasterManager.DeleteCompany(IP_Obj_Company);
                return isDeleted;
            }, "SPExceptionPolicy");
            return isDeleted;
        }
    }
}
