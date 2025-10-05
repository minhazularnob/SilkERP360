using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScPersoISODataFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>
   {

        public ScpmScPersoISODataFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISOData IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScPersoISODataCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISODataManager lcl_obj_ScPersoISODataManager = new BML.SCPM.ScpmScPersoISODataManager();
                System.UInt64 lcl_ui64_ScPersoISODataCodeTmp = lcl_obj_ScPersoISODataManager.Save(IP_obj_T);
                return lcl_ui64_ScPersoISODataCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScPersoISODataCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISODataManager lcl_obj_ScPersoISODataManager = new SilkERP360.BML.SCPM.ScpmScPersoISODataManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISODataTmp = lcl_obj_ScPersoISODataManager.Get(IP_ui64_Code);
                return lcl_obj_ScPersoISODataTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScPersoISOData;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISOData Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISODataManager lcl_obj_ScPersoISODataManager = new SilkERP360.BML.SCPM.ScpmScPersoISODataManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData lcl_obj_ScPersoISODataTmp = lcl_obj_ScPersoISODataManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScPersoISODataTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPersoISOData> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_obj_ScPersoISOData = null;
            lcl_obj_ScPersoISOData = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISODataManager lcl_obj_ScPersoISODataManager = new SilkERP360.BML.SCPM.ScpmScPersoISODataManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISOData> lcl_obj_ScPersoISODataTmp =
                    lcl_obj_ScPersoISODataManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScPersoISODataTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPersoISOData;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScPersoISOData IP_obj_T)
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
