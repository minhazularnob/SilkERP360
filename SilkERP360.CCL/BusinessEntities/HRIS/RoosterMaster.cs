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
    public class RoosterMaster : SilkERP360.CCL.Validation.ValidationBase
    {

        #region CONSTRUCTOR

        public RoosterMaster()
        {

            this.m_obj_EmployeeRooster = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>();
           
    
        }
        #endregion

        #region VALIDATION
    [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "RosterDateFrom", Message = "Roster Date From Entry")]
    
    #endregion

        #region protected VARIABLE
        protected UInt64 m_uint64_RoosterMaseterCode;
        protected UInt64 m_uint64_ShiftCode;
        protected UInt64 m_uint64_DepartmentCode;    
        protected DateTime m_Date_RosterDateFrom;
        protected DateTime m_Date_RosterDateTo;
        protected DateTime m_Date_RosterChangeDate;
        protected Int16 m_int16_IsDeleted;
        protected Int16 m_int16_Status;

        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> m_obj_EmployeeRooster;

       

        
        #endregion

        #region PROPERTIES

        public UInt64 RoosterMaseterCode
        {
            get { return m_uint64_RoosterMaseterCode; }
            set { this.m_uint64_RoosterMaseterCode = value; }
        }
        public UInt64 ShiftCode
        {
            get { return m_uint64_ShiftCode; }
            set { this.m_uint64_ShiftCode = value; }
        }
        public UInt64 DepartmentCode
        {
            get { return m_uint64_DepartmentCode; }
            set { this.m_uint64_DepartmentCode = value; }
        }
        public DateTime RosterDateFrom
        {
            get { return m_Date_RosterDateFrom; }
            set { this.m_Date_RosterDateFrom = value; }
        }
        public DateTime RosterDateTo
        {
            get { return m_Date_RosterDateTo; }
            set { this.m_Date_RosterDateTo = value; }
        }
        public DateTime RosterChangeDate
        {
            get { return m_Date_RosterChangeDate; }
            set { this.m_Date_RosterChangeDate = value; }
        }
        public Int16 IsDeleted
        {
            get { return m_int16_IsDeleted; }
            set { this.m_int16_IsDeleted = value; }
        }
        public Int16 Status
        {
            get { return m_int16_Status; }
            set { this.m_int16_Status = value; }
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> EmployeeRooster
        {
            get { return m_obj_EmployeeRooster; }
            set { this.m_obj_EmployeeRooster = value; }
        }
       
        #endregion
    }
}
