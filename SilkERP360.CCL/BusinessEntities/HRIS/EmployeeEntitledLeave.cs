using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class EmployeeEntitledLeave : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public EmployeeEntitledLeave()
        {
        }
        #endregion

        #region VALIDATION
    [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Balance", Message = "Balance Entry")]
    #endregion

        #region protected VARIABLES

        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.UInt64 m_uint64_LeaveCode;
        protected System.UInt16 m_uint16_Balance;
        protected System.UInt16 m_uint16_IsDeleted;
        protected System.UInt16 m_uint16_Status;

        #endregion

        #region PUBLIC PROPERTIES
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
        public System.UInt64 LeaveCode
        {
            get { return this.m_uint64_LeaveCode; }
            set { this.m_uint64_LeaveCode = value; }
        }
        public System.UInt16 Balance
        {
            get { return this.m_uint16_Balance; }
            set { this.m_uint16_Balance = value; }
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
