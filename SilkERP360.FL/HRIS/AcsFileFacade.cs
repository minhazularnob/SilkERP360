using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class AcsFileFacade: SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public AcsFileFacade()
        {
            this.Initialize();
        }

        public System.UInt64 Save(SilkERP360.CCL.BusinessEntities.HRIS.AcsFile IP_obj_AcsFile)
        {
            System.UInt64 lcl_ui64_AttenRawDtlCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.AcsFileManager lcl_obj_AttendanceManager = new  SilkERP360.BML.HRIS.AcsFileManager();
                System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_AttendanceManager.Save(IP_obj_AcsFile);
                return lcl_ui64_EmployeeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_AttenRawDtlCode;
        }
    }
}
