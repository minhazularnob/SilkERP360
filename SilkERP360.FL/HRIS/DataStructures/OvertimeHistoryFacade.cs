using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS.DataStructures
{
    public class OvertimeHistoryFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public OvertimeHistoryFacade()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> GetDepartmentwiseOvertimeListByDateRange(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList = null;
            lcl_objLst_OvertimeHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>>(() =>
            {
                SilkERP360.BML.HRIS.DataStructures.OvertimeHistoryManager lcl_obj_OvertimeHistoryManager = new SilkERP360.BML.HRIS.DataStructures.OvertimeHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryListTmp = lcl_obj_OvertimeHistoryManager.GetDepartmentwiseOvertimeListByDateRange(IP_ui64_DepartmentCode, IP_dt_StartDate, IP_dt_EndDate);
                return lcl_objLst_OvertimeHistoryListTmp;
            }, "FLExceptionPolicy");
            return lcl_objLst_OvertimeHistoryList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> GetDepartmentwiseOvertimeListByDate(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_OvertimeDate)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList = null;
            lcl_objLst_OvertimeHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>>(() =>
            {
                SilkERP360.BML.HRIS.DataStructures.OvertimeHistoryManager lcl_obj_OvertimeHistoryManager = new SilkERP360.BML.HRIS.DataStructures.OvertimeHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryListTmp = lcl_obj_OvertimeHistoryManager.GetDepartmentwiseOvertimeListByDate(IP_ui64_DepartmentCode, IP_dt_OvertimeDate);
                return lcl_objLst_OvertimeHistoryListTmp;
            }, "FLExceptionPolicy");
            return lcl_objLst_OvertimeHistoryList;
        }
    }
}
