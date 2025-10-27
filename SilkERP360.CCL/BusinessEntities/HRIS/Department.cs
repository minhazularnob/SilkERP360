using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;
using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using System.ComponentModel.DataAnnotations;


namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("DEPARTMENT", "SEQ_DEPARTMENT")]
    public class Department: DepartmentCore
    {
        public Department()
        {
            IsDeleted = 1;
            Status = (ushort)SilkERP360.CCL.Enums.Status.Active;
            IsRosterable = 1;
            Rank = 99;
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DEPARTMENT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_DepartmentCode;
        public System.UInt64 DepartmentCode
        {
            get { return this.m_ui64_DepartmentCode; }
            set { this.m_ui64_DepartmentCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DEPT_NAME", typeof(System.String), false, false)]
        protected System.String m_str_DeptName;
        [Required(ErrorMessage = "Department Name is required.")]
        public System.String DeptName
        {
            get { return this.m_str_DeptName; }
            set { this.m_str_DeptName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SHORT_NAME", typeof(System.String), false, true)]
        protected System.String m_str_ShortName;
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        [Required(ErrorMessage = "Company Code is required.")]
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HEAD_EMPLOYEE_ID", typeof(System.String), false, true)]
        protected System.String m_str_HeadEmployeeId;
        public System.String HeadEmployeeId
        {
            get { return this.m_str_HeadEmployeeId; }
            set { this.m_str_HeadEmployeeId = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_DELETED", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_IsDeleted;
        public System.UInt16 IsDeleted
        {
            get { return this.m_ui16_IsDeleted; }
            set { this.m_ui16_IsDeleted = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_Status;
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ROSTERABLE", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_IsRosterable;
        public System.UInt16 IsRosterable
        {
            get { return this.m_ui16_IsRosterable; }
            set { this.m_ui16_IsRosterable = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RANK", typeof(System.String), false, false)]
        protected System.UInt64 m_ui_Rank;
        public System.UInt64 Rank
        {
            get { return this.m_ui_Rank; }
            set { this.m_ui_Rank = value; }
        }
        public string DeptHeadName { get; set; }

    }
}