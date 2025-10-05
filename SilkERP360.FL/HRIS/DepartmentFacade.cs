using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class DepartmentFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Department>
    {
        public DepartmentFacade()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> GetDepartmentCoresByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCores = null;
            lcl_obj_DepartmentCores = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>>(() =>
            {
                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoresTmp = lcl_obj_DepartmentManager.GetDepartmentCoresByCompany(IP_ui64_CompanyCode);
                return lcl_obj_DepartmentCoresTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_DepartmentCores; 
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength> GetDepartmentStrengthByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength> lcl_obj_DepartmentStrengthList = null;
            lcl_obj_DepartmentStrengthList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength>>(() =>
                {
                    SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoresTmp = lcl_obj_DepartmentManager.GetDepartmentCoresByCompany(IP_ui64_CompanyCode);
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength> lcl_obj_DepartmentStrengthsTmp = new System.Collections.Generic.List<CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength>();
                    System.String lcl_str_DepartmentStrengthQuery = System.String.Empty;
                    //Declare SQLManager Object
                    SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
                    
                    foreach(SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCore in lcl_obj_DepartmentCoresTmp)
                    {
                        System.UInt64 lcl_ui64_DepartmentCode = lcl_obj_DepartmentCore.DepartmentCode;
                        //determine the Department Strength
                        lcl_str_DepartmentStrengthQuery = System.String.Format(@"SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE DEPARTMENT_CODE = {0} 
                                                          AND IS_DELETED = {1} AND (EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3} OR EMPLOYEE_STATUS = {4})", lcl_ui64_DepartmentCode,
                                                          (System.UInt32)SilkERP360.CCL.Enums.YesNo.No, (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Regular,
                                                          (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                        System.Object lcl_obj_DepartmentStrength = lcl_obj_SqlManager.ExecuteScaler(lcl_str_DepartmentStrengthQuery);
                        System.UInt32 lcl_ui32_DepartmentStrength = System.UInt32.Parse(lcl_obj_DepartmentStrength.ToString());
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength lcl_obj_DepartmentStrengthObj = new CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength(lcl_ui64_DepartmentCode, lcl_obj_DepartmentCore.Name, lcl_ui32_DepartmentStrength);
                        lcl_obj_DepartmentStrengthsTmp.Add(lcl_obj_DepartmentStrengthObj);
                    }
                    //lcl_obj_SqlManager.CloseReader();
                    lcl_obj_SqlManager.Close();
                    return lcl_obj_DepartmentStrengthsTmp;
                }, "FLExceptionPolicy");
            return lcl_obj_DepartmentStrengthList;
        }

        public System.UInt64 SaveDepartment(SilkERP360.CCL.BusinessEntities.HRIS.Department IP_Obj_Department)
        {
            System.UInt64 lcl_ui64_DepartmentCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new BML.HRIS.DepartmentManager();
                System.UInt64 lcl_ui64_DepartmentCodeTmp = lcl_obj_DepartmentManager.Save(IP_Obj_Department);
                return lcl_ui64_DepartmentCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_DepartmentCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> GetAllDepartmentWise(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_obj_Department = null;
            lcl_obj_Department = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"Select DEPARTMENT_CODE,DEPT_NAME,SHORT_NAME,COMPANY_CODE,HEAD_EMPLOYEE_ID From  DEPARTMENT
               where company_code = {0} and is_deleted=1 order by COMPANY_CODE desc", IP_ui64_CompanyCode);
                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_obj_DepartmentTmp =
                    lcl_obj_DepartmentManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_DepartmentTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Department;
        }




        public CCL.BusinessEntities.HRIS.Department Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Department Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Department> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Department IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Department IP_obj_T)
        {
            throw new NotImplementedException();
        }
    }
}
