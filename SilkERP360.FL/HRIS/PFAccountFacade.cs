using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class PFAccountFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>
    {

        public PFAccountFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.PFAccount IP_obj_T)
        {
            System.UInt64 lcl_ui64_PFAccountNumber = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new BML.HRIS.PFAccountManager();
                System.UInt64 lcl_ui64_SalaryPFAccountNumberTmp = lcl_obj_PFAccountManager.Save(IP_obj_T);
                return lcl_ui64_SalaryPFAccountNumberTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_PFAccountNumber;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccountTmp = lcl_obj_PFAccountManager.Get(IP_ui64_Code);
                return lcl_obj_PFAccountTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_PFAccount;
        }

        public CCL.BusinessEntities.HRIS.PFAccount Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccountTmp = lcl_obj_PFAccountManager.Get(IP_str_SqlQuery);
                return lcl_obj_PFAccountTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccount> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount> lcl_obj_PFAccount = null;
            lcl_obj_PFAccount = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>>(() =>
            {
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount> lcl_obj_PFAccountTmp =
                    lcl_obj_PFAccountManager.GetList(IP_str_SqlQuery);
                return lcl_obj_PFAccountTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PFAccount;
        }

        public int Update(CCL.BusinessEntities.HRIS.PFAccount IP_obj_T)
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
