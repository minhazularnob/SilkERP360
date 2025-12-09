using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRISFactory
{
    public class SalaryFactory : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SalaryFactory()
        {
            this.Initialize();
        }

        public System.Boolean IsSalaryProcessed(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_end_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_MASTER WHERE COMPANY_CODE = {0} AND SALARY_MONTH = {1} AND SALARY_YEAR = {2}", IP_ui64_CompanyCode, (System.UInt32)IP_end_SalaryMonth, IP_ui16_SalaryYear);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SalaryMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_SalaryMasterReader.HasRows == true)
                    {
                        lcl_obj_SalaryMasterReader.Close();
                        return true;
                    }
                    else
                    {
                        lcl_obj_SalaryMasterReader.Close();
                        return false;
                    }
                }
            }, "BMLExceptionPolicy");
            return lcl_b_Response;
        }
    }
}
