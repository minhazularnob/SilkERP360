using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class WorkGroupServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public WorkGroupServices()
        {
            this.Initialize();
        }


        public System.UInt64 SaveWorkGroupOperationMasterByDateRange(System.DateTime IP_dt_DateFrom, System.DateTime IP_dt_DateUpto, SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_WorkGroupOperationMaster)
        {
            System.UInt64 lcl_ui64_Response = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                System.UInt64 lcl_ui64_ResponseTmp = 0;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupMasterManager = new BML.HRIS.WorkGroupOperationMasterManager();
                    lcl_obj_WorkGroupMasterManager.Initialize();
                    SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupHistoryManager = new BML.HRIS.WorkGroupOperationHistoryManager();
                    lcl_obj_WorkGroupHistoryManager.Initialize();
                    for (System.DateTime lcl_dt_Date = IP_dt_DateFrom; lcl_dt_Date <= IP_dt_DateUpto; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                    {
                        IP_obj_WorkGroupOperationMaster.WorkDate = lcl_dt_Date;
                        System.UInt64 lcl_ui64_WGOperationMasterCode = lcl_obj_WorkGroupMasterManager.Save(IP_obj_WorkGroupOperationMaster, lcl_obj_DBManager.InternalResource);
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WGOperationHistory in IP_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection)
                        {
                            lcl_obj_WGOperationHistory.WorkGroupOperationMasterCode = lcl_ui64_WGOperationMasterCode;
                            lcl_obj_WorkGroupHistoryManager.Save(lcl_obj_WGOperationHistory, lcl_obj_DBManager.InternalResource);
                        }
                    }
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_ui64_ResponseTmp;
            }, "SPExceptionPolicy");
            return lcl_ui64_Response;
        }
    }
}
