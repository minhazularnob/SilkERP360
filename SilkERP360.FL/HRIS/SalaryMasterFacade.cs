using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class SalaryMasterFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>
   {

        public SalaryMasterFacade()
        {
            this.Initialize();
        }



        public ulong Save(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_T)
        {
            System.UInt64 lcl_ui64_SalaryMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new BML.HRIS.SalaryMasterManager();
                System.UInt64 lcl_ui64_SalaryMasterCodeTmp = lcl_obj_SalaryMasterManager.Save(IP_obj_T);
                return lcl_ui64_SalaryMasterCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_SalaryMasterCode;
        }

        public CCL.BusinessEntities.HRIS.SalaryMaster Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new SilkERP360.BML.HRIS.SalaryMasterManager();
                SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterTmp = lcl_obj_SalaryMasterManager.Get(IP_ui64_Code);
                return lcl_obj_SalaryMasterTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_SalaryMaster;
        }

        public CCL.BusinessEntities.HRIS.SalaryMaster Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new SilkERP360.BML.HRIS.SalaryMasterManager();
                SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterTmp = lcl_obj_SalaryMasterManager.Get(IP_str_SqlQuery);
                return lcl_obj_SalaryMasterTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public List<CCL.BusinessEntities.HRIS.SalaryMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster> lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>>(() =>
            {
                SilkERP360.BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new SilkERP360.BML.HRIS.SalaryMasterManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster> lcl_obj_SalaryMasterTmp =
                    lcl_obj_SalaryMasterManager.GetList(IP_str_SqlQuery);
                return lcl_obj_SalaryMasterTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public int Update(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_T)
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
