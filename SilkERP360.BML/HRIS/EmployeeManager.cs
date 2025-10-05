using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Employee>
    {
        public EmployeeManager()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeCode = 0;
            lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;


                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeId = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_ID", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;


                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeAcsCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_ACS_CODE", System.Data.OracleClient.OracleType.NVarChar, 30);
                lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeName = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_NAME", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;

                System.Data.OracleClient.OracleParameter lcl_obj_DesignationCode = new System.Data.OracleClient.OracleParameter("p_DESIGNATION_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;

                System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("p_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;

                System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("p_COMPANY_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;

                System.Data.OracleClient.OracleParameter lcl_obj_RefEmployeeCode = new System.Data.OracleClient.OracleParameter("p_REF_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_SupervisorCode = new System.Data.OracleClient.OracleParameter("p_SUPERVISOR_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;

                System.Data.OracleClient.OracleParameter lcl_obj_JoiningDate = new System.Data.OracleClient.OracleParameter("p_JOINING_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;

                System.Data.OracleClient.OracleParameter lcl_obj_ConfirmationDate = new System.Data.OracleClient.OracleParameter("p_CONFIRMATION_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;

                System.Data.OracleClient.OracleParameter lcl_obj_RetirementDate = new System.Data.OracleClient.OracleParameter("p_RETIREMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;

                System.Data.OracleClient.OracleParameter lcl_obj_SettlementDate = new System.Data.OracleClient.OracleParameter("p_SETTLEMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;

                System.Data.OracleClient.OracleParameter lcl_obj_OfficialFileNo = new System.Data.OracleClient.OracleParameter("p_OFFICIAL_FILE_NO", System.Data.OracleClient.OracleType.NVarChar, 20);
                lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;

                System.Data.OracleClient.OracleParameter lcl_obj_Tin = new System.Data.OracleClient.OracleParameter("p_TIN", System.Data.OracleClient.OracleType.NVarChar, 20);
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

                System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("p_REMARKS", System.Data.OracleClient.OracleType.NVarChar, 1024);
                lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;

                System.Data.OracleClient.OracleParameter lcl_obj_IsPfEligible = new System.Data.OracleClient.OracleParameter("p_IS_PF_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_PfCode = new System.Data.OracleClient.OracleParameter("p_PF_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;

                System.Data.OracleClient.OracleParameter lcl_obj_IsOtEligible = new System.Data.OracleClient.OracleParameter("p_IS_OT_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_SalaryPayableAtBank = new System.Data.OracleClient.OracleParameter("p_SALARY_PAYABLE_AT_BANK", System.Data.OracleClient.OracleType.Number);
                lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;

                System.Data.OracleClient.OracleParameter lcl_obj_Bank = new System.Data.OracleClient.OracleParameter("p_BANK_ACC_NO", System.Data.OracleClient.OracleType.NVarChar, 52);
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

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeStatus = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

                System.Data.OracleClient.OracleParameter lcl_obj_IsOnRoster = new System.Data.OracleClient.OracleParameter("p_IS_ON_ROSTER", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

                System.Data.OracleClient.OracleParameter lcl_obj_ShiftCode = new System.Data.OracleClient.OracleParameter("p_SHIFT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

                System.Data.OracleClient.OracleParameter lcl_obj_BankAccount = new System.Data.OracleClient.OracleParameter("p_BANK_NAME", System.Data.OracleClient.OracleType.NVarChar, 52);
                lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                if (lcl_obj_Employee.BankName == null)
                {
                    lcl_obj_BankAccount.Value = System.DBNull.Value;
                }
                else
                {
                    lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
                }
                lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
                System.Data.OracleClient.OracleParameter lcl_obj_NightBillEligible = new System.Data.OracleClient.OracleParameter("p_NIGHT_BILL_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;                

                System.Data.OracleClient.OracleParameter lcl_obj_JobLocation = new System.Data.OracleClient.OracleParameter("p_JOB_LOCATION", System.Data.OracleClient.OracleType.NVarChar, 152);
                lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

                System.Data.OracleClient.OracleParameter lcl_obj_ComUniformEligible = new System.Data.OracleClient.OracleParameter("p_IS_UNIFORM_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_BondValidityDate = new System.Data.OracleClient.OracleParameter("p_BOND_VALIDITY_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

                System.Data.OracleClient.OracleParameter lcl_obj_BondRefference = new System.Data.OracleClient.OracleParameter("p_BOND_REFERENCE", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

                System.Data.OracleClient.OracleParameter lcl_obj_BondIssueDate = new System.Data.OracleClient.OracleParameter("p_BOND_ISSUE_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

                System.Data.OracleClient.OracleParameter lcl_obj_BondYear = new System.Data.OracleClient.OracleParameter("p_BOND_YEAR", System.Data.OracleClient.OracleType.Number);
                lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

                System.Data.OracleClient.OracleParameter lcl_obj_eTinEligible = new System.Data.OracleClient.OracleParameter("p_E_TIN_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;   

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = {lcl_obj_EmployeeCode,lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode, 
                                                                                     lcl_obj_DepartmentCode, lcl_obj_CompanyCode, lcl_obj_RefEmployeeCode, 
                                                                                     lcl_obj_SupervisorCode, lcl_obj_JoiningDate, lcl_obj_ConfirmationDate,
                                                                                     lcl_obj_RetirementDate, lcl_obj_SettlementDate, lcl_obj_OfficialFileNo, 
                                                                                     lcl_obj_Tin, lcl_obj_Remarks, lcl_obj_IsPfEligible, lcl_obj_PfCode, lcl_obj_IsOtEligible, 
                                                                                     lcl_obj_SalaryPayableAtBank, lcl_obj_Bank, lcl_obj_IsDeleted, lcl_obj_EmployeeStatus, lcl_obj_IsOnRoster, lcl_obj_ShiftCode, lcl_obj_BankAccount, lcl_obj_NightBillEligible, lcl_obj_JobLocation, lcl_obj_ComUniformEligible, lcl_obj_BondValidityDate, lcl_obj_BondRefference, lcl_obj_BondIssueDate, lcl_obj_BondYear, lcl_obj_eTinEligible };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());

            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }
        public ulong update(SilkERP360.CCL.BusinessEntities.HRIS.Employee lcl_obj_Employee, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeCode = 0;
            lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_Employee.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeId = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_ID", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;
                //  lcl_obj_EmployeeId.Value = lcl_obj_Employee.EmployeeId;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeAcsCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_ACS_CODE", System.Data.OracleClient.OracleType.NVarChar, 30);
                lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeName = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_NAME", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;

                System.Data.OracleClient.OracleParameter lcl_obj_DesignationCode = new System.Data.OracleClient.OracleParameter("p_DESIGNATION_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;

                System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("p_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;

                System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("p_COMPANY_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;

                System.Data.OracleClient.OracleParameter lcl_obj_RefEmployeeCode = new System.Data.OracleClient.OracleParameter("p_REF_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_SupervisorCode = new System.Data.OracleClient.OracleParameter("p_SUPERVISOR_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;

                System.Data.OracleClient.OracleParameter lcl_obj_JoiningDate = new System.Data.OracleClient.OracleParameter("p_JOINING_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;

                System.Data.OracleClient.OracleParameter lcl_obj_ConfirmationDate = new System.Data.OracleClient.OracleParameter("p_CONFIRMATION_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;

                System.Data.OracleClient.OracleParameter lcl_obj_RetirementDate = new System.Data.OracleClient.OracleParameter("p_RETIREMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;

                System.Data.OracleClient.OracleParameter lcl_obj_SettlementDate = new System.Data.OracleClient.OracleParameter("p_SETTLEMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;

                System.Data.OracleClient.OracleParameter lcl_obj_OfficialFileNo = new System.Data.OracleClient.OracleParameter("p_OFFICIAL_FILE_NO", System.Data.OracleClient.OracleType.NVarChar, 20);
                lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;

                System.Data.OracleClient.OracleParameter lcl_obj_Tin = new System.Data.OracleClient.OracleParameter("p_TIN", System.Data.OracleClient.OracleType.NVarChar, 20);
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

                System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("p_REMARKS", System.Data.OracleClient.OracleType.NVarChar, 1024);
                lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;

                System.Data.OracleClient.OracleParameter lcl_obj_IsPfEligible = new System.Data.OracleClient.OracleParameter("p_IS_PF_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_PfCode = new System.Data.OracleClient.OracleParameter("p_PF_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;

                System.Data.OracleClient.OracleParameter lcl_obj_IsOtEligible = new System.Data.OracleClient.OracleParameter("p_IS_OT_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_SalaryPayableAtBank = new System.Data.OracleClient.OracleParameter("p_SALARY_PAYABLE_AT_BANK", System.Data.OracleClient.OracleType.Number);
                lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;

                System.Data.OracleClient.OracleParameter lcl_obj_Bank = new System.Data.OracleClient.OracleParameter("p_BANK_ACC_NO", System.Data.OracleClient.OracleType.NVarChar, 52);
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

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeStatus = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

                System.Data.OracleClient.OracleParameter lcl_obj_IsOnRoster = new System.Data.OracleClient.OracleParameter("p_IS_ON_ROSTER", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

                System.Data.OracleClient.OracleParameter lcl_obj_ShiftCode = new System.Data.OracleClient.OracleParameter("p_SHIFT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

                System.Data.OracleClient.OracleParameter lcl_obj_BankAccount = new System.Data.OracleClient.OracleParameter("p_BANK_NAME", System.Data.OracleClient.OracleType.NVarChar, 52);
                lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;

                //System.Data.OracleClient.OracleParameter lcl_obj_BankAccount = new System.Data.OracleClient.OracleParameter("p_BANK_NAME", System.Data.OracleClient.OracleType.NVarChar, 52);
                //lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                //if (lcl_obj_Employee.BankName == null)
                //{
                //    lcl_obj_BankAccount.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;
                //}

                System.Data.OracleClient.OracleParameter lcl_obj_NightBillEligible = new System.Data.OracleClient.OracleParameter("p_NIGHT_BILL_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;                

                System.Data.OracleClient.OracleParameter lcl_obj_JobLocation = new System.Data.OracleClient.OracleParameter("p_JOB_LOCATION", System.Data.OracleClient.OracleType.NVarChar, 152);
                lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

                System.Data.OracleClient.OracleParameter lcl_obj_ComUniformEligible = new System.Data.OracleClient.OracleParameter("p_IS_UNIFORM_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

                System.Data.OracleClient.OracleParameter lcl_obj_BondValidityDate = new System.Data.OracleClient.OracleParameter("p_BOND_VALIDITY_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

                System.Data.OracleClient.OracleParameter lcl_obj_BondRefference = new System.Data.OracleClient.OracleParameter("p_BOND_REFERENCE", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

                System.Data.OracleClient.OracleParameter lcl_obj_BondIssueDate = new System.Data.OracleClient.OracleParameter("p_BOND_ISSUE_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

                System.Data.OracleClient.OracleParameter lcl_obj_BondYear = new System.Data.OracleClient.OracleParameter("p_BOND_YEAR", System.Data.OracleClient.OracleType.Number);
                lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

                System.Data.OracleClient.OracleParameter lcl_obj_eTinEligible = new System.Data.OracleClient.OracleParameter("p_E_TIN_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;   

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = {lcl_obj_EmployeeCode,lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode, 
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
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;
                    // lcl_obj_EmployeeCode.Value = lcl_obj_Employee.EmployeeCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeId = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_ID", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_EmployeeId.Direction = System.Data.ParameterDirection.Output;
                    // lcl_obj_EmployeeId.Value = lcl_obj_Employee.EmployeeId;
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeAcsCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_ACS_CODE", System.Data.OracleClient.OracleType.NVarChar, 30);
                    lcl_obj_EmployeeAcsCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeAcsCode.Value = lcl_obj_Employee.EmployeeACSCode;
                    //System.Data.OracleClient.OracleParameter lcl_obj_EmployeeBmsCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_BMS_CODE", System.Data.OracleClient.OracleType.NVarChar);
                    //lcl_obj_EmployeeBmsCode.Direction = System.Data.ParameterDirection.Input;
                    //lcl_obj_EmployeeBmsCode.Value = lcl_obj_Employee.EmployeeBmsCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeName = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_NAME", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_EmployeeName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeName.Value = lcl_obj_Employee.EmployeeName;
                    System.Data.OracleClient.OracleParameter lcl_obj_DesignationCode = new System.Data.OracleClient.OracleParameter("v_DESIGNATION_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DesignationCode.Value = lcl_obj_Employee.DesignationCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DepartmentCode.Value = lcl_obj_Employee.DepartmentCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_COMPANY_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Employee.CompanyCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_RefEmployeeCode = new System.Data.OracleClient.OracleParameter("v_REF_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_RefEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RefEmployeeCode.Value = lcl_obj_Employee.RefEmployeeCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_SupervisorCode = new System.Data.OracleClient.OracleParameter("v_SUPERVISOR_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_SupervisorCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SupervisorCode.Value = lcl_obj_Employee.SupervisorCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_JoiningDate = new System.Data.OracleClient.OracleParameter("v_JOINING_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_JoiningDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_JoiningDate.Value = lcl_obj_Employee.JoiningDate;
                    System.Data.OracleClient.OracleParameter lcl_obj_ConfirmationDate = new System.Data.OracleClient.OracleParameter("v_CONFIRMATION_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_ConfirmationDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ConfirmationDate.Value = lcl_obj_Employee.ConfirmationDate;
                    System.Data.OracleClient.OracleParameter lcl_obj_RetirementDate = new System.Data.OracleClient.OracleParameter("v_RETIREMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_RetirementDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RetirementDate.Value = lcl_obj_Employee.RetirementDate;
                    System.Data.OracleClient.OracleParameter lcl_obj_SettlementDate = new System.Data.OracleClient.OracleParameter("v_SETTLEMENT_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_SettlementDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SettlementDate.Value = lcl_obj_Employee.SettlementDate;
                    System.Data.OracleClient.OracleParameter lcl_obj_OfficialFileNo = new System.Data.OracleClient.OracleParameter("v_OFFICIAL_FILE_NO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_OfficialFileNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_OfficialFileNo.Value = lcl_obj_Employee.OfficialFileNo;
                    System.Data.OracleClient.OracleParameter lcl_obj_Tin = new System.Data.OracleClient.OracleParameter("v_TIN", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Tin.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Tin.Value = lcl_obj_Employee.Tin;
                    System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("v_REMARKS", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Remarks.Value = lcl_obj_Employee.Remarks;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsPfEligible = new System.Data.OracleClient.OracleParameter("v_IS_PF_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsPfEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsPfEligible.Value = lcl_obj_Employee.IsPfEligible;
                    System.Data.OracleClient.OracleParameter lcl_obj_PfCode = new System.Data.OracleClient.OracleParameter("v_PF_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_PfCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PfCode.Value = lcl_obj_Employee.PfCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsOtEligible = new System.Data.OracleClient.OracleParameter("v_IS_OT_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsOtEligible.Value = lcl_obj_Employee.IsOtEligible;
                    System.Data.OracleClient.OracleParameter lcl_obj_SalaryPayableAtBank = new System.Data.OracleClient.OracleParameter("v_SALARY_PAYABLE_AT_BANK", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_SalaryPayableAtBank.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SalaryPayableAtBank.Value = lcl_obj_Employee.SalaryPayableAtBank;
                    System.Data.OracleClient.OracleParameter lcl_obj_Bank = new System.Data.OracleClient.OracleParameter("p_BANK_ACC_NO", System.Data.OracleClient.OracleType.NVarChar, 52);
                    lcl_obj_Bank.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Bank.Value = lcl_obj_Employee.BankAccNo;

                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = 1;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeStatus = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeStatus.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeStatus.Value = lcl_obj_Employee.EmployeeStatus;

                    System.Data.OracleClient.OracleParameter lcl_obj_IsOnRoster = new System.Data.OracleClient.OracleParameter("p_IS_ON_ROSTER", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsOnRoster.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsOnRoster.Value = lcl_obj_Employee.IsOnRoster;

                    System.Data.OracleClient.OracleParameter lcl_obj_ShiftCode = new System.Data.OracleClient.OracleParameter("p_SHIFT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShiftCode.Value = lcl_obj_Employee.ShiftCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_BankAccount = new System.Data.OracleClient.OracleParameter("p_BANK_NAME", System.Data.OracleClient.OracleType.NVarChar, 52);
                    lcl_obj_BankAccount.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BankAccount.Value = lcl_obj_Employee.BankName;

                    System.Data.OracleClient.OracleParameter lcl_obj_NightBillEligible = new System.Data.OracleClient.OracleParameter("p_NIGHT_BILL_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_NightBillEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_NightBillEligible.Value = lcl_obj_Employee.NightBillEligible;                    

                    System.Data.OracleClient.OracleParameter lcl_obj_JobLocation = new System.Data.OracleClient.OracleParameter("p_JOB_LOCATION", System.Data.OracleClient.OracleType.NVarChar, 152);
                    lcl_obj_JobLocation.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_JobLocation.Value = lcl_obj_Employee.JobLocation;

                    System.Data.OracleClient.OracleParameter lcl_obj_ComUniformEligible = new System.Data.OracleClient.OracleParameter("p_IS_UNIFORM_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ComUniformEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ComUniformEligible.Value = lcl_obj_Employee.ComUniformEligible;

                    System.Data.OracleClient.OracleParameter lcl_obj_BondValidityDate = new System.Data.OracleClient.OracleParameter("p_BOND_VALIDITY_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_BondValidityDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondValidityDate.Value = lcl_obj_Employee.BondValidityDate;

                    System.Data.OracleClient.OracleParameter lcl_obj_BondRefference = new System.Data.OracleClient.OracleParameter("p_BOND_REFERENCE", System.Data.OracleClient.OracleType.NVarChar, 128);
                    lcl_obj_BondRefference.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondRefference.Value = lcl_obj_Employee.BondRefference;

                    System.Data.OracleClient.OracleParameter lcl_obj_BondIssueDate = new System.Data.OracleClient.OracleParameter("p_BOND_ISSUE_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_BondIssueDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondIssueDate.Value = lcl_obj_Employee.BondIssueDate;

                    System.Data.OracleClient.OracleParameter lcl_obj_BondYear = new System.Data.OracleClient.OracleParameter("p_BOND_YEAR", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_BondYear.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BondYear.Value = lcl_obj_Employee.BondYear;

                    System.Data.OracleClient.OracleParameter lcl_obj_eTinEligible = new System.Data.OracleClient.OracleParameter("p_E_TIN_ELIGIBLE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_eTinEligible.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_eTinEligible.Value = lcl_obj_Employee.eTinEligible;

                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_EmployeeId, lcl_obj_EmployeeAcsCode, lcl_obj_EmployeeName, lcl_obj_DesignationCode, lcl_obj_DepartmentCode, lcl_obj_CompanyCode, lcl_obj_RefEmployeeCode, lcl_obj_SupervisorCode, lcl_obj_JoiningDate, lcl_obj_ConfirmationDate, lcl_obj_RetirementDate, lcl_obj_SettlementDate, lcl_obj_OfficialFileNo, lcl_obj_Tin, lcl_obj_Remarks, lcl_obj_IsPfEligible, lcl_obj_PfCode, lcl_obj_IsOtEligible, lcl_obj_SalaryPayableAtBank, lcl_obj_Bank, lcl_obj_IsDeleted, lcl_obj_EmployeeStatus, lcl_obj_IsOnRoster, lcl_obj_ShiftCode, lcl_obj_BankAccount, lcl_obj_NightBillEligible, lcl_obj_JobLocation, lcl_obj_ComUniformEligible, lcl_obj_BondValidityDate, lcl_obj_BondRefference, lcl_obj_BondIssueDate, lcl_obj_BondYear, lcl_obj_eTinEligible };
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
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
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
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE EMPLOYEE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
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
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
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
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
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
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
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
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
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
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeNameReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
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
                    System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeImageReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_DBQuery);
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
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeImageReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_DBQuery);
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