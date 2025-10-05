using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScPackagedBoxFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>
   {

        public ScpmScPackagedBoxFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPackagedBox IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScPackagedBoxCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPackagedBoxManager lcl_obj_ScPackagedBoxManager = new BML.SCPM.ScpmScPackagedBoxManager();
                System.UInt64 lcl_ui64_ScPackagedBoxCodeTmp = lcl_obj_ScPackagedBoxManager.Save(IP_obj_T);
                return lcl_ui64_ScPackagedBoxCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScPackagedBoxCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPackagedBoxManager lcl_obj_ScPackagedBoxManager = new SilkERP360.BML.SCPM.ScpmScPackagedBoxManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBoxTmp = lcl_obj_ScPackagedBoxManager.Get(IP_ui64_Code);
                return lcl_obj_ScPackagedBoxTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScPackagedBox;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPackagedBoxManager lcl_obj_ScPackagedBoxManager = new SilkERP360.BML.SCPM.ScpmScPackagedBoxManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBoxTmp = lcl_obj_ScPackagedBoxManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScPackagedBoxTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScPackagedBoxManager lcl_obj_ScPackagedBoxManager = new SilkERP360.BML.SCPM.ScpmScPackagedBoxManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_obj_ScPackagedBoxTmp =
                    lcl_obj_ScPackagedBoxManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScPackagedBoxTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScPackagedBox IP_obj_T)
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
