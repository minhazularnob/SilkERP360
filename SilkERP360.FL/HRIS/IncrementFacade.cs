using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class IncrementFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Increment>
   {

        public IncrementFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.Increment IP_obj_T)
        {
            System.UInt64 lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
                System.UInt64 lcl_ui64_IncrementCodeTmp = lcl_obj_IncrementManager.Save(IP_obj_T);
                return lcl_ui64_IncrementCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new SilkERP360.BML.HRIS.IncrementManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_IncrementTmp = lcl_obj_IncrementManager.Get(IP_ui64_Code);
                return lcl_obj_IncrementTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new SilkERP360.BML.HRIS.IncrementManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_IncrementTmp = lcl_obj_IncrementManager.Get(IP_str_SqlQuery);
                return lcl_obj_IncrementTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public List<CCL.BusinessEntities.HRIS.Increment> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new SilkERP360.BML.HRIS.IncrementManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_obj_IncrementTmp =
                    lcl_obj_IncrementManager.GetList(IP_str_SqlQuery);
                return lcl_obj_IncrementTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public int Update(CCL.BusinessEntities.HRIS.Increment IP_obj_T)
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
