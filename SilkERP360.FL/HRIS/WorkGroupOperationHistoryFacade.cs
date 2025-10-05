using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class WorkGroupOperationHistoryFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>
   {

       public WorkGroupOperationHistoryFacade()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroupOperationHistory IP_obj_T)
       {
           System.UInt64 lcl_ui64_WorkGroupOperationHistoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new BML.HRIS.WorkGroupOperationHistoryManager();
               System.UInt64 lcl_ui64_WorkGroupOperationHistoryCodeTmp = lcl_obj_WorkGroupOperationHistoryManager.Save(IP_obj_T);
               return lcl_ui64_WorkGroupOperationHistoryCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_WorkGroupOperationHistoryCode;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager();
               SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistoryTmp = lcl_obj_WorkGroupOperationHistoryManager.Get(IP_ui64_Code);
               return lcl_obj_WorkGroupOperationHistoryTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_WorkGroupOperationHistory;
       }

       public CCL.BusinessEntities.HRIS.WorkGroupOperationHistory Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager();
               SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistoryTmp = lcl_obj_WorkGroupOperationHistoryManager.Get(IP_str_SqlQuery);
               return lcl_obj_WorkGroupOperationHistoryTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public List<CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_obj_WorkGroupOperationHistory = null;
           lcl_obj_WorkGroupOperationHistory = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory>>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_obj_WorkGroupOperationHistoryTmp =
                   lcl_obj_WorkGroupOperationHistoryManager.GetList(IP_str_SqlQuery);
               return lcl_obj_WorkGroupOperationHistoryTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_WorkGroupOperationHistory;
       }

       public int Update(CCL.BusinessEntities.HRIS.WorkGroupOperationHistory IP_obj_T)
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
