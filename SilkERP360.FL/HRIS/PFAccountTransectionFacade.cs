using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class PFAccountTransectionFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>
    {

        public PFAccountTransectionFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.PFAccountTransaction IP_obj_T)
        {
            System.UInt64 lcl_ui64_PFAccountTransectionCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransectionManager = new BML.HRIS.PFAccountTransactionManager();
                System.UInt64 lcl_ui64_SalaryPFAccountNumberTmp = lcl_obj_PFAccountTransectionManager.Save(IP_obj_T);
                return lcl_ui64_SalaryPFAccountNumberTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_PFAccountTransectionCode;
        
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransectionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransectionTmp = lcl_obj_PFAccountTransectionManager.Get(IP_ui64_Code);
                return lcl_obj_PFAccountTransectionTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_PFAccountTransection;
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransectionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransectionTmp = lcl_obj_PFAccountTransectionManager.Get(IP_str_SqlQuery);
                return lcl_obj_PFAccountTransectionTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccountTransaction> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransectionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_obj_PFAccountTransectionTmp =
                    lcl_obj_PFAccountTransectionManager.GetList(IP_str_SqlQuery);
                return lcl_obj_PFAccountTransectionTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public int Update(CCL.BusinessEntities.HRIS.PFAccountTransaction IP_obj_T)
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
