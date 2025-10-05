using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("PF_ACCOUNT_TRANSACTION", "SEQ_PF_ACCOUNT_TRAN")]
    public class PFAccountTransaction : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PF_TRANSACTION_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_PFTransectionCode;
        public System.UInt64 PFTransectionCode
        {
            get { return m_ui64_PFTransectionCode; }
            set { this.m_ui64_PFTransectionCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PF_ACCOUNT_NUMBER", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_PFAccountNumber;
        public System.UInt64 PFAccountNumber
        {
            get { return m_ui64_PFAccountNumber; }
            set { this.m_ui64_PFAccountNumber = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PF_TRANSACTION_TYPE", typeof(SilkERP360.CCL.Enums.ProvidentFundTransactionType), false, false)]
        protected SilkERP360.CCL.Enums.ProvidentFundTransactionType m_enm_PFTransactionType;
        public SilkERP360.CCL.Enums.ProvidentFundTransactionType PFTransactionType
        {
            get { return m_enm_PFTransactionType; }
            set { this.m_enm_PFTransactionType = value; }
        }



        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TRANSACTION_MONTH", typeof(SilkERP360.CCL.Enums.Month), true, false)]
        protected SilkERP360.CCL.Enums.Month m_enm_TransactionMonth;
        public SilkERP360.CCL.Enums.Month TransactionMonth
        {
            get { return m_enm_TransactionMonth; }
            set { this.m_enm_TransactionMonth = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TRANSACTION_YEAR", typeof(System.UInt16), true, false)]
        protected System.UInt16 m_ui16_TransactionYear;
        public System.UInt16 TransactionYear
        {
            get { return m_ui16_TransactionYear; }
            set { this.m_ui16_TransactionYear = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TRANSACTION_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_TransactionDate;
        public System.DateTime TransactionDate
        {
            get { return m_dt_TransactionDate; }
            set { this.m_dt_TransactionDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("AMOUNT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcl_Amount;
        public System.Decimal Amount
        {
            get { return m_dcl_Amount; }
            set { this.m_dcl_Amount = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }

        
    }
}
