using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScJobOrderItemFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>
   {

        public ScpmScJobOrderItemFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrderItem IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScJobOrderItemCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScJobOrderItemManager lcl_obj_ScJobOrderItemManager = new BML.SCPM.ScpmScJobOrderItemManager();
                System.UInt64 lcl_ui64_ScJobOrderItemCodeTmp = lcl_obj_ScJobOrderItemManager.Save(IP_obj_T);
                return lcl_ui64_ScJobOrderItemCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScJobOrderItemCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScJobOrderItem = null;
            lcl_obj_ScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScJobOrderItemManager lcl_obj_ScJobOrderItemManager = new SilkERP360.BML.SCPM.ScpmScJobOrderItemManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScJobOrderItemTmp = lcl_obj_ScJobOrderItemManager.Get(IP_ui64_Code);
                return lcl_obj_ScJobOrderItemTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScJobOrderItem;
        }

        public CCL.BusinessEntities.SCPM.ScpmScJobOrderItem Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScJobOrderItem = null;
            lcl_obj_ScJobOrderItem = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScJobOrderItemManager lcl_obj_ScJobOrderItemManager = new SilkERP360.BML.SCPM.ScpmScJobOrderItemManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScJobOrderItemTmp = lcl_obj_ScJobOrderItemManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScJobOrderItemTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScJobOrderItem;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_obj_ScJobOrderItem = null;
            lcl_obj_ScJobOrderItem = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScJobOrderItemManager lcl_obj_ScJobOrderItemManager = new SilkERP360.BML.SCPM.ScpmScJobOrderItemManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> lcl_obj_ScJobOrderItemTmp =
                    lcl_obj_ScJobOrderItemManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScJobOrderItemTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScJobOrderItem;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScJobOrderItem IP_obj_T)
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
