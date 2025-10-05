using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class SalaryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Salary>
    {
        public SalaryManager()
       {
           this.Initialize();
       }

        public ulong Save(CCL.BusinessEntities.HRIS.Salary IP_obj_Salary, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SalaryCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Salary.GetSequence());
            lcl_ui64_SalaryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Salary.SalaryCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_Salary.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Salary IP_obj_Salary)
        {
            System.UInt64 lcl_ui64_SalaryCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SALARY.NEXTVAL AS ID FROM DUAL", IP_obj_Salary.GetSequence());
            lcl_ui64_SalaryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_Salary.SalaryCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_Salary.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryCode;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY WHERE SALARY_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new CCL.BusinessEntities.HRIS.Salary();
                lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                lcl_obj_dr.Close();
                return lcl_obj_TmpSalary;
            }, "BMLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY WHERE SALARY_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new CCL.BusinessEntities.HRIS.Salary();
                    lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                    lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                    lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                    lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                    lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                    lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                    lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                    lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                    lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                    lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                    lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                    lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                    lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                    lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                    lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                    lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                    lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                    lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSalary;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new SilkERP360.CCL.BusinessEntities.HRIS.Salary();
                lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                lcl_obj_dr.Close();

                BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new Services.HRIS.EmployeeServices();
                lcl_obj_EmployeeService.Initialize();
                CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = lcl_obj_EmployeeService.GetMiniEmplpoyeeProfile(lcl_obj_TmpSalary.EmployeeCode, lcl_obj_DBManager);
                lcl_obj_TmpSalary._EmployeeID = lcl_obj_EmployeeProfileMini.EmployeeID;
                lcl_obj_TmpSalary._EmployeeName = lcl_obj_EmployeeProfileMini.EmployeeName;
                lcl_obj_TmpSalary._Department = lcl_obj_EmployeeProfileMini.DepartmentName;
                lcl_obj_TmpSalary._Designation = lcl_obj_EmployeeProfileMini.Designation;

                return lcl_obj_TmpSalary;
            }, "BMLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public CCL.BusinessEntities.HRIS.Salary Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary = null;
            lcl_obj_Salary = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Salary>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new SilkERP360.CCL.BusinessEntities.HRIS.Salary();
                    lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                    lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                    lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                    lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                    lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                    lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                    lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                    lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                    lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                    lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                    lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                    lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                    lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                    lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                    lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                    lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                    lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                    lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSalary;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Salary;
        }

        public List<CCL.BusinessEntities.HRIS.Salary> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary> lcl_objlist_SalaryList = null;
            lcl_objlist_SalaryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary> lcl_objlist_TmpSalaryList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSalaryList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new CCL.BusinessEntities.HRIS.Salary();
                    lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                    lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                    lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                    lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                    lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                    lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                    lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                    lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                    lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                    lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                    lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                    lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                    lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                    lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                    lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                    lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                    lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                    lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                    lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                    lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                    lcl_objlist_TmpSalaryList.Add(lcl_obj_TmpSalary);
                }
                lcl_obj_dr.Close();
                BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new Services.HRIS.EmployeeServices();
                lcl_obj_EmployeeService.Initialize();
                foreach (CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_objlist_TmpSalaryList)
                {
                    CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = lcl_obj_EmployeeService.GetMiniEmplpoyeeProfile(lcl_obj_Salary.EmployeeCode, lcl_obj_DBManager);
                    lcl_obj_Salary._EmployeeID = lcl_obj_EmployeeProfileMini.EmployeeID;
                    lcl_obj_Salary._EmployeeName = lcl_obj_EmployeeProfileMini.EmployeeName;
                    lcl_obj_Salary._Department = lcl_obj_EmployeeProfileMini.DepartmentName;
                    lcl_obj_Salary._Designation = lcl_obj_EmployeeProfileMini.Designation;
                }

                return lcl_objlist_TmpSalaryList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SalaryList;
        }

        public List<CCL.BusinessEntities.HRIS.Salary> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary> lcl_objlist_SalaryList = null;
            lcl_objlist_SalaryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary> lcl_objlist_TmpSalaryList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Salary>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpSalaryList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.Salary lcl_obj_TmpSalary = new CCL.BusinessEntities.HRIS.Salary();
                        lcl_obj_TmpSalary.SalaryCode = System.UInt64.Parse(lcl_obj_dr["SALARY_CODE"].ToString());
                        lcl_obj_TmpSalary.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpSalary.SalaryMasterCode = System.UInt64.Parse(lcl_obj_dr["SALARY_MASTER_CODE"].ToString());
                        lcl_obj_TmpSalary.AdditionArrear = System.Decimal.Parse(lcl_obj_dr["A_ARREAR"].ToString());
                        lcl_obj_TmpSalary.AdditionBonus = System.Decimal.Parse(lcl_obj_dr["A_BONUS"].ToString());
                        lcl_obj_TmpSalary.AdditionPhoneBill = System.Decimal.Parse(lcl_obj_dr["A_PHONE_BILL"].ToString());
                        lcl_obj_TmpSalary.AdditionIncentive = System.Decimal.Parse(lcl_obj_dr["A_INCENTIVE"].ToString());
                        lcl_obj_TmpSalary.AdditionAllowance = System.Decimal.Parse(lcl_obj_dr["A_ALLOWANCE"].ToString());
                        lcl_obj_TmpSalary.AdditionOthers = System.Decimal.Parse(lcl_obj_dr["A_OTHERS"].ToString());
                        lcl_obj_TmpSalary.AdditionNightAllowance = System.Decimal.Parse(lcl_obj_dr["A_NIGHT_ALLOWANCE"].ToString());
                        lcl_obj_TmpSalary.DeductionAdvance = System.Decimal.Parse(lcl_obj_dr["D_ADVANCE"].ToString());
                        lcl_obj_TmpSalary.DeductionPenalty = System.Decimal.Parse(lcl_obj_dr["D_PENALTY"].ToString());
                        lcl_obj_TmpSalary.DeductionIncomeTax = System.Decimal.Parse(lcl_obj_dr["D_INCOME_TAX"].ToString());
                        lcl_obj_TmpSalary.DeductionLate = System.Decimal.Parse(lcl_obj_dr["D_LATE"].ToString());
                        lcl_obj_TmpSalary.DeductionUnpaidLeave = System.Decimal.Parse(lcl_obj_dr["D_UNPAID_LEAVE"].ToString());
                        lcl_obj_TmpSalary.DeductionAbsent = System.Decimal.Parse(lcl_obj_dr["D_ABSENT"].ToString());
                        lcl_obj_TmpSalary.DeductionOthers = System.Decimal.Parse(lcl_obj_dr["D_OTHERS"].ToString());
                        lcl_obj_TmpSalary.DeductionProvidentFund = System.Decimal.Parse(lcl_obj_dr["D_PROVIDENT_FUND"].ToString());
                        lcl_obj_TmpSalary.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                        lcl_obj_TmpSalary.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                        lcl_obj_TmpSalary.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                        lcl_obj_TmpSalary.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                        lcl_obj_TmpSalary.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                        lcl_obj_TmpSalary.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                        lcl_obj_TmpSalary.OverTimeMinutes = System.Double.Parse(lcl_obj_dr["OVERTIME_MINUTES"].ToString());
                        lcl_obj_TmpSalary.OverTimeAmount = System.Decimal.Parse(lcl_obj_dr["OVERTIME_AMOUNT"].ToString());
                        lcl_obj_TmpSalary.GrandTotal = System.Decimal.Parse(lcl_obj_dr["GRAND_TOTAL"].ToString());
                        lcl_obj_TmpSalary.SalaryStatus = (SilkERP360.CCL.Enums.SalaryStatus)(System.Int32.Parse(lcl_obj_dr["SALARY_STATUS"].ToString()));
                        lcl_obj_TmpSalary.Notes = lcl_obj_dr["NOTES"].ToString();
                        lcl_objlist_TmpSalaryList.Add(lcl_obj_TmpSalary);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSalaryList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SalaryList;
        }
    }
}
