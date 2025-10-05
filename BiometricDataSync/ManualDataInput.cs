using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class ManualDataInput
    {
        /// <summary>
        /// 1. Neutralise all AutoOT for peons
        /// 2. Given only manual ot
        /// 3. Recalibrate Salary Table
        /// </summary>
        public void DeductAutoOvertimeAndAdjustFromSalary()
        {
            try
            {
                //Database Connections
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp_dev; Password=silkerp_dev");
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                

                //List<string> emp_ids = new List<string>();
                //emp_ids.Add("");
                //emp_ids.Add("");
                //emp_ids.Add("");
                //emp_ids.Add("");
                //emp_ids.Add("");
                //emp_ids.Add("");


                //string emp_id = "OFC1003356";
                //int manual_ot_hour = 150;
                //int manual_ot_min = manual_ot_hour * 60;

                //string emp_id = "OFC1203654";
                //int manual_ot_hour = 150;
                //int manual_ot_min = manual_ot_hour * 60;

                //string emp_id = "OFC1205704";
                //int manual_ot_hour = 146;
                //int manual_ot_min = manual_ot_hour * 60;

                //string emp_id = "OFC1110546";
                //int manual_ot_hour = 69;
                //int manual_ot_min = manual_ot_hour * 60;

                //string emp_id = "OFC1205702";
                //int manual_ot_hour = 131;
                //int manual_ot_min = manual_ot_hour * 60;

                string emp_id = "OFC1007770-1";
                int manual_ot_hour = 150;
                int manual_ot_min = manual_ot_hour * 60;
                

                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                lcl_obj_EmployeeProfileManager.Initialize();
                SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new SilkERP360.BML.Services.HRIS.SalaryServices();
                lcl_obj_SalaryService.Initialize();
                //foreach (string id in emp_ids)
                //{

                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(emp_id, lcl_obj_DBManager);
                decimal PER_HOUR_SALARY = lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104;
                decimal OT_AMOUNT = System.Math.Round(( manual_ot_hour * PER_HOUR_SALARY ),2);
                string update_salary1 = System.String.Format("UPDATE SALARY SET OVERTIME_MINUTES = {0}, OVERTIME_AMOUNT = {1} WHERE EMPLOYEE_CODE = {2}", manual_ot_min, OT_AMOUNT, lcl_obj_EmployeeProfile.EmployeeCode);
                lcl_obj_DBManager.ExecuteScalar(update_salary1);
                string update_salary2 = System.String.Format("UPDATE SALARY SET GRAND_TOTAL = ((GROSS + OVERTIME_AMOUNT + A_ARREAR + A_ALLOWANCE + A_OTHERS + A_NIGHT_ALLOWANCE) - (D_LATE + D_ABSENT + D_OTHERS + D_PROVIDENT_FUND)) WHERE EMPLOYEE_CODE = {0}", lcl_obj_EmployeeProfile.EmployeeCode);
                lcl_obj_DBManager.ExecuteScalar(update_salary2);
                lcl_obj_DBManager.CommitTransaction();
                Console.WriteLine("sUCCESS!");
                Console.ReadLine();
                //}
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        /// <summary>
        /// FOR JANUARY'2015 ONLY
        /// </summary>
        public void AdjustMonthlyAllowance()
        {
            SilkERP360.CCL.Enums.Month SALARY_MONTH = SilkERP360.CCL.Enums.Month.January;
            //System.DateTime lcl_dt_OTStartDate = System.DateTime.Parse("26/July/2014");
            //System.DateTime lcl_dt_OTEndDate = System.DateTime.Parse("24/August/2014");
            System.UInt16 SALARY_YEAR = 2015;
            try
            {
                /***************************************************************************************************************************/
                //Database Connections
                System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.Boolean lcl_b_ProcessOTOnly = true;
                /***************************************************************************************************************************/
                //Employee Profile Generate
                System.UInt64 lcl_ui64_EntryEmployeeCode = 101000000001;//Me
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DESIG.Rank,DEPT.RANK ASC", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);

                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
                //lcl_obj_SalaryProcessorLog.AppendLine("Processing Salary : " + lcl_objLst_EmployeeProfile[0].Company.Name);
                //GET M.D'S PROFILE FOR WELLPAC SALARY

                /**************************************************************************************************************************************************************/
                //lcl_obj_DBManager.CloseReader();
                //lcl_obj_DBManager.Close();
                //lcl_obj_DBManager.Open();
                SilkERP360.BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new SilkERP360.BML.Services.HRIS.EmployeeServices();
                lcl_obj_EmployeeService.Initialize();
                decimal MONTHLY_ALLOWANCE = 0;
                List<System.String> lcl_strLst_SalaryUpdate = new List<string>();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    System.Decimal lcl_dcm_MonthlyAllowance = lcl_obj_EmployeeService.GetMonthlyAllowance(lcl_obj_EmployeeProfile.EmployeeCode, lcl_obj_DBManager);
                    if (lcl_dcm_MonthlyAllowance > 0)
                    {
                        string str_salary_update = System.String.Format("UPDATE SALARY SET A_ALLOWANCE = A_ALLOWANCE + {0} WHERE EMPLOYEE_CODE = {1}", lcl_dcm_MonthlyAllowance, lcl_obj_EmployeeProfile.EmployeeCode);
                        //lcl_obj_DBManager.ExecuteScalar(str_salary_update);
                    }
                    MONTHLY_ALLOWANCE += lcl_dcm_MonthlyAllowance;
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                int k = 0;
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.ReadLine();
            }
        }

        public void Input()
        {
            System.Text.StringBuilder lcl_obj_SalaryProcessorLog = new StringBuilder();
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objList_OvertimeAugust = null;
            System.Double lcl_dbl_TotalOTAugust = 0;

            SilkERP360.CCL.Enums.Month SALARY_MONTH = SilkERP360.CCL.Enums.Month.January;
            //System.DateTime lcl_dt_OTStartDate = System.DateTime.Parse("26/July/2014");
            //System.DateTime lcl_dt_OTEndDate = System.DateTime.Parse("24/August/2014");
            System.UInt16 SALARY_YEAR = 2015;
            try
            {
                /***************************************************************************************************************************/
                //Database Connections
                System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                System.Boolean lcl_b_ProcessOTOnly = true;
                /***************************************************************************************************************************/
                //Employee Profile Generate
                System.UInt64 lcl_ui64_EntryEmployeeCode = 101000000001;//Me
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DESIG.Rank,DEPT.RANK ASC", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);

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
                #region PF Processing
                //PF Processing
                /*System.String lcl_str_PFEligibleCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\DeductionProvidentFund_WP_JAN_15.csv";
                System.Int32 lcl_i32_TotalPFEligibleUpdated = 0;
                using (System.IO.StreamReader lcl_obj_PFSR = new System.IO.StreamReader(lcl_str_PFEligibleCSVFile))
                {
                    while (!(lcl_obj_PFSR.EndOfStream))
                    {
                        System.String lcl_str_AddLine = lcl_obj_PFSR.ReadLine();
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
                            //lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
                            lcl_obj_SalaryProcessorLog.AppendLine("PF ELIGIBILITY STATUS WAS NOT UPDATED : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("PF ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        lcl_i32_TotalPFEligibleUpdated++;
                        System.String lcl_str_Update = System.String.Format("Update Employee Set IS_PF_ELIGIBLE = 1 WHERE EMPLOYEE_ID = '{0}'", lcl_str_EmployeeID);
                        lcl_obj_DBManager.ExecuteNonQuery(lcl_str_Update);
                        
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                    }
                }
                lcl_obj_SalaryProcessorLog.AppendLine("Total PF Eligible Employee Updated : " + lcl_i32_TotalPFEligibleUpdated.ToString());
                using (System.IO.StreamWriter lcl_obj_Log = new System.IO.StreamWriter("SalaryProcessLog.txt", true))
                {
                    lcl_obj_Log.Write(lcl_obj_SalaryProcessorLog.ToString());
                }
                lcl_obj_DBManager.CommitTransaction();*/
                #endregion
                /***************************************************************************************************************************/
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance> lcl_objList_MonthlyAllowances = new List<SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance>();
                /***************************************************************************************************************************/
                #region Monthly Allowance
                /*System.String lcl_str_MonthlyAllowanceCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\MonthlyAllowanceFixedCSV.csv";

                using (System.IO.StreamReader lcl_obj_MonthlyAllowanceSR = new System.IO.StreamReader(lcl_str_MonthlyAllowanceCSVFile))
                {
                    while (!(lcl_obj_MonthlyAllowanceSR.EndOfStream))
                    {
                        System.String lcl_str_AddLine = lcl_obj_MonthlyAllowanceSR.ReadLine();
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
                            //lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Fixed Allowance ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }

                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);

                        SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance lcl_obj_MonthlyAllowance = new SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance();
                        lcl_obj_MonthlyAllowance.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        lcl_obj_MonthlyAllowance.MonthlyAllowanceType = SilkERP360.CCL.Enums.MonthlyAllowanceType.SpecialAllowance;
                        lcl_obj_MonthlyAllowance.Amount = System.Double.Parse(lcl_str_Amount);
                        lcl_obj_MonthlyAllowance.EffectiveMonthFrom = SilkERP360.CCL.Enums.Month.August;
                        lcl_obj_MonthlyAllowance.EffectiveYearFrom = 2014;
                        lcl_obj_MonthlyAllowance.EffectiveMonthUpto = SilkERP360.CCL.Enums.Month.None;
                        lcl_obj_MonthlyAllowance.EffectiveYearUpto = 0;
                        lcl_obj_MonthlyAllowance.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_MonthlyAllowance.Remarks = "";


                        lcl_objList_MonthlyAllowances.Add(lcl_obj_MonthlyAllowance);
                    }
                    lcl_obj_MonthlyAllowanceSR.Close();
                }

                SilkERP360.BML.HRIS.MonthlyAllowanceManager lcl_obj_MonthlyAllowanceManager = new SilkERP360.BML.HRIS.MonthlyAllowanceManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.MonthlyAllowance lcl_obj_MonthlyAllowance in lcl_objList_MonthlyAllowances)
                {
                    lcl_obj_MonthlyAllowanceManager.Save(lcl_obj_MonthlyAllowance, lcl_obj_DBManager);
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_SalaryProcessorLog.AppendLine("Total Employee With Fixed Employee Allowance : " + lcl_objList_MonthlyAllowances.Count.ToString());
                using (System.IO.StreamWriter lcl_obj_Log = new System.IO.StreamWriter("SalaryProcessLog.txt", true))
                {
                    lcl_obj_Log.Write(lcl_obj_SalaryProcessorLog.ToString());
                }*/
                #endregion
                /***************************************************************************************************************************/
                /***************************************************************************************************************************/
                #region Silkcard O.T
                //Silkcard O.T Entry
                System.String lcl_str_OTCSVFilePath = @"D:\LiveSilkERP360\SilkERP360\OT-February-2015.csv";
                System.Collections.Generic.List<string> lcl_objLst_OvertimeUpdateQuery = new List<string>();
                double total_ot = 0;
                using (System.IO.StreamReader lcl_obj_OvertimeSR = new System.IO.StreamReader(lcl_str_OTCSVFilePath))
                {
                    System.String lcl_str_CSVFileLine = "";
                    while (!(lcl_obj_OvertimeSR.EndOfStream))
                    {
                        lcl_str_CSVFileLine = lcl_obj_OvertimeSR.ReadLine();


                        System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014

                        System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
                        var lcl_obj_EmployeeProfileSorted =
                                                from Emp in lcl_objLst_EmployeeProfile
                                                where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                                                select Emp;

                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                        {
                            // Employee Terminated
                            System.Console.WriteLine("O.T Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }

                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeProfile.EmployeeCode.ToString());
                        System.String lcl_str_EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;

                        
                        System.String lcl_str_OTHour = lcl_str_CSVFileLineSegments[1].Trim();
                        System.Double lcl_dbl_OTHour = ((lcl_str_OTHour == "") || (lcl_str_OTHour == "-"))
                            ? 0.0 : System.Double.Parse(lcl_str_OTHour);
                        System.Double lcl_dbl_OTMinutes = System.Math.Round(lcl_dbl_OTHour * 60, 2); 
                        System.String lcl_str_Update = System.String.Format("UPDATE ATTENDANCE SET OVERTIME_MANUAL_ADJUSTMENT = {0},OVERTIME_TOTAL = OVERTIME_TOTAL + {1},REMARKS = 'MANUAL IP FOR ARREAR OT' WHERE EMPLOYEE_CODE = {2} AND ATTENDANCE_DATE = TO_DATE('26/01/2015','dd/mm/yyyy')", lcl_dbl_OTMinutes, lcl_dbl_OTMinutes, lcl_obj_EmployeeProfile.EmployeeCode);
                        lcl_objLst_OvertimeUpdateQuery.Add(lcl_str_Update);
                        lcl_dbl_TotalOTAugust += lcl_dbl_OTMinutes;
                    }
                    lcl_obj_OvertimeSR.Close();
                    //SilkERP360.BML.HRIS.OvertimeManager lcl_obj_OvertimeManager = new SilkERP360.BML.HRIS.OvertimeManager();
                    foreach (System.String lcl_str_Update in lcl_objLst_OvertimeUpdateQuery)
                    {
                        //lcl_obj_DBManager.ExecuteScalar(lcl_str_Update);
                        
                    }
                    //lcl_obj_DBManager.CommitTransaction();
                    int h = 0;
                }
                #endregion
                /**********************************************************************************************************************************/

                /**********************************************************************************************************************************/

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                /***************************************************************************************************************************/
                #region Addition Allowance
                //Silkcard Other Allowance Entry


                /*foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
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
                    System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_obj_AllowanceReader["AMOUNT"].ToString());
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                    lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                    lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                    lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                    lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance;
                    lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                    lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.August;
                    lcl_obj_AdditionDeduction.EffectiveYear = 2014;
                    lcl_obj_AdditionDeduction.Remarks = "";
                    lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
                    lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    lcl_obj_AllowanceReader.Close();
                }
                //Save Night Allowance Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                lcl_obj_DBManager.CommitTransaction();
                int cf = 0;*/
                #endregion
                /***************************************************************************************************************************/
                /***************************************************************************************************************************/
                #region Addition Others
                //Silkcard Other Allowance Entry
                /*System.String lcl_str_AdditionOthersCSVFile = @"H:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\June\SC-Addition-OtherAllowance-June-2014-CSV.csv";

                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionOthersCSVFile))
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
                            lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Addition Others ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionOthers;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
                        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Night Allowance Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}*/
                #endregion
                /***************************************************************************************************************************/
                /***************************************************************************************************************************/
                #region Addition Night Allowance
                //Silkcard Addition Arrear
                //System.String lcl_str_AdditionNightAllowanceCSVFile = @"D:\LiveSilkERP360\SilkERP360\NightAllowance-February-2015.csv";
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
                //        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
                //        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                //        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                //        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                //        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                //        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionNightAllowance;
                //        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                //        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.February;
                //        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                //        lcl_obj_AdditionDeduction.Remarks = "";
                //        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_AdditionAmount;
                //        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                //    }
                //    lcl_obj_SalaryAdditionSR.Close();
                //}
                ////Save Night Allowance Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}
                ////lcl_obj_DBManager.CommitTransaction();
                //int a = 0;
                #endregion
                /***************************************************************************************************************************/

                //Save Night Allowance Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}*/

                /***************************************************************************************************************************/
                #region Addition Arrear
                //Silkcard Addition Arrear
                /*System.String lcl_str_AdditionArrearAdditionCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\AdditionArrear_WP_JAN_15.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionArrearAdditionCSVFile))
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
                            //lcl_strList_InvalidEmployeeIds.Add("Addition Arrear - Addition : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Addition Arrear Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionArrear;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_AdditionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Night Allowance Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                //lcl_obj_DBManager.CommitTransaction();
                int a = 9;*/
                #endregion
                /***************************************************************************************************************************/
                #region Other Deduction
                //OtherDeduction Entry
                System.String lcl_str_PFEligibleCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\DeductionTax_WP_JAN_15.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_PFEligibleCSVFile))
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
                            //lcl_strList_InvalidEmployeeIds.Add("Other Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Other Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionIncomeTax;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();
                int u = 0;
                #endregion
                /***************************************************************************************************************************/
                //#region Late Deduction
                //LateDeduction Entry
                /*System.String lcl_str_LateDeductionCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\DeductionLate_WP_JAV_15.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_LateDeductionCSVFile))
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
                            //lcl_strList_InvalidEmployeeIds.Add("Other Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Late Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionLate;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                //lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();*/
                /***************************************************************************************************************************/
                /*********************************************************************************************************************************************/
                //AbsentDeduction Entry
                /*System.String lcl_str_AbsentDeductionCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\DeductionAbsent_WP_JAN_15.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AbsentDeductionCSVFile))
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
                            //lcl_strList_InvalidEmployeeIds.Add("Absent Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Absent Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAbsent;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();*/
                /***************************************************************************************************************************/
                //ArrearDeduction Entry
                /*System.String lcl_str_ArrearDeductionCSVFile = @"H:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\Silkcard-Arrear-Deduction-April-2014.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_ArrearDeductionCSVFile))
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
                            lcl_strList_InvalidEmployeeIds.Add("Arrear Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Arrear Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionArrear;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.April;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}
                /**********************************************************************************************************************************/
                #region Deduction PF
                //Provident Fund Deduction Entry

                /*foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    if (lcl_obj_EmployeeProfile.IsPFEligible == SilkERP360.CCL.Enums.YesNo.Yes)
                    {
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Decimal lcl_dcml_DeductionAmount = ((lcl_obj_EmployeeProfile.SalaryStructure.Basic * 10) / 100);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Deduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_Deduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_Deduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_Deduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_Deduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
                        lcl_obj_Deduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_Deduction.EffectiveMonth = SALARY_MONTH;
                        lcl_obj_Deduction.EffectiveYear = SALARY_YEAR;
                        lcl_obj_Deduction.Remarks = "";
                        lcl_obj_Deduction.Amount = System.Double.Parse(lcl_dcml_DeductionAmount.ToString());
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_Deduction);
                    }
                }
                //Save Addition to Database
                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }*/
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();
                //lcl_obj_DBManager.Open();
                //Console.WriteLine("Database Updated Successfully!!!");
                #endregion
                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                #region Tax Deduction
                //Tax Deduction Entry
                /*System.String lcl_str_TaxDeductionCSVFile = @"H:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\May\SC-Deduction-Tax-May-2014.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_TaxDeductionCSVFile))
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
                            lcl_strList_InvalidEmployeeIds.Add("Tax Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Tax Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionIncomeTax;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.May;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                //{
                //    lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                //}*/
                #endregion
                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                #region Loan Deduction
                //Loan Deduction Entry
               /* System.String lcl_str_LoanDeductionCSVFile = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\Wellpac\Jan-2015\DeductionAdvance_WP_JAN_15.csv";
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_LoanDeductionCSVFile))
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
                            //lcl_strList_InvalidEmployeeIds.Add("Loan Deduction : " + lcl_str_EmployeeID);
                            System.Console.WriteLine("Loan Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
                            continue;
                        }
                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                        {
                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                        }
                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
                        {
                            continue;
                        }
                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAdvance;
                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_obj_AdditionDeduction.EffectiveYear = 2015;
                        lcl_obj_AdditionDeduction.Remarks = "";
                        lcl_obj_AdditionDeduction.Amount = (decimal)lcl_dbl_DeductionAmount;
                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
                    }
                    lcl_obj_SalaryAdditionSR.Close();
                }
                //Save Addition to Database
                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
                {
                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
                }
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();*/
                #endregion
                /**********************************************************************************************************************************/
                //Write Invalid Ids in File
                //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("InvalidIds.txt"))
                //{
                //    foreach (System.String lcl_str_Id in lcl_strList_InvalidEmployeeIds)
                //    {
                //        sw.WriteLine(lcl_str_Id);
                //    }
                //    sw.Close();
                //}
                /***************************************************************************************************************************/


                /**********************************************************************************************************************************/

                /***************************************************************************************************************************/
                //Leave Entry
                //CSV Format : <EMPLOYEEID>,<Date1;Date2;..;DateN;DateFrom-DateTo>,<Name>,<LeaveType>
                /***************************************************************************************************************************/
                /**********************************************************************************************************************************/
                //Bio-Metric System Data Upload
                //System.DateTime lcl_dt_TransactionDate = System.DateTime.Now;
                //SilkSalaryProcessor.BMSystem.BMSManager lcl_obj_BMSManager = new SilkSalaryProcessor.BMSystem.BMSManager();
                //System.Collections.Generic.List<SilkSalaryProcessor.BMSystem.BMSTransaction> lcl_obj_BMSTransactions = lcl_obj_BMSManager.GetBMSTransactionsByDate(lcl_dt_TransactionDate);
                //lcl_obj_BMSManager.LogBMTransactionInDatabase(lcl_obj_BMSTransactions);
                //Console.WriteLine("Database Updated");
                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                //ACS System Data Upload
                //SilkSalaryProcessor.ProximitySystem.ProximityTransactionManager lcl_obj_ProximityTransactionManager = new ProximitySystem.ProximityTransactionManager();
                //System.Collections.Generic.List<SilkSalaryProcessor.ProximitySystem.ProximityTransaction> lcl_objList_ProximityTransactions = lcl_obj_ProximityTransactionManager.GetProximityTransactionsFromDBF(@"H:\SilkERP_Offline_Salary_Gen\DATA\Tk20140326.DBF");
                /**********************************************************************************************************************************/

                /**********************************************************************************************************************************/
                //Salary Processor
                /*SilkERP360.CCL.Enums.Month lcl_enm_SalaryMonth = SilkERP360.CCL.Enums.Month.April;
                System.UInt16 lcl_ui16_SalaryYear = 2014;
                System.DateTime lcl_dt_SalaryCycleStartFrom = System.DateTime.Parse("26/May/2014");
                System.DateTime lcl_dt_SalaryCycleEndTo = System.DateTime.Parse("25/June/2014");
                SilkSalaryProcessor.SalaryProcess.SalaryProcessor lcl_obj_SalaryProcessor = new SalaryProcess.SalaryProcessor(lcl_objLst_EmployeeProfile);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_objLst_Salary = lcl_obj_SalaryProcessor.GenerateSalary(lcl_enm_SalaryMonth, lcl_ui16_SalaryYear, lcl_dt_SalaryCycleStartFrom, lcl_dt_SalaryCycleEndTo);
                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                //Write Salary To File
                /*using (System.IO.StreamWriter lcl_obj_SalarySW = new System.IO.StreamWriter("Wellpac-April-2014-Salary.csv"))
                {
                    System.String lcl_str_Salary = System.String.Empty;
                    System.String lcl_str_SalaryFormat = "{0},{1},{2},{3},{4:f2},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31}"; 
                    lcl_obj_SalarySW.WriteLine("Employee ID, Name, Designation, Department, Basic, House Rent, Medical, Entertainment,Conveyence, Phone Bill,Others, Gross,O.T Hour, O.T Amount,Add-Arrear,Add-Bonus,Add-PhoneBill,Add-Incentive,Add-Allowance,Add-N.Allowance,Add-Others,Add-Total,Ded-Absent,Ded-Late,Ded-Advance,Ded-I.Tax,Ded-UnpaidLeave,Ded-Penalty,Ded-Others,Ded-P.Fund,Ded-Total,Grand Total");
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_objLst_Salary)
                    {
                        lcl_str_Salary = System.String.Format(lcl_str_SalaryFormat,
                                                              lcl_obj_Salary.EmployeeID, lcl_obj_Salary.EmployeeName, lcl_obj_Salary.Designation, lcl_obj_Salary.Department,
                                                              lcl_obj_Salary.Basic, lcl_obj_Salary.HouseRent, lcl_obj_Salary.Medical, lcl_obj_Salary.Entertainment,
                                                              lcl_obj_Salary.Conveyence, lcl_obj_Salary.PhoneBill, lcl_obj_Salary.Others, lcl_obj_Salary.Gross,
                                                              lcl_obj_Salary.OvertimeHours, lcl_obj_Salary.OvertimeAmount, lcl_obj_Salary.AdditionArear, lcl_obj_Salary.AdditionBonus,
                                                              lcl_obj_Salary.AdditionPhoneBill, lcl_obj_Salary.AdditionIncentive, lcl_obj_Salary.AdditionAllowance, lcl_obj_Salary.AdditionNightAllowance, 
                                                              lcl_obj_Salary.AdditionOthers,lcl_obj_Salary.AdditionTotal,
                                                              lcl_obj_Salary.DeductionAbsent, lcl_obj_Salary.DeductionLate, lcl_obj_Salary.DeductionAdvance, lcl_obj_Salary.DeductionIncomeTax,
                                                              lcl_obj_Salary.DeductionUnpaidLeave, lcl_obj_Salary.DeductionPenalty, lcl_obj_Salary.DeductionOthers,lcl_obj_Salary.DeductionProvidentFund,
                                                              lcl_obj_Salary.DeductionTotal,lcl_obj_Salary.GrandTotal);
                        lcl_obj_SalarySW.WriteLine(lcl_str_Salary);
                    }
                    lcl_obj_SalarySW.Close();
                }
                /**********************************************************************************************************************************/

                //SilkSalaryProcessor.PDFWritter lcl_obj_PDFWritter = new PDFWritter("file.pdf");
                //lcl_obj_PDFWritter.CreatePDF();

                Console.WriteLine("Data Operation Completed Successfully!!!");
                Console.Read();
                //lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
