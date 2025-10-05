using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeBankAccount : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public EmployeeBankAccount()
        {
        }
        #endregion
        #region PRIVATE VARIABLES
        protected System.UInt64 m_uint64_BankAccountCode;
        protected System.String m_str_BankAccountNumber;
        protected System.UInt64 m_uint64_BankCode;
        //private System.UInt64 m_uint64_EmployeeCode;
        protected System.Int16 m_int16_IsDeleted;
        protected System.Int16 m_int16_Status;

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
        //public System.UInt64 EmployeeCode
        //{
        //    get { return this.m_uint64_EmployeeCode; }
        //    set { this.m_uint64_EmployeeCode = value; }
        //}
        public System.Int16 IsDeleted
        {
            get { return this.m_int16_IsDeleted; }
            set { this.m_int16_IsDeleted = value; }
        }
        public System.Int16 Status
        {
            get { return this.m_int16_Status; }
            set { this.m_int16_Status = value; }
        }
        #endregion
    }
}
