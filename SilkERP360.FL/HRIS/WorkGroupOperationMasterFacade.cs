using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class WorkGroupOperationMasterFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>
   {

        public WorkGroupOperationMasterFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_T)
        {
            System.UInt64 lcl_ui64_WorkGroupOperationMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new BML.HRIS.WorkGroupOperationMasterManager();
                System.UInt64 lcl_ui64_WorkGroupOperationMasterCodeTmp = lcl_obj_WorkGroupOperationMasterManager.Save(IP_obj_T);
                return lcl_ui64_WorkGroupOperationMasterCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_WorkGroupOperationMasterCode;
        }

        public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
            lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMasterTmp = lcl_obj_WorkGroupOperationMasterManager.Get(IP_ui64_Code);
                return lcl_obj_WorkGroupOperationMasterTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_WorkGroupOperationMaster;
        }

        public CCL.BusinessEntities.HRIS.WorkGroupOperationMaster Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = null;
            lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMasterTmp = lcl_obj_WorkGroupOperationMasterManager.Get(IP_str_SqlQuery);
                return lcl_obj_WorkGroupOperationMasterTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WorkGroupOperationMaster;
        }

        public List<CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_obj_WorkGroupOperationMaster = null;
            lcl_obj_WorkGroupOperationMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster>>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_obj_WorkGroupTmp =
                    lcl_obj_WorkGroupOperationMasterManager.GetList(IP_str_SqlQuery);
                return lcl_obj_WorkGroupTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WorkGroupOperationMaster;
        }

        public int Update(CCL.BusinessEntities.HRIS.WorkGroupOperationMaster IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            System.Int32 lcl_i32_RowsUpdated = this.ExceptionManager.Process<System.Int32>(() =>
            {
                System.Int32 lcl_i32_RowsUpdatedTmp = 0;
                SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
                lcl_obj_SqlManager.Initialize();
                System.Object lcl_obj_Response = lcl_obj_SqlManager.ExecuteScaler(IP_str_SqlUpdateQuery);
                lcl_obj_SqlManager.Close();
                lcl_i32_RowsUpdatedTmp = System.Int32.Parse(lcl_obj_Response.ToString());
                return lcl_i32_RowsUpdatedTmp;
            }, "FLExceptionPolicy");
            return lcl_i32_RowsUpdated;
        }
   }
}
