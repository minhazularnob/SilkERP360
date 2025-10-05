using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    /// <summary>
    /// Runs Once A day
    /// </summary>
    public class LeaveAccountSync
    {

        //private const System.UInt64 SC_PRODUCTION = 111000000006;
        //private const System.UInt64 WP_PRODUCTION = 111000000007;

        //private const System.UInt64 SC_MAINTANANCE = 111000000011;
        //private const System.UInt64 WP_MAINTANANCE = 111000000012;

        //private const System.UInt64 SC_SECURITY = 111000000014;
        
        //private const System.UInt64 SC_LOGISTIC = 111000000075;
        //private const System.UInt64 WP_LOGISTIC = 111000000015;

        private readonly System.String[] m_str_SixMonthProbationDepartments = { "111000000006", "111000000007", "111000000011", "111000000012", "111000000014", "111000000075", "111000000015" };



        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                this.m_obj_ServiceLog.LogData("Initialization Error : " + Ex.Message);
            }
        }

        /// <summary>
        /// Checks LeaveAccount For Each Employee.
        /// If Leave Account For an Employee does not exist, Create LeaveAccount For the employee
        /// </summary>
        public void CheckLeaveAccountExistance(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            try
            {
                this.m_obj_ServiceLog = new ServiceLog();
                this.m_obj_ServiceLog.Init(ServiceLogType.LeaveAccountSynchronizer);
                this.m_obj_DBManager.Open();
                //this.m_obj_ServiceLog.Init(ServiceLogType.LeaveAccountSynchronizer);
                SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager lcl_obj_EmployeeLeaveProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager();
                lcl_obj_EmployeeLeaveProfileManager.Initialize();
                System.String lcl_str_UpdateLeaveAccountQuery = "";
                lcl_sb_LogBuilder = new StringBuilder();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                lcl_sb_LogBuilder.AppendLine("Leave Account Generation-" + System.DateTime.Today.Year);
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");

                SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmployeeLeaveAccountManager = new SilkERP360.BML.HRIS.EmployeeLeaveAccountManager();
                lcl_obj_EmployeeLeaveAccountManager.Initialize();

                
                //Phase 1 : Get All Temporary/Probation/Permanent Male Employee List
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP_P.SEX,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_UNIFORM_ELIGIBLE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
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
                                                                        WHERE (EMP.COMPANY_CODE = {0}) AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3})", IP_ui64_CompanyCode, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmployeeLeaveProfileM = lcl_obj_EmployeeLeaveProfileManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount> lcl_objList_EmployeeLeaveAccounts = new List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount>();

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile in lcl_objLst_EmployeeLeaveProfileM)
                {
                    System.TimeSpan lcl_obj_ElapsedTimeInCompany = System.DateTime.Today.Subtract(lcl_obj_EmployeeLeaveProfile.JoiningDate);
                    System.Double lcl_dbl_ElapsedDaysInCompany = lcl_obj_ElapsedTimeInCompany.TotalDays;

                    lcl_sb_LogBuilder.AppendLine("Company : " + lcl_obj_EmployeeLeaveProfile.Company.Name);
                    lcl_sb_LogBuilder.AppendLine("ID : " + lcl_obj_EmployeeLeaveProfile.EmployeeID);
                    lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeLeaveProfile.EmployeeName);
                    lcl_sb_LogBuilder.AppendLine("Gender : Male");
                    lcl_sb_LogBuilder.AppendLine("Dept : " + lcl_obj_EmployeeLeaveProfile.Department.Name);
                    lcl_sb_LogBuilder.AppendLine("Desig : " + lcl_obj_EmployeeLeaveProfile.Designation.Name);
                    lcl_sb_LogBuilder.AppendLine("J.Date : " + lcl_obj_EmployeeLeaveProfile.JoiningDate.ToLongDateString());
                    lcl_sb_LogBuilder.AppendLine("Emp. Status : " + lcl_obj_EmployeeLeaveProfile.EmployeeStatus.ToString());

                    
                    //If Leave Account Dont exist, Crate Leave Account
                    if (lcl_obj_EmployeeLeaveProfile.LeaveAccount == null)
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                        lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_obj_EmployeeLeaveProfile.EmployeeCode;
                        lcl_obj_EmployeeLeaveAccount.CL = 0;
                        lcl_obj_EmployeeLeaveAccount.EL = 0;
                        lcl_obj_EmployeeLeaveAccount.ML = 0;
                        lcl_obj_EmployeeLeaveAccount.SL = 0;
                        lcl_objList_EmployeeLeaveAccounts.Add(lcl_obj_EmployeeLeaveAccount);
                        //lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, this.m_obj_DBManager);

                    }
                }
                this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                this.m_obj_ServiceLog.Close();
                this.m_obj_DBManager.CommitTransaction();
                this.m_obj_DBManager.Close();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
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

        /// <summary>
        /// This function runs every 1st-January to replanish the Leave Accounts
        /// 1. Temporary/Probation Employees SL(Sick) Leave only
        /// 2. Permanent Employees : CL=14/SL=10/EL = EL+26/ML=180 (Female Only)
        /// Each Employees Status is checked
        /// Logic:
        /// Phase 1:
        ///         1. Get All Temporary/Probation/Permanent Male Employee List
        ///         2. If Leave Account dont exist Then
        ///                 Create Leave Account
        ///                 a. Temporary/Probation : CL=0;SL=10;EL=0;ML=0
        ///                 b. Permanent:CL=14;SL=10;ML=0 (If Joining Date > 1 Year -> EL=26
        ///            Else
        ///                 Update Leave Account
        ///                 a. Temporary/Probation : CL=0;SL=10;EL=0;ML=0
        ///                 b. Permanent:CL=14;SL=10;ML=0 (If Joining Date > 1 Year -> EL+=26
        /// Phase 2:
        ///         1. Get All Temporary/Probation/Permanent Female Employee List
        ///         2. If Leave Account dont exist Then
        ///                 Create Leave Account
        ///                 a. Temporary/Probation : CL=0;SL=10;EL=0;ML=0
        ///                 b. Permanent:CL=14;SL=10;ML=180 (If Joining Date > 1 Year -> EL=26
        ///            Else
        ///                 Update Leave Account
        ///                 a. Temporary/Probation : CL=0;SL=10;EL=0;ML=0
        ///                 b. Permanent:CL=14;SL=10;ML=180 (If Joining Date > 1 Year -> EL+=26
        /// </summary>
        public void YearChangeLeaveSynchronization(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            try
            {
                this.m_obj_ServiceLog = new ServiceLog();
                this.m_obj_ServiceLog.Init(ServiceLogType.LeaveAccountSynchronizer);
                this.m_obj_DBManager.Open();
                //this.m_obj_ServiceLog.Init(ServiceLogType.LeaveAccountSynchronizer);
                SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager lcl_obj_EmployeeLeaveProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeLeaveProfileManager();
                lcl_obj_EmployeeLeaveProfileManager.Initialize();
                System.String lcl_str_UpdateLeaveAccountQuery = "";
                lcl_sb_LogBuilder = new StringBuilder();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                lcl_sb_LogBuilder.AppendLine("Annual Leave Synchronization-" + System.DateTime.Today.Year);
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");

                SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmployeeLeaveAccountManager = new SilkERP360.BML.HRIS.EmployeeLeaveAccountManager();
                lcl_obj_EmployeeLeaveAccountManager.Initialize();

                #region MALE EMPLOYEES

                System.Collections.Generic.List<System.String> lcl_strLst_LeaveAccountUpdateQueryList = new List<string>();
                //Phase 1 : Get All Temporary/Probation/Permanent Male Employee List
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP_P.SEX, EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
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
                                                                        WHERE EMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1", IP_ui64_CompanyCode, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmployeeLeaveProfileM = lcl_obj_EmployeeLeaveProfileManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);
                this.m_obj_DBManager.CloseReader();
                int counter = 0;           
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile in lcl_objLst_EmployeeLeaveProfileM)
                {
                    counter++;
                    System.Console.WriteLine("Employee : " + counter.ToString() + " " + lcl_obj_EmployeeLeaveProfile.EmployeeName);

                    System.UInt32 lcl_ui32_CL = 0;
                    System.UInt32 lcl_ui32_SL = 0;
                    System.UInt32 lcl_ui32_EL = 0;
                    System.UInt32 lcl_ui32_ML = 0;

                    System.TimeSpan lcl_obj_ElapsedTimeInCompany = System.DateTime.Today.Subtract(lcl_obj_EmployeeLeaveProfile.JoiningDate);
                    System.Double lcl_dbl_ElapsedDaysInCompany = lcl_obj_ElapsedTimeInCompany.TotalDays;

                    lcl_sb_LogBuilder.AppendLine("Company : " + lcl_obj_EmployeeLeaveProfile.Company.Name);
                    lcl_sb_LogBuilder.AppendLine("ID : " + lcl_obj_EmployeeLeaveProfile.EmployeeID);
                    lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeLeaveProfile.EmployeeName);
                    lcl_sb_LogBuilder.AppendLine("Gender : Male");
                    lcl_sb_LogBuilder.AppendLine("Dept : " + lcl_obj_EmployeeLeaveProfile.Department.Name);
                    lcl_sb_LogBuilder.AppendLine("Desig : " + lcl_obj_EmployeeLeaveProfile.Designation.Name);
                    lcl_sb_LogBuilder.AppendLine("J.Date : " + lcl_obj_EmployeeLeaveProfile.JoiningDate.ToLongDateString());
                    lcl_sb_LogBuilder.AppendLine("Emp. Status : " + lcl_obj_EmployeeLeaveProfile.EmployeeStatus.ToString());

                    //System.Double lcl_ui32_Days = (System.DateTime.Now - lcl_obj_EmployeeLeaveProfile.JoiningDate).TotalDays;

                    #region UPDATE LEAVE ACCOUNT
                    if (lcl_dbl_ElapsedDaysInCompany >= 365)
                    {
                        //Employee More Than 1 Year Old
                        lcl_ui32_CL = 10;
                        lcl_ui32_SL = 14;
                        lcl_ui32_EL = 17;
                        lcl_ui32_ML = 0;
                        if ((lcl_obj_EmployeeLeaveProfile.LeaveAccount.EL) + lcl_ui32_EL > 40)
                        {
                            lcl_ui32_EL = 40;
                        }
                        else
                        {
                            lcl_ui32_EL = lcl_obj_EmployeeLeaveProfile.LeaveAccount.EL + lcl_ui32_EL;
                        }

                        if (lcl_obj_EmployeeLeaveProfile.Gender == 'F')
                        {
                            lcl_ui32_ML = 180;
                        }

                        lcl_sb_LogBuilder.AppendLine("CL : 10 || EL : EL + 26 || ML : 0 || SL : 14");
                        lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                 
                    }
                    else
                    {
                        System.Boolean lcl_b_IsEmployeeOnSixMonthProbation = false;
                        foreach (System.String lcl_str_DepartmentId in this.m_str_SixMonthProbationDepartments)
                        {
                            if (lcl_obj_EmployeeLeaveProfile.Department.DepartmentCode.ToString().Equals(lcl_str_DepartmentId))
                            {
                                //Employee on 06 Month Probation
                                //check Employee age in company
                                if (lcl_dbl_ElapsedDaysInCompany < 180)
                                {
                                    //Employee Less Than 06 Month Old
                                    lcl_ui32_CL = 0;
                                    lcl_ui32_SL = 14;
                                    lcl_ui32_EL = 0;
                                }
                                else
                                {
                                    //Employee More Than Six Month Old
                                    lcl_ui32_CL = 10;
                                    lcl_ui32_SL = 14;
                                    lcl_ui32_EL = 0;
                                    if (lcl_obj_EmployeeLeaveProfile.Gender == 'F')
                                    {
                                        lcl_ui32_ML = 180;
                                    }
                                }
                                lcl_b_IsEmployeeOnSixMonthProbation = true;
                                break;
                            }
                        }
                        if(lcl_b_IsEmployeeOnSixMonthProbation == false)
                        {
                            //Employee on 03 Month Probation
                            //check Employee age in company
                            if (lcl_dbl_ElapsedDaysInCompany < 90)
                            {
                                //Employee Less Than 03 Month Old
                                lcl_ui32_CL = 0;
                                lcl_ui32_SL = 14;
                                lcl_ui32_EL = 0;
                            }
                            else
                            {
                                //Employee More Than Three Month Old
                                lcl_ui32_CL = 10;
                                lcl_ui32_SL = 14;
                                lcl_ui32_EL = 0;
                            }
                        }
                    }

                    lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = {0},SL = {1},EL = {2}, ML = {3} WHERE LEAVE_ACCOUNT_CODE = {4}", lcl_ui32_CL,lcl_ui32_SL,lcl_ui32_EL,lcl_ui32_ML,lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                    //this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);
                    lcl_strLst_LeaveAccountUpdateQueryList.Add(lcl_str_UpdateLeaveAccountQuery);

                    lcl_sb_LogBuilder.AppendLine("CL : 10 || EL : 0 || ML : 0 || SL : 14");
                    lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                                        //}
                    #endregion
                }
                #endregion MALE EMPLOYEES

                #region UPDATE LEAVE ACCOUNT

                foreach (System.String lcl_str_LeaveAccountUpdate in lcl_strLst_LeaveAccountUpdateQueryList)
                {
                    this.m_obj_DBManager.ExecuteNonQuery(lcl_str_LeaveAccountUpdate);
                }
                //this.m_obj_DBManager.CommitTransaction();
                #endregion

                this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                this.m_obj_ServiceLog.Close();
                this.m_obj_DBManager.Close();
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

        /// <summary>
        /// This function runs every day. It checks which employee completes 01 year
        /// on IP_dt_Date and updates Leave Account by 17 EL.
        /// Function also checks if Employee turns Permanenet on IP_dt_Date
        /// and updates Leave Account of the Employee by 10 CL
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_dt_Date"></param>
        public void DailyLeaveSynchronization(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
        }
    }
}
