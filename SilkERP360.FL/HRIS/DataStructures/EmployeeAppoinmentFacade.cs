using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS.DataStructures
{
    public class EmployeeAppoinmentFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeAppoinmentFacade()
        {
            this.Initialize();
        }

        public System.UInt64 Save(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment IP_obj_EmployeeAppoinment)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
                {
                    SilkERP360.BML.HRIS.DataStructures.EmployeeAppoinmentManager lcl_obj_EmployeeAppoinmentManager = new BML.HRIS.DataStructures.EmployeeAppoinmentManager();
                    System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_EmployeeAppoinmentManager.Save(IP_obj_EmployeeAppoinment);
                    return lcl_ui64_EmployeeCodeTmp;
                }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }

    }
}
