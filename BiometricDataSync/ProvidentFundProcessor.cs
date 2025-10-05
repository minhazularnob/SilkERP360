using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class ProvidentFundProcessor
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;

        private SilkERP360.CCL.Enums.Month m_enm_Month;
        private System.UInt16 m_ui16_Year;

        public ProvidentFundProcessor(SilkERP360.CCL.Enums.Month IP_enm_Month, System.UInt16 IP_ui16_Year)
        {
            this.m_enm_Month = IP_enm_Month;
            this.m_ui16_Year = IP_ui16_Year;
        }

        public ProvidentFundProcessor()
        {
        }

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            this.m_obj_ServiceLog = new ServiceLog();
            this.m_obj_ServiceLog.Init(ServiceLogType.MonthlyAllowanceProcessor);
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

        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            this.m_obj_ServiceLog = new ServiceLog();
            this.m_obj_ServiceLog.Init(ServiceLogType.MonthlyAllowanceProcessor);
            try
            {
                this.m_obj_DBManager = IP_obj_DBManager;
            }
            catch (System.Exception Ex)
            {
                this.m_obj_ServiceLog.LogData("Initialization Error : " + Ex.Message);
            }
        }

        public void Process(System.UInt64 IP_ui64_CompanyCode)
        {
            /****************************************************************************************************************************/
            //DISCONTINUE PROVIDENT FUND FOR WELLPAC POLYMERS LTD.
            if (IP_ui64_CompanyCode == 110000000002)
            {
                return;
            }
            /****************************************************************************************************************************/
            //1. Look for active entry in MONTHLY_ALLOWANCE table for each entry
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditionDeduction = new List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objLst_PFAccountTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>();
            try
            {
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_UNIFORM_ELIGIBLE,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) Order By DEPT.Rank,DESIG.Rank ASC",IP_ui64_CompanyCode,(System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);

                
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    if (lcl_obj_EmployeeProfile.IsPFEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                    {
                        //Console.WriteLine("PF for : " + lcl_obj_EmployeeProfile.EmployeeName);
                        //check if PF already Processed for this employee
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_ADDITION_DEDUCTION WHERE EMPLOYEE_CODE = {0} AND EFFECTIVE_MONTH = {1} AND EFFECTIVE_YEAR = {2} AND ADD_DED_TYPE = {3}", lcl_obj_EmployeeProfile.EmployeeCode, (int)this.m_enm_Month, this.m_ui16_Year, (int)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund);
                        System.Data.OracleClient.OracleDataReader lcl_obj_AdditionDeductionReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_AdditionDeductionReader.HasRows == true)
                        {
                            //ProvidentFund has already been processed
                            lcl_obj_AdditionDeductionReader.Close();
                            continue;
                        }
                        else
                        {
                            //ProvidentFund Has not yet been processed
                            lcl_obj_AdditionDeductionReader.Close();
                            SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAdditionDeduction.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                            lcl_obj_SalaryAdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
                            lcl_obj_SalaryAdditionDeduction.Amount = System.Math.Round(((lcl_obj_EmployeeProfile.SalaryStructure.Basic * 10) / 100), 2);
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeduction.Remarks = "P.F";
                            lcl_obj_SalaryAdditionDeduction.EffectiveMonth = this.m_enm_Month;
                            lcl_obj_SalaryAdditionDeduction.EffectiveYear = this.m_ui16_Year;
                            lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode = 10100000000001;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeduction);
                            /****************************************************************************************************************/

                            //CREATE EmployeersContribution & EmployeeContribution instance for PFAccountTransaction
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                            SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                            lcl_obj_PFAccountManager.Initialize();

                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = lcl_obj_PFAccountManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);
                            //Create EmployeeContribution PFAccountTransaction
                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionEmp = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                            lcl_obj_PFAccountTransactionEmp.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                            lcl_obj_PFAccountTransactionEmp.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeeContribution;
                            lcl_obj_PFAccountTransactionEmp.TransactionMonth = lcl_obj_SalaryAdditionDeduction.EffectiveMonth;
                            lcl_obj_PFAccountTransactionEmp.TransactionYear = lcl_obj_SalaryAdditionDeduction.EffectiveYear;
                            lcl_obj_PFAccountTransactionEmp.TransactionDate = lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate;
                            lcl_obj_PFAccountTransactionEmp.Amount = lcl_obj_SalaryAdditionDeduction.Amount;
                            lcl_obj_PFAccountTransactionEmp.Remarks = lcl_obj_SalaryAdditionDeduction.Remarks;
                            lcl_obj_PFAccountTransactionEmp.EntryEmployeeCode = lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode;

                            //Create OfficeContribution PFAccountTransaction
                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionOff = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                            lcl_obj_PFAccountTransactionOff.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                            lcl_obj_PFAccountTransactionOff.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeersContribution;
                            lcl_obj_PFAccountTransactionOff.TransactionMonth = lcl_obj_SalaryAdditionDeduction.EffectiveMonth;
                            lcl_obj_PFAccountTransactionOff.TransactionYear = lcl_obj_SalaryAdditionDeduction.EffectiveYear;
                            lcl_obj_PFAccountTransactionOff.TransactionDate = lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate;
                            lcl_obj_PFAccountTransactionOff.Amount = lcl_obj_SalaryAdditionDeduction.Amount;
                            lcl_obj_PFAccountTransactionOff.Remarks = lcl_obj_SalaryAdditionDeduction.Remarks;
                            lcl_obj_PFAccountTransactionOff.EntryEmployeeCode = lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode;

                            lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionEmp);
                            lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionOff);
                        }
                    }
                }
                 
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                lcl_obj_SalaryAdditionDeductionManager.Initialize();
                System.Decimal total_pf = 0;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditionDeduction)
                {
                    // ************** PF SSL 20161128, 1 ********************
                    lcl_obj_SalaryAdditionDeductionManager.Save(lcl_obj_SalaryAdditionDeduction, this.m_obj_DBManager);
                    total_pf += lcl_obj_SalaryAdditionDeduction.Amount;
                }
                //Save Provident Fund Transactions
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                lcl_obj_PFTransactionManager.Initialize();
                System.Decimal PfAccountTotal = 0;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransaction in lcl_objLst_PFAccountTransaction)
                {
                    // ************** PF SSL 20161128, 1 ********************
                    lcl_obj_PFTransactionManager.Save(lcl_obj_PFAccountTransaction, this.m_obj_DBManager);
                    PfAccountTotal += lcl_obj_PFAccountTransaction.Amount;
                }

                // ************** PF SSL 20161128, 2 ********************
                //this.m_obj_DBManager.CommitTransaction();
                this.m_obj_DBManager.Close();
                int k = 0;
            }
            catch (System.Exception Ex)
            {
                int A = 1;
            }
            finally
            {
                if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Close();
                }
            }
        }

        /// <summary>
        /// Run only Once. For ProvidentFund Account Synchronization
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        public void CreateProvidentFundAccounts(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.IS_UNIFORM_ELIGIBLE,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditionDeduction = new List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount> lcl_objLst_ProvidentFundAccountList = new List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount>();
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                lcl_obj_PFAccountManager.Initialize();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    if (lcl_obj_EmployeeProfile.IsPFEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                    {
                        /*********************************************************************************************************/
                        //Check If PF Account Exists
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                        
                        SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = lcl_obj_PFAccountManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);
                        /*********************************************************************************************************/
                        if (lcl_obj_PFAccount == null)
                        {
                            lcl_obj_PFAccount = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccount();
                            lcl_obj_PFAccount.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                            lcl_obj_PFAccount.CompanyCode = IP_ui64_CompanyCode;
                            lcl_obj_PFAccount.AccountStatus = SilkERP360.CCL.Enums.ProvidentFundAccountStatus.Active;
                            lcl_obj_PFAccount.Remarks = "Synchronized Account";
                            lcl_objLst_ProvidentFundAccountList.Add(lcl_obj_PFAccount);
                        }
                    }
                }

                
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount in lcl_objLst_ProvidentFundAccountList)
                {
                    //lcl_obj_PFAccountManager.Save(lcl_obj_PFAccount, this.m_obj_DBManager);
                }
                //this.m_obj_DBManager.CommitTransaction();
                //this.m_obj_DBManager.Close();

                int A = 0;
            }
            catch (System.Exception Ex)
            {
                int a = 0;
            }
        }

        public void TransferProvidentFundToAccount(System.UInt64 IP_ui64_CompanyCode)
        {
            int a = 0;
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objLst_PFAccountTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>();
            try
            {
                this.m_obj_DBManager.Open();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT WHERE COMPANY_CODE = {0} AND PF_ACCOUNT_NUMBER > 60200000001056", IP_ui64_CompanyCode);
                SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                lcl_obj_PFAccountManager.Initialize();

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccount> lcl_objLst_PFAccount = lcl_obj_PFAccountManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                lcl_obj_SalaryAdditionDeductionManager.Initialize();

                

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount in lcl_objLst_PFAccount)
                {
                    //Get PF Amount from AdditionDeduction
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_ADDITION_DEDUCTION WHERE EMPLOYEE_CODE = {0} AND ADD_DED_TYPE = {1}", lcl_obj_PFAccount.EmployeeCode, (System.UInt16)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund);
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditonDeduction = lcl_obj_SalaryAdditionDeductionManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                    if (lcl_objLst_SalaryAdditonDeduction == null)
                    {
                        continue;
                    }
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditonDeduction)
                    {
                        if (lcl_obj_SalaryAdditionDeduction.EffectiveYear < 2015)
                        {
                            continue;
                        }
                        //Create EmployeeContribution PFAccountTransaction
                        SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionEmp = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                        lcl_obj_PFAccountTransactionEmp.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                        lcl_obj_PFAccountTransactionEmp.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeeContribution;
                        lcl_obj_PFAccountTransactionEmp.TransactionMonth = lcl_obj_SalaryAdditionDeduction.EffectiveMonth;
                        lcl_obj_PFAccountTransactionEmp.TransactionYear = lcl_obj_SalaryAdditionDeduction.EffectiveYear;
                        lcl_obj_PFAccountTransactionEmp.TransactionDate = lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate;
                        lcl_obj_PFAccountTransactionEmp.Amount = lcl_obj_SalaryAdditionDeduction.Amount;
                        lcl_obj_PFAccountTransactionEmp.Remarks = lcl_obj_SalaryAdditionDeduction.Remarks;
                        lcl_obj_PFAccountTransactionEmp.EntryEmployeeCode = lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode;

                        //Create OfficeContribution PFAccountTransaction
                        SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionOff = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                        lcl_obj_PFAccountTransactionOff.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                        lcl_obj_PFAccountTransactionOff.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeersContribution;
                        lcl_obj_PFAccountTransactionOff.TransactionMonth = lcl_obj_SalaryAdditionDeduction.EffectiveMonth;
                        lcl_obj_PFAccountTransactionOff.TransactionYear = lcl_obj_SalaryAdditionDeduction.EffectiveYear;
                        lcl_obj_PFAccountTransactionOff.TransactionDate = lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate;
                        lcl_obj_PFAccountTransactionOff.Amount = lcl_obj_SalaryAdditionDeduction.Amount;
                        lcl_obj_PFAccountTransactionOff.Remarks = lcl_obj_SalaryAdditionDeduction.Remarks;
                        lcl_obj_PFAccountTransactionOff.EntryEmployeeCode = lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode;

                        lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionEmp);
                        lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionOff);
                    }
                }
                
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                lcl_obj_PFTransactionManager.Initialize();

                foreach(SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransaction in lcl_objLst_PFAccountTransaction)
                {
                    //lcl_obj_PFTransactionManager.Save(lcl_obj_PFAccountTransaction, this.m_obj_DBManager);
                    a++;                
                }
                //this.m_obj_DBManager.CommitTransaction();

                int a1 = 0;
            }
            catch (System.Exception Ex)
            {
                int y = a;
                Console.WriteLine(Ex.Message);
            }
        }

        public void ProvidentFundManualInput(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                System.String lcl_str_PFAmountCSVFile = @"D:\LiveSilkERP360\PFAccounts-WonContribution2013-2014.csv";
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.IS_UNIFORM_ELIGIBLE,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP.COMPANY_CODE = {0} AND IS_PF_ELIGIBLE = {1} Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode,(System.UInt32)SilkERP360.CCL.Enums.YesNo.Yes);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);

                System.Collections.Generic.List<System.String> lcl_strLst_InvalidEmployeeIds = new List<string>();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_AdditionDeduction = new List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objLst_PFAccountTransaction = new List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>();

                using (System.IO.StreamReader lcl_obj_PFAmountSR = new System.IO.StreamReader(lcl_str_PFAmountCSVFile))
                {
                    while (!(lcl_obj_PFAmountSR.EndOfStream))
                    {
                        System.String lcl_str_PFAmountFileLine = lcl_obj_PFAmountSR.ReadLine();
                        System.String[] lcl_arr_lcl_str_PFAmountFileLineSegments = lcl_str_PFAmountFileLine.Split(',');
                        System.String lcl_str_EmployeeID = lcl_arr_lcl_str_PFAmountFileLineSegments[0].Trim();
                        var lcl_obj_EmployeeProfileSorted =
                                               from Emp in lcl_objLst_EmployeeProfile
                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                                               select Emp;

                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                        {
                            //Employee Does Not Exist in the PF List from DB
                            lcl_strLst_InvalidEmployeeIds.Add("Inavlid Employee Id : " + lcl_str_EmployeeID);
                            Console.WriteLine("Inavlid Employee Id : " + lcl_str_EmployeeID);
                            //continue;
                        }
                        else
                        {
                            foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                            {
                                lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                            }
                            //Get PF Amount
                            System.Decimal lcl_dcm_PFAmount = System.Decimal.Parse(lcl_arr_lcl_str_PFAmountFileLineSegments[1].Trim());
                            /****************************************************************************************************************/
                            //SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            //lcl_obj_SalaryAdditionDeduction.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                            //lcl_obj_SalaryAdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                            //lcl_obj_SalaryAdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
                            //lcl_obj_SalaryAdditionDeduction.Amount = lcl_dcm_PFAmount;
                            //lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                            //lcl_obj_SalaryAdditionDeduction.Remarks = "P.F";
                            //lcl_obj_SalaryAdditionDeduction.EffectiveMonth = this.m_enm_Month;
                            //lcl_obj_SalaryAdditionDeduction.EffectiveYear = this.m_ui16_Year;
                            //lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode = 10100000000001;
                            //lcl_objLst_AdditionDeduction.Add(lcl_obj_SalaryAdditionDeduction);
                            /****************************************************************************************************************/

                            /****************************************************************************************************************/
                            //CREATE EmployeersContribution & EmployeeContribution instance for PFAccountTransaction
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                            SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                            lcl_obj_PFAccountManager.Initialize();

                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = lcl_obj_PFAccountManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);
                            //Create EmployeeContribution PFAccountTransaction
                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionEmp = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                            lcl_obj_PFAccountTransactionEmp.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                            lcl_obj_PFAccountTransactionEmp.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeeContribution;
                            lcl_obj_PFAccountTransactionEmp.TransactionMonth = this.m_enm_Month;
                            lcl_obj_PFAccountTransactionEmp.TransactionYear = this.m_ui16_Year;
                            lcl_obj_PFAccountTransactionEmp.TransactionDate = System.DateTime.Today;
                            lcl_obj_PFAccountTransactionEmp.Amount = lcl_dcm_PFAmount;
                            lcl_obj_PFAccountTransactionEmp.Remarks = "Starting Balance";// lcl_obj_SalaryAdditionDeduction.Remarks;
                            lcl_obj_PFAccountTransactionEmp.EntryEmployeeCode = 10100000000001;

                            //Create OfficeContribution PFAccountTransaction
                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransactionOff = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                            lcl_obj_PFAccountTransactionOff.PFAccountNumber = lcl_obj_PFAccount.PFAccountNumber;
                            lcl_obj_PFAccountTransactionOff.PFTransactionType = SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeersContribution;
                            lcl_obj_PFAccountTransactionOff.TransactionMonth = this.m_enm_Month;
                            lcl_obj_PFAccountTransactionOff.TransactionYear = this.m_ui16_Year;
                            lcl_obj_PFAccountTransactionOff.TransactionDate = System.DateTime.Today;
                            lcl_obj_PFAccountTransactionOff.Amount = lcl_dcm_PFAmount;
                            lcl_obj_PFAccountTransactionOff.Remarks = "Starting Balance";
                            lcl_obj_PFAccountTransactionOff.EntryEmployeeCode = 10100000000001;

                            lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionEmp);
                            lcl_objLst_PFAccountTransaction.Add(lcl_obj_PFAccountTransactionOff);
                            /****************************************************************************************************************/
                        }
                    }

                    //if (lcl_strLst_InvalidEmployeeIds.Count == 0)
                    //{
                        //All IDs in the file are okay
                        SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                        lcl_obj_SalaryAdditionDeductionManager.Initialize();
                        System.Decimal total_pf = 0;
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_AdditionDeduction)
                        {
                            //lcl_obj_SalaryAdditionDeductionManager.Save(lcl_obj_SalaryAdditionDeduction, this.m_obj_DBManager);
                            total_pf += lcl_obj_SalaryAdditionDeduction.Amount;
                        }
                        //Save Provident Fund Transactions
                        SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                        lcl_obj_PFTransactionManager.Initialize();
                        System.Decimal PfAccountTotal = 0;
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransaction in lcl_objLst_PFAccountTransaction)
                        {
                            //lcl_obj_PFTransactionManager.Save(lcl_obj_PFAccountTransaction, this.m_obj_DBManager);
                            PfAccountTotal += lcl_obj_PFAccountTransaction.Amount;
                        }
                        int a = 0;
                        //this.m_obj_DBManager.CommitTransaction();
                        //this.m_obj_DBManager.Close();
                    //}
                    
                }
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.ReadLine();
            }
        }

        public void PrintProvidentFund(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.IS_UNIFORM_ELIGIBLE,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE EMP.COMPANY_CODE = {0} AND IS_PF_ELIGIBLE = {1} Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode, (System.UInt32)SilkERP360.CCL.Enums.YesNo.Yes);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);

                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                lcl_obj_PFTransactionManager.Initialize();
                System.Text.StringBuilder lcl_sb_PFSummeryFile = new StringBuilder();
                System.Decimal lcl_dcm_EmployeeContribution = 0;
                System.Decimal lcl_dcm_EmployeersContribution = 0;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                    SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new SilkERP360.BML.HRIS.PFAccountManager();
                    lcl_obj_PFAccountManager.Initialize();

                    SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = lcl_obj_PFAccountManager.Get(lcl_str_SqlQuery, this.m_obj_DBManager);
                    if (lcl_obj_PFAccount == null)
                    {
                        continue;
                    }

                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM PF_ACCOUNT_TRANSACTION WHERE PF_ACCOUNT_NUMBER = {0}", lcl_obj_PFAccount.PFAccountNumber);
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objLst_PFAccountTransaction = lcl_obj_PFTransactionManager.GetList(lcl_str_SqlQuery, this.m_obj_DBManager);

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransaction in lcl_objLst_PFAccountTransaction)
                    {
                        //lcl_obj_PFTransactionManager.Save(lcl_obj_PFAccountTransaction, this.m_obj_DBManager);
                        //PfAccountTotal += lcl_obj_PFAccountTransaction.Amount;
                        if (lcl_obj_PFAccountTransaction.PFTransactionType == SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeeContribution)
                        {
                            lcl_dcm_EmployeeContribution += lcl_obj_PFAccountTransaction.Amount;
                        }
                        if (lcl_obj_PFAccountTransaction.PFTransactionType == SilkERP360.CCL.Enums.ProvidentFundTransactionType.EmployeersContribution)
                        {
                            lcl_dcm_EmployeersContribution += lcl_obj_PFAccountTransaction.Amount;
                        }
                    }
                    System.Decimal lcl_dcm_TotalPF = lcl_dcm_EmployeeContribution + lcl_dcm_EmployeersContribution;
                    System.String lcl_str_PFFileLine = System.String.Format("{0},{1},{2},{3},{4},{5}", 
                                                                                            lcl_obj_EmployeeProfile.EmployeeID,
                                                                                            lcl_obj_EmployeeProfile.EmployeeName,
                                                                                            lcl_obj_EmployeeProfile.Designation.Name,
                                                                                            lcl_dcm_EmployeeContribution,
                                                                                            lcl_dcm_EmployeersContribution,
                                                                                            lcl_dcm_TotalPF);
                    lcl_sb_PFSummeryFile.AppendLine(lcl_str_PFFileLine);
                    lcl_dcm_EmployeeContribution = 0;
                    lcl_dcm_EmployeersContribution = 0;
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter("SilkcardPFFile.csv");
                sw.Write(lcl_sb_PFSummeryFile.ToString());
                sw.Flush();
                sw.Close();
                    
                    int a = 0;
                    //this.m_obj_DBManager.CommitTransaction();
                    //this.m_obj_DBManager.Close();
                    //}

                
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.ReadLine();
            }
        }
    }
}
