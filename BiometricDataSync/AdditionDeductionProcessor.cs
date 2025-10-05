using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class AdditionDeductionProcessor
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;

        private SilkERP360.CCL.Enums.Month m_enm_Month;
        private System.UInt16 m_ui16_Year;

        public AdditionDeductionProcessor(SilkERP360.CCL.Enums.Month IP_enm_Month, System.UInt16 IP_ui16_Year)
        {
            this.m_enm_Month = IP_enm_Month;
            this.m_ui16_Year = IP_ui16_Year;
        }

        public AdditionDeductionProcessor()
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

        public void ProcessUnicormDeduction(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                if (IP_ui64_CompanyCode == 110000000002)
                {
                    return;
                }
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP.IS_UNIFORM_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    if (lcl_obj_EmployeeProfile.IsUniformEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                    {
                        //Console.WriteLine("PF for : " + lcl_obj_EmployeeProfile.EmployeeName);
                        //check if PF already Processed for this employee
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_ADDITION_DEDUCTION WHERE EMPLOYEE_CODE = {0} AND EFFECTIVE_MONTH = {1} AND EFFECTIVE_YEAR = {2} AND ADD_DED_TYPE = {3}", lcl_obj_EmployeeProfile.EmployeeCode, (int)this.m_enm_Month, this.m_ui16_Year, (int)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionUniform);
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
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionOthers;
                            lcl_obj_SalaryAdditionDeduction.Amount = 50; //UNIFORM DEDUCTION AMOUNT
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeduction.Remarks = "Deduction Unicorm";
                            lcl_obj_SalaryAdditionDeduction.EffectiveMonth = this.m_enm_Month;
                            lcl_obj_SalaryAdditionDeduction.EffectiveYear = this.m_ui16_Year;
                            lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode = 10100000000001;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeduction);
                        }
                    }
                }

                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                lcl_obj_SalaryAdditionDeductionManager.Initialize();
                System.Decimal total_uniform_deduction = 0;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditionDeduction)
                {
                    // ************************* SSL 20161128, 1 ******************************
                    //lcl_obj_SalaryAdditionDeductionManager.Save(lcl_obj_SalaryAdditionDeduction, this.m_obj_DBManager);
                    total_uniform_deduction += lcl_obj_SalaryAdditionDeduction.Amount;
                }
                // ************************* SSL 20161128, 2 ******************
               //this.m_obj_DBManager.CommitTransaction();
               //this.m_obj_DBManager.Close();
                 int a = 0;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
