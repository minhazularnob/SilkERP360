using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("BONUS", "SEQ_BONUS")]
    public class Bonus : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BONUS_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_BonusCode;
        public System.UInt64 BonusCode
        {
            get { return m_ui64_BonusCode; }
            set { m_ui64_BonusCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BONUS_MASTER_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_BonusMasterCode;
        public System.UInt64 BonusMasterCode
        {
            get { return m_ui64_BonusMasterCode; }
            set { m_ui64_BonusMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_ID", typeof(System.String), true, false)]
        private System.String m_str_EmployeeId;
        public System.String EmployeeId
        {
            get { return m_str_EmployeeId; }
            set { m_str_EmployeeId = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_NAME", typeof(System.String), true, false)]
        private System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return m_str_EmployeeName; }
            set { m_str_EmployeeName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESIGNATION", typeof(System.String), true, false)]
        private System.String m_str_Designation;
        public System.String Designation
        {
            get { return m_str_Designation; }
            set { m_str_Designation = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BANK_ACCOUNT", typeof(System.String), true, false)]
        private System.String m_str_BankAccount;
        public System.String BankAccount
        {
            get { return m_str_BankAccount; }
            set { m_str_BankAccount = value; }
        }

        // TIN 28-Jan-2017, SSL
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TIN", typeof(System.String), true, false)]
        private System.String m_str_Tin;
        public System.String Tin
        {
            get { return m_str_Tin; }
            set { this.m_str_Tin = value; }
        }
        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("JOINING_DATE", typeof(System.DateTime), true, false)]
        private System.DateTime m_dt_JoiningDate;
        public System.DateTime JoiningDate
        {
            get { return m_dt_JoiningDate; }
            set { m_dt_JoiningDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BASIC", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_Basic;
        public System.Decimal Basic
        {
            get { return m_dcm_Basic; }
            set { m_dcm_Basic = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HOUSE_RENT", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_HouseRent;
        public System.Decimal HouseRent
        {
            get { return m_dcm_HouseRent; }
            set { m_dcm_HouseRent = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MEDICAL", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_Medical;
        public System.Decimal Medical
        {
            get { return m_dcm_Medical; }
            set { m_dcm_Medical = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONVEYENCE", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_Conveyence;
        public System.Decimal Conveyence
        {
            get { return m_dcm_Conveyence; }
            set { m_dcm_Conveyence = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("GROSS", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_Gross;
        public System.Decimal Gross
        {
            get { return m_dcm_Gross; }
            set { m_dcm_Gross = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BONUS_AMOUNT", typeof(System.Decimal), true, false)]
        private System.Decimal m_dcm_BonusAmount;
        public System.Decimal BonusAmount
        {
            get { return m_dcm_BonusAmount; }
            set { m_dcm_BonusAmount = value; }
        }
    }
}
