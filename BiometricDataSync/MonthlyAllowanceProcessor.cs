using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class MonthlyAllowanceProcessor
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;

        private SilkERP360.CCL.Enums.Month m_enm_Month;
        private System.UInt16 m_ui16_Year;

        public MonthlyAllowanceProcessor(SilkERP360.CCL.Enums.Month IP_enm_Month, System.UInt16 IP_ui16_Year)
        {
            this.m_enm_Month = IP_enm_Month;
            this.m_ui16_Year = IP_ui16_Year;
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

        /// <summary>
        /// Time to run 25th 12:00 PM
        /// This process runs in Windows service.Runs only once for each sister concern each Month
        /// Before executing, it Checks if the SILKWAYS_GROUP_SALARY_PROFILE has been created or not
        /// if not
        ///     Return
        /// else
        ///     ->Check SILKWAYS_GROUP_SALARY_PROFILE.MONTHLY_ALLOWENCE_PROCESSED (YesNo) flay
        ///     if Yes
        ///         return
        ///     else
        ///         ->process monthly allowance 
        ///         ->Update SILKWAYS_GROUP_SALARY_PROFILE.MONTHLY_ALLOWENCE_PROCESSED = Yes
        ///     end
        /// end
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_enm_Month"></param>
        /// <param name="IP_ui16_Year"></param>
        public void Process(System.UInt64 IP_ui64_CompanyCode)
        {
            //1. Look for active entry in MONTHLY_ALLOWANCE table for each entry
            try
            {
                this.m_obj_DBManager.Open();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT MA.* FROM MONTHLY_ALLOWANCE MA JOIN EMPLOYEE EMP ON MA.EMPLOYEE_CODE = EMP.EMPLOYEE_CODE WHERE EMP.COMPANY_CODE = {0} AND MA.STATUS = {1}", IP_ui64_CompanyCode,(int)SilkERP360.CCL.Enums.YesNo.Yes);
                System.Data.OracleClient.OracleDataReader lcl_obj_MonthlyAllowanceReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_MonthlyAllowanceReader.HasRows == true)
                {
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance> lcl_objLst_MonthlyAllowance = new List<SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance>();
                    while (lcl_obj_MonthlyAllowanceReader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance lcl_obj_MonthlyAllowance = new SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance();
                        lcl_obj_MonthlyAllowance.MonthlyAllowanceCode = System.UInt64.Parse(lcl_obj_MonthlyAllowanceReader["M_ALLOWANCE_CODE"].ToString());
                        lcl_obj_MonthlyAllowance.EmployeeCode = System.UInt64.Parse(lcl_obj_MonthlyAllowanceReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_MonthlyAllowance.MonthlyAllowanceType = System.UInt32.Parse(lcl_obj_MonthlyAllowanceReader["M_ALLOWANCE_TYPE"].ToString());
                        lcl_obj_MonthlyAllowance.Amount = System.Double.Parse(lcl_obj_MonthlyAllowanceReader["AMOUNT"].ToString());
                        lcl_obj_MonthlyAllowance.EmployeeCode = System.UInt64.Parse(lcl_obj_MonthlyAllowanceReader["EMPLOYEE_CODE"].ToString());
                        lcl_objLst_MonthlyAllowance.Add(lcl_obj_MonthlyAllowance);
                    }
                    lcl_obj_MonthlyAllowanceReader.Close();

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditionDeduction = new List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();


                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance lcl_obj_MonthlyAllowance in lcl_objLst_MonthlyAllowance)
                    {
                        //Check If MonthlyAllowance For the Employee Has Already been Processed
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_ADDITION_DEDUCTION WHERE EMPLOYEE_CODE = {0} AND EFFECTIVE_MONTH = {1} AND EFFECTIVE_YEAR = {2} AND ADD_DED_TYPE = {3}", lcl_obj_MonthlyAllowance.EmployeeCode, (int)this.m_enm_Month, this.m_ui16_Year, (int)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionMonthlyAllowance);
                        System.Data.OracleClient.OracleDataReader lcl_obj_AdditionDeductionReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_AdditionDeductionReader.HasRows == true)
                        {
                            //Monthly Allowance Has Already Been Processed
                            lcl_obj_AdditionDeductionReader.Close();
                            continue;
                        }
                        else
                        {
                            //Monthly Allowance Has not yet been processed
                            lcl_obj_MonthlyAllowanceReader.Close();
                            SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAdditionDeduction.EmployeeCode = lcl_obj_MonthlyAllowance.EmployeeCode;
                            lcl_obj_SalaryAdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionMonthlyAllowance;
                            lcl_obj_SalaryAdditionDeduction.Amount = (decimal)lcl_obj_MonthlyAllowance.Amount;
                            lcl_obj_SalaryAdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeduction.Remarks = "MONTHLY FIXED ALLOWANCE";
                            lcl_obj_SalaryAdditionDeduction.EffectiveMonth = this.m_enm_Month;
                            lcl_obj_SalaryAdditionDeduction.EffectiveYear = this.m_ui16_Year;
                            lcl_obj_SalaryAdditionDeduction.EntryEmployeeCode = 10100000000001;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeduction);
                        }
                    }
                    SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                    lcl_obj_SalaryAdditionDeductionManager.Initialize();
                    System.Decimal lcl_dcm_TotalMonthlyAllowance = 0;
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditionDeduction)
                    {
                        //lcl_obj_SalaryAdditionDeductionManager.Save(lcl_obj_SalaryAdditionDeduction, this.m_obj_DBManager);
                        lcl_dcm_TotalMonthlyAllowance += lcl_obj_SalaryAdditionDeduction.Amount;
                    }
                    //this.m_obj_DBManager.CommitTransaction();
                    //this.m_obj_DBManager.Close();
                    int L = 0;
                }
                else
                {
                    lcl_obj_MonthlyAllowanceReader.Close();
                }
            }
            catch (System.Exception Ex)
            {
            }
            finally
            {
                if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                {
                    this.m_obj_DBManager.Close();
                }
            }
        }


    }
}
