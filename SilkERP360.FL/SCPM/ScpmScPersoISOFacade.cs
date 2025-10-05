using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScPersoISOFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>
   {

        public ScpmScPersoISOFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISO IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScPersoISOCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISOManager lcl_obj_ScPersoISOManager = new BML.SCPM.ScpmScPersoISOManager();
                System.UInt64 lcl_ui64_ScPersoISOCodeTmp = lcl_obj_ScPersoISOManager.Save(IP_obj_T);
                return lcl_ui64_ScPersoISOCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScPersoISOCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
            lcl_obj_ScPersoISO = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISOManager lcl_obj_ScPersoISOManager = new SilkERP360.BML.SCPM.ScpmScPersoISOManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISOTmp = lcl_obj_ScPersoISOManager.Get(IP_ui64_Code);
                return lcl_obj_ScPersoISOTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScPersoISO;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
            lcl_obj_ScPersoISO = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISOManager lcl_obj_ScPersoISOManager = new SilkERP360.BML.SCPM.ScpmScPersoISOManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISOTmp = lcl_obj_ScPersoISOManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScPersoISOTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPersoISO;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_obj_ScPersoISO = null;
            lcl_obj_ScPersoISO = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPersoISOManager lcl_obj_ScPersoISOManager = new SilkERP360.BML.SCPM.ScpmScPersoISOManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_obj_ScPersoISOTmp =
                    lcl_obj_ScPersoISOManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScPersoISOTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPersoISO;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScPersoISO IP_obj_T)
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
