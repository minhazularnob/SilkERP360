using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPSync
{
    /// <summary>
    /// Runs Once A day
    /// </summary>
    public class LeaveAccountSync
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        //private ServiceLog m_obj_ServiceLog;

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            //this.m_obj_ServiceLog = new ServiceLog();
            //this.m_obj_ServiceLog.Init(ServiceLogType.LeaveAccountSynchronizer);
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Initialization Error : " + Ex.Message);
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
        public void YearChangeLeaveSynchronization()
        {
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            try
            {
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
                //Phase 1 : Get All Temporary/Probation/Permanent Male Employee List
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP_P.SEX = 'M' AND (EMP.EMPLOYEE_STATUS = {0} OR EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2}) AND EMP.IS_DELETED = 1", (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmployeeLeaveProfileM = lcl_obj_EmployeeLeaveProfileManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile in lcl_objLst_EmployeeLeaveProfileM)
                {
                    lcl_sb_LogBuilder.AppendLine("Company : " + lcl_obj_EmployeeLeaveProfile.Company.Name);
                    lcl_sb_LogBuilder.AppendLine("ID : " + lcl_obj_EmployeeLeaveProfile.EmployeeID);
                    lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeLeaveProfile.EmployeeName);
                    lcl_sb_LogBuilder.AppendLine("Gender : Male");
                    lcl_sb_LogBuilder.AppendLine("Dept : " + lcl_obj_EmployeeLeaveProfile.Department.Name);
                    lcl_sb_LogBuilder.AppendLine("Desig : " + lcl_obj_EmployeeLeaveProfile.Designation.Name);
                    lcl_sb_LogBuilder.AppendLine("J.Date : " + lcl_obj_EmployeeLeaveProfile.JoiningDate.ToLongDateString());
                    lcl_sb_LogBuilder.AppendLine("Emp. Status : " + lcl_obj_EmployeeLeaveProfile.EmployeeStatus.ToString());

                    #region NEW LEAVE ACCOUNT
                    //If Leave Account Dont exist, Crate Leave Account
                    if (lcl_obj_EmployeeLeaveProfile.LeaveAccount == null)
                    {
                        if ((lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Probation) ||
                            (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Temporary))
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                            lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_obj_EmployeeLeaveProfile.EmployeeCode;
                            lcl_obj_EmployeeLeaveAccount.CL = 0;
                            lcl_obj_EmployeeLeaveAccount.EL = 0;
                            lcl_obj_EmployeeLeaveAccount.ML = 0;
                            lcl_obj_EmployeeLeaveAccount.SL = 10;
                            lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, this.m_obj_DBManager);
                           
                            lcl_sb_LogBuilder.AppendLine("CL : 0 || EL : 0 || ML : 0 || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                        if (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Regular)
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                            lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_obj_EmployeeLeaveProfile.EmployeeCode;
                            lcl_obj_EmployeeLeaveAccount.CL = 14;
                            lcl_obj_EmployeeLeaveAccount.ML = 0;
                            lcl_obj_EmployeeLeaveAccount.SL = 10;

                            System.Double lcl_ui32_Days = (System.DateTime.Now - lcl_obj_EmployeeLeaveProfile.JoiningDate).TotalDays;

                            if (lcl_ui32_Days > 365)
                            {
                                lcl_obj_EmployeeLeaveAccount.EL = 26;
                            }
                            else
                            {
                                lcl_obj_EmployeeLeaveAccount.EL = 0;
                            }
                            lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, this.m_obj_DBManager);
                           
                            lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : " +  lcl_obj_EmployeeLeaveAccount.EL.ToString() + " || ML : 0 || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                    }
                    #endregion
                    #region UPDATE LEAVE ACCOUNT
                    else
                    {
                        if ((lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Probation) ||
                            (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Temporary))
                        {
                            lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 0,ML = 0,EL = 0,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                            this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);
                            
                            lcl_sb_LogBuilder.AppendLine("CL : 0 || EL : 0 || ML : 0 || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                        if (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Regular)
                        {
                            System.Double lcl_ui32_Days = (System.DateTime.Now - lcl_obj_EmployeeLeaveProfile.JoiningDate).TotalDays;

                            if (lcl_ui32_Days > 365)
                            {
                                lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 14,ML = 0,EL = EL + 26,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                                this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);
                               
                                lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : EL + 26 || ML : 0 || SL : 10");
                                lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                            }
                            else
                            {
                                lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 14,ML = 0,EL = 0,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                                this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);
                              
                                lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : 0 || ML : 0 || SL : 10");
                                lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                            }
                        }
                    }
                    #endregion
                }
                #endregion MALE EMPLOYEES

                #region FEMALE EMPLOYEES
                lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP_P.SEX = 'F' AND (EMP.EMPLOYEE_STATUS = {0} OR EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2}) AND EMP.IS_DELETED = 1", (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmployeeLeaveProfileF = lcl_obj_EmployeeLeaveProfileManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                //SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmployeeLeaveAccountManager = new SilkERP360.BML.HRIS.EmployeeLeaveAccountManager();
                //lcl_obj_EmployeeLeaveAccountManager.Initialize();

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmployeeLeaveProfile in lcl_objLst_EmployeeLeaveProfileF)
                {
                    #region NEW LEAVE ACCOUNT
                    lcl_sb_LogBuilder.AppendLine("Company : " + lcl_obj_EmployeeLeaveProfile.Company.Name);
                    lcl_sb_LogBuilder.AppendLine("ID : " + lcl_obj_EmployeeLeaveProfile.EmployeeID);
                    lcl_sb_LogBuilder.AppendLine("Name : " + lcl_obj_EmployeeLeaveProfile.EmployeeName);
                    lcl_sb_LogBuilder.AppendLine("Gender : Female");
                    lcl_sb_LogBuilder.AppendLine("Dept : " + lcl_obj_EmployeeLeaveProfile.Department.Name);
                    lcl_sb_LogBuilder.AppendLine("Desig : " + lcl_obj_EmployeeLeaveProfile.Designation.Name);
                    lcl_sb_LogBuilder.AppendLine("J.Date : " + lcl_obj_EmployeeLeaveProfile.JoiningDate.ToLongDateString());
                    lcl_sb_LogBuilder.AppendLine("Emp. Status : " + lcl_obj_EmployeeLeaveProfile.EmployeeStatus.ToString());
                    //If Leave Account Dont exist, Crate Leave Account
                    if (lcl_obj_EmployeeLeaveProfile.LeaveAccount == null)
                    {
                        if ((lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Probation) ||
                            (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Temporary))
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                            lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_obj_EmployeeLeaveProfile.EmployeeCode;
                            lcl_obj_EmployeeLeaveAccount.CL = 0;
                            lcl_obj_EmployeeLeaveAccount.EL = 0;
                            lcl_obj_EmployeeLeaveAccount.ML = 0;
                            lcl_obj_EmployeeLeaveAccount.SL = 10;
                            lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, this.m_obj_DBManager);

                            lcl_sb_LogBuilder.AppendLine("CL : 0 || EL : 0 || ML : 0 || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                        if (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Regular)
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                            lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_obj_EmployeeLeaveProfile.EmployeeCode;
                            lcl_obj_EmployeeLeaveAccount.CL = 14;
                            lcl_obj_EmployeeLeaveAccount.SL = 10;
                            lcl_obj_EmployeeLeaveAccount.ML = 180;
                            System.Double lcl_ui32_Days = (System.DateTime.Now - lcl_obj_EmployeeLeaveProfile.JoiningDate).TotalDays;

                            if (lcl_ui32_Days > 365)
                            {
                                lcl_obj_EmployeeLeaveAccount.EL = 26;
                                
                            }
                            else
                            {
                                lcl_obj_EmployeeLeaveAccount.EL = 0;
                            }
                            lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, this.m_obj_DBManager);

                            lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : " + lcl_obj_EmployeeLeaveAccount.EL.ToString() + " || ML : " + lcl_obj_EmployeeLeaveAccount.ML + " || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                    }
                    #endregion
                    #region UPDATE LEAVE ACCOUNT
                    else
                    {
                        if ((lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Probation) ||
                            (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Temporary))
                        {
                            lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 0,ML = 0,EL = 0,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                            this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);

                            lcl_sb_LogBuilder.AppendLine("CL : 0 || EL : 0 || ML : 0 || SL : 10");
                            lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                        }
                        if (lcl_obj_EmployeeLeaveProfile.EmployeeStatus == SilkERP360.CCL.Enums.EmployeeStatus.Regular)
                        {
                            System.Double lcl_ui32_Days = (System.DateTime.Now - lcl_obj_EmployeeLeaveProfile.JoiningDate).TotalDays;

                            if (lcl_ui32_Days > 365)
                            {
                                lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 14,ML = 180,EL = EL + 26,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                                this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);

                                lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : EL + 26 || ML : 180 || SL : 10");
                                lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                            }
                            else
                            {
                                lcl_str_UpdateLeaveAccountQuery = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = 14,ML = 180,EL = 0,SL = 10 WHERE LEAVE_ACCOUNT_CODE = {0}", lcl_obj_EmployeeLeaveProfile.LeaveAccount.LeaveAccountCode);
                                this.m_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateLeaveAccountQuery);

                                lcl_sb_LogBuilder.AppendLine("CL : 14 || EL : 0 || ML : 180 || SL : 10");
                                lcl_sb_LogBuilder.AppendLine("_________________________________________________________________________________________________");
                            }
                        }
                    }
                    #endregion
                }
                #endregion FEMALE EMPLOYEES


                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                //this.m_obj_ServiceLog.Close();
                this.m_obj_DBManager.CommitTransaction();
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
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Critical Error : " + Ex.Message);
                //this.m_obj_ServiceLog.Close();
            }
        }
    }
}
