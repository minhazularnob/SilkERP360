using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("PF_ACCOUNT", "SEQ_PF_ACCOUNT")]
    public class PFAccount : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PF_ACCOUNT_NUMBER", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_PFAccountNumber;
        public System.UInt64 PFAccountNumber
        {
            get { return m_ui64_PFAccountNumber; }
            set { this.m_ui64_PFAccountNumber = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ACCOUNT_STATUS", typeof(SilkERP360.CCL.Enums.ProvidentFundAccountStatus), false, false)]
        protected SilkERP360.CCL.Enums.ProvidentFundAccountStatus m_enm_AccountStatus;
        public SilkERP360.CCL.Enums.ProvidentFundAccountStatus AccountStatus
        {
            get { return m_enm_AccountStatus; }
            set { this.m_enm_AccountStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_st_Remarks;
        public System.String Remarks
        {
            get { return m_st_Remarks; }
            set { this.m_st_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction m_objLst_PFAccountTransactionList;
        public SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction PFAccountTransactionList
        {
            get { return m_objLst_PFAccountTransactionList; }
            set { m_objLst_PFAccountTransactionList = value; }
        }

    }
}
