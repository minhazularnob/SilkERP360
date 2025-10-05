using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
   public class ScpmScJobOrderFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>
   {

       public ScpmScJobOrderFacade()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrder IP_obj_T)
       {
           System.UInt64 lcl_ui64_ScpmScJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.SCPM.ScpmScJobOrderManager lcl_obj_ScpmScJobOrderManager = new BML.SCPM.ScpmScJobOrderManager();
               System.UInt64 lcl_ui64_ScpmScJobOrderCodeTmp = lcl_obj_ScpmScJobOrderManager.Save(IP_obj_T);
               return lcl_ui64_ScpmScJobOrderCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_ScpmScJobOrderCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               SilkERP360.BML.SCPM.ScpmScJobOrderManager lcl_obj_ScpmScJobOrderManager = new SilkERP360.BML.SCPM.ScpmScJobOrderManager();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrderTmp = lcl_obj_ScpmScJobOrderManager.Get(IP_ui64_Code);
               return lcl_obj_ScpmScJobOrderTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_ScpmScJobOrder;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               SilkERP360.BML.SCPM.ScpmScJobOrderManager lcl_obj_ScpmScJobOrderManager = new SilkERP360.BML.SCPM.ScpmScJobOrderManager();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrderTmp = lcl_obj_ScpmScJobOrderManager.Get(IP_str_SqlQuery);
               return lcl_obj_ScpmScJobOrderTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>>(() =>
           {
               SilkERP360.BML.SCPM.ScpmScJobOrderManager lcl_obj_ScpmScJobOrderManager = new SilkERP360.BML.SCPM.ScpmScJobOrderManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_obj_ScpmScJobOrderTmp =
                   lcl_obj_ScpmScJobOrderManager.GetList(IP_str_SqlQuery);
               return lcl_obj_ScpmScJobOrderTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public int Update(CCL.BusinessEntities.SCPM.ScpmScJobOrder IP_obj_T)
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
