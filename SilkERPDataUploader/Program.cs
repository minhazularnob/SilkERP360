using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilkERPDataUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Text.StringBuilder lcl_obj_SalaryProcessorLog = new StringBuilder();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objList_OvertimeSeptember = null;
            System.Double lcl_dbl_TotalOTSeptember = 0;
       
            SilkERP360.CCL.Enums.Month SALARY_MONTH = SilkERP360.CCL.Enums.Month.September;
            System.DateTime lcl_dt_OTStartDate = System.DateTime.Parse("20/September/2014");
            System.DateTime lcl_dt_OTEndDate = System.DateTime.Parse("20/September/2014");
            System.UInt16 SALARY_YEAR = 2014;
            System.Int32 lcl_i32_OTIndex = 0;
            SilkERP360.DAL.DBManager lcl_obj_DBManager = null;
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
            try
            {
                /***************************************************************************************************************************/
                //Database Connections
                lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp; Password=silkerp");
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.Boolean lcl_b_ProcessOTOnly = true;
                /***************************************************************************************************************************/
                //Employee Profile Generate
                System.UInt64 lcl_ui64_EntryEmployeeCode = 101000000001;//Me
                //System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,EMP.BANK_ACCOUNT_NO,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED
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
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DESIG.Rank,DEPT.RANK ASC", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, lcl_obj_DBManager);

                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
                //lcl_obj_SalaryProcessorLog.AppendLine("Processing Salary : " + lcl_objLst_EmployeeProfile[0].Company.Name);
                //GET M.D'S PROFILE FOR WELLPAC SALARY

                /**************************************************************************************************************************************************************/
                lcl_obj_DBManager.CloseReader();
                lcl_obj_DBManager.Close();
                lcl_obj_DBManager.Open();
                //SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile 
                /***************************************************************************************************************************/
                #region O.T
                //Silkcard O.T Entry
                //System.String lcl_str_OTCSVFilePath = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\September\OT.csv";
                //lcl_objList_OvertimeSeptember = new
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime>();
                //using (System.IO.StreamReader lcl_obj_OvertimeSR = new System.IO.StreamReader(lcl_str_OTCSVFilePath))
                //{
                //    System.String lcl_str_CSVFileLine = "";
                //    while (!(lcl_obj_OvertimeSR.EndOfStream))
                //    {
                //        lcl_str_CSVFileLine = lcl_obj_OvertimeSR.ReadLine();


                //        System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014
                //        if (lcl_str_CSVFileLineSegments.Length != 2)
                //        {
                //            continue;
                //        }
                //        System.String lcl_str_OTHour = lcl_str_CSVFileLineSegments[1].Trim();
                //        if ((lcl_str_OTHour == "") || (lcl_str_OTHour == "-"))
                //        {
                //            continue;
                //        }
                //        System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
                //        var lcl_obj_EmployeeProfileSorted =
                //                                from Emp in lcl_objLst_EmployeeProfile
                //                                where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                //                                select Emp;

                //        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                //        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                //        {
                //            //Employee Terminated
                //            System.Console.WriteLine("O.T Employee ID Not Found : " + lcl_str_EmployeeID);
                //            continue;
                //        }

                //        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                //        {
                //            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                //        }
                //        System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeProfile.EmployeeCode.ToString());
                //        System.String lcl_str_EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                //        lcl_i32_OTIndex = 1;
                //        for (System.DateTime lcl_obj_OTDate = lcl_dt_OTStartDate; lcl_obj_OTDate <= lcl_dt_OTEndDate; lcl_obj_OTDate = lcl_obj_OTDate.AddDays(1))
                //        {
                //            lcl_str_OTHour = lcl_str_CSVFileLineSegments[1];
                //            if ((lcl_str_OTHour.Trim() == "") || (lcl_str_OTHour.Trim() == "-"))
                //            {
                //                continue;
                //            }
                //            lcl_str_OTHour = System.String.Format("{0:0.00}", lcl_str_OTHour);
                //            SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_OverTime = new SilkERP360.CCL.BusinessEntities.HRIS.Overtime();
                //            lcl_obj_OverTime.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                //            //lcl_obj_OverTime._OvertimeType_ENM = SilkERP360.CCL.Enums.OvertimeType.Current;
                //            lcl_obj_OverTime.EmployeeCode = lcl_ui64_EmployeeCode;
                //            //lcl_obj_OverTime._CompanyCode_UI64 = lcl_ui64_CompanyCode;
                //            //lcl_obj_OverTime._EmployeeID_STR = lcl_str_EmployeeID;
                //            //lcl_obj_OverTime._EmployeeName_STR = lcl_obj_EmployeeProfile.EmployeeName;
                //            lcl_obj_OverTime.OvertimeDate = lcl_obj_OTDate;
                //            //System.String lcl_str_OTHour = lcl_str_CSVFileLineSegments[1].Trim();
                //            System.Double lcl_dbl_OTHour = ((lcl_str_OTHour == "") || (lcl_str_OTHour == "-"))
                //                ? 0.0 : System.Double.Parse(lcl_str_OTHour);
                //            lcl_dbl_TotalOTSeptember += lcl_dbl_OTHour;
                //            lcl_obj_OverTime.OvertimeHour = lcl_dbl_OTHour;
                //            lcl_obj_OverTime.EntryDate = System.DateTime.Now;
                //            lcl_objList_OvertimeSeptember.Add(lcl_obj_OverTime);

                //        }

                //    }
                //    lcl_obj_OvertimeSR.Close();
                //    SilkERP360.BML.HRIS.OvertimeManager lcl_obj_OvertimeManager = new SilkERP360.BML.HRIS.OvertimeManager();
                //    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime in lcl_objList_OvertimeSeptember)
                //    {
                //        lcl_obj_OvertimeManager.Save(lcl_obj_Overtime, lcl_obj_DBManager);
                //    }
                //    lcl_obj_DBManager.CommitTransaction();
                //    lcl_obj_DBManager.Close();
                //}
                #endregion

                #region Addition Allowance
                //Silkcard Other Allowance Entry
                System.Decimal lcl_dcm_TMallowance = 0;

                /*foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    if (lcl_obj_EmployeeProfile.EmployeeID.Equals("OFC14081425"))
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM MONTHLY_ALLOWANCE WHERE EMPLOYEE_CODE = {0} AND STATUS = {1}", lcl_obj_EmployeeProfile.EmployeeCode, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                        System.Data.OracleClient.OracleDataReader lcl_obj_AllowanceReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                        if (!(lcl_obj_AllowanceReader.HasRows))
                        {
                            lcl_obj_AllowanceReader.Close();
                            continue;
                        }
                        lcl_obj_AllowanceReader.Read();

                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Decimal lcl_dbl_AdditionAmount = System.Decimal.Parse(lcl_obj_AllowanceReader["AMOUNT"].ToString());
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.September;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
                        lcl_obj_AdditionDeduction.Remarks = "Monthly Fixed Allowance";
                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                        lcl_dcm_TMallowance += lcl_obj_AdditionDeduction.Amount;
                        lcl_obj_AllowanceReader.Close();
                    }
                }
                //Save Night Allowance Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                lcl_obj_DBManager.CommitTransaction();*/
                int cf = 0;
#endregion

                #region Addition Night Allowance
                //System.Decimal lcl_dcm_TotalNightAllowance = 0;
                ////Silkcard Addition Arrear
                //System.String lcl_str_AdditionNightAllowanceCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\September\Silkcard-NightAllowance-September-2014.csv";
                ////System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                ////    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                //using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionNightAllowanceCSVFile))
                //{
                //    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
                //    {
                //        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
                //        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
                //        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
                //        var lcl_obj_EmployeeProfileSorted =
                //                               from Emp in lcl_objLst_EmployeeProfile
                //                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                //                               select Emp;

                //        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                //        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                //        {
                //            //Employee Terminated
                //            //lcl_strList_InvalidEmployeeIds.Add("Night Allowance - Addition : " + lcl_str_EmployeeID);
                //            System.Console.WriteLine("Night Allowance Employee ID Not Found : " + lcl_str_EmployeeID);
                //            continue;
                //        }
                //        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                //        {
                //            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                //        }
                //        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                //        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                //        {
                //            continue;
                //        }
                //        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                //        System.Decimal lcl_dcm_AdditionAmount = System.Decimal.Parse(lcl_str_Amount);
                //        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                //        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                //        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                //        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                //        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionNightAllowance;
                //        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                //        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
                //        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
                //        lcl_obj_AdditionDeduction.Remarks = "";
                //        lcl_obj_AdditionDeduction.Amount = lcl_dcm_AdditionAmount;
                //        lcl_dcm_TotalNightAllowance += lcl_dcm_AdditionAmount;
                //        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                //    }
                //    lcl_obj_SalaryAdditionSR.Close();
                //}
                ////Save Night Allowance Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    System.UInt64 a = lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}
                //lcl_obj_DBManager.CommitTransaction();
                //int a2 = 0;
                #endregion

                #region Addition Bonus Silkcard
                //System.Decimal lcl_dcm_TotalAdditionAmount = 0;
                ////Silkcard Addition Arrear
                //System.String lcl_str_AdditionNightAllowanceCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\September\BonuslessEmployees.txt";
                ////System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                ////    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                //using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionNightAllowanceCSVFile))
                //{
                //    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
                //    {
                //        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
                //        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
                //        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
                //        var lcl_obj_EmployeeProfileSorted =
                //                               from Emp in lcl_objLst_EmployeeProfile
                //                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                //                               select Emp;

                //        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                //        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                //        {
                //            //Employee Terminated
                //            //lcl_strList_InvalidEmployeeIds.Add("Night Allowance - Addition : " + lcl_str_EmployeeID);
                //            System.Console.WriteLine("Bonus Employee ID Not Found : " + lcl_str_EmployeeID);
                //            continue;
                //        }
                //        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                //        {
                //            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                //        }
                //        lcl_objLst_EmployeeProfile.Remove(lcl_obj_EmployeeProfile);
                //    }
                //    lcl_obj_SalaryAdditionSR.Close();
                //}
                //        //System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                //        //if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                //        //{
                //        //    continue;
                //        //}
                //foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_BonusEmployeeProfile in lcl_objLst_EmployeeProfile)
                //{
                //    System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_BonusEmployeeProfile.EmployeeCode;
                //    //System.Decimal lcl_dcm_AdditionAmount = System.Decimal.Parse(lcl_str_Amount);
                //    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                //    lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                //    lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                //    lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                //    lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionBonus;
                //    lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                //    lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
                //    lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
                //    lcl_obj_AdditionDeduction.Remarks = "";
                //    lcl_obj_AdditionDeduction.Amount = lcl_obj_BonusEmployeeProfile.SalaryStructure.Basic;
                //    //lcl_dcm_TotalAdditionAmount += lcl_dcm_AdditionAmount;
                //    lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                //}
                ////Save Night Allowance Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    System.UInt64 a = lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();
                //int a3 = 0;
                #endregion

                #region Addition Bonus
                System.Decimal lcl_dcm_TotalAdditionAmount = 0;
                //Silkcard Addition Arrear
                System.String lcl_str_AdditionNightAllowanceCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\STTL\August\STTL_BankAccounts_August_2014.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionNightAllowanceCSVFile))
                {
                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
                    {
                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
                        var lcl_obj_EmployeeProfileSorted =
                                               from Emp in lcl_objLst_EmployeeProfile
                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                                               select Emp;

                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                        {
                            //Employee Terminated
                            //lcl_strList_InvalidEmployeeIds.Add("Night Allowance - Addition : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Bonus Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        //System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        //if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        //{
                        //    continue;
                        //}
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        //System.Decimal lcl_dcm_AdditionAmount = System.Decimal.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionBonus;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
                        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                        //lcl_dcm_TotalAdditionAmount += lcl_dcm_AdditionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Night Allowance Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    System.UInt64 a = lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                int a2 = 0;
                #endregion

                #region PF Processing
                //PF Processing
                //System.String lcl_str_PFEligibleCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\September\Deduction-PF-September-2014.CSV";
                //System.Int32 lcl_i32_TotalPFEligibleUpdated = 0;
                //System.Decimal lcl_obj_TotalPFDeducted = 0; ;
                //using (System.IO.StreamReader lcl_obj_PFSR = new System.IO.StreamReader(lcl_str_PFEligibleCSVFile))
                //{
                //    while (!(lcl_obj_PFSR.EndOfStream))
                //    {
                //        System.String lcl_str_AddLine = lcl_obj_PFSR.ReadLine();
                //        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
                //        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
                //        var lcl_obj_EmployeeProfileSorted =
                //                               from Emp in lcl_objLst_EmployeeProfile
                //                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                //                               select Emp;

                //        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                //        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                //        {
                //            //Employee Terminated
                //            //lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
                //            lcl_obj_SalaryProcessorLog.AppendLine("PF ELIGIBILITY STATUS WAS NOT UPDATED : " + lcl_str_EmployeeID);
                //            System.Console.WriteLine("PF ID Not Found : " + lcl_str_EmployeeID);
                //            continue;
                //        }
                //        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                //        {
                //            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                //        }
                //        lcl_i32_TotalPFEligibleUpdated++;
                //        //System.String lcl_str_Update = System.String.Format("Update Employee Set IS_PF_ELIGIBLE = 1 WHERE EMPLOYEE_ID = '{0}'", lcl_str_EmployeeID);
                //        //lcl_obj_DBManager.ExecuteNonQuery(lcl_str_Update);
                        
                //        //System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                //        //if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                //        //{
                //        //    continue;
                //        //}


                //        System.Decimal lcl_dcm_PFAmount = (lcl_obj_EmployeeProfile.SalaryStructure.Basic * 10) / 100;
                //        lcl_obj_TotalPFDeducted += lcl_dcm_PFAmount;
                //        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        
                //        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                //        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                //        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                //        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                //        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
                //        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                //        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
                //        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
                //        lcl_obj_AdditionDeduction.Remarks = "";
                //        lcl_obj_AdditionDeduction.Amount = lcl_dcm_PFAmount;
                //        //lcl_dcm_TotalNightAllowance += lcl_dcm_AdditionAmount;
                //        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                //    }
                //}

                //////Save PF
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    System.UInt64 a = lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}
                //lcl_obj_DBManager.CommitTransaction();
                //int a2 = 0;
                //lcl_obj_SalaryProcessorLog.AppendLine("Total PF Eligible Employee Updated : " + lcl_i32_TotalPFEligibleUpdated.ToString());
                //using (System.IO.StreamWriter lcl_obj_Log = new System.IO.StreamWriter("SalaryProcessLog.txt", true))
                //{
                //    lcl_obj_Log.Write(lcl_obj_SalaryProcessorLog.ToString());
                //}
                //lcl_obj_DBManager.CommitTransaction();
                #endregion 
            }
            catch (System.Exception Ex)
            {
                if (lcl_obj_DBManager != null)
                {
                    lcl_obj_DBManager.RollbackTransaction();
                    lcl_obj_DBManager.Close();
                }
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                Console.WriteLine("OT Saved Successfully");
                Console.ReadLine();
            }
        }
    }
}
