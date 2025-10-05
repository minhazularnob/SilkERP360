using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class SalaryService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SalaryService()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure GetSalaryStructureByEmployee(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_SalaryStructure = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_TmpSalaryStructure = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //System.String lcl_str_DBQuery = System.String.Format(@"SELECT * FROM EMPLOYEE_SALARY_STRUCTURE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);

                    SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_EmployeeSalaryStructureManager = new BML.HRIS.EmployeeSalaryStructureManger();
                    lcl_obj_TmpSalaryStructure = lcl_obj_EmployeeSalaryStructureManager.Get(IP_ui64_EmployeeCode, lcl_obj_DBManager.InternalResource);
                    
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpSalaryStructure;
            }, "SPExceptionPolicy");
            return lcl_obj_SalaryStructure;
        }
    }
}
