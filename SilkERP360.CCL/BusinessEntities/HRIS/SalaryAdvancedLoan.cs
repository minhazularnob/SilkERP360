using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class SalaryAdvancedLoan : SilkERP360.CCL.Validation.ValidationBase
    {

        private System.Decimal m_dcm_SalaryAdvancedCode;
        private System.Decimal m_dcm_EmployeeCode;
        private System.DateTime m_Dat_EffectMonth;
        private System.Decimal m_dcm_Amount;
        private System.String m_str_Remarks;
        private System.Decimal m_dcm_NoOfInstallment;
        private System.String m_str_PaidUnpaid;
        private System.Decimal m_dcm_LoanNo;
        private System.Decimal m_dcm_IsDeleted;
        private System.Decimal m_dcm_Status;

        public System.Decimal SalaryAdvancedCode
        {
            get { return this.m_dcm_SalaryAdvancedCode; }
            set { this.m_dcm_SalaryAdvancedCode = value; }
        }
        public System.Decimal EmployeeCode
        {
            get { return this.m_dcm_EmployeeCode; }
            set { this.m_dcm_EmployeeCode = value; }
        }
        public System.DateTime EffectMonth
        {
            get { return this.m_Dat_EffectMonth; }
            set { this.m_Dat_EffectMonth = value; }
        }
        public System.Decimal Amount
        {
            get { return this.m_dcm_Amount; }
            set { this.m_dcm_Amount = value; }
        }
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
        public System.Decimal NoOfInstallment
        {
            get { return this.m_dcm_NoOfInstallment; }
            set { this.m_dcm_NoOfInstallment = value; }
        }
        public System.String PaidUnpaid
        {
            get { return this.m_str_PaidUnpaid; }
            set { this.m_str_PaidUnpaid = value; }
        }
        public System.Decimal LoanNo
        {
            get { return this.m_dcm_LoanNo; }
            set { this.m_dcm_LoanNo = value; }
        }
        public System.Decimal IsDeleted
        {
            get { return this.m_dcm_IsDeleted; }
            set { this.m_dcm_IsDeleted = value; }
        }
        public System.Decimal Status
        {
            get { return this.m_dcm_Status; }
            set { this.m_dcm_Status = value; }
        }
    }
}