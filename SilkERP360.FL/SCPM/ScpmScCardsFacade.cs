using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScCardsFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>
   {

        public ScpmScCardsFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScCards IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScCardsCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScCardsManager lcl_obj_ScCardsManager = new BML.SCPM.ScpmScCardsManager();
                System.UInt64 lcl_ui64_ScCardsCodeTmp = lcl_obj_ScCardsManager.Save(IP_obj_T);
                return lcl_ui64_ScCardsCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScCardsCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScCardsManager lcl_obj_ScCardsManager = new SilkERP360.BML.SCPM.ScpmScCardsManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCardsTmp = lcl_obj_ScCardsManager.Get(IP_ui64_Code);
                return lcl_obj_ScCardsTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScCards;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScCardsManager lcl_obj_ScCardsManager = new SilkERP360.BML.SCPM.ScpmScCardsManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCardsTmp = lcl_obj_ScCardsManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScCardsTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScCards> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards> lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScCardsManager lcl_obj_ScCardsManager = new SilkERP360.BML.SCPM.ScpmScCardsManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards> lcl_obj_ScCardsTmp =
                    lcl_obj_ScCardsManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScCardsTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScCards IP_obj_T)
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
