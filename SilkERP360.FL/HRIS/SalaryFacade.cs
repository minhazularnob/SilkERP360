using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
        public class SalaryFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Salary>
   {

        public SalaryFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.Salary IP_obj_T)
        {
            System.UInt64 lcl_ui64_SalaryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.SalaryManager lcl_obj_SalaryManager = new BML.HRIS.SalaryManager();
                System.UInt64 lcl_ui64_SalaryCodeTmp = lcl_obj_SalaryManager.Save(IP_obj_T);
                return lcl_ui64_SalaryCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_SalaryCode;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                SilkERP360.BML.HRIS.SalaryManager lcl_obj_SalaryManager = new SilkERP360.BML.HRIS.SalaryManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_SalaryTmp = lcl_obj_SalaryManager.Get(IP_ui64_Code);
                return lcl_obj_SalaryTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_Salary;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                SilkERP360.BML.HRIS.SalaryManager lcl_obj_SalaryManager = new SilkERP360.BML.HRIS.SalaryManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_SalaryTmp = lcl_obj_SalaryManager.Get(IP_str_SqlQuery);
                return lcl_obj_SalaryTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public List<CCL.BusinessEntities.HRIS.Salary> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary>>(() =>
            {
                SilkERP360.BML.HRIS.SalaryManager lcl_obj_SalaryManager = new SilkERP360.BML.HRIS.SalaryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_obj_SalaryTmp =
                    lcl_obj_SalaryManager.GetList(IP_str_SqlQuery);
                return lcl_obj_SalaryTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public int Update(CCL.BusinessEntities.HRIS.Salary IP_obj_T)
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
