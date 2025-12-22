using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Employee>
    {
        public EmployeeManager()
        {
            this.Initialize();
        }
        //public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee, System.Object IP_obj_DBManager)
        //{
        //    System.UInt64 lcl_ui64_EmployeeCode = 0;
        //    lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        OracleParameter lcl_obj_EmployeeCode = new OracleParameter("p_EMPLOYEE_CODE", OracleDbType.Int64);
        //        lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;


        //        OracleParameter lcl_obj_EmployeeId = new OracleParameter("p_EMPLOYEE_ID", OracleDbType.NVarchar2, 32);
        //        lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;


        //        OracleParameter lcl_obj_EmployeeAcsCode = new OracleParameter("p_EMPLOYEE_ACS_CODE", OracleDbType.NVarchar2, 30);
        //        lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;

        //        OracleParameter lcl_obj_EmployeeName = new OracleParameter("p_EMPLOYEE_NAME", OracleDbType.NVarchar2, 128);
        //        lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;

        //        OracleParameter lcl_obj_DesignationCode = new OracleParameter("p_DESIGNATION_CODE", OracleDbType.Int64);
        //        lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;

        //        OracleParameter lcl_obj_DepartmentCode = new OracleParameter("p_DEPARTMENT_CODE", OracleDbType.Int64);
        //        lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;

        //        OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
        //        lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;

        //        OracleParameter lcl_obj_RefEmployeeCode = new OracleParameter("p_REF_EMPLOYEE_CODE", OracleDbType.Int64);
        //        lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;

        //        OracleParameter lcl_obj_SupervisorCode = new OracleParameter("p_SUPERVISOR_CODE", OracleDbType.Int64);
        //        lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;

        //        OracleParameter lcl_obj_JoiningDate = new OracleParameter("p_JOINING_DATE", OracleDbType.Date);
        //        lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;

        //        OracleParameter lcl_obj_ConfirmationDate = new OracleParameter("p_CONFIRMATION_DATE", OracleDbType.Date);
        //        lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;

        //        OracleParameter lcl_obj_RetirementDate = new OracleParameter("p_RETIREMENT_DATE", OracleDbType.Date);
        //        lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;

        //        OracleParameter lcl_obj_SettlementDate = new OracleParameter("p_SETTLEMENT_DATE", OracleDbType.Date);
        //        lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;

        //        OracleParameter lcl_obj_OfficialFileNo = new OracleParameter("p_OFFICIAL_FILE_NO", OracleDbType.NVarchar2, 20);
        //        lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;

        //        OracleParameter lcl_obj_Tin = new OracleParameter("p_TIN", OracleDbType.NVarchar2, 20);
        //        lcl_obj_Tin.Direction = System.Data.ParameterDirection.Input;
        //        // lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
        //        if (lcl_obj_Employee.Tin == null)
        //        {
        //            lcl_obj_Tin.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
        //        }

        //        OracleParameter lcl_obj_Remarks = new OracleParameter("p_REMARKS", OracleDbType.NVarchar2, 1024);
        //        lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;

        //        OracleParameter lcl_obj_IsPfEligible = new OracleParameter("p_IS_PF_ELIGIBLE", OracleDbType.Int64);
        //        lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;

        //        OracleParameter lcl_obj_PfCode = new OracleParameter("p_PF_CODE", OracleDbType.Int64);
        //        lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;

        //        OracleParameter lcl_obj_IsOtEligible = new OracleParameter("p_IS_OT_ELIGIBLE", OracleDbType.Int64);
        //        lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;

        //        OracleParameter lcl_obj_SalaryPayableAtBank = new OracleParameter("p_SALARY_PAYABLE_AT_BANK", OracleDbType.Int64);
        //        lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;

        //        OracleParameter lcl_obj_Bank = new OracleParameter("p_BANK_ACC_NO", OracleDbType.NVarchar2, 52);
        //        lcl_obj_Bank.Direction = System.Data.ParameterDirection.Input;
        //        //  lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;
        //        if (lcl_obj_Employee.BankAccNo == null)
        //        {
        //            lcl_obj_Bank.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;
        //        }

        //        OracleParameter lcl_obj_IsDeleted = new OracleParameter("p_IS_DELETED", OracleDbType.Int64);
        //        lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_IsDeleted.Value = 1;

        //        OracleParameter lcl_obj_EmployeeStatus = new OracleParameter("p_EMPLOYEE_STATUS", OracleDbType.Int64);
        //        lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

        //        OracleParameter lcl_obj_IsOnRoster = new OracleParameter("p_IS_ON_ROSTER", OracleDbType.Int64);
        //        lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

        //        OracleParameter lcl_obj_ShiftCode = new OracleParameter("p_SHIFT_CODE", OracleDbType.Int64);
        //        lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

        //        OracleParameter lcl_obj_BankAccount = new OracleParameter("p_BANK_NAME", OracleDbType.NVarchar2, 52);
        //        lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
        //        if (lcl_obj_Employee.BankName == null)
        //        {
        //            lcl_obj_BankAccount.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
        //        }
        //        lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
        //        OracleParameter lcl_obj_NightBillEligible = new OracleParameter("p_NIGHT_BILL_ELIGIBLE", OracleDbType.Int64);
        //        lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;

        //        OracleParameter lcl_obj_JobLocation = new OracleParameter("p_JOB_LOCATION", OracleDbType.NVarchar2, 152);
        //        lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

        //        OracleParameter lcl_obj_ComUniformEligible = new OracleParameter("p_IS_UNIFORM_ELIGIBLE", OracleDbType.Int64);
        //        lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

        //        OracleParameter lcl_obj_BondValidityDate = new OracleParameter("p_BOND_VALIDITY_DATE", OracleDbType.Date);
        //        lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

        //        OracleParameter lcl_obj_BondRefference = new OracleParameter("p_BOND_REFERENCE", OracleDbType.NVarchar2, 128);
        //        lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

        //        OracleParameter lcl_obj_BondIssueDate = new OracleParameter("p_BOND_ISSUE_DATE", OracleDbType.Date);
        //        lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

        //        OracleParameter lcl_obj_BondYear = new OracleParameter("p_BOND_YEAR", OracleDbType.Int64);
        //        lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

        //        OracleParameter lcl_obj_eTinEligible = new OracleParameter("p_E_TIN_ELIGIBLE", OracleDbType.Int64);
        //        lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;

        //        OracleParameter[] lcl_obj_SP_Parameters = {lcl_obj_EmployeeCode,lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode,
        //                                                                             lcl_obj_DepartmentCode, lcl_obj_CompanyCode, lcl_obj_RefEmployeeCode,
        //                                                                             lcl_obj_SupervisorCode, lcl_obj_JoiningDate, lcl_obj_ConfirmationDate,
        //                                                                             lcl_obj_RetirementDate, lcl_obj_SettlementDate, lcl_obj_OfficialFileNo,
        //                                                                             lcl_obj_Tin, lcl_obj_Remarks, lcl_obj_IsPfEligible, lcl_obj_PfCode, lcl_obj_IsOtEligible,
        //                                                                             lcl_obj_SalaryPayableAtBank, lcl_obj_Bank, lcl_obj_IsDeleted, lcl_obj_EmployeeStatus, lcl_obj_IsOnRoster, lcl_obj_ShiftCode, lcl_obj_BankAccount, lcl_obj_NightBillEligible, lcl_obj_JobLocation, lcl_obj_ComUniformEligible, lcl_obj_BondValidityDate, lcl_obj_BondRefference, lcl_obj_BondIssueDate, lcl_obj_BondYear, lcl_obj_eTinEligible };
        //        lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_IU", lcl_obj_SP_Parameters);
        //        return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());

        //    }, "BMLExceptionPolicy");
        //    return lcl_ui64_EmployeeCode;
        //}

        //public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Employee emp, object IP_obj_DBManager)
        //{
        //    return this.ExceptionManager.Process<ulong>(() =>
        //    {
        //        SilkERP360.DAL.DBManager db = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        OracleCommand cmd = db.Command;

        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.Clear();

        //        cmd.CommandText = @"
        //INSERT INTO EMPLOYEE
        //(
        // EMPLOYEE_CODE,
        // EMPLOYEE_ID,
        // EMPLOYEE_ACS_CODE,
        // EMPLOYEE_NAME,
        // DESIGNATION_CODE,
        // DEPARTMENT_CODE,
        // COMPANY_CODE,
        // REF_EMPLOYEE_CODE,
        // SUPERVISOR_CODE,
        // JOINING_DATE,
        // CONFIRMATION_DATE,
        // RETIREMENT_DATE,
        // SETTLEMENT_DATE,
        // OFFICIAL_FILE_NO,
        // TIN,
        // REMARKS,
        // IS_PF_ELIGIBLE,
        // PF_CODE,
        // IS_OT_ELIGIBLE,
        // SALARY_PAYABLE_AT_BANK,
        // BANK_ACCOUNT_NO,
        // IS_DELETED,
        // EMPLOYEE_STATUS,
        // IS_ON_ROSTER,
        // SHIFT_CODE,
        // BANK_NAME,
        // NIGHT_BILL_ELIGIBLE,
        // JOB_LOCATION,
        // BOND_VALIDITY_DATE,
        // BOND_REFERENCE,
        // BOND_ISSUE_DATE,
        // BOND_YEAR,
        // IS_UNIFORM_ELIGIBLE,
        // E_TIN_ELIGIBLE
        //)
        //VALUES
        //(
        // SILKERP.EMPLOYEE_SEQ.NEXTVAL,
        // EMPNEWID(:COMPANY_CODE, :JOINING_DATE),
        // :EMPLOYEE_ACS_CODE,
        // :EMPLOYEE_NAME,
        // :DESIGNATION_CODE,
        // :DEPARTMENT_CODE,
        // :COMPANY_CODE,
        // :REF_EMPLOYEE_CODE,
        // :SUPERVISOR_CODE,
        // :JOINING_DATE,
        // :CONFIRMATION_DATE,
        // :RETIREMENT_DATE,
        // :SETTLEMENT_DATE,
        // :OFFICIAL_FILE_NO,
        // :TIN,
        // :REMARKS,
        // :IS_PF_ELIGIBLE,
        // :PF_CODE,
        // :IS_OT_ELIGIBLE,
        // :SALARY_PAYABLE_AT_BANK,
        // :BANK_ACCOUNT_NO,
        // :IS_DELETED,
        // :EMPLOYEE_STATUS,
        // :IS_ON_ROSTER,
        // :SHIFT_CODE,
        // :BANK_NAME,
        // :NIGHT_BILL_ELIGIBLE,
        // :JOB_LOCATION,
        // :BOND_VALIDITY_DATE,
        // :BOND_REFERENCE,
        // :BOND_ISSUE_DATE,
        // :BOND_YEAR,
        // :IS_UNIFORM_ELIGIBLE,
        // :E_TIN_ELIGIBLE
        //)
        //RETURNING EMPLOYEE_CODE INTO :OUT_EMPLOYEE_CODE";

        //        // OUTPUT
        //        cmd.Parameters.Add("OUT_EMPLOYEE_CODE", OracleDbType.Int64)
        //           .Direction = ParameterDirection.Output;

        //        // INPUT PARAMETERS WITH TYPES

        //        cmd.Parameters.Add("COMPANY_CODE", OracleDbType.Int64).Value = emp.CompanyCode;
        //        cmd.Parameters.Add("JOINING_DATE", OracleDbType.Date).Value = emp.JoiningDate;

        //        cmd.Parameters.Add("EMPLOYEE_ACS_CODE", OracleDbType.NVarchar2, 30).Value = emp.EmployeeACSCode;
        //        cmd.Parameters.Add("EMPLOYEE_NAME", OracleDbType.NVarchar2, 128).Value = emp.EmployeeName;
        //        cmd.Parameters.Add("DESIGNATION_CODE", OracleDbType.Int64).Value = emp.DesignationCode;
        //        cmd.Parameters.Add("DEPARTMENT_CODE", OracleDbType.Int64).Value =       emp.DepartmentCode;
        //        cmd.Parameters.Add("REF_EMPLOYEE_CODE", OracleDbType.Int64).Value = emp.RefEmployeeCode == null ? (object)DBNull.Value : emp.RefEmployeeCode;
        //        cmd.Parameters.Add("SUPERVISOR_CODE", OracleDbType.Int64).Value = emp.SupervisorCode == null ? (object)DBNull.Value : emp.SupervisorCode;

        //        cmd.Parameters.Add("CONFIRMATION_DATE", OracleDbType.Date).Value =      emp.ConfirmationDate == null ? (object)DBNull.Value : emp.ConfirmationDate;
        //        cmd.Parameters.Add("RETIREMENT_DATE", OracleDbType.Date).Value =    emp.RetirementDate == null ? (object)DBNull.Value : emp.RetirementDate;
        //        cmd.Parameters.Add("SETTLEMENT_DATE", OracleDbType.Date).Value =    emp.SettlementDate == null ? (object)DBNull.Value : emp.SettlementDate;

        //        cmd.Parameters.Add("OFFICIAL_FILE_NO", OracleDbType.NVarchar2, 20).Value = string.IsNullOrWhiteSpace(emp.OfficialFileNo) == null ? (object)DBNull.Value : emp.OfficialFileNo;
        //        cmd.Parameters.Add("TIN", OracleDbType.NVarchar2, 20).Value = string.IsNullOrWhiteSpace(emp.Tin) == null ? (object)DBNull.Value : emp.Tin;
        //        cmd.Parameters.Add("REMARKS", OracleDbType.NVarchar2, 1024).Value = emp.Remarks == null ? (object)DBNull.Value : emp.Remarks;

        //        cmd.Parameters.Add("IS_PF_ELIGIBLE", OracleDbType.Int32).Value = emp.IsPfEligible == null ? (object)DBNull.Value : emp.IsPfEligible;
        //        cmd.Parameters.Add("PF_CODE", OracleDbType.Int64).Value =   emp.PfCode == null ? (object)DBNull.Value : emp.PfCode;
        //        cmd.Parameters.Add("IS_OT_ELIGIBLE", OracleDbType.Int32).Value = emp.IsOtEligible == null ? (object)DBNull.Value : emp.IsOtEligible;
        //        cmd.Parameters.Add("SALARY_PAYABLE_AT_BANK", OracleDbType.Int64).Value = emp.SalaryPayableAtBank == null ? (object)DBNull.Value : emp.SalaryPayableAtBank;

        //        cmd.Parameters.Add("BANK_ACCOUNT_NO", OracleDbType.NVarchar2, 52).Value = string.IsNullOrEmpty(emp.BankAccNo) == null ? (object)DBNull.Value : emp.BankAccNo;

        //        cmd.Parameters.Add("IS_DELETED", OracleDbType.Int32).Value = 1;  // This seems to be a fixed value, so no need for DBNull
        //        cmd.Parameters.Add("EMPLOYEE_STATUS", OracleDbType.Int32).Value = emp.EmployeeStatus;
        //        cmd.Parameters.Add("IS_ON_ROSTER", OracleDbType.Int32).Value = emp.IsOnRoster;
        //        cmd.Parameters.Add("SHIFT_CODE", OracleDbType.Int64).Value = emp.ShiftCode == null ? (object)DBNull.Value : emp.ShiftCode;

        //        cmd.Parameters.Add("BANK_NAME", OracleDbType.NVarchar2, 52).Value = string.IsNullOrEmpty(emp.BankName) == null ? (object)DBNull.Value : emp.BankName;
        //        cmd.Parameters.Add("NIGHT_BILL_ELIGIBLE", OracleDbType.Int32).Value = emp.NightBillEligible;
        //        cmd.Parameters.Add("JOB_LOCATION", OracleDbType.NVarchar2, 152).Value = string.IsNullOrEmpty(emp.JobLocation) == null ? (object)DBNull.Value : emp.JobLocation;

        //        cmd.Parameters.Add("BOND_VALIDITY_DATE", OracleDbType.Date).Value = emp.BondValidityDate == null ? (object)DBNull.Value : emp.BondValidityDate;
        //        cmd.Parameters.Add("BOND_REFERENCE", OracleDbType.NVarchar2, 128).Value = string.IsNullOrEmpty(emp.BondRefference) == null ? (object)DBNull.Value : emp.BondRefference;
        //        cmd.Parameters.Add("BOND_ISSUE_DATE", OracleDbType.Date).Value = emp.BondIssueDate == null ? (object)DBNull.Value : emp.BondIssueDate;
        //        cmd.Parameters.Add("BOND_YEAR", OracleDbType.Int64).Value = emp.BondYear;

        //        cmd.Parameters.Add("IS_UNIFORM_ELIGIBLE", OracleDbType.Int32).Value = emp.ComUniformEligible;
        //        cmd.Parameters.Add("E_TIN_ELIGIBLE", OracleDbType.Int32).Value = emp.eTinEligible == null ? (object)DBNull.Value : emp.eTinEligible;

        //        // Execute the command
        //        cmd.ExecuteNonQuery();

        //        return Convert.ToUInt64(cmd.Parameters["OUT_EMPLOYEE_CODE"].Value.ToString());
        //    }, "BMLExceptionPolicy");
        //}

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Employee emp, object IP_obj_DBManager)
        {
            return this.ExceptionManager.Process<ulong>(() =>
            {
                SilkERP360.DAL.DBManager db = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleCommand cmd = db.Command;

                cmd.CommandType = CommandType.Text;

                string ToSqlDate(DateTime? dt) => dt.HasValue ? $"TO_DATE('{dt:yyyy-MM-dd}','YYYY-MM-DD')" : "NULL";
                string ToSqlNumber(long? n) => n.HasValue ? n.Value.ToString() : "NULL";
                string ToSqlInt(int? n) => n.HasValue ? n.Value.ToString() : "NULL";
                string ToSqlString(string s) => string.IsNullOrWhiteSpace(s) ? "NULL" : $"'{s.Replace("'", "''")}'";

                string sql = $@"
INSERT INTO EMPLOYEE
(
    EMPLOYEE_CODE,
    EMPLOYEE_ID,
    EMPLOYEE_ACS_CODE,
    EMPLOYEE_NAME,
    DESIGNATION_CODE,
    DEPARTMENT_CODE,
    COMPANY_CODE,
    REF_EMPLOYEE_CODE,
    SUPERVISOR_CODE,
    JOINING_DATE,
    CONFIRMATION_DATE,
    RETIREMENT_DATE,
    SETTLEMENT_DATE,
    OFFICIAL_FILE_NO,
    TIN,
    REMARKS,
    IS_PF_ELIGIBLE,
    PF_CODE,
    IS_OT_ELIGIBLE,
    SALARY_PAYABLE_AT_BANK,
    BANK_ACCOUNT_NO,
    IS_DELETED,
    EMPLOYEE_STATUS,
    IS_ON_ROSTER,
    SHIFT_CODE,
    BANK_NAME,
    NIGHT_BILL_ELIGIBLE,
    JOB_LOCATION,
    BOND_VALIDITY_DATE,
    BOND_REFERENCE,
    BOND_ISSUE_DATE,
    BOND_YEAR,
    IS_UNIFORM_ELIGIBLE,
    E_TIN_ELIGIBLE
)
VALUES
(
    SILKERP.EMPLOYEE_SEQ.NEXTVAL,
    EMPNEWID({emp.CompanyCode}, TO_DATE('{emp.JoiningDate:yyyy-MM-dd}', 'YYYY-MM-DD')),
    {ToSqlString(emp.EmployeeACSCode)},
    {ToSqlString(emp.EmployeeName)},
    {emp.DesignationCode},
    {emp.DepartmentCode},
    {emp.CompanyCode},
    {(emp.RefEmployeeCode)},
    {(emp.SupervisorCode)},
    TO_DATE('{emp.JoiningDate:yyyy-MM-dd}','YYYY-MM-DD'),
    {ToSqlDate(emp.ConfirmationDate)},
    {ToSqlDate(emp.RetirementDate)},
    {ToSqlDate(emp.SettlementDate)},
    {ToSqlString(emp.OfficialFileNo)},
    {ToSqlString(emp.Tin)},
    {ToSqlString(emp.Remarks)},
    {ToSqlInt(emp.IsPfEligible)},
    {(emp.PfCode)},
    {ToSqlInt(emp.IsOtEligible)},
    {ToSqlNumber(emp.SalaryPayableAtBank)},
    {ToSqlString(emp.BankAccNo)},
    1,
    {emp.EmployeeStatus},
    {emp.IsOnRoster},
    {(emp.ShiftCode)},
    {ToSqlString(emp.BankName)},
    {emp.NightBillEligible},
    {ToSqlString(emp.JobLocation)},
    {ToSqlDate(emp.BondValidityDate)},
    {ToSqlString(emp.BondRefference)},
    {ToSqlDate(emp.BondIssueDate)},
    {emp.BondYear},
    {emp.ComUniformEligible},
    {ToSqlInt(emp.eTinEligible)}
)
RETURNING EMPLOYEE_CODE INTO :OUT_EMPLOYEE_CODE";

                // Output parameter
                cmd.Parameters.Clear();
                cmd.Parameters.Add("OUT_EMPLOYEE_CODE", OracleDbType.Int64).Direction = ParameterDirection.Output;

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();

                return Convert.ToUInt64(cmd.Parameters["OUT_EMPLOYEE_CODE"].Value.ToString());
            }, "BMLExceptionPolicy");
        }



        public ulong update(SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeCode = 0;
            lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_EmployeeCode = new OracleParameter("p_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_Employee.EmployeeCode;

                OracleParameter lcl_obj_EmployeeId = new OracleParameter("p_EMPLOYEE_ID", OracleDbType.NVarchar2, 32);
                lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;
                //  lcl_obj_EmployeeId.Value = lcl_obj_Employee.EmployeeId;

                OracleParameter lcl_obj_EmployeeAcsCode = new OracleParameter("p_EMPLOYEE_ACS_CODE", OracleDbType.NVarchar2, 30);
                lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;

                OracleParameter lcl_obj_EmployeeName = new OracleParameter("p_EMPLOYEE_NAME", OracleDbType.NVarchar2, 128);
                lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;

                OracleParameter lcl_obj_DesignationCode = new OracleParameter("p_DESIGNATION_CODE", OracleDbType.Int64);
                lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;

                OracleParameter lcl_obj_DepartmentCode = new OracleParameter("p_DEPARTMENT_CODE", OracleDbType.Int64);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;

                OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;

                OracleParameter lcl_obj_RefEmployeeCode = new OracleParameter("p_REF_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;

                OracleParameter lcl_obj_SupervisorCode = new OracleParameter("p_SUPERVISOR_CODE", OracleDbType.Int64);
                lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;

                OracleParameter lcl_obj_JoiningDate = new OracleParameter("p_JOINING_DATE", OracleDbType.Date);
                lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;

                OracleParameter lcl_obj_ConfirmationDate = new OracleParameter("p_CONFIRMATION_DATE", OracleDbType.Date);
                lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;

                OracleParameter lcl_obj_RetirementDate = new OracleParameter("p_RETIREMENT_DATE", OracleDbType.Date);
                lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;

                OracleParameter lcl_obj_SettlementDate = new OracleParameter("p_SETTLEMENT_DATE", OracleDbType.Date);
                lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;

                OracleParameter lcl_obj_OfficialFileNo = new OracleParameter("p_OFFICIAL_FILE_NO", OracleDbType.NVarchar2, 20);
                lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;

                OracleParameter lcl_obj_Tin = new OracleParameter("p_TIN", OracleDbType.NVarchar2, 20);
                lcl_obj_Tin.Direction = System.Data.ParameterDirection.Input;
                // lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
                if (lcl_obj_Employee.Tin == null)
                {
                    lcl_obj_Tin.Value = System.DBNull.Value;
                }
                else
                {
                    lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
                }

                OracleParameter lcl_obj_Remarks = new OracleParameter("p_REMARKS", OracleDbType.NVarchar2, 1024);
                lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;

                OracleParameter lcl_obj_IsPfEligible = new OracleParameter("p_IS_PF_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;

                OracleParameter lcl_obj_PfCode = new OracleParameter("p_PF_CODE", OracleDbType.Int64);
                lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;

                OracleParameter lcl_obj_IsOtEligible = new OracleParameter("p_IS_OT_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;

                OracleParameter lcl_obj_SalaryPayableAtBank = new OracleParameter("p_SALARY_PAYABLE_AT_BANK", OracleDbType.Int64);
                lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;

                OracleParameter lcl_obj_Bank = new OracleParameter("p_BANK_ACC_NO", OracleDbType.NVarchar2, 52);
                lcl_obj_Bank.Direction = System.Data.ParameterDirection.Input;
                //  lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;

                if (lcl_obj_Employee.BankAccNo == null)
                {
                    lcl_obj_Bank.Value = System.DBNull.Value;
                }
                else
                {
                    lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;
                }

                OracleParameter lcl_obj_IsDeleted = new OracleParameter("p_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                OracleParameter lcl_obj_EmployeeStatus = new OracleParameter("p_EMPLOYEE_STATUS", OracleDbType.Int64);
                lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

                OracleParameter lcl_obj_IsOnRoster = new OracleParameter("p_IS_ON_ROSTER", OracleDbType.Int64);
                lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

                OracleParameter lcl_obj_ShiftCode = new OracleParameter("p_SHIFT_CODE", OracleDbType.Int64);
                lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

                OracleParameter lcl_obj_BankAccount = new OracleParameter("p_BANK_NAME", OracleDbType.NVarchar2, 52);
                lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;

                //OracleParameter lcl_obj_BankAccount = new OracleParameter("p_BANK_NAME", OracleDbType.NVarchar2, 52);
                //lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                //if (lcl_obj_Employee.BankName == null)
                //{
                //    lcl_obj_BankAccount.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
                //}

                OracleParameter lcl_obj_NightBillEligible = new OracleParameter("p_NIGHT_BILL_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;                

                OracleParameter lcl_obj_JobLocation = new OracleParameter("p_JOB_LOCATION", OracleDbType.NVarchar2, 152);
                lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

                OracleParameter lcl_obj_ComUniformEligible = new OracleParameter("p_IS_UNIFORM_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

                OracleParameter lcl_obj_BondValidityDate = new OracleParameter("p_BOND_VALIDITY_DATE", OracleDbType.Date);
                lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

                OracleParameter lcl_obj_BondRefference = new OracleParameter("p_BOND_REFERENCE", OracleDbType.NVarchar2, 128);
                lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

                OracleParameter lcl_obj_BondIssueDate = new OracleParameter("p_BOND_ISSUE_DATE", OracleDbType.Date);
                lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

                OracleParameter lcl_obj_BondYear = new OracleParameter("p_BOND_YEAR", OracleDbType.Int64);
                lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

                OracleParameter lcl_obj_eTinEligible = new OracleParameter("p_E_TIN_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;   

                OracleParameter[] lcl_obj_SP_Parameters = {lcl_obj_EmployeeCode,lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode, 
                                                                                     lcl_obj_DepartmentCode, lcl_obj_CompanyCode, lcl_obj_RefEmployeeCode, 
                                                                                     lcl_obj_SupervisorCode, lcl_obj_JoiningDate, lcl_obj_ConfirmationDate, lcl_obj_RetirementDate, lcl_obj_SettlementDate, lcl_obj_OfficialFileNo, lcl_obj_Tin, lcl_obj_Remarks, lcl_obj_IsPfEligible, lcl_obj_PfCode, lcl_obj_IsOtEligible, lcl_obj_SalaryPayableAtBank, lcl_obj_Bank, lcl_obj_IsDeleted, lcl_obj_EmployeeStatus, lcl_obj_IsOnRoster, lcl_obj_ShiftCode,lcl_obj_BankAccount, lcl_obj_NightBillEligible, lcl_obj_JobLocation, lcl_obj_ComUniformEligible, lcl_obj_BondValidityDate, lcl_obj_BondRefference, lcl_obj_BondIssueDate, lcl_obj_BondYear, lcl_obj_eTinEligible};

                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_UPDT_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee)
        {
            System.UInt64 lcl_ui64_EmployeeCode = 0;
            lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;
                    // lcl_obj_EmployeeCode.Value = lcl_obj_Employee.EmployeeCode;
                    OracleParameter lcl_obj_EmployeeId = new OracleParameter("v_EMPLOYEE_ID", OracleDbType.NVarchar2);
                    lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;
                    // lcl_obj_EmployeeId.Value = lcl_obj_Employee.EmployeeId;
                    OracleParameter lcl_obj_EmployeeAcsCode = new OracleParameter("v_EMPLOYEE_ACS_CODE", OracleDbType.NVarchar2, 30);
                    lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;
                    //OracleParameter lcl_obj_EmployeeBmsCode = new OracleParameter("v_EMPLOYEE_BMS_CODE", OracleDbType.NVarchar2);
                    //lcl_obj_EmployeeBmsCode.Direction = System.Data.ParameterDirection.Input;
                    //lcl_obj_EmployeeBmsCode.Value = lcl_obj_Employee.EmployeeBmsCode;
                    OracleParameter lcl_obj_EmployeeName = new OracleParameter("v_EMPLOYEE_NAME", OracleDbType.NVarchar2);
                    lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;
                    OracleParameter lcl_obj_DesignationCode = new OracleParameter("v_DESIGNATION_CODE", OracleDbType.Int64);
                    lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;
                    OracleParameter lcl_obj_DepartmentCode = new OracleParameter("v_DEPARTMENT_CODE", OracleDbType.Int64);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;
                    OracleParameter lcl_obj_CompanyCode = new OracleParameter("v_COMPANY_CODE", OracleDbType.Int64);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;
                    OracleParameter lcl_obj_RefEmployeeCode = new OracleParameter("v_REF_EMPLOYEE_CODE", OracleDbType.Int64);
                    lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;
                    OracleParameter lcl_obj_SupervisorCode = new OracleParameter("v_SUPERVISOR_CODE", OracleDbType.Int64);
                    lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;
                    OracleParameter lcl_obj_JoiningDate = new OracleParameter("v_JOINING_DATE", OracleDbType.Date);
                    lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;
                    OracleParameter lcl_obj_ConfirmationDate = new OracleParameter("v_CONFIRMATION_DATE", OracleDbType.Date);
                    lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;
                    OracleParameter lcl_obj_RetirementDate = new OracleParameter("v_RETIREMENT_DATE", OracleDbType.Date);
                    lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;
                    OracleParameter lcl_obj_SettlementDate = new OracleParameter("v_SETTLEMENT_DATE", OracleDbType.Date);
                    lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;
                    OracleParameter lcl_obj_OfficialFileNo = new OracleParameter("v_OFFICIAL_FILE_NO", OracleDbType.NVarchar2);
                    lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;
                    OracleParameter lcl_obj_Tin = new OracleParameter("v_TIN", OracleDbType.NVarchar2);
                    lcl_obj_Tin.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
                    OracleParameter lcl_obj_Remarks = new OracleParameter("v_REMARKS", OracleDbType.NVarchar2);
                    lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;
                    OracleParameter lcl_obj_IsPfEligible = new OracleParameter("v_IS_PF_ELIGIBLE", OracleDbType.Int64);
                    lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;
                    OracleParameter lcl_obj_PfCode = new OracleParameter("v_PF_CODE", OracleDbType.Int64);
                    lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;
                    OracleParameter lcl_obj_IsOtEligible = new OracleParameter("v_IS_OT_ELIGIBLE", OracleDbType.Int64);
                    lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;
                    OracleParameter lcl_obj_SalaryPayableAtBank = new OracleParameter("v_SALARY_PAYABLE_AT_BANK", OracleDbType.Int64);
                    lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;
                    OracleParameter lcl_obj_Bank = new OracleParameter("p_BANK_ACC_NO", OracleDbType.NVarchar2, 52);
                    lcl_obj_Bank.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;

                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("p_IS_DELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = 1;

                    OracleParameter lcl_obj_EmployeeStatus = new OracleParameter("p_EMPLOYEE_STATUS", OracleDbType.Int64);
                    lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

                    OracleParameter lcl_obj_IsOnRoster = new OracleParameter("p_IS_ON_ROSTER", OracleDbType.Int64);
                    lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

                    OracleParameter lcl_obj_ShiftCode = new OracleParameter("p_SHIFT_CODE", OracleDbType.Int64);
                    lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

                    OracleParameter lcl_obj_BankAccount = new OracleParameter("p_BANK_NAME", OracleDbType.NVarchar2, 52);
                    lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;

                    OracleParameter lcl_obj_NightBillEligible = new OracleParameter("p_NIGHT_BILL_ELIGIBLE", OracleDbType.Int64);
                    lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;                    

                    OracleParameter lcl_obj_JobLocation = new OracleParameter("p_JOB_LOCATION", OracleDbType.NVarchar2, 152);
                    lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

                    OracleParameter lcl_obj_ComUniformEligible = new OracleParameter("p_IS_UNIFORM_ELIGIBLE", OracleDbType.Int64);
                    lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

                    OracleParameter lcl_obj_BondValidityDate = new OracleParameter("p_BOND_VALIDITY_DATE", OracleDbType.Date);
                    lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

                    OracleParameter lcl_obj_BondRefference = new OracleParameter("p_BOND_REFERENCE", OracleDbType.NVarchar2, 128);
                    lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

                    OracleParameter lcl_obj_BondIssueDate = new OracleParameter("p_BOND_ISSUE_DATE", OracleDbType.Date);
                    lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

                    OracleParameter lcl_obj_BondYear = new OracleParameter("p_BOND_YEAR", OracleDbType.Int64);
                    lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

                    OracleParameter lcl_obj_eTinEligible = new OracleParameter("p_E_TIN_ELIGIBLE", OracleDbType.Int64);
                    lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;

                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode, lcl_obj_DepartmentCode, lcl_obj_CompanyCode, lcl_obj_RefEmployeeCode, lcl_obj_SupervisorCode, lcl_obj_JoiningDate, lcl_obj_ConfirmationDate, lcl_obj_RetirementDate, lcl_obj_SettlementDate, lcl_obj_OfficialFileNo, lcl_obj_Tin, lcl_obj_Remarks, lcl_obj_IsPfEligible, lcl_obj_PfCode, lcl_obj_IsOtEligible, lcl_obj_SalaryPayableAtBank, lcl_obj_Bank, lcl_obj_IsDeleted, lcl_obj_EmployeeStatus, lcl_obj_IsOnRoster, lcl_obj_ShiftCode, lcl_obj_BankAccount, lcl_obj_NightBillEligible, lcl_obj_JobLocation, lcl_obj_ComUniformEligible, lcl_obj_BondValidityDate, lcl_obj_BondRefference, lcl_obj_BondIssueDate, lcl_obj_BondYear, lcl_obj_eTinEligible };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("EMPLOYEE_IU", lcl_obj_SP_Parameters);
                    // return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }
        public CCL.BusinessEntities.HRIS.Employee Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee = null;
            lcl_obj_Employee = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Employee>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE EMPLOYEE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployee.Get(ID,DBManger)) : Error Retrieving Employee Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                //lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Employee;
        }

        public CCL.BusinessEntities.HRIS.Employee Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee = null;
            lcl_obj_Employee = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Employee>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE EMPLOYEE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Employee.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                    //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                    lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                    lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                    lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                    lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                    lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                    lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                    lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                    lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                    lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                    lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                    lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                    lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                    // lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());   
                    lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                    lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                    lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                    lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                    lcl_obj_Tmp.eTinEligible = System.UInt16.Parse(lcl_obj_dr["E_TIN_ELIGIBLE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Employee;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> lcl_objlist_Employee = null;
            lcl_objlist_Employee = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Employee.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                        //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                        lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                        lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                        lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                        lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                        lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                        lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                        lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                        lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                        lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                        lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                        lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                        lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                        lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                        lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                        lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                        lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                        lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                        lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                        lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                        lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                        lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                        lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                        //  lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                        lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                        lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                        lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                        lcl_obj_Tmp.eTinEligible = System.UInt16.Parse(lcl_obj_dr["E_TIN_ELIGIBLE"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_Employee;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> lcl_objlist_Employee = null;
            lcl_objlist_Employee = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Employee.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                    //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                    lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                    lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                    lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                    lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                    lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                    lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                    lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                    lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                    lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                    lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                    lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                    lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                    //  lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                    lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                    lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                    lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                    lcl_obj_Tmp.eTinEligible = System.UInt16.Parse(lcl_obj_dr["E_TIN_ELIGIBLE"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_Employee;
        }



        public CCL.BusinessEntities.HRIS.Employee Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee = null;
            lcl_obj_Employee = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Employee>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployee.Get(SqlQuery,DBManger)) : Error Retrieving Employee Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                //  lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                lcl_obj_Tmp.eTinEligible = System.UInt16.Parse(lcl_obj_dr["E_TIN_ELIGIBLE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Employee;
        }

        public CCL.BusinessEntities.HRIS.Employee Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee = null;
            lcl_obj_Employee = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Employee>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Employee.Get(SqlQuery)) : No Employee Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Employee();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_Tmp.EmployeeACSCode = lcl_obj_dr["EMPLOYEE_ACS_CODE"].ToString();
                    //lcl_obj_Tmp.EmployeeBmsCode = lcl_obj_dr["EMPLOYEE_BMS_CODE"].ToString();
                    lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.RefEmployeeCode = System.UInt64.Parse(lcl_obj_dr["REF_EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.SupervisorCode = System.UInt64.Parse(lcl_obj_dr["SUPERVISOR_CODE"].ToString());
                    lcl_obj_Tmp.JoiningDate = System.DateTime.Parse(lcl_obj_dr["JOINING_DATE"].ToString());
                    lcl_obj_Tmp.ConfirmationDate = System.DateTime.Parse(lcl_obj_dr["CONFIRMATION_DATE"].ToString());
                    lcl_obj_Tmp.RetirementDate = System.DateTime.Parse(lcl_obj_dr["RETIREMENT_DATE"].ToString());
                    lcl_obj_Tmp.SettlementDate = System.DateTime.Parse(lcl_obj_dr["SETTLEMENT_DATE"].ToString());
                    lcl_obj_Tmp.OfficialFileNo = lcl_obj_dr["OFFICIAL_FILE_NO"].ToString();
                    lcl_obj_Tmp.Tin = lcl_obj_dr["TIN"].ToString();
                    lcl_obj_Tmp.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_Tmp.IsPfEligible = System.UInt16.Parse(lcl_obj_dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.PfCode = System.UInt64.Parse(lcl_obj_dr["PF_CODE"].ToString());
                    lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.SalaryPayableAtBank = System.UInt16.Parse(lcl_obj_dr["SALARY_PAYABLE_AT_BANK"].ToString());
                    lcl_obj_Tmp.BankAccNo = lcl_obj_dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.EmployeeStatus = System.UInt16.Parse(lcl_obj_dr["EMPLOYEE_STATUS"].ToString());
                    lcl_obj_Tmp.IsOnRoster = System.UInt16.Parse(lcl_obj_dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_Tmp.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_Tmp.BankName = lcl_obj_dr["BANK_NAME"].ToString();
                    lcl_obj_Tmp.NightBillEligible = System.UInt16.Parse(lcl_obj_dr["NIGHT_BILL_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.JobLocation = lcl_obj_dr["JOB_LOCATION"].ToString();
                    lcl_obj_Tmp.ComUniformEligible = System.UInt16.Parse(lcl_obj_dr["IS_UNIFORM_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.BondValidityDate = System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                    //  lcl_obj_Tmp.BondValidityDate = (lcl_obj_dr["BOND_VALIDITY_DATE"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["BOND_VALIDITY_DATE"].ToString());
                    lcl_obj_Tmp.BondRefference = lcl_obj_dr["BOND_REFERENCE"].ToString();
                    lcl_obj_Tmp.BondIssueDate = System.DateTime.Parse(lcl_obj_dr["BOND_ISSUE_DATE"].ToString());
                    lcl_obj_Tmp.BondYear = System.UInt32.Parse(lcl_obj_dr["BOND_YEAR"].ToString());
                    lcl_obj_Tmp.eTinEligible = System.UInt16.Parse(lcl_obj_dr["E_TIN_ELIGIBLE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Employee;
        }
        public System.String getEmployeeName(System.UInt64 IP_ui64_EmployeeCode, System.Object IP_obj_DBManager)
        {
            System.String lcl_str_EmployeeName = System.String.Empty;
            lcl_str_EmployeeName = this.ExceptionManager.Process<System.String>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.String lcl_str_EmployeeNameTmp = System.String.Empty;
                System.String lcl_str_SqlQuery = System.String.Format("Select EMPLOYEE_NAME From Employee WHERE EMPLOYEE_CODE = {0} And STATUS = {1} AND IS_DELETED = 1", IP_ui64_EmployeeCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeNameReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_EmployeeNameReader.HasRows == false)
                {
                    return System.String.Empty;
                }
                lcl_obj_EmployeeNameReader.Read();
                lcl_str_EmployeeNameTmp = lcl_obj_EmployeeNameReader["EMPLOYEE_NAME"].ToString();
                return lcl_str_EmployeeNameTmp;
            }, "BMLExceptionPolicy");
            return lcl_str_EmployeeName;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage GetEmployeeImageFromCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImage = null;
            lcl_obj_EmployeeImage = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    System.String lcl_str_DBQuery = System.String.Format("SELECT * FROM employee_image WHERE employee_code = {0} AND IS_DELETED = 1 AND STATUS = 1", IP_ui64_EmployeeCode);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeImageReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_DBQuery);
                    if (!(lcl_obj_EmployeeImageReader.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImageTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage();
                    lcl_obj_EmployeeImageReader.Read();
                    lcl_obj_EmployeeImageTmp.EmployeeImageCode = System.UInt64.Parse(lcl_obj_EmployeeImageReader["employee_image_code"].ToString());
                    lcl_obj_EmployeeImageTmp.ImageType = lcl_obj_EmployeeImageReader["image_type"].ToString();
                    lcl_obj_EmployeeImageTmp.ImageSize = System.Int32.Parse(lcl_obj_EmployeeImageReader["image_size"].ToString());
                    // System.Data.OracleClient.orac

                    //this.m_str_Image_Data = System.Text.Encoding.UTF8.GetString((System.Byte[])(lcl_obj_Employee_Image_Reader["image"]));
                    lcl_obj_EmployeeImageTmp.EmployeeCode = IP_ui64_EmployeeCode;
                    //using (System.IO.MemoryStream ms = new System.IO.MemoryStream((System.Byte[])(lcl_obj_EmployeeImageReader["image"])))
                    //{
                    //    lcl_obj_EmployeeImageTmp.Image = System.Drawing.Image.FromStream(ms);
                    //}

                    //System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                    //this.m_img_Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    lcl_obj_EmployeeImageTmp.ImageData = System.Convert.ToBase64String((System.Byte[])(lcl_obj_EmployeeImageReader["image"]));
                    //this.m_img_Image = null;
                    lcl_obj_EmployeeImageReader.Close();
                    return lcl_obj_EmployeeImageTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeImage;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage GetEmployeeImageFromCode(System.UInt64 IP_ui64_EmployeeCode, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImage = null;
            lcl_obj_EmployeeImage = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.String lcl_str_DBQuery = System.String.Format("SELECT * FROM employee_image WHERE employee_code = {0} AND IS_DELETED = 1 AND STATUS = 1", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeImageReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_DBQuery);
                if (!(lcl_obj_EmployeeImageReader.HasRows))
                {
                    return null;
                }
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImageTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage();
                lcl_obj_EmployeeImageReader.Read();
                lcl_obj_EmployeeImageTmp.EmployeeImageCode = System.UInt64.Parse(lcl_obj_EmployeeImageReader["employee_image_code"].ToString());
                lcl_obj_EmployeeImageTmp.ImageType = lcl_obj_EmployeeImageReader["image_type"].ToString();
                lcl_obj_EmployeeImageTmp.ImageSize = System.Int32.Parse(lcl_obj_EmployeeImageReader["image_size"].ToString());
                // System.Data.OracleClient.orac

                //this.m_str_Image_Data = System.Text.Encoding.UTF8.GetString((System.Byte[])(lcl_obj_Employee_Image_Reader["image"]));
                lcl_obj_EmployeeImageTmp.EmployeeCode = IP_ui64_EmployeeCode;
                //using (System.IO.MemoryStream ms = new System.IO.MemoryStream((System.Byte[])(lcl_obj_EmployeeImageReader["image"])))
                //{
                //    lcl_obj_EmployeeImageTmp.Image = System.Drawing.Image.FromStream(ms);
                //}

                //System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                //this.m_img_Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                lcl_obj_EmployeeImageTmp.ImageData = System.Convert.ToBase64String((System.Byte[])(lcl_obj_EmployeeImageReader["image"]));
                //this.m_img_Image = null;
                lcl_obj_EmployeeImageReader.Close();
                return lcl_obj_EmployeeImageTmp;

            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeImage;
        }


    }
}