using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class BankAccount : SilkERP360.CCL.Validation.ValidationBase
        
    {
        #region CONSTRUCTOR
        public BankAccount()
        {
        }
        #endregion

        #region VALIDATION
       [SilkERP360.CCL.Validation.Attributes.Required(FieldName="BankAccountNumber",Message="Bank Account Number Entry")]
        
        #endregion

        #region protected VARIABLES
        protected System.UInt64 m_uint64_BankAccountCode;
        protected System.String m_str_BankAccountNumber;
        protected System.UInt64 m_uint64_BankCode;
        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.UInt16 m_uint16_IsDeleted;
        protected System.UInt16 m_uint16_Status;
        #endregion

        #region PUBLIC PROPERTIES

        public System.UInt64 BankAccountCode
        {
            get { return this.m_uint64_BankAccountCode; }
            set { this.m_uint64_BankAccountCode = value; }
        }
        public System.String BankAccountNumber
        {
            get { return this.m_str_BankAccountNumber; }
            set { this.m_str_BankAccountNumber = value; }
        }
        public System.UInt64 BankCode
        {
            get { return this.m_uint64_BankCode; }
            set { this.m_uint64_BankCode = value; }
        }
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return this.m_uint16_IsDeleted; }
            set { this.m_uint16_IsDeleted = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_uint16_Status; }
            set { this.m_uint16_Status = value; }
        }
        #endregion
    }
}
