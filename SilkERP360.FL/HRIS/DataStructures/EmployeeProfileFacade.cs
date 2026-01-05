using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS.DataStructures
{
    public class EmployeeProfileFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>
    {
        public EmployeeProfileFacade()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile GetEmployeeProfileByCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;
            lcl_obj_EmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfileTmp = lcl_obj_EmployeeProfileManager.Get(IP_ui64_EmployeeCode);
                return lcl_obj_EmployeeProfileTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfile;
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetEmployeeProfileListByCompanyCode(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2}) AND EMP.IS_DELETED = 1", IP_ui64_CompanyCode, SilkERP360.CCL.Enums.EmployeeStatus.Probation, SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetEmployeeProfileListByDepartmentCode(System.UInt64 IP_ui64_DepartmentCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND  (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1", IP_ui64_DepartmentCode, SilkERP360.CCL.Enums.EmployeeStatus.Probation, SilkERP360.CCL.Enums.EmployeeStatus.Temporary, SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }



        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetRoosterAvailableEmployeeProfileListByDepartmentCode(System.UInt64 IP_ui64_DepartmentCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE, EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND IS_ON_ROSTER=1 AND (EMP.EMPLOYEE_STATUS != {1} AND EMP.EMPLOYEE_STATUS != {2} AND EMP.EMPLOYEE_STATUS != {3}) AND EMP.IS_DELETED = 1 ORDER BY EMP.DESIGNATION_CODE ASC", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetAvailableEmployeeProfileListByDepartmentCode(System.UInt64 IP_ui64_DepartmentCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE, EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_PF_ELIGIBLE,EMP.IS_OT_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,DESIG.RANK,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED,SAL.GROSS
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE SAL
                                                                        ON EMP.EMPLOYEE_CODE = SAL.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND  (EMP.EMPLOYEE_STATUS != {1} AND EMP.EMPLOYEE_STATUS != {2} AND EMP.EMPLOYEE_STATUS != {3}) AND EMP.IS_DELETED = 1 ORDER BY DESIG.RANK,EMP.JOINING_DATE ASC", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetExistingRoosterEmployeeProfileListByDepartment(System.UInt64 IP_ui64_DepartmentCode, System.UInt64 IP_ui64_RoosterMasterCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT A.EMPLOYEE_CODE,A.EMPLOYEE_ID,A.EMPLOYEE_NAME,A.COMPANY_CODE,A.NAME,A.DEPARTMENT_CODE,
                                                                        A.DEPT_NAME,A.DESIGNATION_CODE,A.DEGN_NAME,A.EMPLOYEE_IMAGE_CODE,A.IMAGE,A.IMAGE_TYPE,A.IMAGE_SIZE,nvl(B.IS_DELETED,0)IS_DELETED
                                                                        FROM(SELECT EMP.EMPLOYEE_CODE, EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND (EMP.EMPLOYEE_STATUS != {1} AND EMP.EMPLOYEE_STATUS != {2} AND EMP.EMPLOYEE_STATUS != {3}) AND EMP.IS_DELETED = 1
                                                                         And EMP.EMPLOYEE_CODE not in (
                                                                        Select EMPLOYEE_CODE From 
                                                                        (Select ROOSTER_MASTER_CODE,EMPLOYEE_CODE
                                                                        From employee_Rooster
                                                                        Where DUTY_DATE=to_date(sysDate) And IS_DELETED=1)A
                                                                        Left outer join
                                                                        (Select DEPARTMENT_CODE,ROOSTER_MASTER_CODE From 
                                                                        rooster_master Where to_date(sysDate) between 
                                                                        ROOSTER_DATE_FROM and ROOSTER_DATE_TO)B on  A.ROOSTER_MASTER_CODE=B.ROOSTER_MASTER_CODE
                                                                        Where B.DEPARTMENT_CODE={0} AND A.ROOSTER_MASTER_CODE<>{4}))A
                                                                         Left outer join (Select A.ROOSTER_MASTER_CODE,EMPLOYEE_CODE,B.IS_DELETED From 
                                                                        (Select ROOSTER_MASTER_CODE,ROOSTER_NAME From ROOSTER_MASTER
                                                                        Where ROOSTER_MASTER_CODE={4})A
Left outer join 
(Select Distinct ROOSTER_MASTER_CODE,EMPLOYEE_CODE,IS_DELETED From EMPLOYEE_ROOSTER Where IS_DELETED=1)B On A.ROOSTER_MASTER_CODE=B.ROOSTER_MASTER_CODE)B ON A.EMPLOYEE_CODE=B.EMPLOYEE_CODE ORDER BY A.DESIGNATION_CODE ASC", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated, IP_ui64_RoosterMasterCode);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetLeaveApplicationList(System.UInt64 IP_ui64_LeaveListCode, System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = "";
                if (IP_ui64_LeaveListCode == 2)
                {
                    lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE, EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE
                                                                         ,la.leave_app_code
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        join employee_leave_application LA
                                                                        on  EMP.EMPLOYEE_CODE  =LA.EMPLOYEE_CODE 
                                                                        where COMP.COMPANY_CODE={0} and la.is_approved is null and la.is_recommended is  null
                AND (EMP.EMPLOYEE_STATUS != {1} AND EMP.EMPLOYEE_STATUS != {2} AND EMP.EMPLOYEE_STATUS != {3}) AND EMP.IS_DELETED = 1 order by la.leave_st_date desc", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);

                }
                else
                {
                    lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE, EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE
                                                                        ,la.leave_app_code
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        join employee_leave_application LA
                                                                        on  EMP.EMPLOYEE_CODE  =LA.EMPLOYEE_CODE 
                                                                        where COMP.COMPANY_CODE={0} and la.is_recommended=1 and la.is_approved is null
                AND (EMP.EMPLOYEE_STATUS != {1} AND EMP.EMPLOYEE_STATUS != {2} AND EMP.EMPLOYEE_STATUS != {3}) AND EMP.IS_DELETED = 1 order by la.leave_st_date desc", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);

                }





                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetListLeave(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }
        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeIdCardInfo GetEmployeeIdCardInfo(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeIdCardInfo lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeIdCardInfo>(() =>
            {
                System.String lcl_str_SqlQuery = "";
                  lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE
	                                                        ,EMP.EMPLOYEE_ID
	                                                        ,EMP.EMPLOYEE_NAME
	                                                        ,EMP.JOINING_DATE
	                                                        ,EMP.EMPLOYEE_STATUS
	                                                        ,COMP.NAME
	                                                        ,DEPT.DEPT_NAME
	                                                        ,DESIG.DEGN_NAME
	                                                        ,IMG.IMAGE
	                                                        ,IMG.IMAGE_TYPE
	                                                        ,IMG.IMAGE_SIZE
	                                                        ,emp_p.blood_group
                                                            ,emp_p.citizen_card_id
                                                            ,emp_p.mobile_no
                                                            ,IMG.IMAGE
                                                            ,IMG.IMAGE_TYPE
                                                            ,IMG.IMAGE_SIZE
                                                        FROM EMPLOYEE EMP
                                                        JOIN EMPLOYEE_PERSONAL EMP_P ON EMP.EMPLOYEE_CODE = EMP_P.EMPLOYEE_CODE
                                                        JOIN COMPANY COMP ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                        JOIN DEPARTMENT DEPT ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                        JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                        JOIN EMPLOYEE_IMAGE IMG ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE where EMP.EMPLOYEE_CODE={0}", IP_ui64_EmployeeCode);

                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeIdCardInfo lcl_obj_EmployeeProfileListTmp = lcl_obj_EmployeeProfileManager.GetEmployeeIdCardInfo(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetEmployeeSalaryAddDed(System.UInt64 IP_iu64_EmployeeCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList = null;
            lcl_obj_EmployeeProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME
                                                                        ,sa.add_ded_code,sa.AMOUNT,sa.ADD_DED_DATE,sa.ADD_DED_TYPE
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN SALARY_ADDITION_DEDUCTION sa
                                                                        ON EMP.EMPLOYEE_CODE = sa.EMPLOYEE_CODE
                                                                        where sa.employee_code={0}", IP_iu64_EmployeeCode);
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileListTmp =
                    lcl_obj_EmployeeProfileManager.GetListAddDed(lcl_str_SqlQuery);
                return lcl_obj_EmployeeProfileListTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeProfileList;
        }





        public ulong Save(CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetListWithoutImage(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = null;
            lcl_objLst_EmployeeProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfileTmp = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                lcl_objLst_EmployeeProfileTmp = lcl_obj_EmployeeProfileManager.GetListWithoutImage(IP_str_SqlQuery);
                return lcl_objLst_EmployeeProfileTmp;
            }, "FLExceptionPolicy");
            return lcl_objLst_EmployeeProfile;
        }

        public int Update(CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
