using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
   public class PurchaseOrderFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>
    {

       public ulong Save(CCL.BusinessEntities.WPMS.PurchaseOrder IP_obj_PurchaseOrder)
        {
            //System.UInt64 lcl_ui64_PurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            //{
                SilkERP360.BML.WPMS.PurchaseOrderManager lcl_obj_PurchaseOrderManager = new BML.WPMS.PurchaseOrderManager();
                System.UInt64 lcl_ui64_ItemCodeTmp = lcl_obj_PurchaseOrderManager.Save(IP_obj_PurchaseOrder);
                return lcl_ui64_ItemCodeTmp;
            //}, "FLExceptionPolicy");
            //return lcl_ui64_PurchaseOrderCode;
        }

        public CCL.BusinessEntities.WPMS.PurchaseOrder Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
            lcl_obj_PurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
            {
                SilkERP360.BML.WPMS.PurchaseOrderManager lcl_obj_PurchaseOrderManager = new SilkERP360.BML.WPMS.PurchaseOrderManager();
                SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrderTmp = lcl_obj_PurchaseOrderManager.Get(IP_ui64_Code);
                return lcl_obj_PurchaseOrderTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_PurchaseOrder;
        }

        public CCL.BusinessEntities.WPMS.PurchaseOrder Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrder = null;
            lcl_obj_PurchaseOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>(() =>
            {
                SilkERP360.BML.WPMS.PurchaseOrderManager lcl_obj_PurchaseOrderManager = new SilkERP360.BML.WPMS.PurchaseOrderManager();
                SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder lcl_obj_PurchaseOrderTmp = lcl_obj_PurchaseOrderManager.Get(IP_str_SqlQuery);
                return lcl_obj_PurchaseOrderTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PurchaseOrder;
        }

        public List<CCL.BusinessEntities.WPMS.PurchaseOrder> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_obj_PurchaseOrder = null;
            lcl_obj_PurchaseOrder = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder>>(() =>
            {
                SilkERP360.BML.WPMS.PurchaseOrderManager lcl_obj_PurchaseOrderManager = new SilkERP360.BML.WPMS.PurchaseOrderManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder> lcl_obj_PurchaseOrderTmp =
                    lcl_obj_PurchaseOrderManager.GetList(IP_str_SqlQuery);
                return lcl_obj_PurchaseOrderTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PurchaseOrder;
        }

        public List<CCL.BusinessEntities.WPMS.PurchaseOrderDetails> GetAllPO(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_obj_PurchaseOrderDetails = null;
            lcl_obj_PurchaseOrderDetails = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails>>(() =>
            {
                SilkERP360.BML.WPMS.PurchaseOrderManager lcl_obj_PurchaseOrderManager = new SilkERP360.BML.WPMS.PurchaseOrderManager();
                lcl_obj_PurchaseOrderManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails> PurchaseOrderDetailsTmp =
                    lcl_obj_PurchaseOrderManager.GetAllPO(IP_str_SqlQuery);

                return PurchaseOrderDetailsTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PurchaseOrderDetails;
        }



        public int Update(CCL.BusinessEntities.WPMS.PurchaseOrder IP_obj_T)
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
