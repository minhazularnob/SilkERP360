using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("promotion_history", "SEQ_EMP_PROMOTIONHISTORY")]
    public class PromotionHistory : ValidationBase
    {
        public PromotionHistory()
        {
            IsApproved = (int)PromotionStatus.Pending;
        }

        [SilkERP360.CCL.Validation.Attributes.Required]
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PROMOTION_ID", typeof(System.UInt64), true, false)]
        protected UInt64 m_promotionID;
        public UInt64 PromotionID
        {
            get { return m_promotionID; }
            set { m_promotionID = value; }
        }

        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.String), false, false)]
        protected UInt64 m_employeeCode;
        [Required(ErrorMessage = "Employee Code is required.")]
        public UInt64 EmployeeCode
        {
            get { return m_employeeCode; }
            set { m_employeeCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PREVIOUS_DESIGNATION_CODE", typeof(System.String), false, false)]
        protected UInt64 m_previousDesignationCode;
        [Required(ErrorMessage = "Previous DesignationCode is required.")]
        public UInt64 PreviousDesignationCode
        {
            get { return m_previousDesignationCode; }
            set { m_previousDesignationCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENT_DESIGNATION_CODE", typeof(System.String), false, false)]
        protected UInt64 m_currentDesignationCode;
        [Required(ErrorMessage = "New DesignationCode is required.")]
        public UInt64 CurrentDesignationCode
        {
            get { return m_currentDesignationCode; }
            set { m_currentDesignationCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_FROM", typeof(System.String), false, false)]
        protected string m_effectiveFrom;
        [Required(ErrorMessage = "EffectiveFrom Date is required.")]
        public string EffectiveFrom
        {
            get { return m_effectiveFrom; }
            set { m_effectiveFrom = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), false, true)]
        protected string m_remarks;
        public string Remarks
        {
            get { return m_remarks; }
            set { m_remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, false)]
        protected Int64 m_companyCode;
        [Required(ErrorMessage = "Company Code is required.")]
        public Int64 CompanyCode
        {
            get { return m_companyCode; }
            set { m_companyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ISAPPROVED", typeof(System.UInt64), false, false)]
        protected Int16 m_isApproved;
        public Int16 IsApproved
        {
            get { return m_isApproved; }
            set { m_isApproved = value; }
        }

        public List<ApproverDetail> approverDetails = new List<ApproverDetail>();

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PreviousDesignationName { get; set; }
        public string CurentDesignationName { get; set; }
        public int UserSpecifcApprovalStatus { get; set; }


    }
}


