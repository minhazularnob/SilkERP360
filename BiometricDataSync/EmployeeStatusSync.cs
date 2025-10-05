using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    /// <summary>
    /// Will Run Everyday at 12:01 AM
    /// 1. For Silkcard Production, The probation period is 06 Months
    /// 2. For All Other departments, The probation period is 03 Months
    /// </summary>
    public class EmployeeStatusSync
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;
        public System.Collections.Generic.List<System.UInt64> m_objLst_SixMonthsProbationDepartments;
        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            try
            {
                this.m_obj_ServiceLog = new ServiceLog();
                this.m_obj_ServiceLog.Init(ServiceLogType.EmployeeStatusSunchronizer);
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
                m_objLst_SixMonthsProbationDepartments = new List<ulong>();
                m_objLst_SixMonthsProbationDepartments.Add(111000000006);//Silkcard Production
            }
            catch (System.Exception Ex)
            {
                this.m_obj_ServiceLog.LogData("Initialization Error : " + Ex.Message);
            }
        }

        /// <summary>
        /// Checks The status of every temporary/probation employees and their joinging
        /// date is compared with TODAY. 
        /// </summary>
        public void SyncStatus()
        {
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            try
            {
                System.DateTime lcl_obj_Today = System.DateTime.Today;
                lcl_sb_LogBuilder = new StringBuilder();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                lcl_sb_LogBuilder.AppendLine("Employee Status Synchronization");
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");

                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.NIGHT_BILL_ELIGIBLE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN EMPLOYEE_PERSONAL EMP_PER
                                                                        ON EMP.EMPLOYEE_CODE = EMP_PER.EMPLOYEE_CODE
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        WHERE EMP.EMPLOYEE_STATUS = {0} OR EMP.EMPLOYEE_STATUS = {1} Order By DEPT.Rank,DESIG.Rank ASC", (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);
                if (lcl_objLst_EmployeeProfile == null)
                {
                    lcl_sb_LogBuilder.AppendLine("No Temporary/Probation Employees Found To Update!!!");
                    lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                    this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                    this.m_obj_ServiceLog.Close();
                    this.m_obj_DBManager.Close();
                    return;
                }
                lcl_sb_LogBuilder.AppendLine("Total Temporary/Probation Employee As Of Today : " + lcl_objLst_EmployeeProfile.Count.ToString());
                //For each changeable status update, there will be two queries
                //1. Update query to change status 2.LeaveAccount Updated to give CL leave
                System.Collections.Generic.List<System.String> lcl_strLst_StatusUpdateQueries = new List<string>();
                System.String lcl_str_Query = System.String.Empty;
                System.UInt32 lcl_ui32_StatusUpdatedEmployeeCount = 0;
                System.UInt64 lcl_ui64_ProbationableEmployee = 0;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    //if (lcl_obj_EmployeeProfile.EmployeeID == "QCT1202642")
                    //{
                    //    int s = 0;
                    //}

                    System.TimeSpan lcl_obj_ElapsedTime = lcl_obj_Today.Subtract(lcl_obj_EmployeeProfile.JoiningDate);
                    System.Double lcl_dbl_ElapsedDays = lcl_obj_ElapsedTime.TotalDays;
                    if (lcl_dbl_ElapsedDays > 90)
                    {
                        //Employee Status Changeable->More Than Three Months Old
                        //check If Employee Belong to six month probation departments
                        if (this.m_objLst_SixMonthsProbationDepartments.Contains(lcl_obj_EmployeeProfile.Department.DepartmentCode))
                        {
                            if (lcl_dbl_ElapsedDays > 180)
                            {
                                //Employee Status Changeable
                                lcl_str_Query = System.String.Format("UPDATE EMPLOYEE SET EMPLOYEE_STATUS = {0} WHERE EMPLOYEE_CODE = {1}", (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, lcl_obj_EmployeeProfile.EmployeeCode);
                                lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                                lcl_str_Query = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 10 WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                                lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                                lcl_sb_LogBuilder.AppendLine("-----------------------------------------------------------------------------");
                                lcl_sb_LogBuilder.AppendLine("Employee Id : " + lcl_obj_EmployeeProfile.EmployeeID);
                                lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeProfile.EmployeeName);
                                lcl_sb_LogBuilder.AppendLine("Designation : " + lcl_obj_EmployeeProfile.Designation.Name);
                                lcl_sb_LogBuilder.AppendLine("Department : " + lcl_obj_EmployeeProfile.Department.Name);
                                lcl_sb_LogBuilder.AppendLine("Joining Date : " + lcl_obj_EmployeeProfile.JoiningDate.ToString("dd/MM/yyyy"));
                                lcl_sb_LogBuilder.AppendLine("-----------------------------------------------------------------------------");
                                lcl_ui32_StatusUpdatedEmployeeCount++;
                            }
                            else
                            {
                                //Employee belongs to Production and less than 06 Months old
                                //Put Employee on Probation
                                //lcl_str_Query = System.String.Format("UPDATE EMPLOYEE SET EMPLOYEE_STATUS = {0} WHERE EMPLOYEE_CODE = {1}", (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, lcl_obj_EmployeeProfile.EmployeeCode);
                                //lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                                lcl_ui64_ProbationableEmployee++;
                                continue;
                            }
                        }
                        else
                        {
                            //Employee belong to Six month probation department
                            //check How old the employee is in the company
                            //Change Status
                            lcl_str_Query = System.String.Format("UPDATE EMPLOYEE SET EMPLOYEE_STATUS = {0} WHERE EMPLOYEE_CODE = {1}", (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, lcl_obj_EmployeeProfile.EmployeeCode);
                            lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                            lcl_str_Query = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 10 WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                            lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                            lcl_sb_LogBuilder.AppendLine("-----------------------------------------------------------------------------");
                            lcl_sb_LogBuilder.AppendLine("Employee Id : " + lcl_obj_EmployeeProfile.EmployeeID);
                            lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeProfile.EmployeeName);
                            lcl_sb_LogBuilder.AppendLine("Designation : " + lcl_obj_EmployeeProfile.Designation.Name);
                            lcl_sb_LogBuilder.AppendLine("Department : " + lcl_obj_EmployeeProfile.Department.Name);
                            lcl_sb_LogBuilder.AppendLine("Joining Date : " + lcl_obj_EmployeeProfile.JoiningDate.ToString("dd/MM/yyyy"));
                            lcl_sb_LogBuilder.AppendLine("-----------------------------------------------------------------------------");
                            lcl_ui32_StatusUpdatedEmployeeCount++;
                        }
                    }
                    else
                    {
                        //Employee is less than 90 days old
                        //Put Employee on Probation
                        //lcl_str_Query = System.String.Format("UPDATE EMPLOYEE SET EMPLOYEE_STATUS = {0} WHERE EMPLOYEE_CODE = {1}", (System.UInt32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, lcl_obj_EmployeeProfile.EmployeeCode);
                        //lcl_strLst_StatusUpdateQueries.Add(lcl_str_Query);
                        lcl_ui64_ProbationableEmployee++;
                    }
                }

                foreach (System.String lcl_str_SqlUpdate in lcl_strLst_StatusUpdateQueries)
                {
                    this.m_obj_DBManager.ExecuteNonQuery(lcl_str_SqlUpdate);
                }
                this.m_obj_DBManager.CommitTransaction();
                this.m_obj_DBManager.Close();
                this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                this.m_obj_ServiceLog.Close();
                
            }
            catch (System.Exception Ex)
            {
                if (this.m_obj_DBManager != null)
                {
                    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                    {
                        this.m_obj_DBManager.RollbackTransaction();
                        this.m_obj_DBManager.Close();
                    }
                }
                this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                this.m_obj_ServiceLog.LogData("Critical Error : " + Ex.Message);
                this.m_obj_ServiceLog.Close();
            }
        }
    }
}
