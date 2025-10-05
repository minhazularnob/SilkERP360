using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class WorkGroupFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>
   {

        public WorkGroupFacade()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.HRIS.WorkGroup IP_obj_T)
       {
           System.UInt64 lcl_ui64_WorkGroupCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new BML.HRIS.WorkGroupManager();
               System.UInt64 lcl_ui64_WorkGroupCodeTmp = lcl_obj_WorkGroupManager.Save(IP_obj_T);
               return lcl_ui64_WorkGroupCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_WorkGroupCode;
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
            lcl_obj_WorkGroup = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new SilkERP360.BML.HRIS.WorkGroupManager();
                SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroupTmp = lcl_obj_WorkGroupManager.Get(IP_ui64_Code);
                return lcl_obj_WorkGroupTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_WorkGroup;
        }

        public CCL.BusinessEntities.HRIS.WorkGroup Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
           lcl_obj_WorkGroup = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new SilkERP360.BML.HRIS.WorkGroupManager();
               SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroupTmp = lcl_obj_WorkGroupManager.Get(IP_str_SqlQuery);
               return lcl_obj_WorkGroupTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_WorkGroup;
        }

       public List<CCL.BusinessEntities.HRIS.WorkGroup> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup> lcl_obj_WorkGroup = null;
           lcl_obj_WorkGroup = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>>(() =>
           {
               SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new SilkERP360.BML.HRIS.WorkGroupManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup> lcl_obj_WorkGroupTmp =
                   lcl_obj_WorkGroupManager.GetList(IP_str_SqlQuery);
               return lcl_obj_WorkGroupTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_WorkGroup;
        }

        public int Update(CCL.BusinessEntities.HRIS.WorkGroup IP_obj_T)
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
