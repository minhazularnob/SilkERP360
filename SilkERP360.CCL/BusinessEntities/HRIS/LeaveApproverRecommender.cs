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
    public class LeaveApproverRecommender : SilkERP360.CCL.Validation.ValidationBase
    {
        
        private System.Decimal m_dcm_LeaveRecommenderCode;
        private System.Decimal m_dcm_ApproverRecommenderCode;
        private System.Decimal m_dcm_DepartmentCode;
        private System.Decimal m_dcm_IsDeleted;
        private System.Decimal m_dcm_Status;
        private System.Decimal m_dcm_IsApprover;
        private System.Decimal m_dcm_IsRecommender;

        public System.Decimal LeaveRecommenderCode
        {
            get { return this.LeaveRecommenderCode; }
            set { this.LeaveRecommenderCode = value; }
        }
        public System.Decimal ApproverRecommenderCode
        {
            get { return this.ApproverRecommenderCode; }
            set { this.ApproverRecommenderCode = value; }
        }
        public System.Decimal DepartmentCode
        {
            get { return this.DepartmentCode; }
            set { this.DepartmentCode = value; }
        }
        public System.Decimal IsDeleted
        {
            get { return this.IsDeleted; }
            set { this.IsDeleted = value; }
        }
        public System.Decimal Status
        {
            get { return this.Status; }
            set { this.Status = value; }
        }
        public System.Decimal IsApprover
        {
            get { return this.IsApprover; }
            set { this.IsApprover = value; }
        }
        public System.Decimal IsRecommender
        {
            get { return this.IsRecommender; }
            set { this.IsRecommender = value; }
        }
    }
}