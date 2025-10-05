using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class SalaryAddDedFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>
    {

        public SalaryAddDedFacade()
        {
            this.Initialize();
        }



        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> GetSalaryAddDed(System.UInt64 IP_iu64_EmployeeCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_obj_SalaryAddDed = null;
            lcl_obj_SalaryAddDed = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"Select ADD_DED_CODE,EMPLOYEE_CODE,ADD_OR_DED,ADD_DED_TYPE,AMOUNT,EFFECTIVE_MONTH,EFFECTIVE_YEAR From  SALARY_ADDITION_DEDUCTION
               where EMPLOYEE_CODE = {0} order by EMPLOYEE_CODE desc", IP_iu64_EmployeeCode);
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_obj_SalaryAddDedTmp =
                    lcl_obj_DesignationManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_SalaryAddDedTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryAddDed;
        }



        public System.UInt64 SaveSalaryAdditionDeduction(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_Obj_SalaryAdditionDeduction)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new BML.HRIS.SalaryAdditionDeductionManager();
                System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_SalaryAdditionDeductionManager.Save(IP_Obj_SalaryAdditionDeduction);
                return lcl_ui64_EmployeeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }
        



        public ulong Save(CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_obj_SalaryAddDed = null;
            lcl_obj_SalaryAddDed = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>>(() =>
            {
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_obj_SalaryAddDedTmp =
                    lcl_obj_DesignationManager.GetList(IP_str_SqlQuery);
                return lcl_obj_SalaryAddDedTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryAddDed;
        }

        public int Update(CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
