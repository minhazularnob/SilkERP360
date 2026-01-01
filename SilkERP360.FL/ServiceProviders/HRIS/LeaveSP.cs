using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.HRIS
{
    public class LeaveSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public LeaveSP()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile GetEmployeeLeaveProfile(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile>(() =>
            {
                SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager lcl_obj_EmployeeLeaveProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager();
                lcl_obj_EmployeeLeaveProfileManager.Initialize();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED
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
                                                                        WHERE Emp.Employee_Code = {0}",IP_ui64_EmployeeCode);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmployeeLeaveProfile = lcl_obj_EmployeeLeaveProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_objLst_EmployeeLeaveProfile[0];
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeLeaveProfile;
        }

        public System.UInt64 SaveLeaveApplication(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveApplication)
        {
            System.UInt64 lcl_ui64_LeaveApplicationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                lcl_obj_EmployeeLeaveApplicationManager.Initialize();
                System.UInt64 lcl_ui64_LeaveApplicationCodeTmp = lcl_obj_EmployeeLeaveApplicationManager.Save(IP_obj_EmployeeLeaveApplication);
                return lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_LeaveApplicationCode;
        }

        public System.UInt64 GetLeaveApplication(System.UInt64 IP_ui64_LeaveApplicationCode)
        {
            //System.String lcl_str_SqlQuery = 
            System.UInt64 lcl_ui64_LeaveApplicationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                lcl_obj_EmployeeLeaveApplicationManager.Initialize();
                //System.UInt64 lcl_ui64_LeaveApplicationCodeTmp = lcl_obj_EmployeeLeaveApplicationManager.Save(IP_obj_EmployeeLeaveApplication);
                return 0;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_LeaveApplicationCode;
        }
    }
}
