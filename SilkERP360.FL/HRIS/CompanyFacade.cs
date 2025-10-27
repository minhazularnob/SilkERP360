using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class CompanyFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
      public CompanyFacade()
      {
          this.Initialize();
      }

      public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> GetAllCompanyWise()
      {
          System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_obj_Company = null;
          lcl_obj_Company = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>>(() =>
          {
              System.String lcl_str_SqlQuery = System.String.Format(@"Select COMPANY_CODE,NAME,ADDRESS,PHONE_NO,FAX_NO,EMAIL,WEB_SITE,COMPANY_SHORT_NAME From  COMPANY
               where is_deleted=1 order by COMPANY_CODE desc");
              SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
              System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_obj_CompanyTmp = lcl_obj_CompanyManager.GetList(lcl_str_SqlQuery);
              return lcl_obj_CompanyTmp;
          }, "FLExceptionPolicy");
          return lcl_obj_Company;
      }

        public System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee> GetAllEmployeeList(UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee> lcl_obj_Employee = null;
            lcl_obj_Employee = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,emp.IS_DELETED
                                                                        FROM EMPLOYEE EMP
                                                                        JOIN EMPLOYEE_PERSONAL EMP_P
                                                                        ON EMP.EMPLOYEE_CODE = EMP_P.EMPLOYEE_CODE 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1", IP_ui64_CompanyCode, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee> lcl_obj_EmployeeTmp = lcl_obj_CompanyManager.GetAllEmployeeList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Employee;
        }
    }
}
