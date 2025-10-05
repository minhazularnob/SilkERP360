using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.Services.HRIS
{
    public class SalaryServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SalaryServices()
        {
            this.Initialize();
        }

        public void CreateSalaryProfile(CCL.BusinessEntities.HRIS.GroupSalaryProfile IP_obj_GroupSalaryProfile)
        {
        }

        /// <summary>
        /// 1.Save Salary
        /// 2. Insert Absent Deduction in SalaryAdditionDeduction
        /// 3. Insert Late Deduction in SalaryAdditionDeduction
        /// 4. Insert Allowance in SalaryAdditionDeduction for Salary._MonthlyAllowance
        /// </summary>
        /// <param name="IP_obj_SalaryMaster"></param>
        /// <returns></returns>
        public System.Boolean SaveSalary(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new BML.HRIS.SalaryMasterManager();
                    lcl_obj_SalaryMasterManager.Initialize();
                    BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new BML.HRIS.SalaryAdditionDeductionManager();
                    lcl_obj_SalaryAdditionDeductionManager.Initialize();
                    lcl_obj_SalaryMasterManager.Save(IP_obj_SalaryMaster, lcl_obj_DBManager.InternalResource);
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditionDeduction = new List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                    foreach (CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in IP_obj_SalaryMaster.SalaryList)
                    {
                        /************************************************************************************************/
                        //Create AdditionDeduction for Wellpac Employees with Attendance Bonus
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalAddDed in lcl_obj_Salary.SalaryAdditionDeductionList)
                        {
                           // lcl_obj_SalAddDed.EffectiveMonth = (CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth;
                            //lcl_obj_SalAddDed.EffectiveYear = (ushort)IP_obj_SalaryMaster.SalaryYear;
                            lcl_obj_SalAddDed.EntryDate = System.DateTime.Today;
                            lcl_obj_SalAddDed.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalAddDed.EntryEmployeeCode = IP_obj_SalaryMaster.PreparationEmployeeCode;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalAddDed);
                        }
                        /************************************************************************************************/
                        if (lcl_obj_Salary.DeductionAbsent > 0)
                        {
                            CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionDA = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAdditionDeductionDA.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                            lcl_obj_SalaryAdditionDeductionDA.EffectiveMonth = (CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth;
                            lcl_obj_SalaryAdditionDeductionDA.EffectiveYear = (ushort)IP_obj_SalaryMaster.SalaryYear;
                            lcl_obj_SalaryAdditionDeductionDA.EntryDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeductionDA.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeductionDA.EntryEmployeeCode = IP_obj_SalaryMaster.PreparationEmployeeCode; 
                            lcl_obj_SalaryAdditionDeductionDA.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Deduction;
                            lcl_obj_SalaryAdditionDeductionDA.AdditionDeductionType = CCL.Enums.AdditionDeductionType.DeductionAbsent;
                            lcl_obj_SalaryAdditionDeductionDA.Amount = lcl_obj_Salary.DeductionAbsent;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeductionDA);
                        }
                        if (lcl_obj_Salary.DeductionLate > 0)
                        {
                            CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionDL = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAdditionDeductionDL.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                            lcl_obj_SalaryAdditionDeductionDL.EffectiveMonth = (CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth;
                            lcl_obj_SalaryAdditionDeductionDL.EffectiveYear = (ushort)IP_obj_SalaryMaster.SalaryYear;
                            lcl_obj_SalaryAdditionDeductionDL.EntryDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeductionDL.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeductionDL.EntryEmployeeCode = IP_obj_SalaryMaster.PreparationEmployeeCode; ;
                            lcl_obj_SalaryAdditionDeductionDL.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Deduction;
                            lcl_obj_SalaryAdditionDeductionDL.AdditionDeductionType = CCL.Enums.AdditionDeductionType.DeductionLate;
                            lcl_obj_SalaryAdditionDeductionDL.Amount = lcl_obj_Salary.DeductionLate;
                            lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeductionDL);
                        }
                        //if (lcl_obj_Salary._MonthlyFixedAllowance > 0)
                        //{
                        //    CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionAA = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        //    lcl_obj_SalaryAdditionDeductionAA.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                        //    lcl_obj_SalaryAdditionDeductionAA.EffectiveMonth = (CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth;
                        //    lcl_obj_SalaryAdditionDeductionAA.EffectiveYear = (ushort)IP_obj_SalaryMaster.SalaryYear;
                        //    lcl_obj_SalaryAdditionDeductionAA.EntryDate = System.DateTime.Today;
                        //    lcl_obj_SalaryAdditionDeductionAA.AdditionDeductionDate = System.DateTime.Today;
                        //    lcl_obj_SalaryAdditionDeductionAA.EntryEmployeeCode = 0;
                        //    lcl_obj_SalaryAdditionDeductionAA.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Addition;
                        //    lcl_obj_SalaryAdditionDeductionAA.AdditionDeductionType = CCL.Enums.AdditionDeductionType.AdditionAllowance;
                        //    lcl_obj_SalaryAdditionDeductionAA.Amount = lcl_obj_Salary._MonthlyFixedAllowance;
                        //    lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeductionAA);
                        //}
                        //if (lcl_obj_Salary.DeductionProvidentFund > 0)
                        //{
                        //    CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionDP = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        //    lcl_obj_SalaryAdditionDeductionDP.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                        //    lcl_obj_SalaryAdditionDeductionDP.EffectiveMonth = (CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth;
                        //    lcl_obj_SalaryAdditionDeductionDP.EffectiveYear = (ushort)IP_obj_SalaryMaster.SalaryYear;
                        //    lcl_obj_SalaryAdditionDeductionDP.EntryDate = System.DateTime.Today;
                        //    lcl_obj_SalaryAdditionDeductionDP.AdditionDeductionDate = System.DateTime.Today;
                        //    lcl_obj_SalaryAdditionDeductionDP.EntryEmployeeCode = 0;
                        //    lcl_obj_SalaryAdditionDeductionDP.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Deduction;
                        //    lcl_obj_SalaryAdditionDeductionDP.AdditionDeductionType = CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
                        //    lcl_obj_SalaryAdditionDeductionDP.Amount = lcl_obj_Salary._MonthlyFixedAllowance;
                        //    lcl_objLst_SalaryAdditionDeduction.Add(lcl_obj_SalaryAdditionDeductionDP);
                        //}

                        
                    }

                    foreach (CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditionDeduction)
                    {
                        lcl_obj_SalaryAdditionDeductionManager.Save(lcl_obj_SalaryAdditionDeduction, lcl_obj_DBManager.InternalResource);
                    }
                    
                    /******************************************************************************************************************************************/
                    //BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new BML.HRIS.SalaryMasterManager();
                    //lcl_obj_SalaryMasterManager.Initialize();
                    BML.HRIS.CompanyManager lcl_obj_CompanyManager = new BML.HRIS.CompanyManager();
                    lcl_obj_CompanyManager.Initialize();
                    CCL.BusinessEntities.HRIS.Company lcl_obj_Company = lcl_obj_CompanyManager.Get(IP_obj_SalaryMaster.CompanyCode, lcl_obj_DBManager.InternalResource);
                    System.String lcl_str_SalaryMonth = ((CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth).ToString();
                    System.String lcl_str_SalaryYear = IP_obj_SalaryMaster.SalaryYear.ToString();
                    System.String lcl_str_MailSubject = System.String.Format("Monthly Salary {0},{1}-{2}", lcl_str_SalaryMonth, lcl_str_SalaryYear, lcl_obj_Company.Name);

                    System.String lcl_str_SalaryReport = lcl_obj_SalaryMasterManager.GetSalarySummeryHTML(IP_obj_SalaryMaster, lcl_obj_DBManager.InternalResource);
                    List<string> lcl_objLst_MailListTo = new List<string>();
                    List<string> lcl_objLst_MailListCC = new List<string>();
                    //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                    //lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");


                    lcl_objLst_MailListCC.Add("manik@silkways.net");
                    //lcl_objLst_MailListCC.Add("sarder@silkways.net");
                    //lcl_objLst_MailListCC.Add("shameem.sc@silkways.net");
                    
                    switch (IP_obj_SalaryMaster.CompanyCode)
                    {
                        case 110000000001:
                            //Silkcard
                            lcl_objLst_MailListTo.Add("zinia.sc@silkways.net");
                            lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                            //lcl_objLst_MailListCC.Add("taj.sc@silkways.net");
                            //lcl_objLst_MailListTo.Add("saiyara.sc@silkways.net");
                            //lcl_objLst_MailListCC.Add("jalilur.sc@silkways.net");
                            break;
                        case 110000000002:
                            //lcl_objLst_MailListTo.Add("ataur.wp@silkways.net");
                            //lcl_objLst_MailListTo.Add("julfikar.wp@silkways.net");
                            //lcl_objLst_MailListCC.Add("sabbir.wp@silkways.net");
                            //lcl_objLst_MailListTo.Add("saiyara.sc@silkways.net");
                            lcl_objLst_MailListTo.Add("tauhid.wp@silkways.net");
                            lcl_objLst_MailListCC.Add("tariqul.wellpac@silkways.net");
                            lcl_objLst_MailListCC.Add("lota.sc@silkways.net");
                            //lcl_objLst_MailListCC.Add("rasul.as@silkways.net");
                            //Wellpac
                            break;
                        case 110000000003:
                            //SSL
                            //lcl_objLst_MailListTo.Add("saiyara.sc@silkways.net");
                            lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                            break;
                        case 110000000004:
                            //STTL
                            lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                            break;
                        case 110000000018:
                            //STTL
                            lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                            break;
                        case 110000000019:
                            //STTL
                            lcl_objLst_MailListTo.Add("zinia.sc@silkways.net");
                            lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                            lcl_objLst_MailListCC.Add("tariqul.wellpac@silkways.net");
                            break;
                    }
                    //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                    lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");
                    //lcl_objLst_MailListCC.Add("hasan.ss@silkways.net");
                    CCL.Misc.Mailer lcl_obj_Mailer = new CCL.Misc.Mailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    lcl_obj_Mailer.SendMail(lcl_str_MailSubject, lcl_str_SalaryReport);

                 
                    /******************************************************************************************************************************************/
                    return true;
                }
            }, "BMLExceptionPolicy");
            return lcl_b_Response;
        }

        /// <summary>
        /// Pre-Condition:
        /// 1. Tax Processor is Run
        /// 2. MonthlyAllowanceProcessor is run
        /// 3. ProvidentFundProcessor is Run
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_enm_SalaryMonth"></param>
        /// <param name="IP_ui16_SalaryYear"></param>
        /// <param name="IP_dt_SalaryCycleFrom"></param>
        /// <param name="IP_dt_SalaryCycleUpto"></param>
        /// <param name="IP_obj_SalaryMaster"></param>
        /// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster GenerateSalary(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear, System.DateTime IP_dt_SalaryCycleFrom, System.DateTime IP_dt_SalaryCycleUpto, SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    
                    BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new EmployeeServices();
                    lcl_obj_EmployeeService.Initialize();
                    BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();

                    BML.HRIS.EmployeeSalaryStructureManger lcl_obj_EmployeeSalaryStructureManager = new BML.HRIS.EmployeeSalaryStructureManger();
                    lcl_obj_EmployeeSalaryStructureManager.Initialize();
                    BML.HRIS.SalaryAdditionDeductionManager lcl_obj_SalaryAdditionDeductionManager = new BML.HRIS.SalaryAdditionDeductionManager();
                    lcl_obj_SalaryAdditionDeductionManager.Initialize();
                    foreach (CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in IP_obj_SalaryMaster.SalaryList)
                    {
                        if (lcl_obj_Salary.EmployeeCode == 101000002872)
                        {
                            int g = 0;
                        }
                        lcl_obj_Salary.Notes = System.String.Empty;
                        System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_SALARY_STRUCTURE WHERE EMPLOYEE_CODE = {0}", lcl_obj_Salary.EmployeeCode);
                        CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = lcl_obj_EmployeeSalaryStructureManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                        lcl_obj_Salary.Basic = lcl_obj_EmployeeSalaryStructure.Basic;
                        lcl_obj_Salary.Conveyence = lcl_obj_EmployeeSalaryStructure.Conveyence;
                        lcl_obj_Salary.Entertainment = lcl_obj_EmployeeSalaryStructure.Entertainment;
                        lcl_obj_Salary.HouseRent = lcl_obj_EmployeeSalaryStructure.HouseRent;
                        lcl_obj_Salary.Medical = lcl_obj_EmployeeSalaryStructure.Medical;
                        lcl_obj_Salary.Gross = System.Math.Round(lcl_obj_EmployeeSalaryStructure.Gross,2);

                        /****************************************************************************************************************************/
                        //lcl_obj_Salary.Basic = 0;
                        //lcl_obj_Salary.Conveyence = 0;
                        //lcl_obj_Salary.Entertainment = 0;
                        //lcl_obj_Salary.HouseRent = 0;
                        //lcl_obj_Salary.Medical = 0;
                        //lcl_obj_Salary.Gross = 0;
                        /****************************************************************************************************************************/


                        //System.Decimal lcl_dcm_SalaryPerHour = System.Math.Round(lcl_obj_Salary.Basic / 104, 2);
                        //System.Decimal lcl_dcm_SalaryPerDay = System.Math.Round(lcl_obj_Salary.Basic / 30, 2);
                        System.DateTime lcl_dt_JoiningDate = lcl_obj_EmployeeService.GetJoiningDate(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource);


                        System.Decimal lcl_dcm_SalaryPerHour = System.Math.Round(lcl_obj_EmployeeSalaryStructure.Basic / 104, 2);
                        System.Decimal lcl_dcm_SalaryPerDay = System.Math.Round(lcl_obj_EmployeeSalaryStructure.Basic / 30, 2);
                        System.Decimal lcl_dcm_GrossSalaryPerDay = System.Math.Round(lcl_obj_EmployeeSalaryStructure.Gross / 30, 2);

                        //Get BankAccountNo
                        lcl_obj_Salary.BankAccountNo = lcl_obj_EmployeeService.GetBankAccount(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource);
                        // Get TIN No 28-Jan-2017, SSL
                        lcl_obj_Salary.Tin = lcl_obj_EmployeeService.GetTin(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource);
                        //Check Monthly Allowance
                       // lcl_obj_Salary._MonthlyFixedAllowance = lcl_obj_EmployeeService.GetMonthlyAllowance(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource);
                        //IP_obj_SalaryMaster._TotalAdditionAllowance += lcl_obj_Salary._MonthlyFixedAllowance;
                        //Process Provident Fund
                        //if (lcl_obj_EmployeeService.IsPfEligible(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource) == CCL.Enums.YesNo.Yes)
                        //{
                        //    lcl_obj_Salary.DeductionProvidentFund = System.Math.Round(((lcl_obj_Salary.Basic * 10) / 100), 2);
                        //    //IP_obj_SalaryMaster._TotalDeductionProvidentFund += lcl_obj_Salary.DeductionProvidentFund;
                        //}
                        //Process Addition Deduction
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_ADDITION_DEDUCTION WHERE EMPLOYEE_CODE = {0} AND EFFECTIVE_MONTH = {1} AND EFFECTIVE_YEAR = {2} AND IS_PROCESSED = 0", lcl_obj_Salary.EmployeeCode, (System.UInt16)IP_enm_SalaryMonth, IP_ui16_SalaryYear);
                        System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAdditionDeduction = lcl_obj_SalaryAdditionDeductionManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                        if (lcl_objLst_SalaryAdditionDeduction != null)
                        {
                            foreach (CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeduction in lcl_objLst_SalaryAdditionDeduction)
                            {
                                if (lcl_obj_SalaryAdditionDeduction.AdditionOrDeduction == CCL.Enums.AdditionOrDeduction.Addition)
                                {
                                    switch (lcl_obj_SalaryAdditionDeduction.AdditionDeductionType)
                                    {
                                        case CCL.Enums.AdditionDeductionType.AdditionMonthlyAllowance:
                                            lcl_obj_Salary.AdditionAllowance += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionAllowance += lcl_obj_Salary.AdditionAllowance;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionAllowance:
                                            lcl_obj_Salary.AdditionAllowance += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionAllowance += lcl_obj_Salary.AdditionAllowance;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionArrear:
                                            lcl_obj_Salary.AdditionArrear += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionOthers += lcl_obj_Salary.AdditionArrear;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionBonus:
                                            lcl_obj_Salary.AdditionBonus += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionOthers += lcl_obj_Salary.AdditionBonus;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionIncentive:
                                            lcl_obj_Salary.AdditionIncentive += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionOthers += lcl_obj_Salary.AdditionIncentive;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionNightAllowance:
                                            lcl_obj_Salary.AdditionNightAllowance += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionAllowance += lcl_obj_Salary.AdditionNightAllowance;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionOthers:
                                            lcl_obj_Salary.AdditionOthers += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionOthers += lcl_obj_Salary.AdditionOthers;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.AdditionPhoneBill:
                                            lcl_obj_Salary.AdditionPhoneBill += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalAdditionOthers += lcl_obj_Salary.AdditionPhoneBill;
                                            break;
                                    }
                                }
                                if (lcl_obj_SalaryAdditionDeduction.AdditionOrDeduction == CCL.Enums.AdditionOrDeduction.Deduction)
                                {
                                    switch (lcl_obj_SalaryAdditionDeduction.AdditionDeductionType)
                                    {
                                        case CCL.Enums.AdditionDeductionType.DeductionAdvance:
                                            lcl_obj_Salary.DeductionAdvance += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalDeductionAdvance += lcl_obj_Salary.DeductionAdvance;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.DeductionIncomeTax:
                                            lcl_obj_Salary.DeductionIncomeTax += lcl_obj_SalaryAdditionDeduction.Amount;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.DeductionOthers:
                                            lcl_obj_Salary.DeductionOthers += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalDeductionOthers += lcl_obj_Salary.DeductionOthers;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.DeductionPenalty:
                                            lcl_obj_Salary.DeductionPenalty += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalDeductionOthers += lcl_obj_Salary.DeductionPenalty;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.DeductionProvidentFund:
                                            lcl_obj_Salary.DeductionProvidentFund += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalDeductionProvidentFund += lcl_obj_Salary.DeductionProvidentFund;
                                            break;
                                        case CCL.Enums.AdditionDeductionType.DeductionUnpaidLeave:
                                            lcl_obj_Salary.DeductionUnpaidLeave += lcl_obj_SalaryAdditionDeduction.Amount;
                                            //IP_obj_SalaryMaster._TotalDeductionOthers += lcl_obj_Salary.DeductionUnpaidLeave;
                                            break;
                                    }
                                }
                            }
                        }
                        //Process Overtime & Attendance
                        System.UInt16 lcl_ui16_TotalLateDays = 0;
                        System.UInt16 lcl_ui16_TotalAbsentDays = 0;
                        System.Double lcl_dbl_TotalOvertimeMinutes = 0;

                        System.Int32 lcl_i32_TotalNonJoiningDay = 0;

                        if (lcl_dt_JoiningDate > IP_dt_SalaryCycleFrom)
                        {
                            lcl_i32_TotalNonJoiningDay = lcl_dt_JoiningDate.Subtract(IP_dt_SalaryCycleFrom).Days;
                        }

                        //System.DateTime lcl_dt_DeductionBypassDate = System.DateTime.Parse("16/01/2015");
                        System.Boolean lcl_b_EligibleForAttendanceBonus = true;

                        System.Decimal lcl_dcm_TotalFoodAllowance = 0;
                        System.Decimal lcl_dcm_TotalOvertimeAmount = 0;
                        for (System.DateTime lcl_obj_AttendanceDate = IP_dt_SalaryCycleFrom; lcl_obj_AttendanceDate <= IP_dt_SalaryCycleUpto; lcl_obj_AttendanceDate = lcl_obj_AttendanceDate.AddDays(1))
                        {
                            
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_Salary.EmployeeCode, lcl_obj_AttendanceDate.ToString("dd/M/yyyy"));
                            CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                            if (lcl_obj_Attendance == null)
                            {
                                //Employee Didn't Join.
                                //Old Employee Reinstated in broken months
                                //if (lcl_dt_JoiningDate < IP_dt_SalaryCycleFrom)
                                //{
                                //    lcl_i32_TotalNonJoiningDay++;
                                //}
                            }
                            else
                            {
                                //if ((lcl_obj_AttendanceDate.Month == 6 && lcl_obj_AttendanceDate.Day == 16) || (lcl_obj_AttendanceDate.Month == 6 && lcl_obj_AttendanceDate.Day == 15))
                                System.DateTime lcl_dt_CheckStartDate = new DateTime(2018, 4, 26);
                                System.DateTime lcl_dt_CheckEndDate = new DateTime(2018, 5, 25);
                                if ((lcl_obj_AttendanceDate >= lcl_dt_CheckStartDate && lcl_obj_AttendanceDate <= lcl_dt_CheckEndDate))// || (lcl_obj_AttendanceDate.Month == 6 && lcl_obj_AttendanceDate.Day == 15))
                                {
                                    //ADD OVERTIME OF PREVIOUS MONTH
                                    //MUST BE COMMENTED AFTER June'2018 salary
                                    lcl_dbl_TotalOvertimeMinutes += lcl_obj_Attendance.OvertimeTotal;
                                    lcl_dcm_TotalOvertimeAmount += System.Decimal.Round(((System.Decimal)lcl_obj_Attendance.OvertimeTotal / 60) * lcl_obj_Attendance.PaidPerHour, 2);
                                    continue;
                                }
                                else
                                {
                                    if (lcl_obj_Salary.IsAbsentDeductionWaived == CCL.Enums.YesNo.No)
                                    {
                                        if (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ABSENT)
                                        //(lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND))
                                        {
                                            lcl_ui16_TotalAbsentDays++;
                                        }
                                    }
                                    if (lcl_obj_Salary.IsLateDeductionWaived == CCL.Enums.YesNo.No)
                                    {
                                        if (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.LATE)
                                        {
                                            lcl_ui16_TotalLateDays++;
                                        }
                                    }
                                }
                                /**************************************************************************************************************/
                                //For Attendance Bonus
                                if((lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ON_LEAVE) || 
                                    (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.LATE) ||
                                    (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.LATE_APPROVED) ||
                                    (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ABSENT_OVERRIDDEN_PRESENT) || 
                                    (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ABSENT))
                                {
                                    lcl_b_EligibleForAttendanceBonus = false;
                                }
                                /**************************************************************************************************************/
                                /**************************************************************************************************************/
                                //FOR Wellpac Food Allowance
                                if (IP_ui64_CompanyCode == 110000000002)
                                {

                                    if ((lcl_obj_Salary._EmployeeID == "WPL0071318") ||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071317") ||
                                        (lcl_obj_Salary._EmployeeID == "0257071509") ||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071275") ||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071187") ||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071194") ||
                                        (lcl_obj_Salary._EmployeeID == "0211801404") ||
                                        (lcl_obj_Salary._EmployeeID == "2136671812") ||
                                        (lcl_obj_Salary._EmployeeID == "0263501512") ||
                                        (lcl_obj_Salary._EmployeeID == "02136671812")||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071319") ||
                                        (lcl_obj_Salary._EmployeeID == "0213811101") ||
                                        (lcl_obj_Salary._EmployeeID == "WPL0071447") ||
                                        (lcl_obj_Salary._EmployeeID == "0261281510"))
                                    {
                                        //EXCLUDE THOSE WELLPAC EMPLOYEES WHO SIT IN CORPORATE OFFICE
                                    }
                                    else
                                    {
                                        if ((lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.PRESENT) ||
                                        (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.LATE) ||
                                        (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.LATE_APPROVED) ||
                                        (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY) ||
                                        (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.ABSENT_OVERRIDDEN_PRESENT) ||
                                        (lcl_obj_Attendance.AttnStatus == CCL.Enums.AttendanceStatus.OUTSIDE_DUTY))
                                        {
                                            lcl_obj_Salary.AdditionOthers += 25;
                                            SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionFoodAll = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                                            lcl_obj_SalaryAdditionDeductionFoodAll.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.AdditionDeductionType = CCL.Enums.AdditionDeductionType.AdditionOthers;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Addition;
                                            //lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionDeductionDate = System.DateTime.Today;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.EffectiveMonth = IP_enm_SalaryMonth;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.EffectiveYear = IP_ui16_SalaryYear;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.Amount = 25;
                                            lcl_obj_SalaryAdditionDeductionFoodAll.Remarks = "Food Allowance";
                                            lcl_dcm_TotalFoodAllowance += 25;
                                            lcl_obj_Salary.SalaryAdditionDeductionList.Add(lcl_obj_SalaryAdditionDeductionFoodAll);
                                        }
                                    }
                                }
                                /**************************************************************************************************************/
                                //MUST BE UNCOMMENTED LATER
                                lcl_dbl_TotalOvertimeMinutes += lcl_obj_Attendance.OvertimeTotal;
                                lcl_dcm_TotalOvertimeAmount += System.Decimal.Round(((System.Decimal)lcl_obj_Attendance.OvertimeTotal / 60) * lcl_obj_Attendance.PaidPerHour,2);

                                /******************************************************************************************************************************/
                                //MUST BE UNCOMMENTED LATER
                                lcl_obj_Salary.AdditionNightAllowance += lcl_obj_Attendance.NightAllowance;
                                /******************************************************************************************************************************/
                            }
                        }
                        if (lcl_dcm_TotalFoodAllowance > 0)
                        {
                            lcl_obj_Salary.Notes += "|Food Allow : " + lcl_dcm_TotalFoodAllowance.ToString();
                        }
                        /*******************************************************************************************************************/
                        //Assign Attendance Bonus To Wellpac Employees
                        if (IP_ui64_CompanyCode == 110000000002)
                        {
                            if (lcl_obj_EmployeeService.IsOTEligble(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager.InternalResource) == CCL.Enums.YesNo.Yes)
                            {
                                if (lcl_b_EligibleForAttendanceBonus == true)
                                {
                                    
                                    if (lcl_dt_JoiningDate < IP_dt_SalaryCycleFrom)
                                    {
                                        //Employees Joining After the start of salary cycle will not receive the attendance bonus
                                        lcl_obj_Salary.AdditionOthers += 500;
                                        lcl_obj_Salary.Notes += "|Attn Bonus : 500.00";
                                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionAttnBonus = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionDeductionType = CCL.Enums.AdditionDeductionType.AdditionOthers;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Addition;
                                        //lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionDeductionDate = System.DateTime.Today;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.EffectiveMonth = IP_enm_SalaryMonth;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.EffectiveYear = IP_ui16_SalaryYear;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.Amount = 500;
                                        lcl_obj_SalaryAdditionDeductionAttnBonus.Remarks = "Attn Bonus";

                                        lcl_obj_Salary.SalaryAdditionDeductionList.Add(lcl_obj_SalaryAdditionDeductionAttnBonus);
                                    }
                                    else
                                    {
                                        int h = 0;
                                    }
                                    //lcl_obj_Salary
                                }
                            }
                        }
                        /*******************************************************************************************************************/
                        //Pre-Condition : If employee rejoins, his/her joining date has to be changed as well
                        //Deduction for broken month joinee
                        System.Decimal lcl_dcm_DeductionForBrokenJoinee = System.Math.Round((lcl_dcm_GrossSalaryPerDay * lcl_i32_TotalNonJoiningDay), 2);
                        lcl_obj_Salary.DeductionOthers += lcl_dcm_DeductionForBrokenJoinee;
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionBrokenMonth = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.AdditionDeductionType = CCL.Enums.AdditionDeductionType.DeductionOthers;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Deduction;
                        //lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.EffectiveMonth = IP_enm_SalaryMonth;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.EffectiveYear = IP_ui16_SalaryYear;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.Amount = lcl_dcm_DeductionForBrokenJoinee;
                        lcl_obj_SalaryAdditionDeductionBrokenMonth.Remarks = "Broken Month Recruitment Deduction";
                        lcl_obj_Salary.SalaryAdditionDeductionList.Add(lcl_obj_SalaryAdditionDeductionBrokenMonth);

                        //Absent Deduction//For one days Salary, 03 days deduction
                        lcl_obj_Salary.DeductionAbsent = System.Math.Round(((lcl_dcm_SalaryPerDay * 3) * lcl_ui16_TotalAbsentDays), 2);
                        //Late Deduction
                        if (lcl_ui16_TotalLateDays >= 3)
                        {
                            lcl_obj_Salary.DeductionLate = System.Math.Round(((lcl_ui16_TotalLateDays / 3) * lcl_dcm_SalaryPerDay), 2);
                        }
                        //Calculate Overtime Amount
                        /******************************************************************************************************************************/
                        //MUST BE UNCOMMENTED LATER
                        lcl_obj_Salary.OverTimeMinutes = lcl_dbl_TotalOvertimeMinutes;
                        System.String lcl_str_OvertimeHour = ((long)(lcl_dbl_TotalOvertimeMinutes / 60)).ToString() + "." + ((long)(lcl_dbl_TotalOvertimeMinutes % 60)).ToString();

                        //lcl_obj_Salary.OverTimeAmount = System.Math.Round((((double)lcl_dcm_SalaryPerHour) * ((double)(lcl_dbl_TotalOvertimeMinutes/60))),2);
                        lcl_obj_Salary.OverTimeAmount = lcl_dcm_TotalOvertimeAmount;// System.Math.Round((System.Decimal.Parse(lcl_str_OvertimeHour) * lcl_dcm_SalaryPerHour), 2);
                        //lcl_obj_Salary.OverTimeMinutes = 0;
                        //lcl_obj_Salary.OverTimeAmount = 0;
                        /******************************************************************************************************************************/
                        lcl_obj_Salary.GrandTotal = System.Math.Round(((lcl_obj_Salary.Gross +  lcl_obj_Salary.OverTimeAmount + lcl_obj_Salary.AdditionAllowance + lcl_obj_Salary.AdditionArrear + lcl_obj_Salary.AdditionBonus + lcl_obj_Salary.AdditionIncentive + lcl_obj_Salary.AdditionNightAllowance + lcl_obj_Salary.AdditionOthers + lcl_obj_Salary.AdditionPhoneBill ) -
                            (lcl_obj_Salary.DeductionAbsent + lcl_obj_Salary.DeductionAdvance + lcl_obj_Salary.DeductionIncomeTax + lcl_obj_Salary.DeductionLate + lcl_obj_Salary.DeductionOthers + lcl_obj_Salary.DeductionPenalty + lcl_obj_Salary.DeductionProvidentFund + lcl_obj_Salary.DeductionUnpaidLeave)),2);

                        /***********************************************************************************************************************/
                        //Check for Negative Salary
                        //If Salary is Negative, Salary will be rounded to 0. The Negative amount will be added in AdditionDeduction
                        //as deduction to be adjusted with next months salary
                        if (lcl_obj_Salary.GrandTotal < 0)
                        {
                            System.Decimal lcl_dcm_NextMonthDeductionAmount = lcl_obj_Salary.GrandTotal;

                            lcl_obj_Salary.GrandTotal = 0;
                            lcl_obj_Salary.Notes += " | Neg Sal.Rounded to 0.Neg Amt to be Adjusted Next Month : " + lcl_dcm_NextMonthDeductionAmount.ToString();

                            SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAdditionDeductionNegSal = new CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAdditionDeductionNegSal.EmployeeCode = lcl_obj_Salary.EmployeeCode;
                            lcl_obj_SalaryAdditionDeductionNegSal.AdditionDeductionType = CCL.Enums.AdditionDeductionType.DeductionOthers;
                            lcl_obj_SalaryAdditionDeductionNegSal.AdditionOrDeduction = CCL.Enums.AdditionOrDeduction.Deduction;
                            lcl_obj_SalaryAdditionDeductionNegSal.EffectiveMonth = IP_enm_SalaryMonth + 1;
                            if (IP_enm_SalaryMonth == CCL.Enums.Month.December)
                            {
                                lcl_obj_SalaryAdditionDeductionNegSal.EffectiveYear = (ushort)(IP_ui16_SalaryYear + 1);
                            }
                            else
                            {
                                lcl_obj_SalaryAdditionDeductionNegSal.EffectiveYear = IP_ui16_SalaryYear;
                            }
                            //lcl_obj_SalaryAdditionDeductionAttnBonus.AdditionDeductionDate = System.DateTime.Today;
                            lcl_obj_SalaryAdditionDeductionNegSal.Amount = (lcl_dcm_NextMonthDeductionAmount * -1);
                            lcl_obj_SalaryAdditionDeductionNegSal.Remarks = "Neg Sal Adjustment of Last Month";

                            lcl_obj_Salary.SalaryAdditionDeductionList.Add(lcl_obj_SalaryAdditionDeductionNegSal);

                        }
                        /***********************************************************************************************************************/

                        IP_obj_SalaryMaster._TotalGrossSalary += lcl_obj_Salary.Gross;

                        IP_obj_SalaryMaster._TotalAdditionAllowance += (lcl_obj_Salary.AdditionAllowance + lcl_obj_Salary.AdditionNightAllowance);
                        IP_obj_SalaryMaster._TotalAdditionOthers += (lcl_obj_Salary.AdditionArrear + lcl_obj_Salary.AdditionBonus + lcl_obj_Salary.AdditionIncentive + lcl_obj_Salary.AdditionOthers + lcl_obj_Salary.AdditionPhoneBill);

                        IP_obj_SalaryMaster._TotalOvertimeMinutes += (ulong)lcl_obj_Salary.OverTimeMinutes;
                        IP_obj_SalaryMaster._TotalOvertimeAmount += lcl_obj_Salary.OverTimeAmount;

                        IP_obj_SalaryMaster._TotalDeductionAbsent += lcl_obj_Salary.DeductionAbsent;
                        IP_obj_SalaryMaster._TotalDeductionAdvance += lcl_obj_Salary.DeductionAdvance;
                        IP_obj_SalaryMaster._TotalDeductionLate += lcl_obj_Salary.DeductionLate;
                        IP_obj_SalaryMaster._TotalDeductionOthers += (lcl_obj_Salary.DeductionOthers + lcl_obj_Salary.DeductionPenalty + lcl_obj_Salary.DeductionUnpaidLeave);
                        IP_obj_SalaryMaster._TotalDeductionProvidentFund += lcl_obj_Salary.DeductionProvidentFund;
                        IP_obj_SalaryMaster._TotalDeductionTax += lcl_obj_Salary.DeductionIncomeTax;

                        IP_obj_SalaryMaster._TotalAmountPayable += lcl_obj_Salary.GrandTotal;

                        /***********************************************************************************************************************/
                        //Check for Negative Salary
                        //If Salary is Negative, Salary will be rounded to 0. The Negative amount will be added in AdditionDeduction
                        //as deduction to be adjusted with next months salary

                        /***********************************************************************************************************************/

                        //IP_obj_SalaryMaster.ProcessDate = 
                        //lcl_obj_Salary.SalaryStatus = CCL.Enums.SalaryStatus.Released;
                    }
                    /******************************************************************************************************************************************/
                    //Implant M.D's Salary For Wellpac
                    if (IP_ui64_CompanyCode == 110000000002)
                    {
                        /*SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_SalaryMD = new CCL.BusinessEntities.HRIS.Salary();
                        lcl_obj_SalaryMD.EmployeeCode = 101000001099;
                        lcl_obj_SalaryMD._EmployeeID = "MGT0411002";
                        lcl_obj_SalaryMD._Department = "Management";
                        lcl_obj_SalaryMD._Designation = "Managing Director (M.D)";
                        lcl_obj_SalaryMD._EmployeeName = "Sk. Farid Ahmed";
                        lcl_obj_SalaryMD.Basic = 363000;
                        lcl_obj_SalaryMD.HouseRent = 181500;
                        lcl_obj_SalaryMD.Medical = 30250;
                        lcl_obj_SalaryMD.Conveyence = 30250;
                        lcl_obj_SalaryMD.DeductionIncomeTax = 150000;
                        lcl_obj_SalaryMD.Gross = 605000;
                        lcl_obj_SalaryMD.BankAccountNo = "-";
                        lcl_obj_SalaryMD.Tin = "682281507570"; // TIN 28-Jan-2017, SSL
                        lcl_obj_SalaryMD.SalaryStatus = CCL.Enums.SalaryStatus.Released;
                        lcl_obj_SalaryMD.GrandTotal = lcl_obj_SalaryMD.Gross - lcl_obj_SalaryMD.DeductionIncomeTax;
                        IP_obj_SalaryMaster.SalaryList.Insert(0, lcl_obj_SalaryMD);
                        IP_obj_SalaryMaster._TotalGrossSalary += lcl_obj_SalaryMD.Gross;
                        IP_obj_SalaryMaster._TotalDeductionTax += lcl_obj_SalaryMD.DeductionIncomeTax;
                        IP_obj_SalaryMaster._TotalAmountPayable += lcl_obj_SalaryMD.GrandTotal;*/
                    }
                    /******************************************************************************************************************************************/
                    /******************************************************************************************************************************************/
                    /*BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new BML.HRIS.SalaryMasterManager();
                    lcl_obj_SalaryMasterManager.Initialize();
                    System.String lcl_str_SalaryReport = lcl_obj_SalaryMasterManager.GetSalarySummeryHTML(IP_obj_SalaryMaster, lcl_obj_DBManager.InternalResource);
                    List<string> lcl_objLst_MailListTo = new List<string>();
                    List<string> lcl_objLst_MailListCC = new List<string>();
                    lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                    lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");
                    CCL.Misc.Mailer lcl_obj_Mailer = new CCL.Misc.Mailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                    System.String lcl_str_MailSubject = "Salary";
                    lcl_obj_Mailer.SendMail(lcl_str_MailSubject, lcl_str_SalaryReport);
                    /******************************************************************************************************************************************/
                    lcl_obj_DBManager.InternalResource.Close();
                    return IP_obj_SalaryMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMasterRet;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster GetSalaryMaster(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new EmployeeServices();
                    lcl_obj_EmployeeService.Initialize();

                    BML.HRIS.SalaryMasterManager lcl_obj_SalaryMasterManager = new BML.HRIS.SalaryMasterManager();
                    lcl_obj_SalaryMasterManager.Initialize();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SALARY_MASTER WHERE COMPANY_CODE = {0} AND SALARY_MONTH = {1} AND SALARY_YEAR = {2}", IP_ui64_CompanyCode, (ushort)IP_enm_SalaryMonth, IP_ui16_SalaryYear);
                    CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = lcl_obj_SalaryMasterManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    return lcl_obj_SalaryMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMasterRet;
        }

    }
}
