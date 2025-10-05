using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class OvertimeHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public OvertimeHistoryManager()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> GetDepartmentwiseOvertimeListByDateRange(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList = null;
            lcl_objLst_OvertimeHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_TmpOvertimeHistoryList = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>();

                    //Get Employee Profile for the Department
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM SilkERP.EMPLOYEE EMP 
                                                                        JOIN SilkERP.COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN SilkERP.DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN SilkERP.DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN SilkERP.EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN SilkERP.EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1 AND EMP.IS_OT_ELIGIBLE = 1  Order By DESIG.Rank,DEPT.RANK ASC", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new EmployeeProfileManager();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList =
                            lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                    //Get Overtime history for each employee Profile
                    SilkERP360.BML.HRIS.OvertimeManager lcl_obj_OvertimeManager = new OvertimeManager();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_obj_EmployeeProfileList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM OVERTIME WHERE EMPLOYEE_CODE = {0} AND OT_DATE >= TO_DATE('{1}','DD/MM/YY') AND OT_DATE <= TO_DATE('{2}','DD/MM/YY')", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_StartDate.ToString("dd/MM/yyyy"), IP_dt_EndDate.ToString("dd/MM/yyyy"));
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objLst_OvertimeList = lcl_obj_OvertimeManager.GetList(lcl_str_SqlQuery,lcl_obj_DBManager.InternalResource);
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory lcl_obj_OvertimeHistory = new CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory();
                        lcl_obj_OvertimeHistory.EmployeeProfile = lcl_obj_EmployeeProfile;
                        lcl_obj_OvertimeHistory.OvertimeList = lcl_objLst_OvertimeList;
                        //Calculate Total O.T
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime in lcl_objLst_OvertimeList)
                        {
                            lcl_obj_OvertimeHistory.TotalOvertime += lcl_obj_Overtime.OvertimeHour;
                        }
                        //Calculate OvertimeRate
                        System.Decimal lcl_dcm_OvertimeRate = System.Decimal.Round((lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104), 2);
                        lcl_obj_OvertimeHistory.OvertimeRate = lcl_dcm_OvertimeRate;
                        lcl_objLst_TmpOvertimeHistoryList.Add(lcl_obj_OvertimeHistory);
                    }
                    return lcl_objLst_TmpOvertimeHistoryList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_OvertimeHistoryList;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> GetDepartmentwiseOvertimeListByDate(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_OvertimeDate)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList = null;
            lcl_objLst_OvertimeHistoryList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_TmpOvertimeHistoryList = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory>();

                    //Get Employee Profile for the Department
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM SilkERP.EMPLOYEE EMP 
                                                                        JOIN SilkERP.COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN SilkERP.DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN SilkERP.DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN SilkERP.EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN SilkERP.EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE DEPT.DEPARTMENT_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) 
                                                                        AND EMP.IS_DELETED = 1 AND EMP.IS_OT_ELIGIBLE = 1 AND 
                                                                        EMP.JOINING_DATE < TO_DATE('{4}','DD/MM/YYYY')  Order By DESIG.Rank", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, IP_dt_OvertimeDate.ToString("dd/MM/yyyy"));
                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new EmployeeProfileManager();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_obj_EmployeeProfileList =
                            lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                    //Get Overtime history for each employee Profile
                    SilkERP360.BML.HRIS.OvertimeManager lcl_obj_OvertimeManager = new OvertimeManager();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_obj_EmployeeProfileList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM OVERTIME WHERE EMPLOYEE_CODE = {0} AND OT_DATE = TO_DATE('{1}','DD/MM/YY') AND IS_PROCESSED = {2}", lcl_obj_EmployeeProfile.EmployeeCode, IP_dt_OvertimeDate.ToString("dd/MM/yyyy"), (System.Int16)SilkERP360.CCL.Enums.YesNo.No);
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objLst_OvertimeList = lcl_obj_OvertimeManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory lcl_obj_OvertimeHistory = new CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory();
                        lcl_obj_OvertimeHistory.EmployeeProfile = lcl_obj_EmployeeProfile;
                        lcl_obj_OvertimeHistory.OvertimeList = lcl_objLst_OvertimeList;
                        //Calculate Total O.T
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime in lcl_objLst_OvertimeList)
                        {
                            lcl_obj_OvertimeHistory.TotalOvertime += lcl_obj_Overtime.OvertimeHour;
                        }
                        //Calculate OvertimeRate
                        System.Decimal lcl_dcm_OvertimeRate = System.Decimal.Round((lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104),2);
                        lcl_obj_OvertimeHistory.OvertimeRate = lcl_dcm_OvertimeRate;
                        lcl_objLst_TmpOvertimeHistoryList.Add(lcl_obj_OvertimeHistory);
                    }
                    return lcl_objLst_TmpOvertimeHistoryList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_OvertimeHistoryList;
        }

    
    }
}
