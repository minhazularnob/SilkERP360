using Newtonsoft.Json.Linq;
using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.CCL.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;



namespace SilkERP360.BML.HRIS
{
    public class StaffLoanManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        CommonManager _commonManager = new CommonManager();
        bool sendSms = GlobalFlags.SendSms;
        bool sendMail = GlobalFlags.SendMail;

        public StaffLoanManager()
        {
            this.Initialize();

        }

        public UInt64 SaveStaffLoan(StaffLoan loan)
        {
            return this.ExceptionManager.Process<UInt64>(() =>
            {
                using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        dbManager.InternalResource.Open();

                    
                        UInt64 newLoanCode = Convert.ToUInt64(dbManager.InternalResource.ExecuteScalar("SELECT NVL(MAX(LOAN_CODE), 1300000000) FROM STAFF_LOAN")) + 1;

                    string insertLoanSql = $@"INSERT INTO STAFF_LOAN(LOAN_CODE, EMPLOYEE_CODE, LOAN_AMOUNT, NO_OF_INSTALLMENT, LOAN_DISBURSE_DATE,INSTALLMENT_START_MONTH, INSTALLMENT_START_YEAR, CURRENT_DUE_AMOUNT, ENTRY_DATE, STATUS, LOAN_TYPE)
                                           VALUES({newLoanCode}, {loan.EmployeeCode}, {loan.LoanAmount}, {loan.NoOfInstallments},SYSDATE,{loan.InstallmentStartMonth}, {loan.InstallmentStartYear},{loan.LoanAmount}, SYSDATE, {(int)LoanStatus.Running}, {(int)loan.LoanType})";

                    dbManager.InternalResource.ExecuteScalar(insertLoanSql);

                    foreach (var schedule in loan.Installments)
                        {
                            UInt64 newScheduleCode = Convert.ToUInt64(dbManager.InternalResource.ExecuteScalar("SELECT NVL(MAX(LOAN_SCHEDULE_CODE), 1500000000) FROM STAFF_LOAN_SCHEDULE")) + 1;

                            dbManager.InternalResource.ExecuteScalar($@"INSERT INTO STAFF_LOAN_SCHEDULE (LOAN_SCHEDULE_CODE, LOAN_CODE, MONTH, YEAR, SCHEDULED_AMOUNT, PAID_AMOUNT, STATUS) 
                           VALUES ({newScheduleCode}, {newLoanCode}, {schedule.Month}, {schedule.Year}, {schedule.ScheduledAmount}, 0, {(int)LoanScheduleStatus.Unpaid})");
                        }

                        dbManager.InternalResource.CommitTransaction();
                        return newLoanCode;
                }
            }, "BMLExceptionPolicy");
        }

        public List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> GetEmployeeLoanList(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> employeeLoanList = new List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan>();

                        if (!lcl_obj_dr.HasRows)
                        {
                            return employeeLoanList;
                        }

                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan();

                            // Safe parsing
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["Employee_code"]);
                            item.EmployeeId = Convert.ToString(lcl_obj_dr["Employee_id"]);
                            item.EmployeeName = Convert.ToString(lcl_obj_dr["employee_name"]);
                            item.LoanCode = Convert.ToUInt64(lcl_obj_dr["Loan_code"]);
                            item.LoanAmount = Convert.ToDecimal(lcl_obj_dr["loan_amount"]);
                            item.NoOfInstallments = Convert.ToInt16(lcl_obj_dr["no_of_installment"]);
                            item.LoanDisburseDate = Convert.ToString(lcl_obj_dr["Loan_disburse_date"]);
                            item.InstallmentStartMonth = Convert.ToInt16(lcl_obj_dr["installment_start_month"]);
                            item.InstallmentStartYear = Convert.ToInt16(lcl_obj_dr["installment_start_year"]);
                            item.CurrentDueAmount = Convert.ToDecimal(lcl_obj_dr["current_due_amount"]);
                            item.EntryDate = Convert.ToString(lcl_obj_dr["entry_date"]);
                            item.TotalPaidAmount = Convert.ToDecimal(lcl_obj_dr["total_paid_amount"]);
                            item.Status = Convert.ToInt16(lcl_obj_dr["status"]);
                            item.LoanType = Convert.ToInt16(lcl_obj_dr["loan_type"]);


                            employeeLoanList.Add(item);
                        }

                        return employeeLoanList;
                    }
                }
            }, "BMLExceptionPolicy");
        }
    }
}