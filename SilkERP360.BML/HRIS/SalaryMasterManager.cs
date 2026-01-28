using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class SalaryMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>
    {
        public SalaryMasterManager()
       {
           this.Initialize();
       }

        public System.String GetSalarySummeryHTML(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster, DAL.DBManager IP_obj_DBManager)
        {
            System.String lcl_str_SalarySummeryHTML = this.ExceptionManager.Process<System.String>(() =>
            {
                BML.HRIS.CompanyManager lcl_obj_CompanyManager = new CompanyManager();
                lcl_obj_CompanyManager.Initialize();
                CCL.BusinessEntities.HRIS.Company lcl_obj_Company = lcl_obj_CompanyManager.Get(IP_obj_SalaryMaster.CompanyCode, IP_obj_DBManager);
                System.String lcl_str_SalaryMonth = ((CCL.Enums.Month)IP_obj_SalaryMaster.SalaryMonth).ToString();
                System.String lcl_str_SalaryYear = IP_obj_SalaryMaster.SalaryYear.ToString();

                System.String lcl_str_HTMLReport = @"<style type='text/css'>

        .report_head
        {
            width:100%;
            font-size:12px;
        }
        
        .report_head tr
        {
            
        }
        
        .report_head tr td
        {
            border:1px solid #cccccc  ;
        }
        
        .report_header_label
        {
            text-align:left;
            /*border:1px solid #F8F8F8  ;*/
            font-weight:bold;
            font-family:Verdana;
            color: #ffffff;
            background-color:#66cc33;
            border:1px solid #cccccc;

        }

        .report_header_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;

        }

        
        .report_summery_label
        {
            text-align:right;
            color: #ffffff;
            background-color:#66cc33;
            font-weight:bold;
            border:1px solid #cccccc;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_grid_text
        {
            text-align:center;
             border:1px solid #cccccc  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
            font-family:Verdana;
        }
        .report_grid_header
        {
           
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#3399FF;
            color: #ffffff;
            font-weight:bold;
            font-size:14px;
            border:1px solid black;
            font-family:Verdana;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
             font-family:Verdana;
            
        }
        
    </style>";

                lcl_str_HTMLReport += System.String.Format(@"
                                                            <div style='margin:0 auto;width:70%;'>
                                                                <div id='dvBody' style=' width:70%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:70%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Human Resource Information System (H.R.I.S)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Report Title : 
                                                                            </td>
                                                                            <td class='report_header_text'  style='text-align:left;'>
                                                                                Monthly Salary-{0},{1}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               T.Employee :
                                                                            </td>
                                                                            <td class='report_header_text'  style='text-align:left;'>
                                                                            {2}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Company :
                                                                            </td>
                                                                            <td class='report_header_text'  style='text-align:left;'>
                                                                            {3}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Salary Date :
                                                                            </td>
                                                                            <td class='report_header_text'  style='text-align:left;'>
                                                                            {4}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td colspan='2' class='report_header_label'  style='text-align:center;font-size:16px;'>
                                                                                MONTHLY SALARY DETAILS
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    
                                                                    <table id='tblSalary' class='report_summery' style='width:70%; margin:0 auto;'>
                                                                        <tr style=''>    
                                                                            <td class='report_grid_header' style='width:20%; text-align:right;'>
                                                                                Gross (T) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%;text-align:right;'>
                                                                               {5}
                                                                            </td>
                                                                            <td class='report_grid_header' style='width:20%;text-align:right;'>
                                                                                P.F (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style='width:30%; text-align:right;'>
                                                                                {6}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Overtime (HR.) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:left;'>
                                                                                {7}
                                                                            </td>
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Tax (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {8}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_grid_header' style=' text-align:right;'>
                                                                                Overtime cost :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {9}
                                                                            </td>
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Absent (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {10}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_grid_header' style=' text-align:right;'>
                                                                                Allowances (+) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {11}
                                                                            </td>
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Late (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {12}
                                                                            </td>
                                                                        </tr>
                                                                         <tr style=''>    
                                                                            <td class='report_grid_header' style=' text-align:right;'>
                                                                                Others (+) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {13}
                                                                            </td>
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Loan Inst. (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {14}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td class='report_grid_header' style=' text-align:right;'>
                                                                                
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                
                                                                            </td>
                                                                            <td class='report_grid_header' style='text-align:right;'>
                                                                                Others. (-) :
                                                                            </td>
                                                                            <td class='report_summery_text'  style=' text-align:right;'>
                                                                                {15}
                                                                            </td>
                                                                        </tr>
                                                                        <tr style=''>    
                                                                            <td colspan='2' class='report_summery_text'  style='width:50%;text-align:right;font-size:14px;'>
                                                                               <b>T.Payable :
                                                                            </td>
                                                                            <td  colspan='2'  class='report_header_label'  style='width:50%;text-align:right;font-size:14px;'>
                                                                                <b>{16}</b>
                                                                            </td>
                                                                        </tr>
                                                                      </table></div></div>", lcl_str_SalaryMonth, lcl_str_SalaryYear,
                                                                               IP_obj_SalaryMaster.SalaryList.Count.ToString(),
                                                                               lcl_obj_Company.Name,
                                                                               System.DateTime.Today.ToLongDateString(),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalGrossSalary),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionProvidentFund),
                                                                               ((int)(IP_obj_SalaryMaster._TotalOvertimeMinutes / 60)).ToString() + ":" + (IP_obj_SalaryMaster._TotalOvertimeMinutes % 60).ToString() + " Hrs.",
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionTax),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalOvertimeAmount),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionAbsent),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalAdditionAllowance),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionLate),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalAdditionOthers),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionAdvance),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalDeductionOthers),
                                                                               string.Format("{0:0.00}", IP_obj_SalaryMaster._TotalAmountPayable));
                return lcl_str_HTMLReport;
            }, "BMLExceptionPolicy");
            return lcl_str_SalarySummeryHTML;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SalaryMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SalaryMaster.GetSequence());
            lcl_ui64_SalaryMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SalaryMaster.SalaryMasterCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SalaryMaster.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

                //Save Salary
                BML.HRIS.SalaryManager lcl_obj_SalaryManager = new SalaryManager();
                lcl_obj_SalaryManager.Initialize();
                foreach (CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in IP_obj_SalaryMaster.SalaryList)
                {
                    lcl_obj_Salary.SalaryMasterCode = IP_obj_SalaryMaster.SalaryMasterCode;
                    lcl_obj_SalaryManager.Save(lcl_obj_Salary, IP_obj_DBManager);
                }

                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryMasterCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            System.UInt64 lcl_ui64_SalaryMasterCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SALARY_MASTER.NEXTVAL AS ID FROM DUAL", IP_obj_SalaryMaster.GetSequence());
            lcl_ui64_SalaryMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_SalaryMaster.SalaryMasterCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SalaryMaster.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryMasterCode;
        }

        public CCL.BusinessEntities.HRIS.SalaryMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_MASTER WHERE SALARY_MASTER_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
                lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpSalaryMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public bool ProcessIncomeTax(UInt64 empCode, int month, UInt16 year, object dbObj)
        {
            return this.ExceptionManager.Process<bool>(() =>
            {
                var db = (SilkERP360.DAL.DBManager)dbObj;
                if (db.ConnectionState != System.Data.ConnectionState.Open) db.Open();

                object addDedCode = db.ExecuteScalar(
                    $"SELECT ADD_DED_CODE FROM SALARY_ADDITION_DEDUCTION " +
                    $"WHERE EMPLOYEE_CODE={empCode} AND EFFECTIVE_MONTH={month} AND EFFECTIVE_YEAR={year} " +
                    $"AND ADD_OR_DED=2 AND ADD_DED_TYPE=3");

                object taxObj = db.ExecuteScalar(
                    $"SELECT TAX_AMOUNT FROM EMPLOYEE_TAX " +
                    $"WHERE EMPLOYEE_CODE={empCode} AND IS_TAX_DEDUCTION=1 AND TAX_AMOUNT>0");

                //  No tax → delete if exists
                if (taxObj == null || taxObj == DBNull.Value)
                {
                    if (addDedCode != null)
                        db.ExecuteNonQuery($"DELETE FROM SALARY_ADDITION_DEDUCTION WHERE ADD_DED_CODE={addDedCode}");
                    return true;
                }

                decimal taxAmount = Convert.ToDecimal(taxObj);

                //  Update
                if (addDedCode != null)
                {
                    db.ExecuteNonQuery(
                        $"UPDATE SALARY_ADDITION_DEDUCTION SET AMOUNT={taxAmount}, IS_PROCESSED=0, ENTRY_DATE=SYSDATE " +
                        $"WHERE ADD_DED_CODE={addDedCode}");
                }
                //  Insert
                else
                {
                    UInt64 newCode = Convert.ToUInt64(
                        db.ExecuteScalar("SELECT NVL(MAX(ADD_DED_CODE),1200000000) FROM SALARY_ADDITION_DEDUCTION")) + 1;

                    db.ExecuteNonQuery(
                        $"INSERT INTO SALARY_ADDITION_DEDUCTION " +
                        $"(ADD_DED_CODE,EMPLOYEE_CODE,ADD_OR_DED,ADD_DED_TYPE,AMOUNT,ADD_DED_DATE," +
                        $"EFFECTIVE_MONTH,EFFECTIVE_YEAR,IS_PROCESSED,STATUS,ENTRY_EMPLOYEE_CODE,ENTRY_DATE) " +
                        $"VALUES({newCode},{empCode},2,3,{taxAmount},SYSDATE,{month},{year},0,1,{empCode},SYSDATE)");
                }

                return true;
            }, "BMLExceptionPolicy");
        }




        public CCL.BusinessEntities.HRIS.SalaryMaster Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_MASTER WHERE SALARY_MASTER_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
                    lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                    lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                    lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                    lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                    lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSalaryMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public CCL.BusinessEntities.HRIS.SalaryMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster();
                lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                lcl_obj_dr.Close();

                //Get Salary List
                BML.HRIS.SalaryManager lcl_obj_SalaryManager = new SalaryManager();
                lcl_obj_SalaryManager.Initialize();
                IP_str_SqlQuery = System.String.Format("SELECT * FROM SALARY SAL JOIN EMPLOYEE EMP ON EMP.EMPLOYEE_CODE = SAL.EMPLOYEE_CODE JOIN DEPARTMENT DEPT ON DEPT.DEPARTMENT_CODE = EMP.DEPARTMENT_CODE JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE WHERE SALARY_MASTER_CODE = {0} ORDER BY DEPT.RANK,DESIG.RANK ASC", lcl_obj_TmpSalaryMaster.SalaryMasterCode);
                lcl_obj_TmpSalaryMaster.SalaryList = lcl_obj_SalaryManager.GetList(IP_str_SqlQuery, IP_obj_DBManager);

                foreach (CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_obj_TmpSalaryMaster.SalaryList)
                {
                    lcl_obj_TmpSalaryMaster._TotalGrossSalary += lcl_obj_Salary.Gross;

                    lcl_obj_TmpSalaryMaster._TotalAdditionAllowance += lcl_obj_Salary.AdditionAllowance;
                    lcl_obj_TmpSalaryMaster._TotalNightAllowance += lcl_obj_Salary.AdditionNightAllowance;
                    lcl_obj_TmpSalaryMaster._TotalAdditionOthers += (lcl_obj_Salary.AdditionArrear + lcl_obj_Salary.AdditionBonus + lcl_obj_Salary.AdditionIncentive + lcl_obj_Salary.AdditionOthers + lcl_obj_Salary.AdditionPhoneBill);

                    lcl_obj_TmpSalaryMaster._TotalOvertimeMinutes += (ulong)lcl_obj_Salary.OverTimeMinutes;
                    lcl_obj_TmpSalaryMaster._TotalOvertimeAmount += lcl_obj_Salary.OverTimeAmount;

                    lcl_obj_TmpSalaryMaster._TotalDeductionAbsent += lcl_obj_Salary.DeductionAbsent;
                    lcl_obj_TmpSalaryMaster._TotalDeductionAdvance += lcl_obj_Salary.DeductionAdvance;
                    lcl_obj_TmpSalaryMaster._TotalDeductionLate += lcl_obj_Salary.DeductionLate;
                    lcl_obj_TmpSalaryMaster._TotalDeductionOthers += (lcl_obj_Salary.DeductionOthers + lcl_obj_Salary.DeductionPenalty + lcl_obj_Salary.DeductionUnpaidLeave);
                    lcl_obj_TmpSalaryMaster._TotalDeductionProvidentFund += lcl_obj_Salary.DeductionProvidentFund;
                    lcl_obj_TmpSalaryMaster._TotalDeductionTax += lcl_obj_Salary.DeductionIncomeTax;

                    lcl_obj_TmpSalaryMaster._TotalAmountPayable += lcl_obj_Salary.GrandTotal;
                }

                return lcl_obj_TmpSalaryMaster;
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public CCL.BusinessEntities.HRIS.SalaryMaster Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = null;
            lcl_obj_SalaryMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster();
                    lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                    lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                    lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                    lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                    lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSalaryMaster;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryMaster;
        }

        public List<CCL.BusinessEntities.HRIS.SalaryMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster> lcl_objlist_SalaryMasterList = null;
            lcl_objlist_SalaryMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster> lcl_objlist_TmpSalaryMasterList = new
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSalaryMasterList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
                    lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                    lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                    lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                    lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                    lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                    lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                    lcl_objlist_TmpSalaryMasterList.Add(lcl_obj_TmpSalaryMaster);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSalaryMasterList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SalaryMasterList;
        }

        public List<CCL.BusinessEntities.HRIS.SalaryMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster> lcl_objlist_SalaryMasterList = null;
            lcl_objlist_SalaryMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster> lcl_objlist_TmpSalaryMasterList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.SalaryMaster>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSalaryMasterList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_TmpSalaryMaster = new CCL.BusinessEntities.HRIS.SalaryMaster();
                        lcl_obj_TmpSalaryMaster.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.SalaryMonth = System.UInt32.Parse(lcl_obj_dr["SALARY_MONTH"].ToString());
                        lcl_obj_TmpSalaryMaster.SalaryYear = System.UInt32.Parse(lcl_obj_dr["SALARY_YEAR"].ToString());
                        lcl_obj_TmpSalaryMaster.TotalEmployee = System.UInt32.Parse(lcl_obj_dr["TOTAL_EMPLOYEE"].ToString());
                        lcl_obj_TmpSalaryMaster.IsManagementApproved = System.UInt32.Parse(lcl_obj_dr["IS_MANAGEMENT_APPROVED"].ToString());
                        lcl_obj_TmpSalaryMaster.ManagementEmployeeCode = System.UInt64.Parse(lcl_obj_dr["MANAGEMENT_EMP_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.PreparationEmployeeCode = System.UInt64.Parse(lcl_obj_dr["PREPARATION_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.Signatory1EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY1_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.Signatory2EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY2_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.Signatory3EmployeeCode = System.UInt64.Parse(lcl_obj_dr["SIGNATORY3_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSalaryMaster.ProcessDate = System.DateTime.Parse(lcl_obj_dr["PROCESS_DATE"].ToString());
                        lcl_obj_TmpSalaryMaster.ApprovalPin = lcl_obj_dr["APPROVAL_PIN"].ToString();
                        lcl_objlist_TmpSalaryMasterList.Add(lcl_obj_TmpSalaryMaster);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSalaryMasterList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SalaryMasterList;
        }
    }
}
