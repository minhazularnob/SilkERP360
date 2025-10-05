using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.OfflineDataProcessing
{
    class Program
    {
        //        public System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance> GetOvertimeAllowanceList(System.UInt64 IP_ui64_CompanyCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        //        {
        //            /*************************************************************************************************************************/
        //            /*************************************************************************************************************************/
        //            //SEPARATE OVERTIME CALCULATON
        //            SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
        //            System.String lcl_str_SqlQuery = System.String.Empty;

        //            System.DateTime lcl_dt_OvertimeCycleFrom = System.DateTime.Parse("26/August/2015");
        //            System.DateTime lcl_dt_OvertimeCycleUpto = System.DateTime.Parse("25/September/2015");

        //            SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
        //            lcl_obj_AttendanceManager.Initialize();

        //            SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new BML.Services.HRIS.SalaryServices();
        //            lcl_obj_SalaryService.Initialize();
        //            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
        //            lcl_obj_SalaryMaster = lcl_obj_SalaryService.GetSalaryMaster(IP_ui64_CompanyCode, CCL.Enums.Month.September, 2015);

        //            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance> lcl_objLst_OvertimeNightAllowance = new List<CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance>();

        //            foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_obj_SalaryMaster.SalaryList)
        //            {
        //                System.Double lcl_dbl_TotalOvertimeMinutes = 0;
        //                System.UInt32 lcl_ui32_TotalOvertimeAmount = 0;
        //                System.Double lcl_dbl_TotalNightAllowance = 0;

        //                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_Salary.EmployeeCode;
        //                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_ui64_EmployeeCode, IP_obj_DBManager);
        //                if (lcl_obj_EmployeeProfile.IsOTEligible == CCL.Enums.YesNo.Yes)
        //                {
        //                    CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance lcl_obj_EmployeeOvertimeNightAllowance = new CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance();
        //                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Department = lcl_obj_EmployeeProfile.Department.Name;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Designation = lcl_obj_EmployeeProfile.Designation.Name;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeRate = lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104;
        //                    //Calculate Overtime
        //                    for (System.DateTime lcl_obj_OvertimeDate = lcl_dt_OvertimeCycleFrom; lcl_obj_OvertimeDate <= lcl_dt_OvertimeCycleUpto; lcl_obj_OvertimeDate = lcl_obj_OvertimeDate.AddDays(1))
        //                    {

        //                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_Salary.EmployeeCode, lcl_obj_OvertimeDate.ToString("dd/M/yyyy"));
        //                        CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);
        //                        if (lcl_obj_Attendance == null)
        //                        {
        //                            //Employee Didn't Join
        //                        }
        //                        else
        //                        {
        //                            lcl_dbl_TotalNightAllowance += (double)lcl_obj_Attendance.NightAllowance;
        //                            lcl_dbl_TotalOvertimeMinutes += lcl_obj_Attendance.OvertimeTotal;
        //                            /******************************************************************************************************************************/
        //                            //MUST BE UNCOMMENTED LATER
        //                            //lcl_obj_Salary.AdditionNightAllowance += lcl_obj_Attendance.NightAllowance;
        //                            /******************************************************************************************************************************/
        //                        }
        //                    }
        //                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeMinutes = lcl_ui32_TotalOvertimeAmount;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeHour = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeMinutes / 60;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeAmount = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeRate * (decimal)lcl_obj_EmployeeOvertimeNightAllowance._OvertimeHour;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._NightAllowance = (decimal)lcl_dbl_TotalNightAllowance;
        //                    lcl_obj_EmployeeOvertimeNightAllowance._TotalPayable = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeAmount + lcl_obj_EmployeeOvertimeNightAllowance._NightAllowance;
        //                    lcl_objLst_OvertimeNightAllowance.Add(lcl_obj_EmployeeOvertimeNightAllowance);
        //                    int check = 0;
        //                }
        //            }

        //            return lcl_objLst_OvertimeNightAllowance;
        //        }

        //        static void Main(string[] args)
        //        {

        //            #region HRIS OPERATIONS
        //            //System.Text.StringBuilder lcl_obj_SalaryProcessorLog = new StringBuilder();

        //            //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objList_OvertimeAugust = null;
        //            //System.Double lcl_dbl_TotalOTAugust = 0;

        //            //SilkERP360.CCL.Enums.Month SALARY_MONTH = SilkERP360.CCL.Enums.Month.December;
        //            //System.DateTime lcl_dt_OTStartDate = System.DateTime.Parse("26/November/2014");
        //            //System.DateTime lcl_dt_OTEndDate = System.DateTime.Parse("25/December/2014");
        //            System.UInt16 SALARY_YEAR = 2019;
        //            try
        //            {
//                      System.String lcl_str_DBConnection = "Data Source=DB; User Id=silkerp; Password=silkerp";
//                //System.String lcl_str_DBConnection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
//                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(lcl_str_DBConnection);
//                lcl_obj_DBManager.Initialize();
//                lcl_obj_DBManager.Open();
//        //                /***************************************************************************************************************************/
//        //                //Employee Profile Generate
//                        System.UInt64 lcl_ui64_EntryEmployeeCode = 101000000001;//Me
                       System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
//        //                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
//        //                //System.UInt64 lcl_ui64_CompanyCode = 110000000003;//Silkways Solutions Ltd
//        //                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
//        //                //System.String lcl_str_DataFileRootPath = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\STTL\December\";
//        //                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
//                        System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.NIGHT_BILL_ELIGIBLE,EMP.EMPLOYEE_NAME,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
//                                                                                DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,EMP.IS_DELETED
//                                                                                FROM SilkERP.EMPLOYEE EMP 
//                                                                                JOIN SilkERP.COMPANY COMP
//                                                                                ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
//                                                                                JOIN SilkERP.DEPARTMENT DEPT
//                                                                                ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
//                                                                                JOIN SilkERP.DESIGNATION DESIG
//                                                                                ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
//                                                                                JOIN SilkERP.EMPLOYEE_SALARY_STRUCTURE EMP_SAL
//                                                                                ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
//                                                                                JOIN SilkERP.EMPLOYEE_IMAGE IMG
//                                                                                ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
//                                                                                WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DEPT.RANK,DESIG.Rank ASC", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
//                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);


//        //                //System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM 
//        //                //lcl_obj_DBManager.Close();
//        //                /*************************************************************************************************************************/
//        //                /*************************************************************************************************************************/

//        //                int k = 0;
//        //                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
//        //                //lcl_obj_SalaryProcessorLog.AppendLine("************************************************************************************************");
//        //                //lcl_obj_SalaryProcessorLog.AppendLine("Processing Salary : " + lcl_objLst_EmployeeProfile[0].Company.Name);
//        //                //GET M.D'S PROFILE FOR WELLPAC SALARY

        //                /**************************************************************************************************************************************************************/
        //                //lcl_obj_DBManager.CloseReader();
        //                //lcl_obj_DBManager.Close();
        //                //lcl_obj_DBManager.Open();
        //                //SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile 
        //                /***************************************************************************************************************************/

        //                /***************************************************************************************************************************/
        //                /***************************************************************************************************************************/
        //                #region Increment
        //                //Silkcard O.T Entry
        //                /*System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_IncrementList = new List<CCL.BusinessEntities.HRIS.Increment>();
        //                System.Collections.Generic.List<System.String> lcl_strLst_SalaryUpdateSQL = new List<string>();
        //                System.String lcl_str_IncrementCSVFilePath = @"D:\LiveSilkERP360\SilkERP360\IncSSL.csv";
        //                List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_Increment = new List<SilkERP360.CCL.BusinessEntities.HRIS.Increment>();

        //                using (System.IO.StreamReader lcl_obj_IncrementSR = new System.IO.StreamReader(lcl_str_IncrementCSVFilePath))
        //                {
        //                    System.String lcl_str_CSVFileLine = "";
        //                    while (!(lcl_obj_IncrementSR.EndOfStream))
        //                    {
        //                        lcl_str_CSVFileLine = lcl_obj_IncrementSR.ReadLine();


        //                        System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014

        //                        System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                                from Emp in lcl_objLst_EmployeeProfile
        //                                                where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                                select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            // Employee Terminated
        //                            System.Console.WriteLine("Increment Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }

        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeProfile.EmployeeCode.ToString());
        //                        System.String lcl_str_EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
        //                        System.Decimal lcl_dcm_IncrementGross = System.Decimal.Parse(lcl_str_CSVFileLineSegments[1].ToString());

        //                        System.Decimal lcl_dcm_Basic = (lcl_dcm_IncrementGross * 60) / 100;
        //                        System.Decimal lcl_dcm_HouseRent = (lcl_dcm_IncrementGross * 30) / 100;
        //                        System.Decimal lcl_dcm_Medical = (lcl_dcm_IncrementGross * 5) / 100;
        //                        System.Decimal lcl_dcm_Conveyence = (lcl_dcm_IncrementGross * 5) / 100;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = new CCL.BusinessEntities.HRIS.Increment();
        //                        lcl_obj_Increment.IncrementMasterCode = 504000000003;
        //                        lcl_obj_Increment.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_Increment.PreviousGross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
        //                        lcl_obj_Increment.IncBasic = lcl_dcm_Basic;
        //                        lcl_obj_Increment.IncHouseRent = lcl_dcm_HouseRent;
        //                        lcl_obj_Increment.IncMedical = lcl_dcm_Medical;
        //                        lcl_obj_Increment.IncConveyence = lcl_dcm_Conveyence;
        //                        lcl_obj_Increment.IncGross = lcl_dcm_IncrementGross;

        //                        lcl_obj_Increment.IncrementDate = System.DateTime.Today;
        //                        lcl_obj_Increment.EntryDate = System.DateTime.Now;
        //                        lcl_obj_Increment.EntryEmployeeCode = 101000000001;

        //                        lcl_objLst_IncrementList.Add(lcl_obj_Increment);

        //                        System.String lcl_str_SQLUpdate = System.String.Format("UPDATE EMPLOYEE_SALARY_STRUCTURE SET BASIC = {0},HOUSE_RENT = {1},MEDICAL = {2}, CONVEYENCE = {3}, GROSS = {4} WHERE EMPLOYEE_CODE = {5}",
        //                                                                                lcl_dcm_Basic, lcl_dcm_HouseRent, lcl_dcm_Medical, lcl_dcm_Conveyence, lcl_dcm_IncrementGross, lcl_obj_EmployeeProfile.EmployeeCode);
        //                        lcl_strLst_SalaryUpdateSQL.Add(lcl_str_SQLUpdate);

        //                    }
        //                    lcl_obj_IncrementSR.Close();

        //                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
        //                    lcl_obj_IncrementManager.Initialize();

        //                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment in lcl_objLst_IncrementList)
        //                    {
        //                        //lcl_obj_IncrementManager.Save(lcl_obj_Increment, lcl_obj_DBManager);
        //                    }

        //                    foreach (System.String lcl_str_UpdateSalary in lcl_strLst_SalaryUpdateSQL)
        //                    {
        //                        //lcl_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateSalary);
        //                    }

        //                    //lcl_obj_DBManager.CommitTransaction();
        //                    //lcl_obj_DBManager.Close();
        //                    Console.WriteLine("DATA INSERTED SUCCESSFULLY!");
        //                    int a = 0;
        //                }*/
        //                #endregion
        //                /**********************************************************************************************************************************/

                        #region Silkcard Bonus
        //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> lcl_objLst_BonusList = new List<CCL.BusinessEntities.HRIS.Bonus>();

        //System.String lcl_str_NonBonusCSVFilePath = @"D:\LiveSilkERP360\Bonus_Eid_ul_Fitr_2018\Silkcard\Entitled for eid bonus - Eid UL Fitr  2018.csv";

        //List<string> lcl_objLst_NoBonusEmployeeList = new List<string>();
        //using (System.IO.StreamReader lcl_obj_BonusSR = new System.IO.StreamReader(lcl_str_NonBonusCSVFilePath))
        //{
        //    System.String lcl_str_CSVFileLine = "";
        //    while (!(lcl_obj_BonusSR.EndOfStream))
        //    {
        //        lcl_str_CSVFileLine = lcl_obj_BonusSR.ReadLine();


        //        System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014

        //        System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
        //        lcl_objLst_NoBonusEmployeeList.Add(lcl_str_EmployeeID);
        //    }
        //    lcl_obj_BonusSR.Close();
        //}


        //foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //{
        //    //Check if Employee Exist in No Bonus List
        //    var lcl_str_EmpId = from EmpId in lcl_objLst_NoBonusEmployeeList
        //                      where EmpId.Equals(lcl_obj_EmployeeProfile.EmployeeID)
        //                      select EmpId;
        //    if (lcl_objLst_NoBonusEmployeeList.Contains(lcl_obj_EmployeeProfile.EmployeeID))
        //    {
        //        //employee Exist in No Bonus List
        //        //lcl_objLst_NoBonusEmployeeList.Remove(lcl_obj_EmployeeProfile.EmployeeID);
        //        Console.WriteLine("No Bonus : " + lcl_obj_EmployeeProfile.EmployeeName);
        //        continue;
        //    }
        //    //Employee Eligible For Bonus
        //    SilkERP360.CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus = new CCL.BusinessEntities.HRIS.Bonus();
        //    lcl_obj_Bonus.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //    lcl_obj_Bonus.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
        //    lcl_obj_Bonus.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
        //    lcl_obj_Bonus.Designation = lcl_obj_EmployeeProfile.Designation.Name;
        //    lcl_obj_Bonus.BankAccount = lcl_obj_EmployeeProfile.BankAccountNo;
        //    lcl_obj_Bonus.JoiningDate = lcl_obj_EmployeeProfile.JoiningDate;
        //    lcl_obj_Bonus.Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
        //    lcl_obj_Bonus.HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
        //    lcl_obj_Bonus.Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
        //    lcl_obj_Bonus.Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
        //    lcl_obj_Bonus.Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
        //    lcl_obj_Bonus.BonusAmount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;

        //    lcl_objLst_BonusList.Add(lcl_obj_Bonus);
        //}

        //SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
        //lcl_obj_BonusMaster.CompanyCode = lcl_ui64_CompanyCode;
        //lcl_obj_BonusMaster.Occasion = CCL.Enums.BonusOccasion.EidUlFitr;
        //lcl_obj_BonusMaster.Month = CCL.Enums.Month.May;
        //lcl_obj_BonusMaster.Year = 2018;
        //lcl_obj_BonusMaster.BonusDate = System.DateTime.Today;
        //lcl_obj_BonusMaster.EntryDate = System.DateTime.Today;
        //lcl_obj_BonusMaster.EntryEmployeeCode = 101000000003;
        //lcl_obj_BonusMaster.BonusList = lcl_objLst_BonusList;

        //BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new BML.HRIS.BonusMasterManager();
        //lcl_obj_BonusMasterManager.Initialize();
        ////lcl_obj_BonusMasterManager.Save(lcl_obj_BonusMaster, lcl_obj_DBManager);

        ////lcl_obj_DBManager.CommitTransaction();
        ////lcl_obj_DBManager.Close();

        //Console.WriteLine("BONUS DATA INSERTED SUCCESSFULLY!");
        //int a = 0;*/

                       #endregion

                       // #region Bonus
                       //     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> lcl_objLst_BonusList = new List<CCL.BusinessEntities.HRIS.Bonus>();

                       //     System.String lcl_str_BonusCSVFilePath = @"C:\Documents and Settings\amitav.SILKAPP\Desktop\STTL.csv";

                       //     List<string> lcl_objLst_BonusEmployeeList = new List<string>();
                       //     using (System.IO.StreamReader lcl_obj_BonusSR = new System.IO.StreamReader(lcl_str_BonusCSVFilePath))
                       //     {
                       //         System.String lcl_str_CSVFileLine = "";
                       //         while (!(lcl_obj_BonusSR.EndOfStream))
                       //         {
                       //             lcl_str_CSVFileLine = lcl_obj_BonusSR.ReadLine();


                       //             System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014

                       //             System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
                       //             lcl_objLst_BonusEmployeeList.Add(lcl_str_EmployeeID);
                       //         }
                       //         lcl_obj_BonusSR.Close();
                       //     }


                       //     foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                       //     {
                       //         Check if Employee Exist in No Bonus List
                       //         var lcl_str_EmpId = from EmpId in lcl_objLst_BonusEmployeeList
                       //                             where EmpId.Equals(lcl_obj_EmployeeProfile.EmployeeID)
                       //                             select EmpId;
                       //         if (lcl_objLst_BonusEmployeeList.Contains(lcl_obj_EmployeeProfile.EmployeeID))
                       //         {
                       //             employee Exist in No Bonus List
                       //             lcl_objLst_NoBonusEmployeeList.Remove(lcl_obj_EmployeeProfile.EmployeeID);
                       //             SilkERP360.CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus = new CCL.BusinessEntities.HRIS.Bonus();
                       //             lcl_obj_Bonus.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                       //             lcl_obj_Bonus.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                       //             lcl_obj_Bonus.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                       //             lcl_obj_Bonus.Designation = lcl_obj_EmployeeProfile.Designation.Name;
                       //             lcl_obj_Bonus.BankAccount = lcl_obj_EmployeeProfile.BankAccountNo;
                       //             lcl_obj_Bonus.Tin = (lcl_obj_EmployeeProfile.Tin == "") ? "n/a" : lcl_obj_EmployeeProfile.Tin; // TIN 28-Jan-2017, SSL
                       //             lcl_obj_Bonus.JoiningDate = lcl_obj_EmployeeProfile.JoiningDate;
                       //             lcl_obj_Bonus.Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                       //             lcl_obj_Bonus.HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
                       //             lcl_obj_Bonus.Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
                       //             lcl_obj_Bonus.Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
                       //             lcl_obj_Bonus.Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
                       //             lcl_obj_Bonus.BonusAmount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                       //             lcl_obj_Bonus.BonusAmount = System.Decimal.Round(((lcl_obj_EmployeeProfile.SalaryStructure.Basic * 60) / 100), 2);
                       //             if (lcl_objLst_BonusEmployeeList.IndexOf(lcl_obj_EmployeeProfile.EmployeeID) == 3)
                       //             {
                       //                 lcl_obj_Bonus.BonusAmount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                       //             }
                       //             else
                       //             {
                       //                 lcl_obj_Bonus.BonusAmount = System.Decimal.Round(((lcl_obj_EmployeeProfile.SalaryStructure.Basic * 60) / 100), 2);
                       //             }
                       //             lcl_objLst_BonusList.Add(lcl_obj_Bonus);
                       //         }
                       //         else
                       //         {
                       //             Console.WriteLine("Cant Find ID : " + lcl_obj_EmployeeProfile.EmployeeID);
                       //         }
                       //     }
                       //Console.WriteLine(lcl_objLst_BonusList.Count.ToString());

                       //                        //Implant M.D Bonus While Processing Wellpac Bonus
                       //                        //SilkERP360.CCL.BusinessEntities.HRIS.Bonus BonusMD = new CCL.BusinessEntities.HRIS.Bonus();
                       //                        //BonusMD.EmployeeCode = 101000001099;
                       //                        //BonusMD.EmployeeId = "MGT0411002";
                       //                        //BonusMD.EmployeeName = "Sk. Farid Ahmed";
                       //                        //BonusMD.Designation = "Managing Director";
                       //                        //BonusMD.BankAccount = "";
                       //                        //BonusMD.JoiningDate = System.DateTime.Parse("03/11/2004");
                       //                        //BonusMD.Basic = 363000;
                       //                        //BonusMD.HouseRent = 181500;
                       //                        //BonusMD.Conveyence = 30250;
                       //                        //BonusMD.Medical = 30250;
                       //                        //BonusMD.Gross = 605000;
                       //                        //BonusMD.BonusAmount = 363000;
                       //                        //lcl_objLst_BonusList.Insert(0, BonusMD);

                       //     SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
                       //     lcl_obj_BonusMaster.CompanyCode = lcl_ui64_CompanyCode;
                       //     lcl_obj_BonusMaster.Occasion = CCL.Enums.BonusOccasion.EidUlAzha;
                       //     lcl_obj_BonusMaster.Month = CCL.Enums.Month.August;
                       //     lcl_obj_BonusMaster.Year = 2019;
                       //     lcl_obj_BonusMaster.BonusDate = System.DateTime.Today;
                       //     lcl_obj_BonusMaster.EntryDate = System.DateTime.Today;
                       //     lcl_obj_BonusMaster.EntryEmployeeCode = 101000000003;
                       //     lcl_obj_BonusMaster.BonusList = lcl_objLst_BonusList;



                       //     BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new BML.HRIS.BonusMasterManager();
                       //     lcl_obj_BonusMasterManager.Initialize();
                       //     lcl_obj_BonusMasterManager.Save(lcl_obj_BonusMaster, lcl_obj_DBManager);

                       //     lcl_obj_DBManager.CommitTransaction();
                       //     lcl_obj_DBManager.Close();

                       //     Console.WriteLine("DATA INSERTED SUCCESSFULLY!");
                       //                        //int a = 0;
                       // #endregion

//        //                #region STTL SSL Bonus
        //                /*System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> lcl_objLst_BonusList = new List<CCL.BusinessEntities.HRIS.Bonus>();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //                {
        //                    //Check if Employee Exist in No Bonus List

        //                    //employee Exist in No Bonus List
        //                    //lcl_objLst_NoBonusEmployeeList.Remove(lcl_obj_EmployeeProfile.EmployeeID);
        //                    SilkERP360.CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus = new CCL.BusinessEntities.HRIS.Bonus();
        //                    lcl_obj_Bonus.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                    lcl_obj_Bonus.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
        //                    lcl_obj_Bonus.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
        //                    lcl_obj_Bonus.Designation = lcl_obj_EmployeeProfile.Designation.Name;
        //                    lcl_obj_Bonus.BankAccount = lcl_obj_EmployeeProfile.BankAccountNo;
        //                    lcl_obj_Bonus.JoiningDate = lcl_obj_EmployeeProfile.JoiningDate;
        //                    lcl_obj_Bonus.Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
        //                    lcl_obj_Bonus.HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
        //                    lcl_obj_Bonus.Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
        //                    lcl_obj_Bonus.Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
        //                    lcl_obj_Bonus.Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
        //                    lcl_obj_Bonus.BonusAmount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
        //                    lcl_objLst_BonusList.Add(lcl_obj_Bonus);

        //                }

        //                SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
        //                lcl_obj_BonusMaster.CompanyCode = lcl_ui64_CompanyCode;
        //                lcl_obj_BonusMaster.Occasion = CCL.Enums.BonusOccasion.EidUlAzha;
        //                lcl_obj_BonusMaster.Month = CCL.Enums.Month.September;
        //                lcl_obj_BonusMaster.Year = 2015;
        //                lcl_obj_BonusMaster.BonusDate = System.DateTime.Today;
        //                lcl_obj_BonusMaster.EntryDate = System.DateTime.Today;
        //                lcl_obj_BonusMaster.EntryEmployeeCode = 101000000001;
        //                lcl_obj_BonusMaster.BonusList = lcl_objLst_BonusList;

        //                BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new BML.HRIS.BonusMasterManager();
        //                lcl_obj_BonusMasterManager.Initialize();
        //                //lcl_obj_BonusMasterManager.Save(lcl_obj_BonusMaster, lcl_obj_DBManager);

        //                //lcl_obj_DBManager.CommitTransaction();
        //                lcl_obj_DBManager.Close();

        //                Console.WriteLine("DATA INSERTED SUCCESSFULLY!");*/
        //                #endregion
        //                /**********************************************************************************************************************************/

        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                /***************************************************************************************************************************/
        //                #region Addition Allowance
        //                //Silkcard Other Allowance Entry


        //                /*foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //                {
        //                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM MONTHLY_ALLOWANCE WHERE EMPLOYEE_CODE = {0} AND STATUS = {1}", lcl_obj_EmployeeProfile.EmployeeCode, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
        //                    System.Data.OracleClient.OracleDataReader lcl_obj_AllowanceReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
        //                    if (!(lcl_obj_AllowanceReader.HasRows))
        //                    {
        //                        lcl_obj_AllowanceReader.Close();
        //                        continue;
        //                    }
        //                    lcl_obj_AllowanceReader.Read();

        //                    System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                    System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_obj_AllowanceReader["AMOUNT"].ToString());
        //                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                    lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                    lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                    lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                    lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance;
        //                    lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                    lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                    lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                    lcl_obj_AdditionDeduction.Remarks = "";
        //                    lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                    lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    lcl_obj_AllowanceReader.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 0;*/
        //                #endregion
        //                /***************************************************************************************************************************/
        //                /***************************************************************************************************************************/
        //                #region Addition Others
        //                //Silkcard Other Allowance Entry
        //                /*System.String lcl_str_AdditionOthersCSVFile = @"H:\SilkERP_Offline_Salary_Gen\DataFiles\Silkcard\June\SC-Addition-OtherAllowance-June-2014-CSV.csv";

        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionOthersCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Addition Others ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionOthers;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                //{
        //                //    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                //}*/
        //                #endregion

        //                #region Addition Allowance
        //                //Silkcard Other Allowance Entry
        //                /*System.String lcl_str_AdditionOthersCSVFile = lcl_str_DataFileRootPath + "STTL-Addition-OtherAllowance-Dec-2014.csv";

        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionOthersCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Other Allowance - Addition : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Addition Others ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionOthers;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 0;*/
        //                #endregion
        //                /***************************************************************************************************************************/
        //                /***************************************************************************************************************************/
        //                #region Addition Night Allowance
        //                //Silkcard Addition Arrear
        //                /*System.String lcl_str_AdditionNightAllowanceCSVFile = lcl_str_DataFileRootPath + "Silkcard-Night-Allowance-Dec-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionNightAllowanceCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Night Allowance - Addition : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Night Allowance Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionNightAllowance;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SALARY_MONTH;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = SALARY_YEAR;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 0;*/
        //                #endregion
        //                #region Addition Special Allowance
        //                //Silkcard Addition Arrear
        //                /*System.String lcl_str_AdditionNightAllowanceCSVFile = lcl_str_DataFileRootPath + "Wellpac-Addition-SpecialAllowance-October-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionNightAllowanceCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Night Allowance - Addition : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Night Allowance Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.October;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 0;*/
        //                #endregion
        //                /***************************************************************************************************************************/

        //                //Save Night Allowance Addition to Database
        //                //SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                //{
        //                //    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                //}*/

        //                /***************************************************************************************************************************/
        //                #region Addition Arrear
        //                //Silkcard Addition Arrear
        //                /*System.String lcl_str_AdditionArrearAdditionCSVFile = lcl_str_DataFileRootPath + "Wellpac-Addition-Arrear-October-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AdditionArrearAdditionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Addition Arrear - Addition : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Addition Arrear Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_AdditionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Addition;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionArrear;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth =  SilkERP360.CCL.Enums.Month.October ;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_AdditionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Night Allowance Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion
        //                /***************************************************************************************************************************/
        //                #region Other Deduction
        //                //OtherDeduction Entry
        //                /*System.String lcl_str_OtherDeductionCSVFile = lcl_str_DataFileRootPath + "WP-Deduction-Arrear-Dec-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_OtherDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Other Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Other Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionOthers;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int aa1 = 0;*/
        //                #endregion
        //                /***************************************************************************************************************************/
        //                #region Late Deduction
        //                //LateDeduction Entry
        //                /*System.String lcl_str_LateDeductionCSVFile = lcl_str_DataFileRootPath + "WP-Deduction-Late-Dec-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_LateDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Other Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Late Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionLate;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion
        //                /***************************************************************************************************************************/
        //                /*********************************************************************************************************************************************/
        //                //AbsentDeduction Entry
        //                #region Deduction Absent
        //                /*System.String lcl_str_AbsentDeductionCSVFile = lcl_str_DataFileRootPath + "WP-Deduction-Absent-Dec-2014_1.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_AbsentDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Absent Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Absent Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAbsent;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion
        //                /***************************************************************************************************************************/

        //                /**********************************************************************************************************************************/
        //                #region Deduction PF From File
        //                /*System.String lcl_str_PFDeductionCSVFile = @"C:\Documents and Settings\amitav.SILKAPP\Desktop\WPL Salary deduction for the month of August 2018 at WPL.csv";
        //                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                System.Collections.Generic.List<String> lcl_strLst_SalaryDeductionQuery = new List<string>();
        //                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //                //{
        //                //    if (lcl_obj_EmployeeProfile.IsOTEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                //    {
        //                //        System.Decimal lcl_dcm_CurrentGross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
        //                //        System.Decimal lcl_dcm_NewGross = lcl_dcm_CurrentGross + ((lcl_dcm_CurrentGross * 10) / 100);
        //                //        lcl_obj_EmployeeProfile.SalaryStructure.Gross = lcl_dcm_NewGross;
        //                //        lcl_obj_EmployeeProfile.SalaryStructure.Basic = (lcl_dcm_NewGross * 60) / 100;
        //                //        lcl_obj_EmployeeProfile.SalaryStructure.HouseRent = (lcl_dcm_NewGross * 30) / 100;
        //                //        lcl_obj_EmployeeProfile.SalaryStructure.Medical = (lcl_dcm_NewGross * 5) / 100;
        //                //        lcl_obj_EmployeeProfile.SalaryStructure.Conveyence = (lcl_dcm_NewGross * 5) / 100;
        //                //    }
        //                //}
        //                System.Double lcl_dbl_TotalPF = 0;
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_PFDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Other Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("PF Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        //System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        //if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        //{
        //                        //    continue;
        //                        //}

        //                        //DEDUCT 10% OF BASIC AS PF
        //                        System.Decimal lcl_dcm_DeductionAmount = System.Decimal.Parse(lcl_arr_AddSegments[1].Trim());

        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        //System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionOthers;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.August;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2018;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dcm_DeductionAmount;
        //                        //lcl_dbl_TotalPF += lcl_obj_AdditionDeduction.Amount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                        System.String lcl_str_SalaryDeductionQuery = System.String.Format("UPDATE SALARY SET D_OTHERS = D_OTHERS - {0}, GRAND_TOTAL = GRAND_TOTAL - {1} WHERE SALARY_MASTER_CODE = 5002000000002801 AND EMPLOYEE_CODE = {2}", lcl_dcm_DeductionAmount, lcl_dcm_DeductionAmount, lcl_ui64_EmployeeCode);
        //                        lcl_strLst_SalaryDeductionQuery.Add(lcl_str_SalaryDeductionQuery);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                foreach (System.String lcl_str_UpdateQuery in lcl_strLst_SalaryDeductionQuery)
        //                {
        //                    //lcl_obj_DBManager.ExecuteNonQuery(lcl_str_UpdateQuery);
        //                }
        //                lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion

        //                #region Deduction PF
        //                //Provident Fund Deduction Entry
        //                /*System.Double lcl_dbl_TotalPFDeduction = 0;
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
        //                {
        //                    if (lcl_obj_EmployeeProfile.IsPFEligible == SilkERP360.CCL.Enums.YesNo.Yes)
        //                    {
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Decimal lcl_dcml_DeductionAmount = ((lcl_obj_EmployeeProfile.SalaryStructure.Basic * 10) / 100);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Deduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_Deduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_Deduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_Deduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_Deduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund;
        //                        lcl_obj_Deduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_Deduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.November;
        //                        lcl_obj_Deduction.EffectiveYear = 2014;
        //                        lcl_obj_Deduction.Remarks = "";
        //                        lcl_obj_Deduction.Amount = System.Decimal.Parse(lcl_dcml_DeductionAmount.ToString());
        //                        lcl_dbl_TotalPFDeduction += lcl_obj_Deduction.Amount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_Deduction);
        //                    }
        //                }
        //                //Save Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                //lcl_obj_DBManager.Close();
        //                //lcl_obj_DBManager.Open();
        //                int a = 0;
        //                Console.WriteLine("Database Updated Successfully!!!");*/
        //                #endregion
        //                /**********************************************************************************************************************************/
        //                /**********************************************************************************************************************************/
        //                #region Tax Deduction
        //                //Tax Deduction Entry
        //                /*System.String lcl_str_TaxDeductionCSVFile = lcl_str_DataFileRootPath + "STTL-Deduction-IncomeTax-Dec-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_TaxDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Tax Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Tax Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionIncomeTax;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                //Save Addition to Database
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion
        //                /**********************************************************************************************************************************/
        //                /**********************************************************************************************************************************/
        //                #region Loan Deduction
        //                //Loan Deduction Entry
        //                /*System.String lcl_str_LoanDeductionCSVFile = lcl_str_DataFileRootPath + "STTL-Deduction-Installment-Dec-2014.csv";
        //                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objList_SalaryAdditionDeduction = new 
        //                //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
        //                using (System.IO.StreamReader lcl_obj_SalaryAdditionSR = new System.IO.StreamReader(lcl_str_LoanDeductionCSVFile))
        //                {
        //                    while (!(lcl_obj_SalaryAdditionSR.EndOfStream))
        //                    {
        //                        System.String lcl_str_AddLine = lcl_obj_SalaryAdditionSR.ReadLine();
        //                        System.String[] lcl_arr_AddSegments = lcl_str_AddLine.Split(',');
        //                        System.String lcl_str_EmployeeID = lcl_arr_AddSegments[0].Trim();
        //                        var lcl_obj_EmployeeProfileSorted =
        //                                               from Emp in lcl_objLst_EmployeeProfile
        //                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
        //                                               select Emp;

        //                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

        //                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
        //                        {
        //                            //Employee Terminated
        //                            //lcl_strList_InvalidEmployeeIds.Add("Loan Deduction : " + lcl_str_EmployeeID);
        //                            System.Console.WriteLine("Loan Deduction Employee ID Not Found : " + lcl_str_EmployeeID);
        //                            continue;
        //                        }
        //                        foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
        //                        {
        //                            lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
        //                        }
        //                        System.String lcl_str_Amount = lcl_arr_AddSegments[1].ToString().Trim();
        //                        if ((lcl_str_Amount.Trim() == "-") || (lcl_str_Amount.Trim() == ""))
        //                        {
        //                            continue;
        //                        }
        //                        System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
        //                        System.Double lcl_dbl_DeductionAmount = System.Double.Parse(lcl_str_Amount);
        //                        SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_AdditionDeduction = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
        //                        lcl_obj_AdditionDeduction.EmployeeCode = lcl_ui64_EmployeeCode;
        //                        lcl_obj_AdditionDeduction.EntryEmployeeCode = lcl_ui64_EntryEmployeeCode;
        //                        lcl_obj_AdditionDeduction.AdditionOrDeduction = SilkERP360.CCL.Enums.AdditionOrDeduction.Deduction;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionType = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAdvance;
        //                        lcl_obj_AdditionDeduction.AdditionDeductionDate = System.DateTime.Today;
        //                        lcl_obj_AdditionDeduction.EffectiveMonth = SilkERP360.CCL.Enums.Month.December;
        //                        lcl_obj_AdditionDeduction.EffectiveYear = 2014;
        //                        lcl_obj_AdditionDeduction.Remarks = "";
        //                        lcl_obj_AdditionDeduction.Amount = lcl_dbl_DeductionAmount;
        //                        lcl_objList_SalaryAdditionDeduction.Add(lcl_obj_AdditionDeduction);
        //                    }
        //                    lcl_obj_SalaryAdditionSR.Close();
        //                }
        //                SilkERP360.BML.HRIS.SalaryAdditionDeductionManager lcl_obj_AdditionDeductionManager = new SilkERP360.BML.HRIS.SalaryAdditionDeductionManager();
        //                foreach (SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_Addition in lcl_objList_SalaryAdditionDeduction)
        //                {
        //                    //lcl_obj_AdditionDeductionManager.Save(lcl_obj_Addition, lcl_obj_DBManager);
        //                }
        //                //lcl_obj_DBManager.CommitTransaction();
        //                int a = 9;*/
        //                #endregion
        //                /**********************************************************************************************************************************/
        //                //Write Invalid Ids in File
        //                //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("InvalidIds.txt"))
        //                //{
        //                //    foreach (System.String lcl_str_Id in lcl_strList_InvalidEmployeeIds)
        //                //    {
        //                //        sw.WriteLine(lcl_str_Id);
        //                //    }
        //                //    sw.Close();
        //                //}
        //                /***************************************************************************************************************************/


        //                /**********************************************************************************************************************************/

        //                /***************************************************************************************************************************/
        //                //Leave Entry
        //                //CSV Format : <EMPLOYEEID>,<Date1;Date2;..;DateN;DateFrom-DateTo>,<Name>,<LeaveType>
        //                /***************************************************************************************************************************/
        //                /**********************************************************************************************************************************/
        //                //Bio-Metric System Data Upload
        //                //System.DateTime lcl_dt_TransactionDate = System.DateTime.Now;
        //                //SilkSalaryProcessor.BMSystem.BMSManager lcl_obj_BMSManager = new SilkSalaryProcessor.BMSystem.BMSManager();
        //                //System.Collections.Generic.List<SilkSalaryProcessor.BMSystem.BMSTransaction> lcl_obj_BMSTransactions = lcl_obj_BMSManager.GetBMSTransactionsByDate(lcl_dt_TransactionDate);
        //                //lcl_obj_BMSManager.LogBMTransactionInDatabase(lcl_obj_BMSTransactions);
        //                //Console.WriteLine("Database Updated");
        //                /**********************************************************************************************************************************/
        //                /**********************************************************************************************************************************/
        //                //ACS System Data Upload
        //                //SilkSalaryProcessor.ProximitySystem.ProximityTransactionManager lcl_obj_ProximityTransactionManager = new ProximitySystem.ProximityTransactionManager();
        //                //System.Collections.Generic.List<SilkSalaryProcessor.ProximitySystem.ProximityTransaction> lcl_objList_ProximityTransactions = lcl_obj_ProximityTransactionManager.GetProximityTransactionsFromDBF(@"H:\SilkERP_Offline_Salary_Gen\DATA\Tk20140326.DBF");
        //                /**********************************************************************************************************************************/

        //                /**********************************************************************************************************************************/
        //                //Salary Processor
        //                /*SilkERP360.CCL.Enums.Month lcl_enm_SalaryMonth = SilkERP360.CCL.Enums.Month.April;
        //                System.UInt16 lcl_ui16_SalaryYear = 2014;
        //                System.DateTime lcl_dt_SalaryCycleStartFrom = System.DateTime.Parse("26/May/2014");
        //                System.DateTime lcl_dt_SalaryCycleEndTo = System.DateTime.Parse("25/June/2014");
        //                SilkSalaryProcessor.SalaryProcess.SalaryProcessor lcl_obj_SalaryProcessor = new SalaryProcess.SalaryProcessor(lcl_objLst_EmployeeProfile);
        //                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_objLst_Salary = lcl_obj_SalaryProcessor.GenerateSalary(lcl_enm_SalaryMonth, lcl_ui16_SalaryYear, lcl_dt_SalaryCycleStartFrom, lcl_dt_SalaryCycleEndTo);
        //                /**********************************************************************************************************************************/
        //                /**********************************************************************************************************************************/
        //                //Write Salary To File
        //                /*using (System.IO.StreamWriter lcl_obj_SalarySW = new System.IO.StreamWriter("Wellpac-April-2014-Salary.csv"))
        //                {
        //                    System.String lcl_str_Salary = System.String.Empty;
        //                    System.String lcl_str_SalaryFormat = "{0},{1},{2},{3},{4:f2},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31}"; 
        //                    lcl_obj_SalarySW.WriteLine("Employee ID, Name, Designation, Department, Basic, House Rent, Medical, Entertainment,Conveyence, Phone Bill,Others, Gross,O.T Hour, O.T Amount,Add-Arrear,Add-Bonus,Add-PhoneBill,Add-Incentive,Add-Allowance,Add-N.Allowance,Add-Others,Add-Total,Ded-Absent,Ded-Late,Ded-Advance,Ded-I.Tax,Ded-UnpaidLeave,Ded-Penalty,Ded-Others,Ded-P.Fund,Ded-Total,Grand Total");
        //                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_objLst_Salary)
        //                    {
        //                        lcl_str_Salary = System.String.Format(lcl_str_SalaryFormat,
        //                                                              lcl_obj_Salary.EmployeeID, lcl_obj_Salary.EmployeeName, lcl_obj_Salary.Designation, lcl_obj_Salary.Department,
        //                                                              lcl_obj_Salary.Basic, lcl_obj_Salary.HouseRent, lcl_obj_Salary.Medical, lcl_obj_Salary.Entertainment,
        //                                                              lcl_obj_Salary.Conveyence, lcl_obj_Salary.PhoneBill, lcl_obj_Salary.Others, lcl_obj_Salary.Gross,
        //                                                              lcl_obj_Salary.OvertimeHours, lcl_obj_Salary.OvertimeAmount, lcl_obj_Salary.AdditionArear, lcl_obj_Salary.AdditionBonus,
        //                                                              lcl_obj_Salary.AdditionPhoneBill, lcl_obj_Salary.AdditionIncentive, lcl_obj_Salary.AdditionAllowance, lcl_obj_Salary.AdditionNightAllowance, 
        //                                                              lcl_obj_Salary.AdditionOthers,lcl_obj_Salary.AdditionTotal,
        //                                                              lcl_obj_Salary.DeductionAbsent, lcl_obj_Salary.DeductionLate, lcl_obj_Salary.DeductionAdvance, lcl_obj_Salary.DeductionIncomeTax,
        //                                                              lcl_obj_Salary.DeductionUnpaidLeave, lcl_obj_Salary.DeductionPenalty, lcl_obj_Salary.DeductionOthers,lcl_obj_Salary.DeductionProvidentFund,
        //                                                              lcl_obj_Salary.DeductionTotal,lcl_obj_Salary.GrandTotal);
        //                        lcl_obj_SalarySW.WriteLine(lcl_str_Salary);
        //                    }
        //                    lcl_obj_SalarySW.Close();
        //                }
        //                /**********************************************************************************************************************************/

        //                //SilkSalaryProcessor.PDFWritter lcl_obj_PDFWritter = new PDFWritter("file.pdf");
        //                //lcl_obj_PDFWritter.CreatePDF();

                        //Console.WriteLine("Data Operation Completed Successfully!!!");
        //                Console.Read();
        //                //lcl_obj_DBManager.CommitTransaction();
        //                lcl_obj_DBManager.Close();
        //            }
        //            catch (System.Exception Ex)
        //            {
        //               Console.WriteLine(Ex.Message);
        //            }
        //            finally
        //            {
        //                Console.Read();
        //            }
        //            #endregion HRIS OPERATIONS

        //            #region SPM SYSTEM OPERATIONS
        //            /***************************************************************************************************************************/
        //            //Database Connections
        //            //System.String lcl_str_DBConnection = "Data Source=DB; User Id=silkerp; Password=silkerp";
        //            ////System.String lcl_str_DBConnection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
        //            //SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(lcl_str_DBConnection);
        //            //lcl_obj_DBManager.Initialize();
        //            //lcl_obj_DBManager.Open();


        //            //SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = new CCL.BusinessEntities.SPM.SpmProductMaster();
        //            //lcl_obj_SpmProductMaster.CustomerCode = 1000001;
        //            //lcl_obj_SpmProductMaster.ProductName = "9 Tk. Internet Card 5-in-1";
        //            //lcl_obj_SpmProductMaster.ProductType = CCL.Enums.SPM.SPMProductType.ScratchCard;
        //            //lcl_obj_SpmProductMaster.Description = "";
        //            //lcl_obj_SpmProductMaster.IsActive = CCL.Enums.YesNo.Yes;

        //            //SilkERP360.BML.SPM.SpmProductMasterManager lcl_obj_SpmProductMasterManager = new BML.SPM.SpmProductMasterManager();
        //            //lcl_obj_SpmProductMasterManager.Initialize();
        //            //ulong product_code = lcl_obj_SpmProductMasterManager.Save(lcl_obj_SpmProductMaster);
        //            //Console.WriteLine("Poduct Code : " + product_code.ToString());
        //            //Console.ReadLine();
        //            /***************************************************************************************************************************/

        //            #endregion SPM SYSTEM OPERATIONS
        //        }



        //        }
        static void Main(string[] args)
        {
            try
            {
                #region Bonus

                System.String lcl_str_DBConnection = "Data Source=DB; User Id=silkerp; Password=silkerp";
                //System.String lcl_str_DBConnection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(lcl_str_DBConnection);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                //                System.Boolean lcl_b_ProcessOTOnly = true;
                //                /***************************************************************************************************************************/
                //                //Employee Profile Generate
                System.UInt64 lcl_ui64_EntryEmployeeCode = 101000000001;//Me
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
                //                //System.UInt64 lcl_ui64_CompanyCode = 110000000003;//Silkways Solutions Ltd
                //                System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                //System.String lcl_str_DataFileRootPath = @"I:\SilkERP_Offline_Salary_Gen\DataFiles\STTL\December\";
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.NIGHT_BILL_ELIGIBLE,EMP.EMPLOYEE_NAME,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
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
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DEPT.RANK,DESIG.Rank ASC", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);


                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> lcl_objLst_BonusList = new List<CCL.BusinessEntities.HRIS.Bonus>();

                //System.String lcl_str_BonusCSVFilePath = @"C:\Users\Amitav\Desktop\EID-UL-FITR BONUS-2020\STTL.csv";
                //System.String lcl_str_BonusCSVFilePath = @"SilkCardBonus_EidulFitr_2020.csv";
                System.String lcl_str_BonusCSVFilePath = @"D:\LiveSilkERP360\Eid-ul-Adha-2025\Employees Silkcard Eid Ul-Adha Bonus 2025.csv";
                List<string> lcl_objLst_BonusEmployeeList = new List<string>();
                using (System.IO.StreamReader lcl_obj_BonusSR = new System.IO.StreamReader(lcl_str_BonusCSVFilePath))
                {
                    System.String lcl_str_CSVFileLine = "";
                    while (!(lcl_obj_BonusSR.EndOfStream))
                    {
                        lcl_str_CSVFileLine = lcl_obj_BonusSR.ReadLine();


                        System.String[] lcl_str_CSVFileLineSegments = lcl_str_CSVFileLine.Split(',');//each segment is a days OT; Index 0=EmployeeID || Index 1 To Index = 26 : OT For 26/03/2014 To 25/04/2014

                        System.String lcl_str_EmployeeID = lcl_str_CSVFileLineSegments[0].Trim();
                        lcl_objLst_BonusEmployeeList.Add(lcl_str_EmployeeID);
                    }
                    lcl_obj_BonusSR.Close();
                }


                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                {
                    //Check if Employee Exist in No Bonus List
                    var lcl_str_EmpId = from EmpId in lcl_objLst_BonusEmployeeList
                                        where EmpId.Equals(lcl_obj_EmployeeProfile.EmployeeID)
                                        select EmpId;
                    if (lcl_objLst_BonusEmployeeList.Contains(lcl_obj_EmployeeProfile.EmployeeID))
                    {
                        //employee Exist in No Bonus List
                        //lcl_objLst_NoBonusEmployeeList.Remove(lcl_obj_EmployeeProfile.EmployeeID);
                        SilkERP360.CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus = new CCL.BusinessEntities.HRIS.Bonus();
                        lcl_obj_Bonus.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        lcl_obj_Bonus.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                        lcl_obj_Bonus.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                        lcl_obj_Bonus.Designation = lcl_obj_EmployeeProfile.Designation.Name;
                        lcl_obj_Bonus.BankAccount = lcl_obj_EmployeeProfile.BankAccountNo;
                        lcl_obj_Bonus.Tin = (lcl_obj_EmployeeProfile.Tin == "") ? "n/a" : lcl_obj_EmployeeProfile.Tin; // TIN 28-Jan-2017, SSL
                        lcl_obj_Bonus.JoiningDate = lcl_obj_EmployeeProfile.JoiningDate;
                        lcl_obj_Bonus.Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                        lcl_obj_Bonus.HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
                        lcl_obj_Bonus.Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
                        lcl_obj_Bonus.Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
                        lcl_obj_Bonus.Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
                        lcl_obj_Bonus.BonusAmount = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                        lcl_objLst_BonusList.Add(lcl_obj_Bonus);
                    }
                }

               
                Console.WriteLine("TOTAL BONUS : " + lcl_objLst_BonusList.Count);
                //Implant M.D Bonus While Processing Wellpac Bonus
                /* SilkERP360.CCL.BusinessEntities.HRIS.Bonus BonusMD = new CCL.BusinessEntities.HRIS.Bonus();
                 BonusMD.EmployeeCode = 101000001099;
                 BonusMD.EmployeeId = "MGT0411002";
                 BonusMD.EmployeeName = "Sk. Farid Ahmed";
                 BonusMD.Designation = "Managing Director";
                 BonusMD.BankAccount = "";
                 BonusMD.JoiningDate = System.DateTime.Parse("03/11/2004");
                 BonusMD.Basic = 363000;
                 BonusMD.HouseRent = 181500;
                 BonusMD.Conveyence = 30250;
                 BonusMD.Medical = 30250;
                 BonusMD.Gross = 605000;
                 BonusMD.BonusAmount = 363000;
                 lcl_objLst_BonusList.Insert(0, BonusMD);*/

                SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = new CCL.BusinessEntities.HRIS.BonusMaster();
                lcl_obj_BonusMaster.CompanyCode = lcl_ui64_CompanyCode;
                lcl_obj_BonusMaster.Occasion = CCL.Enums.BonusOccasion.EidUlAzha;
                lcl_obj_BonusMaster.Month = CCL.Enums.Month.June;
                lcl_obj_BonusMaster.Year = 2025;
                lcl_obj_BonusMaster.BonusDate = System.DateTime.Today;
                lcl_obj_BonusMaster.EntryDate = System.DateTime.Today;
                lcl_obj_BonusMaster.EntryEmployeeCode = 101000000001;
                lcl_obj_BonusMaster.BonusList = lcl_objLst_BonusList;



                BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new BML.HRIS.BonusMasterManager();
                //lcl_obj_BonusMasterManager.Initialize();
                //lcl_obj_BonusMasterManager.Save(lcl_obj_BonusMaster, lcl_obj_DBManager);

                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();

                Console.WriteLine("DATA INSERTED SUCCESSFULLY!");
                Console.ReadLine();
                //int a = 0;
                #endregion

                Console.ReadLine();
            }
            catch(System.Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.ReadLine();
            }
        }

    }
}