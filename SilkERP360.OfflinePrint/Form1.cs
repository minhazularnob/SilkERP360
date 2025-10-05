using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace SilkERP360.OfflinePrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance> GetOvertimeAllowanceList(System.UInt64 IP_ui64_CompanyCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            /*************************************************************************************************************************/
            /*************************************************************************************************************************/
            //SEPARATE OVERTIME CALCULATON
            SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
            System.String lcl_str_SqlQuery = System.String.Empty;

            System.DateTime lcl_dt_OvertimeCycleFrom = System.DateTime.Parse("26/August/2015");
            System.DateTime lcl_dt_OvertimeCycleUpto = System.DateTime.Parse("25/September/2015");

            SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
            lcl_obj_AttendanceManager.Initialize();

            SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new BML.Services.HRIS.SalaryServices();
            lcl_obj_SalaryService.Initialize();
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
            lcl_obj_SalaryMaster = lcl_obj_SalaryService.GetSalaryMaster(IP_ui64_CompanyCode, CCL.Enums.Month.September, 2015);

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance> lcl_objLst_OvertimeNightAllowance = new List<CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance>();

            foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_obj_SalaryMaster.SalaryList)
            {
                System.UInt32 lcl_ui32_TotalOvertimeMinutes = 0;
                System.Double lcl_dbl_TotalOvertimeAmount = 0;
                System.Double lcl_dbl_TotalNightAllowance = 0;

                System.UInt64 lcl_ui64_EmployeeCode = lcl_obj_Salary.EmployeeCode;
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_ui64_EmployeeCode, IP_obj_DBManager);
                //if (lcl_obj_EmployeeProfile.IsOTEligible == CCL.Enums.YesNo.Yes)
                //{
                    CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance lcl_obj_EmployeeOvertimeNightAllowance = new CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance();
                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                    lcl_obj_EmployeeOvertimeNightAllowance._EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                    lcl_obj_EmployeeOvertimeNightAllowance._Department = lcl_obj_EmployeeProfile.Department.Name;
                    lcl_obj_EmployeeOvertimeNightAllowance._Designation = lcl_obj_EmployeeProfile.Designation.Name;
                    lcl_obj_EmployeeOvertimeNightAllowance._Basic = lcl_obj_EmployeeProfile.SalaryStructure.Basic;
                    lcl_obj_EmployeeOvertimeNightAllowance._Medical = lcl_obj_EmployeeProfile.SalaryStructure.Medical;
                    lcl_obj_EmployeeOvertimeNightAllowance._Conveyence = lcl_obj_EmployeeProfile.SalaryStructure.Conveyence;
                    lcl_obj_EmployeeOvertimeNightAllowance._HouseRent = lcl_obj_EmployeeProfile.SalaryStructure.HouseRent;
                    lcl_obj_EmployeeOvertimeNightAllowance._Gross = lcl_obj_EmployeeProfile.SalaryStructure.Gross;
                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeRate = lcl_obj_EmployeeProfile.SalaryStructure.Basic / 104;
                    //Calculate Overtime
                    for (System.DateTime lcl_obj_OvertimeDate = lcl_dt_OvertimeCycleFrom; lcl_obj_OvertimeDate <= lcl_dt_OvertimeCycleUpto; lcl_obj_OvertimeDate = lcl_obj_OvertimeDate.AddDays(1))
                    {

                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_Salary.EmployeeCode, lcl_obj_OvertimeDate.ToString("dd/M/yyyy"));
                        CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);
                        if (lcl_obj_Attendance == null)
                        {
                            //Employee Didn't Join
                        }
                        else
                        {
                            lcl_dbl_TotalNightAllowance += (double)lcl_obj_Attendance.NightAllowance;
                            lcl_ui32_TotalOvertimeMinutes += (uint)lcl_obj_Attendance.OvertimeTotal;
                            /******************************************************************************************************************************/
                            //MUST BE UNCOMMENTED LATER
                            //lcl_obj_Salary.AdditionNightAllowance += lcl_obj_Attendance.NightAllowance;
                            /******************************************************************************************************************************/
                        }
                    }
                    lcl_obj_EmployeeOvertimeNightAllowance._BankAccountNo = lcl_obj_EmployeeProfile.BankAccountNo;
                    lcl_obj_EmployeeOvertimeNightAllowance._Tin = lcl_obj_EmployeeProfile.Tin; // TIN 28-Jan-2017, SSL
                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeMinutes = lcl_ui32_TotalOvertimeMinutes;
                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeHour = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeMinutes / 60;
                    lcl_obj_EmployeeOvertimeNightAllowance._OvertimeAmount = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeRate * (decimal)lcl_obj_EmployeeOvertimeNightAllowance._OvertimeHour;
                    lcl_obj_EmployeeOvertimeNightAllowance._NightAllowance = (decimal)lcl_dbl_TotalNightAllowance;
                    lcl_obj_EmployeeOvertimeNightAllowance._TotalPayable = lcl_obj_EmployeeOvertimeNightAllowance._OvertimeAmount + lcl_obj_EmployeeOvertimeNightAllowance._NightAllowance;
                    lcl_objLst_OvertimeNightAllowance.Add(lcl_obj_EmployeeOvertimeNightAllowance);
                    int check = 0;
            }
            return lcl_objLst_OvertimeNightAllowance;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             try
            {
                /***************************************************************************************************************************/
                //Database Connections
                SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager("Data Source=DB; User Id=silkerp; Password=silkerp");
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                /***************************************************************************************************************************/
                /****************************************************************************************************************/
                /****************************************************************************************************************/
                //Employee Profile Generate
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//Silkways Tours & Travels
                //System.UInt64 lcl_ui64_CompanyCode = 110000000003;//SSL
                SilkERP360.BML.HRIS.BonusManager lcl_obj_BonusManager = new BML.HRIS.BonusManager();
                lcl_obj_BonusManager.Initialize();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT * FROM BONUS WHERE BONUS_MASTER_CODE =5000100000000541 ORDER BY BONUS_CODE ASC");
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> lcl_objLst_BonusList = lcl_obj_BonusManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                               

                //SilkcardSalarySheet_SubTotal lcl_obj_SalarySheet_SubTotal = new SilkcardSalarySheet_SubTotal();
                Bonus lcl_rpt_Bonus = new Bonus();
                /****************************************************************************************************************/
                
                /****************************************************************************************************************/
                lcl_rpt_Bonus.Database.Tables[0].SetDataSource(lcl_objLst_BonusList);
                //lcl_obj_SalarySlip.Database.Tables[1].SetDataSource(lcl_objLst_SalarySummery);

                /****************************************************************************************************************/
                /****************************************************************************************************************/

                /*System.Collections.Generic.List<CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance> lcl_objLst_EmployeeOvertimeNightAllowance =
                    this.GetOvertimeAllowanceList(lcl_ui64_CompanyCode,lcl_obj_DBManager);
                OvertimeNightAllowance lcl_rpt_OvertimeNightAllowance = new OvertimeNightAllowance();
                lcl_rpt_OvertimeNightAllowance.Database.Tables[0].SetDataSource(lcl_objLst_EmployeeOvertimeNightAllowance);

                
                 
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Wellpac-Overtime-NAllowance-September-2015.csv"))
                {
                    int sl = 1;

                    sw.WriteLine("Sl,ID,Name,BankAccountNo,TotalAmount");
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeOvertimeNightAllowance lcl_obj_Overtime in lcl_objLst_EmployeeOvertimeNightAllowance)
                    {
                        if ((lcl_obj_Overtime._BankAccountNo.Trim() != "") && (lcl_obj_Overtime._BankAccountNo.Trim() != "-"))
                        {
                            if (lcl_obj_Overtime._TotalPayable > 0)
                            {
                                sw.WriteLine(sl.ToString() + "," + lcl_obj_Overtime._EmployeeId + "," + lcl_obj_Overtime._EmployeeName + "," + lcl_obj_Overtime._BankAccountNo + "," + lcl_obj_Overtime._TotalPayable);
                                sl++;
                            }
                        }

                    }
                    sw.Close();
                }
                 */

                //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                //if (xlApp == null) { MessageBox.Show("Excel is not properly installed!!"); return; }
                //var xlWorkBook = xlApp.Workbooks.Add("");
                //var xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); 
                //xlWorkSheet.Cells[1, 1] = "Sl";
                //xlWorkSheet.Cells[1, 2] = "ID";
                //xlWorkSheet.Cells[1, 3] = "Name";
                //xlWorkSheet.Cells[1, 4] = "Bank Account No";
                //xlWorkSheet.Cells[1, 5] = "Total Amount";

                
                
         

                //xlWorkBook.SaveAs("SCL_Bonus_Eid_ul_Fitr_2018.xls");

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"D:\LiveSilkERP360\Eid-ul-Adha-2025\Silkcard_Bonus_Eid_ul_Adha_2025.csv"))
                {
                    int sl = 1;

                    sw.WriteLine("Sl,ID,Name,BankAccountNo,TotalAmount");
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Bonus lcl_obj_Bonus in lcl_objLst_BonusList)
                    {
                        //if ((lcl_obj_Bonus.BankAccount.Trim() != "") && (lcl_obj_Bonus.BankAccount.Trim() != "-"))
                        //{
                        sw.WriteLine(sl.ToString() + "," + lcl_obj_Bonus.EmployeeId + "," + lcl_obj_Bonus.EmployeeName + "," + lcl_obj_Bonus.BankAccount + "," + lcl_obj_Bonus.BonusAmount);
                        sl++;
                        //}

                    }
                    sw.Close();
                }
                //lcl_obj_SalarySheet_SubTotal.Database.Tables[1].SetDataSource(lcl_objLst_BonusSalary);
                //lcl_obj_SalarySheet_SubTotal.Database.Tables[0].SetDataSource(lcl_objLst_SalarySummery);
                this.crystalReportViewer1.ReportSource = lcl_rpt_Bonus;
                //this.crystalReportViewer1.ReportSource = lcl_rpt_OvertimeNightAllowance;
                
            }
            catch (System.Exception Ex)
            {
                int a = 0;
            }
        }
    }
}
 
