using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class ScpmScDataRepositoryFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>
   {

        public ScpmScDataRepositoryFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScDataRepository IP_obj_T)
        {
            System.UInt64 lcl_ui64_ScDataRepositoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScDataRepositoryManager lcl_obj_ScDataRepositoryManager = new BML.SCPM.ScpmScDataRepositoryManager();
                System.UInt64 lcl_ui64_ScDataRepositoryCodeTmp = lcl_obj_ScDataRepositoryManager.Save(IP_obj_T);
                return lcl_ui64_ScDataRepositoryCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ScDataRepositoryCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
            lcl_obj_ScDataRepository = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScDataRepositoryManager lcl_obj_ScDataRepositoryManager = new SilkERP360.BML.SCPM.ScpmScDataRepositoryManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepositoryTmp = lcl_obj_ScDataRepositoryManager.Get(IP_ui64_Code);
                return lcl_obj_ScDataRepositoryTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_ScDataRepository;
        }

        public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
            lcl_obj_ScDataRepository = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScDataRepositoryManager lcl_obj_ScDataRepositoryManager = new SilkERP360.BML.SCPM.ScpmScDataRepositoryManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepositoryTmp = lcl_obj_ScDataRepositoryManager.Get(IP_str_SqlQuery);
                return lcl_obj_ScDataRepositoryTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScDataRepository;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_obj_ScDataRepository = null;
            lcl_obj_ScDataRepository = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>>(() =>
            {
                SilkERP360.BML.SCPM.ScpmScDataRepositoryManager lcl_obj_ScDataRepositoryManager = new SilkERP360.BML.SCPM.ScpmScDataRepositoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_obj_ScDataRepositoryTmp =
                    lcl_obj_ScDataRepositoryManager.GetList(IP_str_SqlQuery);
                return lcl_obj_ScDataRepositoryTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_ScDataRepository;
        }

        public int Update(CCL.BusinessEntities.SCPM.ScpmScDataRepository IP_obj_T)
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
